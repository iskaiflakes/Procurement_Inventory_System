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
        private Dictionary<string, string> itemsToUpdate = new Dictionary<string, string>();
        public UpdatePurchaseRqstWindow()
        {
            InitializeComponent();

            // Attach the DataError event to the corresponding event handler.
            this.dataGridView1.DataError +=
                new DataGridViewDataErrorEventHandler(dataGridView1_DataError);

            DataTable item_rqst_tbl = new DataTable();

            item_rqst_tbl.Columns.Add("Item ID", typeof(string));
            item_rqst_tbl.Columns.Add("Name", typeof(string));
            item_rqst_tbl.Columns.Add("Quantity", typeof(string));
            item_rqst_tbl.Columns.Add("Selected", typeof(bool)); //this will show checkboxes

            //sample row
            for (int i = 1; i <= 3; i++)
            {
                DataRow row = item_rqst_tbl.NewRow();
                row["Item ID"] = "44324422";
                row["Name"] = "Kane";
                row["Quantity"] = "33";
                row["Selected"] = false; // This is getting displayed as System.Windows.Forms.CheckBox,CheckState=0

                item_rqst_tbl.Rows.Add(row);
            }

            //add rows here from the database...

            dataGridView1.DataSource = item_rqst_tbl;
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
            foreach (var item in itemsToUpdate)
            {
                string updateQuery = $"UPDATE Purchase_Request_Item SET purchase_item_status = '{item.Value}' WHERE purchase_request_item_id = '{item.Key}'";
                db.insDelUp(updateQuery);
            }
            db.CloseConnection();
            this.Close();
            UpdatePurchaseRqstPrompt form = new UpdatePurchaseRqstPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            PurchaseRequestItemIDNum.PurchaseReqItemID = val;
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
            string query = $"SELECT purchase_request_item_id AS 'Purchase Request Item ID', item_name AS 'Item Name', pri.item_quantity AS 'Quantity', ISNULL(CONVERT(varchar, iq.unit_price), 'N/A') AS 'Unit Price', pri.purchase_item_status AS 'Status' FROM Purchase_Request_Item pri JOIN Item_List il ON pri.item_id=il.item_id LEFT JOIN Item_Quotation iq ON iq.quotation_id=pri.quotation_id WHERE pri.purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}'";
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
            }
        }
    }
    public static class PurchaseRequestItemIDNum
    {
        public static string PurchaseReqItemID { get; set; }
    }
}
