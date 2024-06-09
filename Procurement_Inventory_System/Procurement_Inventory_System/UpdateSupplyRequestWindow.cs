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
    public partial class UpdateSupplyRequestWindow : Form
    {
        private const int PageSize = 15; // Number of records per page
        private int currentPage = 1;
        private DataTable supply_request_item_table;

        private SupplyRequestPage supplyRequestPage;
        private Dictionary<string, string> itemsToUpdate = new Dictionary<string, string>();
        private Dictionary<string, string> originalStatuses = new Dictionary<string, string>(); // for audit logs

        bool approvalFlag;
        double pendingPercentage;
        public UpdateSupplyRequestWindow(SupplyRequestPage supplyRequestPage)
        {
            InitializeComponent();
            this.supplyRequestPage = supplyRequestPage;
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            // Handle dashboard click event here
        }

        private void UpdateSupplyRequestWindow_Load(object sender, EventArgs e)
        {
            PopulateSupplyRequestItem();
        }
        public void HideButtons()
        {
            approverqstbtn.Visible = false;
            rejectrqstbtn.Visible = false;
            releaseitemsbtn.Visible = true;
        }
        public void HideRelease()
        {
            approverqstbtn.Visible = true;
            rejectrqstbtn.Visible = true;
            releaseitemsbtn.Visible = false;
        }
        public void ShowButtons()
        {
            approverqstbtn.Visible = true;
            rejectrqstbtn.Visible = true;
            releaseitemsbtn.Visible = true;
        }
        public void ViewDetails()
        {
            approverqstbtn.Visible = false;
            rejectrqstbtn.Visible = false;
            releaseitemsbtn.Visible = false;
        }
        private string[] GetHeaders()
        {
            string[] headers = new string[dataGridView1.Columns.Count];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                headers[i] = dataGridView1.Columns[i].HeaderText;
            }
            return headers;
        }

        public void PopulateSupplyRequestItem()
        {
            supply_request_item_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT requested_item_id AS 'Requested Item ID', il.item_id AS 'Item ID', item_name AS 'Item Name', sri.request_quantity AS 'Quantity', " +
                           $"remarks AS 'Remarks', supply_item_status AS 'Status' " +
                           $"FROM Supply_Request_Item sri JOIN Item_List il ON sri.item_id = il.item_id " +
                           $"WHERE supply_request_id = '{SupplyRequest_ID.SR_ID}'";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(supply_request_item_table);
            DisplayCurrentPage();

            foreach (DataRow row in supply_request_item_table.Rows)
            {
                originalStatuses[row["Requested Item ID"].ToString()] = row["Status"].ToString();
            }

            db.CloseConnection();
        }

        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, supply_request_item_table.Rows.Count - 1);

            DataTable pageTable = supply_request_item_table.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(supply_request_item_table.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage < (supply_request_item_table.Rows.Count + PageSize - 1) / PageSize)
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
        private void approverqstbtn_Click(object sender, EventArgs e)
        {
            if (SupplyRequestItemIDNum.RequestedItemID == null)
            {
                MessageBox.Show("Click supply request item id first.");
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cellValue = row.Cells["Requested Item ID"].Value;

                        // Check if cellValue is not null before calling ToString()
                        if (cellValue != null && cellValue.ToString() == SupplyRequestItemIDNum.RequestedItemID)
                        {
                            DialogResult result = MessageBox.Show("Are you sure you want to proceed?", "Warning",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                row.Cells["Status"].Value = "APPROVED";
                                itemsToUpdate[SupplyRequestItemIDNum.RequestedItemID] = "APPROVED";
                                break;
                            }
                            else if (result == DialogResult.No)
                            {
                                break;
                            }
                        }
                    }
                        
                }
                
                RefreshSupplyRequestTable();
                
            }
        }

        private void rejectrqstbtn_Click(object sender, EventArgs e)
        {
            if (SupplyRequestItemIDNum.RequestedItemID == null)
            {
                MessageBox.Show("Click supply request item id first.");
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Requested Item ID"].Value.ToString() == SupplyRequestItemIDNum.RequestedItemID)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to proceed?", "Warning",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            row.Cells["Status"].Value = "REJECTED";
                            itemsToUpdate[SupplyRequestItemIDNum.RequestedItemID] = "REJECTED";
                            break;
                        }else if(result == DialogResult.No)
                        {
                            break;
                        }
                    }
                }
               
                RefreshSupplyRequestTable();
            }
        }
        private double CalculateApprovedPercentage()
        {
            int approvedCount = 0;
            int validRowCount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Skip new rows that are not committed
                if (row.IsNewRow) continue;

                // Skip rows with null or empty status
                var cellValue = row.Cells["Status"].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString())) continue;

                validRowCount++; // Increment valid row count

                // Check for "Approved" status
                if (cellValue.ToString().Equals("PENDING", StringComparison.OrdinalIgnoreCase))
                {
                    approvedCount++;
                }
            }

            if (validRowCount == 0)
            {
                return 0; // Avoid division by zero
            }

            return (double)approvedCount / validRowCount * 100;
        }


        private void updaterqstbtn_Click(object sender, EventArgs e)
        {

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            SqlTransaction transaction = db.GetSqlConnection().BeginTransaction();
            try
            {
                approvalFlag = false;
                pendingPercentage = CalculateApprovedPercentage();

                foreach (var item in itemsToUpdate)
                {
                    if (item.Value == "APPROVED")
                    {
                        approvalFlag = true;
                    }
                    string updateQuery = $"UPDATE Supply_Request_Item SET supply_item_status = @Status WHERE requested_item_id = @ItemID";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, db.GetSqlConnection(), transaction))
                    {
                        cmd.Parameters.AddWithValue("@Status", item.Value);
                        cmd.Parameters.AddWithValue("@ItemID", item.Key);
                        cmd.ExecuteNonQuery();
                        AuditLog auditLog = new AuditLog();
                        string oldValue = originalStatuses[item.Key];
                        string newValue = item.Value;
                        auditLog.LogEvent(CurrentUserDetails.UserID, "Supply Request", "Update", SupplyRequest_ID.SR_ID, $"Status of {item.Key} changed from {oldValue} to {newValue}");
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
                RefreshSupplyRequestTable();
                if (approvalFlag)
                {
                    string purchasingDetailsQuery = @"SELECT TOP 1 emp_fname, emp_lname, email_address 
                                    FROM Employee 
                                    WHERE role_id=11 AND 
                                    branch_id=@BranchId AND 
                                    department_id=@DepartmentId AND 
                                    section_id=@Section";
                    // change to role of custodian, temporarily placed admin role in the role id
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
                    if (pendingPercentage==0.00)
                    {
                        if (!string.IsNullOrEmpty(purchasingEmail))
                        {
                            string[] headers = GetHeaders();
                            string htmlHeader = EmailBuilder.TableHeaders(headers.ToList());
                            string[] htmlTable = new string[dataGridView1.Rows.Count];
                            int count = 0;
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    string[] rows = new string[headers.Length];
                                    for (int i = 0; i < rows.Length; i++)
                                    {
                                        rows[i] = row.Cells[i].Value.ToString();
                                    }
                                    htmlTable[count] = EmailBuilder.TableRow(rows.ToList());
                                    count++;
                                }
                            }


                            // EMAIL PART
                            var emailSender = new EmailSender(
                            smtpHost: "smtp.gmail.com",
                            smtpPort: 587,
                            smtpUsername: "procurementinventory27@gmail.com",
                            smtpPassword: "urdm dgrf imzq gpam",
                            sslOptions: SecureSocketOptions.StartTls
                            );

                            string EmailStatus = emailSender.SendEmail(
                                fromName: "APPROVAL NOTIFICATION [NOREPLY]",
                                fromAddress: "procurementinventory27@gmail.com",
                                toName: purchasingFullName,
                                toAddress: purchasingEmail,
                                subject: $"ITEM APPROVED! Supply Request {SupplyRequest_ID.SR_ID}",
                                htmlTable: EmailBuilder.ContentBuilder(
                                    requestID: SupplyRequest_ID.SR_ID,
                                    Receiver: purchasingFullName,
                                    Sender: "Approver",
                                    UserAction: "APPROVED",
                                    TypeOfRequest: "Supply Request Item",
                                    TableTitle: "Requested Item",
                                    Header: htmlHeader,
                                    Body: htmlTable
                                    )
                                );
                            MessageBox.Show(EmailStatus);
                        }
                    }
                    
                }
            }
        }

        public void RefreshSupplyRequestTable()
        {
            supplyRequestPage.DisplaySupplierReqTable();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["Requested Item ID"].Value.ToString();
                SupplyRequestItemIDNum.RequestedItemID = val;
            }
        }

        private void SendEmailToPurchasingDepartment(string purchasingEmail, string purchasingName)
        {
            string body = $"Hello {purchasingName}! \n\nItem/s were approved in {SupplyRequest_ID.SR_ID} and requires your release. Please review the supply request at your earliest convenience.\n\nSupply Request ID: {SupplyRequest_ID.SR_ID}";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Approval Notification [NOREPLY]", "procurementinventory27@gmail.com"));
            message.To.Add(new MailboxAddress("Purchasing Department", "yelliarchives@gmail.com"));
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void releaseitemsbtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to release the items?", "Confirm Release", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                SqlTransaction transaction = db.GetSqlConnection().BeginTransaction();
                try
                {
                    bool sufficientInventory = true;
                    string checkInventoryQuery = @"SELECT available_quantity 
                                           FROM Item_Inventory 
                                           WHERE item_id = @itemId";

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string itemId = row.Cells["Item ID"].Value.ToString(); 
                            string itemName = row.Cells["Item Name"].Value.ToString(); 
                            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                            using (SqlCommand checkInventoryCmd = new SqlCommand(checkInventoryQuery, db.GetSqlConnection(), transaction))
                            {
                                checkInventoryCmd.Parameters.AddWithValue("@itemId", itemId);
                                int availableQuantity = (int)checkInventoryCmd.ExecuteScalar();

                                if (availableQuantity < quantity)
                                {
                                    sufficientInventory = false;
                                    MessageBox.Show($"Not enough inventory for item {itemName}. Available quantity: {availableQuantity}, required quantity: {quantity}");
                                    break;
                                }
                            }
                        }
                    }

                    if (sufficientInventory)
                    {
                        bool Approved = false;
                        string updateQuery = "UPDATE Supply_Request SET supply_request_status = 'RELEASE' WHERE supply_request_id = @RequestID";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, db.GetSqlConnection(), transaction))
                        {
                            cmd.Parameters.AddWithValue("@RequestID", SupplyRequest_ID.SR_ID);
                            cmd.ExecuteNonQuery();
                        }

                        string deductInventoryQuery = @"UPDATE Item_Inventory 
                                                SET available_quantity = available_quantity - @quantity 
                                                WHERE item_id = @itemId";

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                if (row.Cells["Status"].Value.ToString() == "APPROVED")
                                {
                                    string itemId = row.Cells["Item ID"].Value.ToString();
                                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                                    MessageBox.Show($"{itemId}|| {quantity}");

                                    using (SqlCommand updateInventoryCmd = new SqlCommand(deductInventoryQuery, db.GetSqlConnection(), transaction))
                                    {
                                        updateInventoryCmd.Parameters.AddWithValue("@quantity", quantity);
                                        updateInventoryCmd.Parameters.AddWithValue("@itemId", itemId);
                                        updateInventoryCmd.ExecuteNonQuery();
                                    }
                                    Approved = true;
                                }
                                else
                                {
                                    continue;
                                }
                                
                            }
                        }
                        if (Approved)
                        {
                            AuditLog auditLog = new AuditLog();
                            auditLog.LogEvent(CurrentUserDetails.UserID, "Supply Request", "Release", SupplyRequest_ID.SR_ID, "Supply request released");
                            string[] headers = GetHeaders();
                            string htmlHeader = EmailBuilder.TableHeaders(headers.ToList());
                            string[] htmlTable = new string[dataGridView1.Rows.Count];
                            int count = 0;
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    string[] rows = new string[headers.Length];
                                    for (int i = 0; i < rows.Length; i++)
                                    {
                                        rows[i] = row.Cells[i].Value.ToString();
                                    }
                                    htmlTable[count] = EmailBuilder.TableRow(rows.ToList());
                                    count++;
                                }
                            }

                            // EMAIL PART
                            var emailSender = new EmailSender(
                            smtpHost: "smtp.gmail.com",
                            smtpPort: 587,
                            smtpUsername: "procurementinventory27@gmail.com",
                            smtpPassword: "tyov yxim zcjx ynfp",
                            sslOptions: SecureSocketOptions.StartTls
                            );

                            string EmailStatus = emailSender.SendEmail(
                                fromName: "SUPPLY REQUEST NOTIFICATION [NOREPLY]",
                                fromAddress: "procurementinventory27@gmail.com",
                                toName: $"{CurrentUserDetails.FName} {CurrentUserDetails.LName}",
                                toAddress: "mendegorinraf@gmail.com",
                                subject: $"ITEM RELEASED! Supply Request {SupplyRequest_ID.SR_ID}",
                                htmlTable: EmailBuilder.ContentBuilder(
                                    requestID: SupplyRequest_ID.SR_ID,
                                    Receiver: $"{CurrentUserDetails.FName} {CurrentUserDetails.LName}",
                                    Sender: "Approver",
                                    UserAction: "RELEASED",
                                    TypeOfRequest: "Supply Request Item",
                                    TableTitle: "Requested Item",
                                    Header: htmlHeader,
                                    Body: htmlTable
                                    )
                                );
                            MessageBox.Show(EmailStatus);
                            transaction.Commit();
                            MessageBox.Show("Supply request released successfully.");
                        }
                        
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("An error occurred while releasing the supply request: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                    RefreshSupplyRequestTable();
                }
            }

        }

        public static class SupplyRequestItemIDNum
        {
            public static string RequestedItemID { get; set; }
        }
    }
}
