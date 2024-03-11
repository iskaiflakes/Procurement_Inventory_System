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
    public partial class AddPurchaseOrderWindow : Form
    {
        private PurchaseOrderPage purchaseOrderPage;
        private bool _isFiltered = false;
        public AddPurchaseOrderWindow(PurchaseOrderPage purchaseOrderPage)
        {
            InitializeComponent();
            this.purchaseOrderPage = purchaseOrderPage;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addorderbtn_Click(object sender, EventArgs e)
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
                    string purchaseRequestItemId = row.Cells["Purchase Request Item ID"].Value.ToString();
                    decimal unitPrice = Convert.ToDecimal(row.Cells["Unit Price"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
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
                }
            }
            //RefreshOrderListTable();
            AddPurchaseOrderPrompt form = new AddPurchaseOrderPrompt();
            form.ShowDialog();
            // EMAIL PART
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
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal unitPrice = Convert.ToDecimal(row.Cells["Unit Price"].Value);
                    decimal totalPrice = quantity * unitPrice;
                    orderTotal += totalPrice; // Add to the order total

                    itemsHtml.Append($"<tr><td>{itemName}</td><td>{quantity}</td><td>{unitPrice:0.00}</td><td>{totalPrice:0.00}</td></tr>");
                }
            }

            itemsHtml.Append("</table>");
            itemsHtml.Append($"<p><strong>Order Total: {orderTotal:0.00}</strong></p>");
            itemsHtml.Append($"<p>Contact Person: {CurrentUserDetails.FName} {CurrentUserDetails.LName}</p>");
            itemsHtml.Append("<p>[This is a system generated email. Please do not reply.]</p>");
            itemsHtml.Append("</body></html>");

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("NCT Corporation [NOREPLY]", "procurementinventory27@gmail.com"));
            email.To.Add(new MailboxAddress("Supplier", "mendegorinraf@gmail.com")); // Replace with actual supplier email
            email.Subject = $"Purchase Order {nextPoId}";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = itemsHtml.ToString()
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587);
                smtp.Authenticate("procurementinventory27@gmail.com", "lkxn iide twel ixno");
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            RefreshPurchaseOrderTable();
        }

        private void AddPurchaseOrderWindow_Load(object sender, EventArgs e)
        {
            PopulateApprovedItems();
        }
        private void PopulateApprovedItems()
        {
            dataGridView1.DataSource = null;
            DataTable purchase_request_item_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $@"SELECT su.supplier_name AS 'Supplier', 
                              pri.purchase_request_id AS 'Purchase Request ID',
                              il.item_name AS 'Item Name', 
                              pri.item_quantity AS 'Quantity', 
                              COALESCE(iq.unit_price, 'N/A') AS 'Unit Price', 
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
                            WHERE 
                              pri.purchase_item_status = 'APPROVED' AND il.department_id = '{CurrentUserDetails.DepartmentId}' AND il.section_id = '{CurrentUserDetails.DepartmentSection}'
                            AND NOT EXISTS (
                            SELECT 1 FROM Purchase_Order_Item poi
                            WHERE poi.purchase_request_item_id = pri.purchase_request_item_id
                          )";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(purchase_request_item_table);
            // Check if the checkbox column already exists
            // Add a Boolean column for checkboxes before setting the DataSource of dataGridView1
            purchase_request_item_table.Columns.Add("Select", typeof(bool));
            foreach (DataRow row in purchase_request_item_table.Rows)
            {
                row["Select"] = false; // This will be the checkbox state
            }
            dataGridView1.DataSource = purchase_request_item_table;
            dataGridView1.AllowUserToAddRows = false;
            db.CloseConnection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

                if (!string.IsNullOrEmpty(selectedSupplier))
                {
                    // This is a LINQ query to filter the DataTable based on the supplier
                    // You might need to adjust this according to how you're retrieving data
                    var filteredData = ((DataTable)dataGridView1.DataSource).AsEnumerable()
                                        .Where(row => row.Field<string>("Supplier") == selectedSupplier);

                    // Set the DataSource to the filtered data
                    dataGridView1.DataSource = filteredData.CopyToDataTable();
                }
            }
            else
            {
                // If no checkboxes are checked, show all approved purchase items
                PopulateApprovedItems();
            }
        }
        private void RefreshPurchaseOrderTable()
        {
            purchaseOrderPage.PopulatePurchaseOrder();
        }
    }
}
