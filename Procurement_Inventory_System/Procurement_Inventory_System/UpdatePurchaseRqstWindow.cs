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
using static Procurement_Inventory_System.UpdateSupplyRequestWindow;
using MailKit.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Reflection.Emit;

namespace Procurement_Inventory_System
{
    public partial class UpdatePurchaseRqstWindow : Form
    {
        private const int PageSize = 10; // Number of records per page
        private int currentPage = 1;
        private DataTable purchase_request_item_table;

        private PurchaseRequestPage purchaseRequestPage;
        private Dictionary<string, string> itemsToUpdate = new Dictionary<string, string>();
        private Dictionary<string, string> originalStatuses = new Dictionary<string, string>(); // for audit logs
        bool approvalFlag;

        private string[] parts;
        private string number;
        private double numberDouble;
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

        private double CalculateApprovedPercentage()
        {
            int approvedCount = 0;
            int validRowCount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Skip new rows that are not committed
                if (row.IsNewRow) continue;

                // Skip rows with null or empty status
                var cellValue = row.Cells["Unit Price"].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString())) continue;

                validRowCount++; // Increment valid row count

                // Check for "Approved" status
                if (cellValue.ToString().Equals("N/A", StringComparison.OrdinalIgnoreCase))
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
        public bool HasQuotation()
        {

            if (CalculateApprovedPercentage() == 0) return true;
            else { return false; }
        }

        private void addsupplyqtnbtn_Click(object sender, EventArgs e)
        {
            if (PurchaseRequestIDNum.PurchaseReqID == null)
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
        private string[] GetHeaders()
        {
            string[] headers = new string[dataGridView1.Columns.Count];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                headers[i] = dataGridView1.Columns[i].HeaderText;
            }
            return headers;
        }

        public void HideAllButtons()
        {
            approverqstbtn.Visible = false;
            rejectrqstbtn.Visible = false;
            addsupplyqtnbtn.Visible = false;
            updaterqstbtn.Visible = false;
            cancelbtn.Text = "BACK";
            CenterButton(cancelbtn);
        }


        public void ShowAll()
        {
            approverqstbtn.Visible = true;
            rejectrqstbtn.Visible = true;
            addsupplyqtnbtn.Visible = true;
        }

        private void CenterButton(Button button)
        {
            // Calculate the center position
            //int x = (panel1.Width - button.Width) / 2;
            //int y = (panel1.Height - button.Height) / 2; // Adjust y if you want it to be centered vertically, or set a fixed y value to keep it in place

            // Set the button's position
            //button.Location = new Point(x, y);
        }

        private async void updaterqstbtn_Click(object sender, EventArgs e)
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
                    string purchasingDetailsQuery = @"SELECT emp_fname, emp_lname, email_address FROM Employee
                                        INNER JOIN Account ON Employee.emp_id=Account.emp_id 
                                        WHERE Employee.role_id = '14' AND Account.account_status = 'ACTIVATED'";

                    List<string> emailAddresses = new List<string>();
                    List<string> fullNames = new List<string>();

                    SqlCommand cmd = new SqlCommand(purchasingDetailsQuery, db.GetSqlConnection());
                    db.GetSqlConnection().Open();
                    SqlDataReader approverDr = cmd.ExecuteReader();
                    while (approverDr.Read())
                    {
                        emailAddresses.Add(approverDr["email_address"].ToString());
                        fullNames.Add($"{approverDr["emp_fname"].ToString()} {approverDr["emp_lname"].ToString()}");
                    }
                    approverDr.Close();
                    db.GetSqlConnection().Close();

                    var emailSender = new EmailSender(
                        smtpHost: "smtp.gmail.com",
                        smtpPort: 587,
                        smtpUsername: "procurementinventory27@gmail.com",
                        smtpPassword: "vkxg wsci roob nuif",
                        sslOptions: SecureSocketOptions.StartTls
                    );

