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

namespace Procurement_Inventory_System
{
    public partial class UpdatePurchaseRqstWindow : Form
    {
        private PurchaseRequestPage purchaseRequestPage;
        private Dictionary<string, string> itemsToUpdate = new Dictionary<string, string>();
        private Dictionary<string, string> originalStatuses = new Dictionary<string, string>(); // for audit logs
        bool approvalFlag;
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
                // assuming you have a reference to your DataGridView named dataGridView1
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
                    {
                        DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];

                        // assuming your cells are not null and contain string values
                        if (selectedRow.Cells.Count >= 6)
                        {
                            string sixthCellValue = selectedRow.Cells[5].Value.ToString();

                            PurchaseRequestItemIDNum.Supplier = sixthCellValue;
                        }
                        else
                        {
                            MessageBox.Show("Selected row does not contain a 6th cell.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No row is selected.");
                    }
                }
                else
                {
                    MessageBox.Show("No cell is selected.");
                }
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
                approvalFlag = false;
                foreach (var item in itemsToUpdate)
                {
                    string updateQuery;
                    if (item.Value == "APPROVED")
                    {
                        approvalFlag = true;
                        updateQuery = $"UPDATE Purchase_Request_Item SET purchase_item_status = @Status, date_updated = @DateUpdated, approved_date = @ApprovedDate, approver_user_id = @ApproverUserID WHERE purchase_request_item_id = @ItemID";
                    }
                    else
                    {
                        updateQuery = $"UPDATE Purchase_Request_Item SET purchase_item_status = @Status, date_updated = @DateUpdated, approver_user_id = @ApproverUserID WHERE purchase_request_item_id = @ItemID";
                    }
                    using (SqlCommand cmd = new SqlCommand(updateQuery, db.GetSqlConnection(), transaction))
                    {
                        cmd.Parameters.AddWithValue("@Status", item.Value);
                        cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Now);
                        if (item.Value == "APPROVED")
                        {
                            cmd.Parameters.AddWithValue("@ApprovedDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@ApproverUserID", CurrentUserDetails.UserID);
                        }
                        else if (item.Value == "REJECTED")
                        {
                            cmd.Parameters.AddWithValue("@ApproverUserID", CurrentUserDetails.UserID);
                        }
                        cmd.Parameters.AddWithValue("@ItemID", item.Key);
                        cmd.ExecuteNonQuery();
                        AuditLog auditLog = new AuditLog();
                        string oldValue = originalStatuses[item.Key];
                        string newValue = item.Value;
                        auditLog.LogEvent(CurrentUserDetails.UserID, "Purchase Request", "Update", PurchaseRequestIDNum.PurchaseReqID, $"Status of {item.Key} changed from {oldValue} to {newValue}");
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
                if (approvalFlag)
                {
                    string purchasingDetailsQuery = @"SELECT TOP 1 emp_fname, emp_lname, email_address 
                                    FROM Employee 
                                    WHERE role_id=13 AND 
                                    branch_id=@BranchId AND 
                                    department_id=@DepartmentId AND 
                                    section_id=@Section";

                    SqlCommand cmd = new SqlCommand(purchasingDetailsQuery, db.GetSqlConnection());
                    cmd.Parameters.AddWithValue("@BranchId", CurrentUserDetails.BranchId);
                    cmd.Parameters.AddWithValue("@DepartmentId", CurrentUserDetails.DepartmentId);
                    cmd.Parameters.AddWithValue("@Section", CurrentUserDetails.DepartmentSection);

                    db.GetSqlConnection().Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    string purchasingEmail = "";
                    string purchasingFullName = "";

                    if (reader.Read())
                    {
                        purchasingFullName = $"{reader["emp_fname"].ToString()} {reader["emp_lname"].ToString()}";
                        purchasingEmail = reader["email_address"].ToString();
                    }

                    db.GetSqlConnection().Close();

                    if (!string.IsNullOrEmpty(purchasingEmail))
                    {
                        SendEmailToPurchasingDepartment(purchasingEmail, purchasingFullName);
                    }
                } 
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
            string query = $"SELECT purchase_request_item_id AS 'Purchase Request Item ID', item_name AS 'Item Name', pri.item_quantity AS 'Quantity', \r\nISNULL(CONVERT(varchar, iq.unit_price), 'N/A') AS 'Unit Price', pri.purchase_item_status AS 'Status', Supplier.supplier_id AS 'Supplier' \r\nFROM Purchase_Request_Item pri JOIN Item_List il ON pri.item_id = il.item_id LEFT JOIN Item_Quotation iq \r\nON pri.quotation_id = iq.quotation_id AND pri.item_id = iq.item_id \r\nJOIN Supplier ON il.supplier_id=Supplier.supplier_id\r\nWHERE pri.purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}'";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(purchase_request_item_table);
            dataGridView1.DataSource = purchase_request_item_table;
            foreach (DataRow row in purchase_request_item_table.Rows)
            {
                originalStatuses[row["Purchase Request Item ID"].ToString()] = row["Status"].ToString();
            }

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
                        itemsToUpdate[PurchaseRequestItemIDNum.PurchaseReqItemID] = "APPROVED";
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
        private void SendEmailToPurchasingDepartment(string purchasingEmail, string purchasingName)
        {
            string body = $"Hello {purchasingName}! \n\nItem/s were approved in {PurchaseRequestIDNum.PurchaseReqID} and requires your procurement. Please review the purchase request at your earliest convenience.\n\nPurchase Request ID: {PurchaseRequestIDNum.PurchaseReqID}";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Approval Notification [NOREPLY]", "procurementinventory27@gmail.com"));
            message.To.Add(new MailboxAddress("Purchasing Department", purchasingEmail));
            message.Subject = "New Item/s Approved";
            message.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                client.Authenticate("procurementinventory27@gmail.com", "urdm dgrf imzq gpam");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
    public static class PurchaseRequestItemIDNum
    {
        public static string PurchaseReqItemID { get; set; }
        public static string Supplier { get; set; }
    }
}
