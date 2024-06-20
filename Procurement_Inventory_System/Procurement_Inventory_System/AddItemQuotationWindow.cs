using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Security;

namespace Procurement_Inventory_System
{
    
    public partial class AddItemQuotationWindow : Form
    {
        private const int PageSize = 10; // Number of records per page
        private int currentPage = 1;
        private DataTable quotation_item;

        private UpdatePurchaseRqstWindow updatePurchaseRqstWindow;
        public ItemQuotation NewQuotationItem { get; private set; } = null;
        DataTable item_qtn_tbl;
        public SupplierQuotation NewSupQuo { get; private set; } = null;

        public AddItemQuotationWindow(UpdatePurchaseRqstWindow updatePurchaseRqstWindow)
        {
            InitializeComponent();
            this.updatePurchaseRqstWindow = updatePurchaseRqstWindow;
            item_qtn_tbl = new DataTable();

            item_qtn_tbl.Columns.Add("Item ID", typeof(string));
            item_qtn_tbl.Columns.Add("Item Name", typeof(string));
            item_qtn_tbl.Columns.Add("Quantity", typeof(string));
            item_qtn_tbl.Columns.Add("Unit Price", typeof(string));
        }

        public void LoadTable()
        {
            item_qtn_tbl.Rows.Add(NewQuotationItem.ItemId, NewQuotationItem.ItemName, NewQuotationItem.quantity, NewQuotationItem.unit_price);
            dataGridView1.DataSource = item_qtn_tbl;
        }

        public void LoadItemName()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";

            // will use purchase_request_id variable (depending on what purchase request is selected)
            query = $"SELECT Item_List.item_id, Item_List.item_name, Purchase_Request_Item.item_quantity \r\nFROM Purchase_Request_Item INNER JOIN Item_List ON Purchase_Request_Item.item_id = Item_List.item_id \r\nINNER JOIN Supplier ON Supplier.supplier_id=Item_List.supplier_id\r\nWHERE Purchase_Request_Item.purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}' AND Supplier.supplier_id = '{PurchaseRequestItemIDNum.Supplier}'";

            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Add item quantity to the ComboBox data source
            dt.Columns.Add("DisplayMember", typeof(string), "item_name + ' (Qty: ' + item_quantity + ')'");

            // Clear existing items to avoid duplication if this method is called more than once
            itemName.DataSource = null;
            itemName.DataSource = dt;
            itemName.DisplayMember = "DisplayMember";
            itemName.ValueMember = "item_id";

            itemName.SelectedItem = null;

            db.CloseConnection();
        }

        public void StoreQuotation() // method for storing quotation details
        {
            // variables used for ID formatting
            string idPrefix = "QUO-" + DateTime.Now.ToString("yyyyMMdd");
            string lastIdQuery = $"SELECT TOP 1 quotation_id FROM Quotation WHERE quotation_id LIKE '{idPrefix}-%' ORDER BY quotation_id DESC";
            string nextQuotationId = $"{idPrefix}-001"; 
            string userID = CurrentUserDetails.UserID;
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlDataReader dr = db.GetRecord(lastIdQuery);
            if (dr.Read()) 
            {
                string lastId = dr["quotation_id"].ToString();
                int lastNumber = int.Parse(lastId.Split('-')[2]);
                nextQuotationId = $"{idPrefix}-{(lastNumber + 1):D3}";
            }
            dr.Close();
            GetQuotationDetails.QuotationID = nextQuotationId;
            string insertCmd = $"INSERT INTO Quotation (quotation_id, supplier_id, vat_status, quotation_date, quotation_validity, quotation_user_id) VALUES(@QuotationID, @SupplierID, @VatStatus, GETDATE(), @QuotationValidity, @UserID)";
            using (SqlCommand cmd = new SqlCommand(insertCmd, db.GetSqlConnection()))
            {
                cmd.Parameters.AddWithValue("@QuotationID", nextQuotationId);
                cmd.Parameters.AddWithValue("@SupplierID", GetQuotationDetails.SupplierID);
                cmd.Parameters.AddWithValue("@VatStatus", GetQuotationDetails.VatStatus);
                cmd.Parameters.AddWithValue("@QuotationValidity", GetQuotationDetails.Validity);
                cmd.Parameters.AddWithValue("@UserID", userID);
                int returnRow = cmd.ExecuteNonQuery();
                if (returnRow > 0) 
                {
                    db.CloseConnection(); 
                }
            }

            NewSupQuo = new SupplierQuotation
            {
                QuotationID = nextQuotationId,
                Supplier = GetQuotationDetails.SupplierID,
                Validity = GetQuotationDetails.Validity,
                Vat_Status = GetQuotationDetails.VatStatus
            };
        }

