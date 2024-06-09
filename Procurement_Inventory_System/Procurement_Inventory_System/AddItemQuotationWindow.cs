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
            item_qtn_tbl.Columns.Add("Quantity", typeof(string));
            item_qtn_tbl.Columns.Add("Unit Price", typeof(string));
        }

        public void LoadTable()
        {
            item_qtn_tbl.Rows.Add(NewQuotationItem.ItemId, NewQuotationItem.quantity, NewQuotationItem.unit_price);
            dataGridView1.DataSource = item_qtn_tbl;
        }

        public void LoadItemName()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";

            // will use purchase_request_id variable (depending on what purchase request is selected)
            query = $"SELECT Item_List.item_id, Item_List.item_name \r\nFROM Purchase_Request_Item INNER JOIN Item_List ON Purchase_Request_Item.item_id = Item_List.item_id \r\nINNER JOIN Supplier ON Supplier.supplier_id=Item_List.supplier_id\r\nWHERE Purchase_Request_Item.purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}' AND Supplier.supplier_id = '{PurchaseRequestItemIDNum.Supplier}'";

            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Clear existing items to avoid duplication if this method is called more than once
            itemName.DataSource = null;
            itemName.DataSource = dt;
            itemName.DisplayMember = "item_name";
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
                    double unitPrice = Convert.ToDouble(row.Cells[2].Value);
                    

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
            // If the quotation was stored successfully, send an email to the approver.
            string approverDetailsQuery = @"SELECT TOP 1 emp_fname, emp_lname, email_address 
                                    FROM Employee 
                                    WHERE role_id=12 AND 
                                            branch_id=@BranchId AND 
                                            department_id=@DepartmentId AND 
                                            section_id=@Section";
            SqlCommand cmd = new SqlCommand(approverDetailsQuery, db.GetSqlConnection());
            cmd.Parameters.AddWithValue("@BranchId", CurrentUserDetails.BranchId);
            cmd.Parameters.AddWithValue("@DepartmentId", CurrentUserDetails.DepartmentId);
            cmd.Parameters.AddWithValue("@Section", CurrentUserDetails.DepartmentSection);

            db.GetSqlConnection().Open();
            SqlDataReader reader = cmd.ExecuteReader();

            string approverEmail = "";
            string approverFullName = "";

            if (reader.Read())
            {
                approverFullName = $"{reader["emp_fname"].ToString()} {reader["emp_lname"].ToString()}";
                approverEmail = reader["email_address"].ToString();
            }

            db.GetSqlConnection().Close();

            if (!string.IsNullOrEmpty(approverEmail))
            {
                SendEmailToApprover(approverEmail, approverFullName, GetQuotationDetails.QuotationID);
            }
            
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

        private void SendEmailToApprover(string approverEmail, string approverName, string quotationId)
        {
            string body = $"Hello {approverName}! \n\nA new quotation has been inserted to {PurchaseRequestIDNum.PurchaseReqID} and requires your approval. Please review the quotation at your earliest convenience.\n\nQuotation ID: {GetQuotationDetails.QuotationID}";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Quotation Notification [NOREPLY]", "procurementinventory27@gmail.com"));
            message.To.Add(new MailboxAddress("Approver", approverEmail));
            message.Subject = "New Quotation Inserted";
            message.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587); 
                client.Authenticate("procurementinventory27@gmail.com", "rckg lazd pzjh wkdi"); 
                client.Send(message);
                client.Disconnect(true);
            }
        }

        private void AddItemQtnBtnClick(object sender, EventArgs e)
        {
            string selectedItemId = itemName.SelectedValue.ToString();
            string selectedItemName = itemName.Text;

            NewQuotationItem = new ItemQuotation
            {
                ItemId = selectedItemId,
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

        private void SaveQuotationBtnClick(object sender, EventArgs e)
        {
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
    }

    public class ItemQuotation
    {
        public string ItemId { get; set; }
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