                    for (int i = 0; i < emailAddresses.Count; i++)
                    {
                        string email = emailAddresses[i];
                        string fullName = fullNames[i];

                        string[] headers = GetHeaders();
                        string htmlHeader = EmailBuilder.TableHeaders(headers.ToList());
                        string[] htmlTable = new string[dataGridView1.Rows.Count];
                        int count = 0;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string[] rows = new string[headers.Length];
                                for (int j = 0; j < rows.Length; j++)
                                {
                                    rows[j] = row.Cells[j].Value.ToString();
                                }
                                htmlTable[count] = EmailBuilder.TableRow(rows.ToList());
                                count++;
                            }
                        }

                        string EmailStatus = await emailSender.SendEmail(
                            fromName: "APPROVAL NOTIFICATION [NOREPLY]",
                            fromAddress: "procurementinventory27@gmail.com",
                            toName: fullName,
                            toAddress: email,
                            subject: $"ITEM APPROVED! Purchase Request {PurchaseRequestIDNum.PurchaseReqID}",
                            htmlTable: EmailBuilder.ContentBuilder(
                                requestID: PurchaseRequestIDNum.PurchaseReqID,
                                Receiver: fullName,
                                Sender: $"{CurrentUserDetails.FName} {CurrentUserDetails.LName}",
                                UserAction: "APPROVED FOR PURCHASE",
                                TypeOfRequest: "Purchase Request Item",
                                TableTitle: "Requested Item",
                                Header: htmlHeader,
                                Body: htmlTable
                            )
                        );
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
            DisplayOverallPrice();

            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);
                if ((userRole == "12"))   // if the role is approver and admin, add quotation should be hidden
                {
                    addsupplyqtnbtn.Visible = false;

                    parts = label1.Text.Split(' ');
                    number = parts[3];
                    numberDouble = double.Parse(number);

                    if (numberDouble > 50000.00)
                    {
                        approverqstbtn.Text = "NOTIFY PRESIDENT";
                    }
                }

                if (userRole == "17")
                {
                    addsupplyqtnbtn.Visible = false;
                }

                if (userRole == "14")    // if the role is purchase dept, approve and reject btns should be hidden
                {
                    approverqstbtn.Visible = false;
                    rejectrqstbtn.Visible = false;
                }

                if (userRole == "13")
                {
                    HideAllButtons();
                }
            }
        }
        public void PopulatePurchaseRequestItem()
        {

            purchase_request_item_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT purchase_request_item_id AS 'Purchase Request Item ID', item_name AS 'Item Name', pri.item_quantity AS 'Quantity', \r\nISNULL(CONVERT(varchar, iq.unit_price), 'N/A') AS 'Unit Price', pri.purchase_item_status AS 'Status', Supplier.supplier_id AS 'Supplier' \r\nFROM Purchase_Request_Item pri JOIN Item_List il ON pri.item_id = il.item_id LEFT JOIN Item_Quotation iq \r\nON pri.quotation_id = iq.quotation_id AND pri.item_id = iq.item_id \r\nJOIN Supplier ON il.supplier_id=Supplier.supplier_id\r\nWHERE pri.purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}'";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(purchase_request_item_table);
            DisplayCurrentPage();
            foreach (DataRow row in purchase_request_item_table.Rows)
            {
                originalStatuses[row["Purchase Request Item ID"].ToString()] = row["Status"].ToString();
            }
            DisplayOverallPrice();
            db.CloseConnection();
        }
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, purchase_request_item_table.Rows.Count - 1);

            DataTable pageTable = purchase_request_item_table.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(purchase_request_item_table.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage < (purchase_request_item_table.Rows.Count + PageSize - 1) / PageSize)
            {
                currentPage++;
                DisplayCurrentPage();
                DisplayOverallPrice(); // Update total price after changing page
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
                DisplayOverallPrice(); // Update total price after changing page
            }

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
                    var cellValue = row.Cells["Purchase Request Item ID"].Value;

                    // Check if cellValue is not null before calling ToString()
                    if (cellValue != null && cellValue.ToString() == PurchaseRequestItemIDNum.PurchaseReqItemID)
                    {
                        if (row.Cells["Unit Price"].Value.ToString() != "N/A")
                        {
                            DialogResult result = MessageBox.Show("Are you sure you want to proceed?", "Warning",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                row.Cells["Status"].Value = "REJECTED";
                                itemsToUpdate[PurchaseRequestItemIDNum.PurchaseReqItemID] = "REJECTED";
                                break;
                            }
                            else if (result == DialogResult.No)
                            {
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Create a Quotation first.");
                        }
                    }
                }
                RefreshPurchaseRequestTable();

            }
        }


        private async void approverqstbtn_Click(object sender, EventArgs e)
        {
            if (PurchaseRequestItemIDNum.PurchaseReqItemID == null)
            {
                if (approverqstbtn.Text == "NOTIFY PRESIDENT")
                {
                    if ((CurrentUserDetails.BranchId == "MOF") && (CurrentUserDetails.Role == "17"))
                    {
                        ApproveRequest();
                    }
                    else
                    {
                        MessageBox.Show("An email will be sent to the President.");
                        await NotifyPresident();
                    }
                }
                else
                {
                    MessageBox.Show("Click purchase request item id first.");
                }
            }
            else
            {

                parts = label1.Text.Split(' ');
                number = parts[3];
                numberDouble = double.Parse(number);

                if (numberDouble <= 50000)
                {
                    ApproveRequest();
                }
                else if ((CurrentUserDetails.BranchId == "MOF") && (CurrentUserDetails.Role == "17"))
                {
                    ApproveRequest();
                }
            }
        }

        private bool HasNAInUnitPrice()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cellValue = row.Cells["Unit Price"].Value;
                if (cellValue != null && cellValue.ToString() == "N/A")
                {
                    return true;
                }
            }
            return false;
        }

        private void ApproveRequest()
        {
            if (HasNAInUnitPrice())
            {
                MessageBox.Show("Create a Quotation first for all items with N/A unit price.");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cellValue = row.Cells["Purchase Request Item ID"].Value;

                // Check if cellValue is not null before calling ToString()
                if (cellValue != null && cellValue.ToString() == PurchaseRequestItemIDNum.PurchaseReqItemID)
                {
                    if (row.Cells["Unit Price"].Value.ToString() != "N/A")
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to proceed?", "Warning",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            row.Cells["Status"].Value = "APPROVED";
                            itemsToUpdate[PurchaseRequestItemIDNum.PurchaseReqItemID] = "APPROVED";
                            addsupplyqtnbtn.Visible = false;
                            break;
                        }
                        else if (result == DialogResult.No)
                        {
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Create a Quotation first.");
                    }

                }
            }

            RefreshPurchaseRequestTable();
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
            try
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["Purchase Request Item ID"].Value.ToString();
                PurchaseRequestItemIDNum.PurchaseReqItemID = val;
            }
            catch
            {

            }
        }

        private double ComputeOverallPrice()
        {
            double totalPrice = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Skip new rows that are not committed
                if (row.IsNewRow) continue;

                // Get quantity and unit price values
                var quantityCell = row.Cells["Quantity"].Value;
                var unitPriceCell = row.Cells["Unit Price"].Value;

                if (quantityCell != null && unitPriceCell != null &&
                    double.TryParse(quantityCell.ToString(), out double quantity) &&
                    double.TryParse(unitPriceCell.ToString(), out double unitPrice))
                {
                    totalPrice += quantity * unitPrice;
                }
            }

            return totalPrice;
        }

        private void DisplayOverallPrice()
        {
            double overallPrice = ComputeOverallPrice();
            // Assuming you have a Label control to display the total price
            label1.Text = $"Total Price: PHP {overallPrice:F2}";
            //label1.AutoSize = false;
            //label1.TextAlign = ContentAlignment.MiddleRight;
        }
        private async Task NotifyPresident()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string presidentDetailsQuery = @"SELECT TOP 1 emp_fname, emp_lname, email_address 
                                     FROM Employee 
                                     WHERE role_id=17";

            SqlCommand cmd = new SqlCommand(presidentDetailsQuery, db.GetSqlConnection());
            SqlDataReader reader = cmd.ExecuteReader();

            string presidentEmail = "";
            string presidentFullName = "";

            if (reader.Read())
            {
                presidentFullName = $"{reader["emp_fname"].ToString()} {reader["emp_lname"].ToString()}";
                presidentEmail = reader["email_address"].ToString();
            }

            db.CloseConnection();

            if (!string.IsNullOrEmpty(presidentEmail))
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
                    smtpPassword: "vkxg wsci roob nuif",
                    sslOptions: SecureSocketOptions.StartTls
                );

                string EmailStatus = await emailSender.SendEmail(
                    fromName: "PURCHASE REQUEST NOTIFICATION [NOREPLY]",
                    fromAddress: "procurementinventory27@gmail.com",
                    toName: "PRESIDENT",
                    toAddress: presidentEmail,
                    subject: $"Approval Needed: Purchase Request {PurchaseRequestIDNum.PurchaseReqID}",
                    htmlTable: EmailBuilder.ContentBuilder(
                        requestID: PurchaseRequestIDNum.PurchaseReqID,
                        Receiver: presidentFullName,
                        Sender: $"{CurrentUserDetails.FName} {CurrentUserDetails.LName}",
                        UserAction: "QUOTED AND REQUIRES PRESIDENT'S APPROVAL",
                        TypeOfRequest: "Purchase Request",
                        TableTitle: "Requested Item",
                        Header: htmlHeader,
                        Body: htmlTable
                    )
                );
            }
        }
    }
    public static class PurchaseRequestItemIDNum
    {
        public static string PurchaseReqItemID { get; set; }
        public static string Supplier { get; set; }
    }
}
