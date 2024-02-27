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
    public partial class UpdatePurchaseRqstWindow : Form
    {
        private PurchaseRequestPage purchaseRequestPage;
        private Dictionary<string, string> itemsToUpdate = new Dictionary<string, string>();
        public UpdatePurchaseRqstWindow(PurchaseRequestPage purchaseRequestPage)
        {
            InitializeComponent();
            this.purchaseRequestPage = purchaseRequestPage;
            // Attach the DataError event to the corresponding event handler.
            this.dataGridView1.DataError +=
                new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
        }
        private void dataGridView1_DataError(object sender,
        DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is
            // commited, display an error message.
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("CustomerID value must be unique.");
            }
        }

        private void addsupplyqtnbtn_Click(object sender, EventArgs e)
        {
            if(PurchaseRequestIDNum.PurchaseReqID == null)
            {
                MessageBox.Show("Click purchase request id first.");
            }
            else
            {
                SupplierQuotationWindow form = new SupplierQuotationWindow(this);
                form.ShowDialog();
            }
        }

        private void updaterqstbtn_Click(object sender, EventArgs e)
        {
                DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            SqlTransaction transaction = db.GetSqlConnection().BeginTransaction();
            try
            {
                foreach (var item in itemsToUpdate)
                {
                    string updateQuery = $"UPDATE Purchase_Request_Item SET purchase_item_status = @Status WHERE purchase_request_item_id = @ItemID";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, db.GetSqlConnection(), transaction))
                    {
                        cmd.Parameters.AddWithValue("@Status", item.Value);
                        cmd.Parameters.AddWithValue("@ItemID", item.Key);
                        cmd.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("The transaction was cancelled. An error occurred: " + ex.Message);
            }
            finally
            {
                itemsToUpdate.Clear();
                db.CloseConnection();
                this.Close();
                // Update the UI to reflect the changes
                UpdatePurchaseRqstPrompt form = new UpdatePurchaseRqstPrompt();
                form.ShowDialog();
                RefreshPurchaseRequestTable();
            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdatePurchaseRqstWindow_Load(object sender, EventArgs e)
        {
            PopulatePurchaseRequestItem();
        }
        public void PopulatePurchaseRequestItem()
        {

            DataTable purchase_request_item_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT purchase_request_item_id AS 'Purchase Request Item ID', item_name AS 'Item Name', pri.item_quantity AS 'Quantity', ISNULL(CONVERT(varchar, iq.unit_price), 'N/A') AS 'Unit Price', pri.purchase_item_status AS 'Status' FROM Purchase_Request_Item pri JOIN Item_List il ON pri.item_id = il.item_id LEFT JOIN Item_Quotation iq ON pri.quotation_id = iq.quotation_id AND pri.item_id = iq.item_id WHERE pri.purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}'";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(purchase_request_item_table);
            dataGridView1.DataSource = purchase_request_item_table;
            db.CloseConnection();
        }

        private void rejectrqstbtn_Click(object sender, EventArgs e)
        {
            if (PurchaseRequestItemIDNum.PurchaseReqItemID == null)
            {
                MessageBox.Show("Click purchase request item id first.");
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Purchase Request Item ID"].Value.ToString() == PurchaseRequestItemIDNum.PurchaseReqItemID)
                    {
                        row.Cells["Status"].Value = "REJECTED";
                        itemsToUpdate[PurchaseRequestItemIDNum.PurchaseReqItemID] = "REJECTED"; 
                        break;
                    }
                }
                RefreshPurchaseRequestTable();
            }
        }

        private void approverqstbtn_Click(object sender, EventArgs e)
        {
            if (PurchaseRequestItemIDNum.PurchaseReqItemID == null)
            {
                MessageBox.Show("Click purchase request item id first.");
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Purchase Request Item ID"].Value.ToString() == PurchaseRequestItemIDNum.PurchaseReqItemID)
                    {
                        row.Cells["Status"].Value = "APPROVED";
                        itemsToUpdate[PurchaseRequestItemIDNum.PurchaseReqItemID] = "APPROVED"; // or "REJECTED"
                        break;
                    }
                }
                RefreshPurchaseRequestTable();
            }
        }
        public void RefreshPurchaseRequestTable()
        {
            if (purchaseRequestPage != null)
            {
                purchaseRequestPage.PopulateRequestTable();
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            string val = dataGridView1.Rows[e.RowIndex].Cells["Purchase Request Item ID"].Value.ToString();
            PurchaseRequestItemIDNum.PurchaseReqItemID = val;
        }
    }
    public static class PurchaseRequestItemIDNum
    {
        public static string PurchaseReqItemID { get; set; }
    }
}
