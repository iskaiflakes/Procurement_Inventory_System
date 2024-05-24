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
    public partial class UpdatePurchaseOrderWindow : Form
    {
        private Dictionary<string, string> itemsToUpdate = new Dictionary<string, string>();
        private Dictionary<string, string> originalStatuses = new Dictionary<string, string>(); // for audit logs
        private PurchaseOrderPage purchaseOrderPage;
        public UpdatePurchaseOrderWindow(PurchaseOrderPage purchaseOrderPage)
        {
            InitializeComponent();
            this.purchaseOrderPage = purchaseOrderPage;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updatepostatusbtn_Click(object sender, EventArgs e)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlTransaction transaction = null;
            try
            {
                // Start a new transaction
                transaction = db.GetSqlConnection().BeginTransaction();

                foreach (var item in itemsToUpdate)
                {
                    string itemId = item.Key;
                    string newStatus = item.Value;
                    string oldStatus = originalStatuses[itemId];
                    string updateQuery = @"UPDATE Purchase_Order_Item 
                                   SET order_item_status = @newStatus 
                                   WHERE purchase_request_item_id = @itemId";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, db.GetSqlConnection(), transaction))
                    {
                        cmd.Parameters.AddWithValue("@newStatus", item.Value);
                        cmd.Parameters.AddWithValue("@itemId", item.Key);
                        cmd.ExecuteNonQuery();
                        AuditLog auditLog = new AuditLog();
                        auditLog.LogEvent(CurrentUserDetails.UserID, "Purchase Order", "Update", PurchaseOrderIDNum.PurchaseOrderID, $"Status of {itemId} changed from {oldStatus} to {newStatus}");
                    }
                    if (item.Value == "DELIVERED")
                    {
                        string updateInventoryQuery = @"UPDATE Item_Inventory 
                                                SET available_quantity = available_quantity + (SELECT item_quantity FROM Purchase_Request_Item WHERE purchase_request_item_id = @itemId) 
                                                WHERE item_id = (SELECT item_id FROM Purchase_Request_Item WHERE purchase_request_item_id = @itemId)";
                        using (SqlCommand updateInventoryCmd = new SqlCommand(updateInventoryQuery, db.GetSqlConnection(), transaction))
                        {
                            updateInventoryCmd.Parameters.AddWithValue("@itemId", item.Key);
                            updateInventoryCmd.ExecuteNonQuery();
                        }
                    }
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // If an error occurs, roll back the transaction
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show("The transaction was cancelled. An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                db.CloseConnection();

                if (transaction != null)
                {
                    transaction.Dispose();
                }
            }
            // Clear the updates dictionary and refresh the UI
            itemsToUpdate.Clear();
            RefreshPurchaseOrderTable();
            this.Close();
            UpdatePurchaseOrderPrompt form = new UpdatePurchaseOrderPrompt();
            form.ShowDialog();
        }

        private void UpdatePurchaseOrderWindow_Load(object sender, EventArgs e)
        {
            PopulatePurchaseOrderItem();
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public void PopulatePurchaseOrderItem()
        {
            DataTable purchase_order_item_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT poi.purchase_order_id AS 'Purchase Order ID', poi.purchase_request_item_id AS 'Purchase Order Item ID', il.item_name AS 'Item Name', pri.item_quantity AS 'Quantity', ISNULL(CONVERT(varchar, iq.unit_price), 'N/A') AS 'Unit Price', poi.order_item_status AS 'Status' FROM Purchase_Order_Item poi JOIN Purchase_Request_Item pri ON poi.purchase_request_item_id=pri.purchase_request_item_id JOIN Item_List il ON pri.item_id=il.item_id LEFT JOIN Item_Quotation iq ON pri.quotation_id = iq.quotation_id AND pri.item_id = iq.item_id WHERE poi.purchase_order_id = '{PurchaseOrderIDNum.PurchaseOrderID}'";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(purchase_order_item_table);
            dataGridView1.DataSource = purchase_order_item_table;
            db.CloseConnection();
            purchase_order_item_table.Columns.Add("Select", typeof(bool));
            foreach (DataRow row in purchase_order_item_table.Rows)
            {
                row["Select"] = false; // This will be the checkbox state
                originalStatuses[row["Purchase Order Item ID"].ToString()] = row["Status"].ToString();
            }
            dataGridView1.DataSource = purchase_order_item_table;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void RefreshPurchaseOrderTable()
        {
            purchaseOrderPage.PopulatePurchaseOrder();
        }

        private void cancelorderbtn_Click(object sender, EventArgs e)
        {
            UpdateSelectedItemsStatus("CANCELLED");
        }

        private void settodeliveredbtn_Click(object sender, EventArgs e)
        {
            UpdateSelectedItemsStatus("DELIVERED");
        }
        private void UpdateSelectedItemsStatus(string newStatus)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    string purchaseOrderItemId = row.Cells["Purchase Order Item ID"].Value.ToString();
                    row.Cells["Status"].Value = newStatus;
                    itemsToUpdate[purchaseOrderItemId] = newStatus;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
