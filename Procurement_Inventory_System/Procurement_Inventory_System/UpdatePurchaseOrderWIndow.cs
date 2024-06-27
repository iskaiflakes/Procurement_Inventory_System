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
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Security;

namespace Procurement_Inventory_System
{
    public partial class UpdatePurchaseOrderWindow : Form
    {
        private const int PageSize = 10; // Number of records per page
        private int currentPage = 1;
        private DataTable purchase_order_item_table;

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
        public void HideButtons()
        {
            cancelorderbtn.Visible = false;
            settodeliveredbtn.Visible = false;
            updatepostatusbtn.Visible = false;
            cancelbtn.Text = "BACK";
            CenterButton(cancelbtn);

        }
        public void ShowButtons()
        {
            cancelorderbtn.Visible = true;
            settodeliveredbtn.Visible = true;

        }

        private void CenterButton(Button button)
        {
            // Calculate the center position
            //int x = (panel1.Width - button.Width) / 2;
            //int y = (panel1.Height - button.Height) / 2; // Adjust y if you want it to be centered vertically, or set a fixed y value to keep it in place

            // Set the button's position
            //button.Location = new Point(x, y);
        }

        private async void updatepostatusbtn_Click(object sender, EventArgs e)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlTransaction transaction = null;
            List<(string Email, string FullName)> purchasingDepartmentEmployees = new List<(string Email, string FullName)>();

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
                    else if (item.Value == "CANCELLED" && oldStatus != "TO BE DELIVERED")
                    {
                        // Deduct the added quantity only if the previous status was not "PENDING"
                        string deductInventoryQuery = @"UPDATE Item_Inventory 
                                                SET available_quantity = available_quantity - (SELECT item_quantity FROM Purchase_Request_Item WHERE purchase_request_item_id = @itemId) 
                                                WHERE item_id = (SELECT item_id FROM Purchase_Request_Item WHERE purchase_request_item_id = @itemId)";
                        using (SqlCommand deductInventoryCmd = new SqlCommand(deductInventoryQuery, db.GetSqlConnection(), transaction))
                        {
                            deductInventoryCmd.Parameters.AddWithValue("@itemId", item.Key);
                            deductInventoryCmd.ExecuteNonQuery();
                        }
                    }
                }

                // Commit the transaction
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

            this.Close();
            RefreshPurchaseOrderTable();

            DatabaseClass dbEmail = new DatabaseClass();
            dbEmail.ConnectDatabase();

            string purchasingEmailQuery = @"SELECT emp_fname, emp_lname, email_address 
                                    FROM Employee 
                                    INNER JOIN Account ON Employee.emp_id = Account.emp_id
                                    WHERE Employee.role_id = '14' AND Account.account_status = 'ACTIVATED'";
            using (SqlCommand emailCmd = new SqlCommand(purchasingEmailQuery, dbEmail.GetSqlConnection()))
            {
                using (SqlDataReader reader = emailCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        purchasingDepartmentEmployees.Add((reader["email_address"].ToString(), $"{reader["emp_fname"]} {reader["emp_lname"]}"));
                    }
                }
            }

            // Send email notifications
            var emailSender = new EmailSender(
                smtpHost: "smtp.gmail.com",
                smtpPort: 587,
                smtpUsername: "procurementinventory27@gmail.com",
                smtpPassword: "nxil kusg izwe gayx",
                sslOptions: SecureSocketOptions.StartTls
            );

            string[] headers = { "Purchase Order Item ID", "Item Name", "Quantity", "Unit Price", "Status" };
            string htmlHeader = EmailBuilder.TableHeaders(headers.ToList());
            List<string> htmlTableRows = new List<string>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    List<string> rowData = new List<string>
            {
                row.Cells["Purchase Order Item ID"].Value.ToString(),
                row.Cells["Item Name"].Value.ToString(),
                row.Cells["Quantity"].Value.ToString(),
                row.Cells["Unit Price"].Value.ToString(),
                row.Cells["Status"].Value.ToString()
            };
                    htmlTableRows.Add(EmailBuilder.TableRow(rowData));
                }
            }

            foreach (var employee in purchasingDepartmentEmployees)
            {
                string emailStatus = await emailSender.SendEmail(
                    fromName: "Purchase Order Update [NOREPLY]",
                    fromAddress: "procurementinventory27@gmail.com",
                    toName: employee.FullName,
                    toAddress: employee.Email,
                    subject: $"Purchase Order {PurchaseOrderIDNum.PurchaseOrderID} Update",
                    htmlTable: EmailBuilder.ContentBuilder(
                        requestID: PurchaseOrderIDNum.PurchaseOrderID,
                        Receiver: employee.FullName,
                        Sender: $"{CurrentUserDetails.FName} {CurrentUserDetails.LName}",
                        UserAction: "UPDATED",
                        TypeOfRequest: "PURCHASE ORDER",
                        TableTitle: "Updated Purchase Order Items",
                        Header: htmlHeader,
                        Body: htmlTableRows.ToArray()
                    )
                );
            }
            dbEmail.CloseConnection();
            itemsToUpdate.Clear();
        }



        private void UpdatePurchaseOrderWindow_Load(object sender, EventArgs e)
        {
            PopulatePurchaseOrderItem();
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public void PopulatePurchaseOrderItem()
        {
            purchase_order_item_table = new DataTable();
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
            DisplayCurrentPage();
            dataGridView1.AllowUserToAddRows = false;
        }
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, purchase_order_item_table.Rows.Count - 1);

            DataTable pageTable = purchase_order_item_table.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(purchase_order_item_table.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage < (purchase_order_item_table.Rows.Count + PageSize - 1) / PageSize)
            {
                currentPage++;
                DisplayCurrentPage();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }

        }
        private void RefreshPurchaseOrderTable()
        {
            purchaseOrderPage.PopulatePurchaseOrder();
        }

        private void cancelorderbtn_Click(object sender, EventArgs e)
        {
            if (IsAnyItemSelected())
            {
                UpdateSelectedItemsStatus("CANCELLED");
            }
            else
            {
                MessageBox.Show("Select item first.");
            }
        }

        private void settodeliveredbtn_Click(object sender, EventArgs e)
        {
            if (IsAnyItemSelected())
            {
                UpdateSelectedItemsStatus("DELIVERED");
            }
            else
            {
                MessageBox.Show("Select item first.");
            }
        }

        private bool IsAnyItemSelected()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    return true;
                }
            }
            return false;
        }

        private void UpdateSelectedItemsStatus(string newStatus)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    if (row.Cells["Status"].Value.ToString() != newStatus)
                    {
                        string purchaseOrderItemId = row.Cells["Purchase Order Item ID"].Value.ToString();
                        row.Cells["Status"].Value = newStatus;
                        itemsToUpdate[purchaseOrderItemId] = newStatus;
                        row.Cells["Select"].Value = false;
                    }
                    else
                    {
                        MessageBox.Show($"Order is already {newStatus}");
                    }
                }
            }
        }
        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = selectRadBtn.Checked;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells["Select"];
                checkBoxCell.Value = isChecked;
            }
        }
        private void checkBoxDeselectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = deselectRadBtn.Checked;
            if (isChecked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells["Select"];
                    checkBoxCell.Value = false;
                }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
            }
            catch
            {

            }
        }
    }
}
