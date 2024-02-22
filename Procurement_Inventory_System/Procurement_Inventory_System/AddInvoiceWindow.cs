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

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addinvoicebtn_Click(object sender, EventArgs e)
        {
            StoreInvoiceDetails();
            RefreshRequestListTable();
        }

        private void AddInvoiceWindow_Load(object sender, EventArgs e)
        {
            InitializePurchaseOrderCB();
        }

        public void InitializePurchaseOrderCB()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"select distinct Purchase_Order.purchase_order_id from Purchase_Order inner join Purchase_Order_Item on Purchase_Order.purchase_order_id = Purchase_Order_Item.purchase_order_id inner join Purchase_Request_Item on Purchase_Request_Item.purchase_request_item_id = Purchase_Order_Item.purchase_request_item_id inner join Item_List on Item_List.item_id = Purchase_Request_Item.item_id where Item_List.department_id = '{CurrentUserDetails.DepartmentId}' AND Item_List.section = '{CurrentUserDetails.DepartmentSection}' and Purchase_Order.purchase_order_status = 'SHIPPED'";
            
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
            string amountQuery = $"SELECT SUM(total_price) + SUM(vat_amount) as total_amount, Purchase_Order.supplier_id FROM Purchase_Order INNER JOIN Purchase_Order_Item ON Purchase_Order.purchase_order_id = Purchase_Order_Item.purchase_order_id inner join Purchase_Request_Item on Purchase_Request_Item.purchase_request_item_id = Purchase_Order_Item.purchase_request_item_id inner join Item_List on Item_List.item_id = Purchase_Request_Item.item_id WHERE Purchase_Order.purchase_order_id = '{itemName.SelectedValue}' AND Item_List.department_id = '{CurrentUserDetails.DepartmentId}' AND Item_List.section = '{CurrentUserDetails.DepartmentSection}' GROUP BY Purchase_Order.supplier_id;";
            string supID = "";

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

            SqlDataReader dr1 = db.GetRecord(amountQuery);
            if (dr1.Read())
            {
                totalAmount = Convert.ToDouble(dr1["total_amount"]);
                supID = dr1["supplier_id"].ToString();
            }
            dr1.Close();

            string insertCmd = $"INSERT INTO Invoice (invoice_id, supplier_id, purchase_order_id, invoice_user_id, total_amount, invoice_date) VALUES ('{nextInvoiceId}', '{supID}', '{itemName.SelectedValue}', '{CurrentUserDetails.UserID}', '{totalAmount}', '{textBox1.Text}')";

            int returnRow = db.insDelUp(insertCmd);

            if (returnRow > 0)  // checks if the insertion was done successfully
            {
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
    }
}
