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
    public partial class AddPurchaseOrderWindow : Form
    {
        private const int PageSize = 20; // Number of records per page
        private int currentPage = 1;
        private DataTable purchase_request_item_table;

        private PurchaseOrderPage purchaseOrderPage;
        private bool _isFiltered = false;
        public AddPurchaseOrderWindow(PurchaseOrderPage purchaseOrderPage)
        {
            InitializeComponent();
            this.purchaseOrderPage = purchaseOrderPage;
        }

        private void AddPurchaseOrderWindow_Load(object sender, EventArgs e)
        {
            PopulateApprovedItems();
            PopulateBranch();   // populate the values inside branchFilter combobox
        }
        private void PopulateApprovedItems()
        {
            dataGridView1.DataSource = null;
            purchase_request_item_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query1 = $@"SELECT su.supplier_name AS 'Supplier', 
                              su.supplier_id AS 'Supplier ID', 
                              pri.purchase_request_id AS 'Purchase Request ID',
                              pri.purchase_request_item_id AS 'PR Item ID',
                              br.branch_name AS 'Branch',
                              il.section_id AS 'Section',
                              il.item_name AS 'Item Name', 
                              pri.item_quantity AS 'Qty', 
                              COALESCE(iq.unit_price, 'N/A') AS 'Unit Price', 
                              qu.vat_status AS 'VAT Status',
                              pri.purchase_item_status AS 'Status' 
                            FROM 
                              Purchase_Request_Item pri 
                            JOIN 
                              Item_List il ON pri.item_id = il.item_id 
                            LEFT JOIN 
                              Item_Quotation iq ON pri.quotation_id = iq.quotation_id AND pri.item_id = iq.item_id
                            JOIN 
                              Quotation qu ON iq.quotation_id = qu.quotation_id 
                            JOIN 
                              Supplier su ON su.supplier_id = qu.supplier_id
                            JOIN
                              Section se ON se.section_id=il.section_id
                            JOIN
                              Department de ON de.department_id=se.department_id
                            JOIN 
                              Branch br ON br.branch_id=de.branch_id
                            WHERE 
                              pri.purchase_item_status = 'APPROVED'";
            string query2 = $@"SELECT su.supplier_name AS 'Supplier', 
                              su.supplier_id AS 'Supplier ID', 
                              pri.purchase_request_id AS 'Purchase Request ID',
                              pri.purchase_request_item_id AS 'PR Item ID',
                              br.branch_name AS 'Branch',
                              il.item_name AS 'Item Name', 
                              pri.item_quantity AS 'Qty', 
                              COALESCE(iq.unit_price, 'N/A') AS 'Unit Price', 
                              qu.vat_status AS 'VAT Status',
                              pri.purchase_item_status AS 'Status' 
                            FROM 
                              Purchase_Request_Item pri 
                            JOIN 
                              Item_List il ON pri.item_id = il.item_id 
                            LEFT JOIN 
                              Item_Quotation iq ON pri.quotation_id = iq.quotation_id AND pri.item_id = iq.item_id
                            JOIN 
                              Quotation qu ON iq.quotation_id = qu.quotation_id 
                            JOIN 
                              Supplier su ON su.supplier_id = qu.supplier_id
                            JOIN
                              Department de ON de.department_id = il.department_id
                            JOIN 
                              Branch br ON br.branch_id=de.branch_id
                            WHERE 
                              pri.purchase_item_status = 'APPROVED' AND de.branch_id = '{CurrentUserDetails.BranchId}'";
            if ((CurrentUserDetails.BranchId == "MOF" && CurrentUserDetails.Role == "11") || (CurrentUserDetails.BranchId == "MOF" || CurrentUserDetails.BranchId == "CAL" && CurrentUserDetails.Role == "14"))
            {
                SqlDataAdapter da = db.GetMultipleRecords(query1);
                da.Fill(purchase_request_item_table);
            }
            else if (CurrentUserDetails.Role == "11")
            {
                branchFilter.Visible = false;   // making branchFilter combobox invisible
                SqlDataAdapter da = db.GetMultipleRecords(query2);
                da.Fill(purchase_request_item_table);
            }
            // Check if the checkbox column already exists
            // Add a Boolean column for checkboxes before setting the DataSource of dataGridView1
            purchase_request_item_table.Columns.Add("Select", typeof(bool));
            foreach (DataRow row in purchase_request_item_table.Rows)
            {
                row["Select"] = false; // This will be the checkbox state
            }
            DisplayCurrentPage();
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
            if (purchase_request_item_table != null)
            {
                if (currentPage < (purchase_request_item_table.Rows.Count + PageSize - 1) / PageSize)
                {
                    currentPage++;
                    DisplayCurrentPage();
                }
            }
            else
            {
                MessageBox.Show("No data to show.");
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
        private void FilterDataGridView()
        {
            // Determine if any checkbox is checked
            _isFiltered = dataGridView1.Rows.Cast<DataGridViewRow>()
                          .Any(row => (bool?)row.Cells["Select"].Value == true);

            // If at least one checkbox is checked, filter the items for that supplier only
            if (_isFiltered)
            {
                string selectedSupplier = dataGridView1.Rows.Cast<DataGridViewRow>()
                                           .Where(row => (bool?)row.Cells["Select"].Value == true)
                                           .Select(row => row.Cells["Supplier"].Value.ToString())
                                           .FirstOrDefault();
                string selectedVat = dataGridView1.Rows.Cast<DataGridViewRow>()
                                           .Where(row => (bool?)row.Cells["Select"].Value == true)
                                           .Select(row => row.Cells["VAT Status"].Value.ToString())
                                           .FirstOrDefault();
                string selectedBranch = dataGridView1.Rows.Cast<DataGridViewRow>()
                                           .Where(row => (bool?)row.Cells["Select"].Value == true)
                                           .Select(row => row.Cells["Branch"].Value.ToString())
                                           .FirstOrDefault();

                if (!string.IsNullOrEmpty(selectedSupplier))
                {
                    var filteredData = (((DataTable)dataGridView1.DataSource).AsEnumerable()
                                        .Where(row => row.Field<string>("Supplier") == selectedSupplier && row.Field<string>("VAT Status") == selectedVat && row.Field<string>("Branch") == selectedBranch));

                    // Set the DataSource to the filtered data
                    dataGridView1.DataSource = filteredData.CopyToDataTable();
                }
            }
            else
            {
                // If no checkboxes are checked, show all approved purchase items
                PopulateApprovedItems();
                if ((CurrentUserDetails.BranchId == "MOF" && CurrentUserDetails.Role == "11") || (CurrentUserDetails.BranchId == "MOF" || CurrentUserDetails.BranchId == "CAL" && CurrentUserDetails.Role == "14"))
                {
                    FilterData();
                }
            }
        }
        private void RefreshPurchaseOrderTable()
        {
            purchaseOrderPage.PopulatePurchaseOrder();
        }

        private async void AddOrderBtnClick(object sender, EventArgs e)
        {
            try
            {
                string supplierId = "";
                this.Close();
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Select"].Value))
                    {
                        supplierId = row.Cells["Supplier ID"].Value.ToString();
                        break; // Since all items have the same supplier, we just need the first one
                    }
                }
                string datePrefix = DateTime.Now.ToString("yyyyMMdd");
                string lastIdQuery = @"SELECT TOP 1 purchase_order_id FROM Purchase_Order
                     WHERE purchase_order_id LIKE 'PO-" + datePrefix + "-%' ORDER BY purchase_order_id DESC";
                string nextPoId = $"PO-{datePrefix}-001"; // Default if no items found for today
                SqlDataReader dr = db.GetRecord(lastIdQuery);
                if (dr.Read())
                {
                    string lastId = dr["purchase_order_id"].ToString();
                    int lastNumber = int.Parse(lastId.Split('-')[2]);
                    nextPoId = $"PO-{datePrefix}-{(lastNumber + 1):D3}";
                }
                dr.Close();
                // Insert into Purchase_Order
                string prQuery = @"INSERT INTO Purchase_Order (purchase_order_id, supplier_id, order_user_id, purchase_order_date, purchase_order_status) 
                                   VALUES (@nextPoId, @supplierId, @userId, GETDATE(), 'TO BE DELIVERED')";
                using (SqlCommand cmd = new SqlCommand(prQuery, db.GetSqlConnection()))
                {
                    cmd.Parameters.AddWithValue("@nextPoId", nextPoId);
                    cmd.Parameters.AddWithValue("@supplierId", supplierId);
                    cmd.Parameters.AddWithValue("@userId", CurrentUserDetails.UserID);
                    cmd.ExecuteNonQuery();
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Select"].Value))
                    {
                        string purchaseRequestItemId = row.Cells["PR Item ID"].Value.ToString();
                        decimal unitPrice = Convert.ToDecimal(row.Cells["Unit Price"].Value);
                        int quantity = Convert.ToInt32(row.Cells["Qty"].Value);
                        decimal totalPrice = unitPrice * quantity;
                        //string nextItemId = GetNextItemId(datePrefix, db); 
                        // Insert into Purchase_Order_Item
                        string poiQuery = @"INSERT INTO Purchase_Order_Item (purchase_order_id, purchase_request_item_id, total_price, order_item_status) 
                                    VALUES (@nextPoId, @priId, @totalPrice, 'TO BE DELIVERED')";
                        using (SqlCommand itemCmd = new SqlCommand(poiQuery, db.GetSqlConnection()))
                        {
                            itemCmd.Parameters.AddWithValue("@nextPoId", nextPoId);
                            itemCmd.Parameters.AddWithValue("@priId", purchaseRequestItemId);
                            itemCmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                            itemCmd.ExecuteNonQuery();
                        }
                        string updatePriStatusQuery = @"UPDATE Purchase_Request_Item SET purchase_item_status = 'ORDERED' 
                                                    WHERE purchase_request_item_id = @priId";
                        using (SqlCommand updateCmd = new SqlCommand(updatePriStatusQuery, db.GetSqlConnection()))
                        {
                            updateCmd.Parameters.AddWithValue("@priId", purchaseRequestItemId);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }
                AuditLog auditLog = new AuditLog();
                auditLog.LogEvent(CurrentUserDetails.UserID, "Purchase Order", "Insert", nextPoId, $"Added purchase order");
                //RefreshOrderListTable();
                AddPurchaseOrderPrompt form = new AddPurchaseOrderPrompt();
                form.ShowDialog();
                StringBuilder itemsHtml = new StringBuilder();
                itemsHtml.Append("<html><body>");
                itemsHtml.Append("<style>table { width: 100%; border-collapse: collapse; } th, td { border: 1px solid #ddd; padding: 8px; text-align: left; } th { background-color: #f2f2f2; } </style>");
                itemsHtml.Append("<p><strong>Purchase Order from NCT Corporation.</strong></p>");
                itemsHtml.Append("<h2>Purchase Order</h2>");
                itemsHtml.Append("<table><tr><th>Item Name</th><th>Quantity</th><th>Unit Price</th><th>Total Price</th></tr>");

                decimal orderTotal = 0m; // To calculate the total order value

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Select"].Value))
                    {
                        string itemName = row.Cells["Item Name"].Value.ToString();
                        int quantity = Convert.ToInt32(row.Cells["Qty"].Value);
                        decimal unitPrice = Convert.ToDecimal(row.Cells["Unit Price"].Value);
                        decimal totalPrice = quantity * unitPrice;
                        orderTotal += totalPrice; // Add to the order total

                        itemsHtml.Append($"<tr><td>{itemName}</td><td>{quantity}</td><td>{unitPrice:0.00}</td><td>{totalPrice:0.00}</td></tr>");
                    }
                }

                itemsHtml.Append("</table>");
                itemsHtml.Append($"<p><strong>Order Total: {orderTotal:0.00}</strong></p>");
                itemsHtml.Append($"<p>Contact Person: {CurrentUserDetails.FName} {CurrentUserDetails.LName}</p>");
                itemsHtml.Append($"<p>Mobile Number: {CurrentUserDetails.MobileNum}</p>");
                itemsHtml.Append($"<p>Email Address: {CurrentUserDetails.Email}</p>");
                itemsHtml.Append("<p>[This is a system generated email. Please do not reply.]</p>");
                itemsHtml.Append("</body></html>");

                // Send the email
                var emailSender = new EmailSender(
                    smtpHost: "smtp.gmail.com",
                    smtpPort: 587,
                    smtpUsername: "procurementinventory27@gmail.com",
                    smtpPassword: "lkxn iide twel ixno",
                    sslOptions: SecureSocketOptions.StartTls
                );

                string EmailStatus = await emailSender.SendEmail(
                    fromName: "NCT Corporation [NOREPLY]",
                    fromAddress: "procurementinventory27@gmail.com",
                    toName: "Supplier",
                    toAddress: "mendegorinraf@gmail.com", // Replace with actual supplier email
                    subject: $"Purchase Order {nextPoId}",
                    htmlTable: itemsHtml.ToString()
                );

                MessageBox.Show(EmailStatus);
                RefreshPurchaseOrderTable();
            }
            catch
            {
                MessageBox.Show("There is no Purchase Order to create.");
            }
        }

        private void CancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on a checkbox column
            if (e.ColumnIndex == dataGridView1.Columns["Select"].Index && e.RowIndex != -1)
            {
                // Toggle the checkbox
                bool isChecked = (bool)dataGridView1[e.ColumnIndex, e.RowIndex].Value;
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = !isChecked;

                // Filter the DataGridView based on the checked state of the checkbox
                FilterDataGridView();
            }
        }

        private void PopulateBranch()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();


            string query = "";

            query = "select BRANCH_NAME, BRANCH_ID from BRANCH";   // select all branch name

            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Clear existing items to avoid duplication if this method is called more than once
            branchFilter.DataSource = null;
            branchFilter.DataSource = dt;
            branchFilter.DisplayMember = "BRANCH_NAME";
            branchFilter.ValueMember = "BRANCH_NAME";
            db.CloseConnection();
        }
        private void FilterData()
        {
            DataTable dt = (dataGridView1.DataSource as DataTable);
            string brFilter = branchFilter.SelectedValue.ToString();
            if (purchase_request_item_table != null)
            {
                dt.DefaultView.RowFilter = $"Branch = '{brFilter}'";
            }
        }

        private void branchFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CurrentUserDetails.BranchId == "MOF" && CurrentUserDetails.Role == "11") || (CurrentUserDetails.BranchId == "MOF" || CurrentUserDetails.BranchId == "CAL" && CurrentUserDetails.Role == "14"))
            {
                FilterData();
            }
        }
    }
}