        public void StoreItemQuotation()    // for storing item quotation
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string quoID = GetQuotationDetails.QuotationID;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string itemId = row.Cells[0].Value.ToString();
                    double unitPrice = Convert.ToDouble(row.Cells[3].Value);

                    string insertCmd = $"INSERT INTO Item_Quotation (quotation_id, item_id, unit_price) VALUES('{quoID}', '{itemId}', '{unitPrice}');";
                    int returnRow = db.insDelUp(insertCmd);

                    // Update Purchase_Request_Item with the new QuotationId
                    string updateCmd = $"UPDATE Purchase_Request_Item SET quotation_id = '{quoID}' WHERE purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}' AND item_id = '{itemId}';";
                    db.insDelUp(updateCmd);
                }
            }
            db.CloseConnection();
            AuditLog auditLog = new AuditLog();
            auditLog.LogEvent(CurrentUserDetails.UserID, "Quotation", "Insert", quoID, $"Added quotation to {PurchaseRequestIDNum.PurchaseReqID}");

            // Check if all items have quotations and calculate the total value
            string checkQuotationsQuery = $@"SELECT pri.item_quantity, iq.unit_price
                                     FROM Purchase_Request_Item pri
                                     LEFT JOIN Item_Quotation iq ON pri.quotation_id = iq.quotation_id AND pri.item_id = iq.item_id
                                     WHERE pri.purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}'";
            SqlCommand checkCmd = new SqlCommand(checkQuotationsQuery, db.GetSqlConnection());
            db.OpenConnection();
            SqlDataReader reader = checkCmd.ExecuteReader();

            bool allItemsQuoted = true;
            double totalValue = 0;

            while (reader.Read())
            {
                if (reader["unit_price"] == DBNull.Value)
                {
                    allItemsQuoted = false;
                    break;
                }
                else
                {
                    int quantity = Convert.ToInt32(reader["item_quantity"]);
                    double unitPrice = Convert.ToDouble(reader["unit_price"]);
                    totalValue += quantity * unitPrice;
                }
            }
            reader.Close();
            string deptID = GetDeptID(PurchaseRequestIDNum.PurchaseReqID, db);
            if (allItemsQuoted)
            {
                string recipientRoleId = totalValue > 50000 ? "17" : "12";
                string approverDetailsQuery = @"SELECT TOP 1 emp_fname, emp_lname, email_address 
                                     FROM Employee 
                                     WHERE role_id = 12 AND department_id = @DepartmentId";
                SqlCommand cmd = new SqlCommand(approverDetailsQuery, db.GetSqlConnection());
                cmd.Parameters.AddWithValue("@DepartmentId", deptID);
                SqlDataReader approverReader = cmd.ExecuteReader();

                string approverEmail = "";
                string approverFullName = "";

                if (approverReader.Read())
                {
                    approverFullName = $"{approverReader["emp_fname"].ToString()} {approverReader["emp_lname"].ToString()}";
                    approverEmail = approverReader["email_address"].ToString();
                }

                db.CloseConnection();

                if (!string.IsNullOrEmpty(approverEmail))
                {
                    SendEmailToApprover(approverEmail, approverFullName, GetQuotationDetails.QuotationID);
                }
            }

        }
        private string GetDeptID(string purchaseReqID, DatabaseClass db)
        {
            string deptID = "";
            string deptIDQuery = @"SELECT DISTINCT IL.department_id 
                           FROM Purchase_Request_Item PRI
                           INNER JOIN Item_List IL ON PRI.item_id = IL.item_id
                           WHERE PRI.purchase_request_id = @purchaseReqID
                           GROUP BY IL.department_id";
            using (SqlCommand cmd = new SqlCommand(deptIDQuery, db.GetSqlConnection()))
            {
                cmd.Parameters.AddWithValue("@purchaseReqID", purchaseReqID);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        deptID = dr["department_id"].ToString();
                    }
                    dr.Close();
                }
            }

            return deptID;
        }
        public void LoadSelectedItemQuotation() // loading the item quotation details
        {
            quotation_item = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT Item_List.item_id, Item_List.item_name, Item_Quotation.quantity, Item_Quotation.unit_price FROM Item_Quotation INNER JOIN Quotation ON Item_Quotation.quotation_id = Quotation.quotation_id INNER JOIN Item_List ON Item_List.item_id = Item_Quotation.item_id WHERE Quotation.quotation_id = '{GetQuotationDetails.QuotationID}'";

            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(quotation_item);

            DisplayCurrentPage();
            db.CloseConnection();
        }
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, quotation_item.Rows.Count - 1);

            DataTable pageTable = quotation_item.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(quotation_item.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (quotation_item != null)
            {
                if (currentPage < (quotation_item.Rows.Count + PageSize - 1) / PageSize)
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

            try
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    DisplayCurrentPage();
                }
            }
            catch (NullReferenceException)
            {
                ;
            }
        }
        private void AddItemQuotationWindow_Load(object sender, EventArgs e)
        {
            LoadItemName();
        }

        public void RefreshItemListTable()
        {
            LoadSelectedItemQuotation();
        }

        private async void SendEmailToApprover(string approverEmail, string approverName, string quotationId)
        {
            string htmlHeader = EmailBuilder.TableHeaders(new List<string> { "Item ID", "Item Name", "Quantity", "Unit Price" });
            List<string> htmlTableRows = new List<string>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    List<string> rowData = new List<string>();
                    rowData.Add(row.Cells["Item ID"].Value.ToString());
                    rowData.Add(row.Cells["Item Name"].Value.ToString());
                    rowData.Add(row.Cells["Quantity"].Value.ToString());
                    rowData.Add(row.Cells["Unit Price"].Value.ToString());
                    htmlTableRows.Add(EmailBuilder.TableRow(rowData));
                }
            }

            var emailSender = new EmailSender(
                smtpHost: "smtp.gmail.com",
                smtpPort: 587,
                smtpUsername: "procurementinventory27@gmail.com",
                smtpPassword: "bcvd ioys uohi nsin",
                sslOptions: SecureSocketOptions.StartTls
            );

            string EmailStatus = await emailSender.SendEmail(
                fromName: "Quotation Notification [NOREPLY]",
                fromAddress: "procurementinventory27@gmail.com",
                toName: "APPROVER",
                toAddress: approverEmail,
                subject: "New Quotation Inserted",
                htmlTable: EmailBuilder.ContentBuilder(
                    requestID: PurchaseRequestIDNum.PurchaseReqID,
                    Receiver: approverName,
                    Sender: $"{CurrentUserDetails.FName} {CurrentUserDetails.LName}",
                    UserAction: "ADDED QUOTATION",
                    TypeOfRequest: "Purchase Request",
                    TableTitle: "Requested Item",
                    Header: htmlHeader,
                    Body: htmlTableRows.ToArray()
                )
            );
        }

        private void AddItemQtnBtnClick(object sender, EventArgs e)
        {
            bool isDouble = double.TryParse(itemUnitPrice.Text, out double result);

            if (!isDouble)
            {
                errorProvider1.SetError(itemUnitPrice, "Enter a valid number.");
            }
            else
            {
                int unitPrice = int.Parse(itemUnitPrice.Text);
                if (unitPrice < 1)
                {
                    errorProvider1.SetError(itemUnitPrice, "The value must be greater than 0.");
                    return; // Exit the method if the quantity is not valid
                }
                else
                {
                    errorProvider1.SetError(itemUnitPrice, string.Empty);
                }
            }

            if ((itemQuant.Text != "") && (isDouble))
            {
                string selectedItemId = itemName.SelectedValue.ToString();
                string selectedItemName = (itemName.SelectedItem as DataRowView)["item_name"].ToString();
                NewQuotationItem = new ItemQuotation
                {
                    ItemId = selectedItemId, //include item name 
                    ItemName = selectedItemName,
                    quantity = Convert.ToInt32(itemQuant.Text),
                    unit_price = itemUnitPrice.Text
                };

                // Update DataGridView
                LoadTable();

                // Remove the selected item from the ComboBox
                DataTable dt = itemName.DataSource as DataTable;
                if (dt != null)
                {
                    DataRow[] rows = dt.Select($"item_id = '{selectedItemId}'");
                    foreach (DataRow row in rows)
                    {
                        dt.Rows.Remove(row);
                    }
                }

                // Reset and remove the selected combobox to prevent choosing it again
                itemQuant.Text = null;
                itemUnitPrice.Text = null;
                itemName.SelectedItem = null;
            }
            else
            {
                if ((itemQuant.Text == ""))
                {
                    MessageBox.Show("Select item first before adding it.", "Invalid item and item quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void SaveQuotationBtnClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please add the item/s before proceeding.");
                return; // Exit the method if the DataGridView is empty
            }

            // Check if there are more items in the ComboBox
            if (itemName.Items.Count > 0)
            {
                // Ask the user if they are sure they want to proceed without adding all items
                DialogResult dialogResult = MessageBox.Show("There are still items in the list. Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.No)
                {
                    // User chose not to proceed, so exit the method
                    return;
                }
            }

            // saves quotation data to quotation tbl
            StoreQuotation();
            StoreItemQuotation();
            updatePurchaseRqstWindow.PopulatePurchaseRequestItem();
            // update datagridview in SupplierQuotationPage (stil figuring it out)

            SupplierQuotationPrompt form = new SupplierQuotationPrompt();
            form.ShowDialog();
            this.Close();

            GetQuotationDetails.SupplierID = null;
        }

        private void CancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ItemNameSelectedValueChanged(object sender, EventArgs e)
        {
            // if there is no selected item in the item name combobox, the quantity textbox should be null as well
            if (itemName.SelectedItem == null)
            {
                itemQuant.Text = null;
            }
            else
            {
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string query = $"SELECT Purchase_Request_Item.item_quantity FROM Purchase_Request INNER JOIN Purchase_Request_Item on Purchase_Request.purchase_request_id = Purchase_Request_Item.purchase_request_id INNER JOIN Item_List on Item_List.item_id = Purchase_Request_Item.item_id WHERE Purchase_Request.purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}' AND Item_List.item_id = '{itemName.SelectedValue}';";
                SqlDataReader quantRec = db.GetRecord(query);

                if (quantRec.HasRows)
                {
                    quantRec.Read();

                    itemQuant.Text = quantRec["item_quantity"].ToString();  // displays the quantity of the selected item
                }

                db.CloseConnection();
            }
        }

        private void deleteitemqtnbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // create a list to keep track of rows to delete
                List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

                // loop through selected cells and add their rows to the list
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    DataGridViewRow row = cell.OwningRow;
                    if (!row.IsNewRow && !rowsToDelete.Contains(row))
                    {
                        rowsToDelete.Add(row);
                    }
                }

                // remove the rows and add them back to the ComboBox
                foreach (DataGridViewRow row in rowsToDelete)
                {
                    string itemId = row.Cells["Item ID"].Value.ToString();
                    string itemName = GetItemNameById(itemId); 
                    string itemQuantity = row.Cells["Quantity"].Value.ToString();

                    // Add the deleted item back to the ComboBox data source
                    DataTable dt = this.itemName.DataSource as DataTable;
                    if (dt != null)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["item_id"] = itemId;
                        newRow["item_name"] = itemName;
                        newRow["item_quantity"] = itemQuantity;
                        dt.Rows.Add(newRow);
                    }

                    // Remove the row from the DataGridView
                    dataGridView1.Rows.Remove(row);
                }

                // refresh the DataGridView
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Delete Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Helper method to get item name by its ID
        private string GetItemNameById(string itemId)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string itemName = "";
            string query = $"SELECT item_name FROM Item_List WHERE item_id = '{itemId}'";
            SqlDataReader reader = db.GetRecord(query);
            if (reader.Read())
            {
                itemName = reader["item_name"].ToString();
            }

            reader.Close();
            db.CloseConnection();

            return itemName;
        }
    }

    public class ItemQuotation
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int quantity { get; set; }
        public string unit_price { get; set; }
    }

    public class SupplierQuotation
    {
        public string QuotationID { get; set; }
        public string Supplier { get; set; }
        public string Validity { get; set; }
        public string Vat_Status { get; set; }
    }
}
