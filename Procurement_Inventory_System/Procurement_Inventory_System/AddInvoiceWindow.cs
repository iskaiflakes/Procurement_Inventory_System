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

namespace Procurement_Inventory_System
{
    public partial class AddInvoiceWindow : Form
    {
        private InvoicePage invoicePage;
        public AddInvoiceWindow(InvoicePage invoicePage)
        {
            InitializeComponent();
            this.invoicePage = invoicePage;
        }

        public void InitializePurchaseOrderCB()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            if (((CurrentUserDetails.BranchId == "MOF") && (userRole == "11")) || ((CurrentUserDetails.BranchId == "MOF") && (userRole == "16")))   // if the user is an admin and accountant and is from MOF, all Fulfilled PO options are loaded
            {
                query = "select distinct Purchase_Order.purchase_order_id from Purchase_Order \r\ninner join Purchase_Order_Item on Purchase_Order.purchase_order_id = Purchase_Order_Item.purchase_order_id \r\ninner join Purchase_Request_Item on Purchase_Request_Item.purchase_request_item_id = Purchase_Order_Item.purchase_request_item_id \r\ninner join Item_List on Item_List.item_id = Purchase_Request_Item.item_id\r\nWHERE Purchase_Order.purchase_order_status = 'FULFILLED' \r\nAND NOT EXISTS(SELECT Purchase_Order.purchase_order_id FROM Invoice WHERE Purchase_Order.purchase_order_id = Invoice.purchase_order_id)";
            }
            else 
            {
                if (userRole == "11")   // if the user is an admin, Fulfilled PO options are loaded within your branch only
                {
                    query = $"select distinct Purchase_Order.purchase_order_id from Purchase_Order \r\ninner join Purchase_Order_Item on Purchase_Order.purchase_order_id = Purchase_Order_Item.purchase_order_id \r\ninner join Purchase_Request_Item on Purchase_Request_Item.purchase_request_item_id = Purchase_Order_Item.purchase_request_item_id \r\ninner join Item_List on Item_List.item_id = Purchase_Request_Item.item_id\r\ninner join DEPARTMENT ON DEPARTMENT.DEPARTMENT_ID = Item_List.department_id\r\nWHERE Purchase_Order.purchase_order_status = 'FULFILLED' \r\nAND NOT EXISTS(SELECT Purchase_Order.purchase_order_id FROM Invoice WHERE Purchase_Order.purchase_order_id = Invoice.purchase_order_id)\r\nAND DEPARTMENT.BRANCH_ID = '{CurrentUserDetails.BranchId}'";
                }
            }
            
            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);

            itemName.DataSource = null;
            itemName.DataSource = dt;
            itemName.DisplayMember = "purchase_order_id";
            itemName.ValueMember = "purchase_order_id";

            itemName.SelectedItem = null;

