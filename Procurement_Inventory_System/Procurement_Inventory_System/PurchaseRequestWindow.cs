using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Procurement_Inventory_System
{
    public partial class PurchaseRequestWindow : Form
    {
        private PurchaseRequestPage purchaseRequestPage;
        public PurchaseRequestWindow(PurchaseRequestPage purchaseRequestPage)
        {
            InitializeComponent();
            this.purchaseRequestPage = purchaseRequestPage;
        }

        private void additemrqstbtn_Click(object sender, EventArgs e)
        {
            using (AddRequestItemWindow addItemForm = new AddRequestItemWindow())
            {
                if (addItemForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the new item data
                    ItemData newItem = addItemForm.NewItem;
                    if (newItem != null)
                    {
                        DataTable dt = (DataTable)dataGridView1.DataSource ?? new DataTable(); // if there is no table, a new one is created

                        if (dt.Columns.Count == 0)
                        {
                            // Assuming the DataTable doesn't have columns defined
                            dt.Columns.Add("Item ID", typeof(string));
                            dt.Columns.Add("Item Name", typeof(string));
                            dt.Columns.Add("Quantity", typeof(int));
                            dt.Columns.Add("Remarks", typeof(string));
                        }

                        dt.Rows.Add(newItem.ItemId, newItem.ItemName, newItem.Quantity, newItem.Remarks);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void createnewrqstbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string datePrefix = DateTime.Now.ToString("yyyyMMdd");
            string lastIdQuery = @"SELECT TOP 1 purchase_request_id FROM Purchase_Request 
                     WHERE purchase_request_id LIKE 'PR-" + datePrefix + "-%' ORDER BY purchase_request_id DESC";
            string nextPrId = $"PR-{datePrefix}-001"; // Default if no items found for today
            SqlDataReader dr = db.GetRecord(lastIdQuery);
            if (dr.Read())
            {
                string lastId = dr["purchase_request_id"].ToString();
                int lastNumber = int.Parse(lastId.Split('-')[2]);
                nextPrId = $"PR-{datePrefix}-{(lastNumber + 1):D3}";
            }
            dr.Close();
            string prQuery = @"INSERT INTO Purchase_Request VALUES (@nextPrId,@userId,'PENDING',GETDATE())";
            using (SqlCommand cmd = new SqlCommand(prQuery, db.GetSqlConnection()))
            {
                cmd.Parameters.AddWithValue("@nextPrId", nextPrId);
                cmd.Parameters.AddWithValue("@userId", CurrentUserDetails.UserID);
                cmd.ExecuteNonQuery();
            }
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string itemId = row.Cells[0].Value.ToString();
                    int itemQty = Convert.ToInt32(row.Cells[2].Value);
                    string remarks = row.Cells[3].Value.ToString();

                    string nextItemId = GetNextItemId(datePrefix, db); // Assume GetNextItemId is a method that generates the next item ID

                    string priQuery = @"INSERT INTO Purchase_Request_Item (purchase_request_item_id, purchase_request_id, item_id, item_quantity, remarks) VALUES (@nextItemId, @prId, @itemId, @itemQty, @remarks)";
                    using (SqlCommand itemCmd = new SqlCommand(priQuery, db.GetSqlConnection()))
                    {
                        itemCmd.Parameters.AddWithValue("@nextItemId", nextItemId);
                        itemCmd.Parameters.AddWithValue("@prId", nextPrId);
                        itemCmd.Parameters.AddWithValue("@itemId", itemId);
                        itemCmd.Parameters.AddWithValue("@itemQty", itemQty);
                        itemCmd.Parameters.AddWithValue("@remarks", remarks);
                        itemCmd.ExecuteNonQuery();
                    }
                }
            }
            RefreshRequestListTable();
            RequestPrompt form = new RequestPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PurchaseRequestWindow_Load(object sender, EventArgs e)
        {

        }
        private void PopulateItemRequests()
        {

        }
        private string GetNextItemId(string datePrefix, DatabaseClass db)
        {
            string lastItemIdQuery = @"SELECT TOP 1 purchase_request_item_id FROM Purchase_Request_Item 
                     WHERE purchase_request_item_id LIKE 'PRI-" + datePrefix + "-%' ORDER BY purchase_request_item_id DESC";
            string nextItemId = $"PRI-{datePrefix}-001"; // Default if no items found for today
            SqlDataReader dr = db.GetRecord(lastItemIdQuery);
            if (dr.Read())
            {
                string lastId = dr["purchase_request_item_id"].ToString();
                int lastNumber = int.Parse(lastId.Split('-')[2]);
                nextItemId = $"PRI-{datePrefix}-{(lastNumber + 1):D3}";
            }
            dr.Close();
            return nextItemId;
        }
        public void RefreshRequestListTable()
        {
            if (purchaseRequestPage != null)
            {
                purchaseRequestPage.PopulateRequestTable();
            }
        }
    }
}