            db.CloseConnection();
        }

        public void StoreInvoiceDetails()
        {
            // variable for total_amount
            double totalAmount = 0;
            double vatAmount = 0;

            // query for determining the vat status of the supplier
            string vatStatus = $"SELECT Q.vat_status FROM Purchase_Request_Item PRI\r\nINNER JOIN Purchase_Order_Item POI ON PRI.purchase_request_item_id=POI.purchase_request_item_id\r\nINNER JOIN Quotation Q ON Q.quotation_id=PRI.quotation_id\r\nWHERE POI.purchase_order_id = '{itemName.SelectedValue}'\r\nGROUP BY Q.vat_status";
            string supID = "", supVatStatus = "", amountQuery = "";

            // variables used for ID formattiing
            string idPrefix = "INV-" + DateTime.Now.ToString("yyyyMMdd");
            string lastIdQuery = $"SELECT TOP 1 invoice_id FROM Invoice WHERE invoice_id LIKE '{idPrefix}-%' ORDER BY invoice_id DESC";
            string nextInvoiceId = $"{idPrefix}-001"; // Default if no items found for today (this will be used when no record inside the table yet)

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlDataReader dr = db.GetRecord(lastIdQuery);
            if (dr.Read())  // checks if there is a record inside the table
            {
                string lastId = dr["invoice_id"].ToString();
                int lastNumber = int.Parse(lastId.Split('-')[2]);
                nextInvoiceId = $"{idPrefix}-{(lastNumber + 1):D3}";
            }
            dr.Close();

            // gets the vat status of the supplier
            SqlDataReader dr1 = db.GetRecord(vatStatus);
            if (dr1.Read())
            {
                supVatStatus = dr1["vat_status"].ToString();
            }
            dr1.Close();

            // conditional statement for vat status
            if (supVatStatus == "VAT INCLUDED") // if VAT INCLUDED, then there is no VAT that the company will be paying
            {
                amountQuery = $"SELECT SUM(total_price) as total_amount, (SUM(total_price) * 0) as vat_amount, Purchase_Order.supplier_id \r\nFROM Purchase_Order INNER JOIN Purchase_Order_Item ON Purchase_Order.purchase_order_id = Purchase_Order_Item.purchase_order_id \r\ninner join Purchase_Request_Item on Purchase_Request_Item.purchase_request_item_id = Purchase_Order_Item.purchase_request_item_id \r\ninner join Item_List on Item_List.item_id = Purchase_Request_Item.item_id\r\nWHERE Purchase_Order.purchase_order_id = '{itemName.SelectedValue}' AND Purchase_Order_Item.order_item_status = 'DELIVERED' \r\nGROUP BY Purchase_Order.supplier_id";
            }
            else if (supVatStatus == "VAT EXCLUDED")    // if VAT INCLUDED, then there is VAT that the company will be paying
            {
                amountQuery = $"SELECT SUM(total_price) as total_amount, (SUM(total_price) * 0.12) as vat_amount, Purchase_Order.supplier_id \r\nFROM Purchase_Order INNER JOIN Purchase_Order_Item ON Purchase_Order.purchase_order_id = Purchase_Order_Item.purchase_order_id \r\ninner join Purchase_Request_Item on Purchase_Request_Item.purchase_request_item_id = Purchase_Order_Item.purchase_request_item_id \r\ninner join Item_List on Item_List.item_id = Purchase_Request_Item.item_id\r\nWHERE Purchase_Order.purchase_order_id = '{itemName.SelectedValue}' AND Purchase_Order_Item.order_item_status = 'DELIVERED' \r\nGROUP BY Purchase_Order.supplier_id";
            }

            // getting the computed total amount, vat amount and the supplier id
            SqlDataReader dr2 = db.GetRecord(amountQuery);
            if (dr2.Read())
            {
                totalAmount = Convert.ToDouble(dr2["total_amount"]);
                vatAmount = Convert.ToDouble(dr2["vat_amount"]);
                supID = dr2["supplier_id"].ToString();
            }
            dr2.Close();

            string query = $"SELECT Supplier_Term.supplier_term_id FROM Purchase_Order INNER JOIN Supplier  ON Purchase_Order.supplier_id = Supplier.supplier_id INNER JOIN Supplier_Term ON Supplier.supplier_term_id = Supplier_Term.supplier_term_id WHERE Purchase_Order.purchase_order_id = '{itemName.SelectedValue}'";
            string supTerm = "";

            // getting the supplier term
            SqlDataReader dr3 = db.GetRecord(query);
            if (dr3.Read())
            {
                supTerm = dr3["supplier_term_id"].ToString();
            }
            dr3.Close();

            DateTime invDate, dueDate;

            if ((supTerm == "COD") || (supTerm == "DPY"))
            {
                invDate = DateTime.Today;
                dueDate = invDate;
            }
            else if(supTerm == "30D")
            {
                invDate = DateTime.Today;
                dueDate = DateTime.Today.AddDays(30);
            }
            else
            {
                invDate = DateTime.Today;
                dueDate = DateTime.Today.AddDays(45);
            }


            string insertCmd = "INSERT INTO Invoice (invoice_id, supplier_id, purchase_order_id, invoice_user_id, total_amount, invoice_date, vat_amount, payment_due_date) " +
                   "VALUES (@nextInvoiceId, @supID, @purchaseOrderId, @userId, @totalAmount, @invDate, @vatAmount, @dueDate)";

            SqlCommand cmd = new SqlCommand(insertCmd, db.GetSqlConnection());

            // Add parameters to the command
            cmd.Parameters.AddWithValue("@nextInvoiceId", nextInvoiceId);
            cmd.Parameters.AddWithValue("@supID", supID);
            cmd.Parameters.AddWithValue("@purchaseOrderId", itemName.SelectedValue);
            cmd.Parameters.AddWithValue("@userId", CurrentUserDetails.UserID);
            cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
            cmd.Parameters.AddWithValue("@invDate", invDate);
            cmd.Parameters.AddWithValue("@vatAmount", vatAmount);
            cmd.Parameters.AddWithValue("@dueDate", dueDate);

            int returnRow = cmd.ExecuteNonQuery();


            if (returnRow > 0)  // checks if the insertion was done successfully
            {
                AuditLog auditLog = new AuditLog();
                auditLog.LogEvent(CurrentUserDetails.UserID, "Invoice", "Insert", nextInvoiceId, $"Added invoice");
                db.CloseConnection();   // closes the db connection to prevent the app from crashing
            }
        }

        public void RefreshRequestListTable()
        {
            if (invoicePage != null)
            {
                invoicePage.PopulateInvoiceTable();
            }
        }

        private void AddInvoiceWindowLoad(object sender, EventArgs e)
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            // will only load if the users are either admin or purchasing department
            if ((userRole == "11") || (userRole == "16"))
            {
                InitializePurchaseOrderCB();
            }
                
        }

        private void AddInvoiceBtnClick(object sender, EventArgs e)
        {
            StoreInvoiceDetails();
            RefreshRequestListTable();

            AddInvoicePrompt form = new AddInvoicePrompt();
            form.ShowDialog();

            this.Close();
        }

        private void CancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
