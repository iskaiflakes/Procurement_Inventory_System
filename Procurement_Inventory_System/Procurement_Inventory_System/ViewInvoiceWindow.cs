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
    public partial class ViewInvoiceWindow : Form
    {
        public ViewInvoiceWindow()
        {
            InitializeComponent();

            DataTable invoice_item_tbl = new DataTable();

            invoice_item_tbl.Columns.Add("Item Name", typeof(string));
            invoice_item_tbl.Columns.Add("Description", typeof(string));
            invoice_item_tbl.Columns.Add("Quantity", typeof(string));
            invoice_item_tbl.Columns.Add("Unit Price", typeof(string));
            invoice_item_tbl.Columns.Add("Amount", typeof(string));

            //sample row
            //for (int i = 1; i <= 3; i++)
            //{
            //    DataRow row = invoice_item_tbl.NewRow();
            //    row["Item Name"] = "44324422";
            //    row["Description"] = "Steel Bars";
            //    row["Quantity"] = "4";
            //    row["Unit Price"] = "250.00";
            //    row["Amount"] = "1,0000.00";

            //    invoice_item_tbl.Rows.Add(row);
            //}

            //add rows here from the database...

            dataGridView1.DataSource = invoice_item_tbl;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {

        }

        private void ViewInvoiceWindow_Load(object sender, EventArgs e)
        {
            LoadSupplierDetails();
            LoadCompanyDetails();
            LoadSummaryInvoiceDetails();
            LoadBreakdownInvoiceDetails();
        }

        public void LoadSupplierDetails()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT Supplier.supplier_name, Supplier.city, Supplier.province, Supplier.zip_code FROM Invoice INNER JOIN Purchase_Order ON Invoice.purchase_order_id = Purchase_Order.purchase_order_id INNER JOIN Supplier ON Purchase_Order.supplier_id = Supplier.supplier_id WHERE Invoice.invoice_id = '{InvoiceID.InvID}'";

            SqlDataReader dr = db.GetRecord(query);
            if (dr.Read())
            {
                label8.Text = dr["supplier_name"].ToString();
                label2.Text = dr["city"].ToString();
                label3.Text = dr["province"].ToString();
                label4.Text = dr["zip_code"].ToString();
            }
            dr.Close();
            db.CloseConnection();
        }

        public void LoadCompanyDetails()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT BRANCH_NAME, CITY, PROVINCE, ZIP_CODE FROM BRANCH WHERE BRANCH_ID = '{CurrentUserDetails.BranchId}'";

            SqlDataReader dr = db.GetRecord(query);
            if (dr.Read())
            {
                label9.Text = dr["BRANCH_NAME"].ToString();
                label7.Text = dr["CITY"].ToString();
                label6.Text = dr["PROVINCE"].ToString();
                label5.Text = dr["ZIP_CODE"].ToString();
            }
            dr.Close();
            db.CloseConnection();

        }

        public void LoadSummaryInvoiceDetails()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT Invoice.invoice_id, Invoice.invoice_date, Invoice.payment_due_date, Invoice.total_amount, Invoice.vat_amount, (Invoice.total_amount +  Invoice.vat_amount) as amount FROM Invoice INNER JOIN Purchase_Order ON Invoice.purchase_order_id = Purchase_Order.purchase_order_id WHERE Invoice.invoice_id = '{InvoiceID.InvID}'";

            SqlDataReader dr = db.GetRecord(query);
            if (dr.Read())
            {
                label11.Text = dr["invoice_id"].ToString();

                DateTime invoiceDate = Convert.ToDateTime(dr["invoice_date"]);
                label14.Text = invoiceDate.ToShortDateString();

                DateTime paymentDueDate = Convert.ToDateTime(dr["payment_due_date"]);
                label16.Text = paymentDueDate.ToShortDateString();

                label18.Text = dr["amount"].ToString();
            }
            dr.Close();

            SqlDataReader dr1 = db.GetRecord(query);
            if (dr1.Read())
            {
                label20.Text = dr1["total_amount"].ToString();
                label24.Text = dr1["vat_amount"].ToString();
                label26.Text = dr1["amount"].ToString();
            }
            dr1.Close();
            db.CloseConnection();
        }

        public void LoadBreakdownInvoiceDetails()
        {
            DataTable invoice_details = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT Item_List.item_name as [Item Name], Purchase_Request_item.remarks as [Remarks], Purchase_Request_Item.item_quantity as [QTY], Item_Quotation.unit_price as [Unit Price], Purchase_Order_Item.total_price as [Total Price] FROM Item_Quotation INNER JOIN Item_List ON Item_List.item_id = Item_Quotation.item_id INNER JOIN Purchase_Request_Item ON Item_List.item_id = Purchase_Request_Item.item_id INNER JOIN Purchase_Order_Item ON Purchase_Order_Item.purchase_request_item_id = Purchase_Request_Item.purchase_request_item_id INNER JOIN Purchase_Order ON Purchase_Order.purchase_order_id = Purchase_Order_Item.purchase_order_id INNER JOIN Invoice ON Invoice.purchase_order_id = Purchase_Order.purchase_order_id WHERE Invoice.invoice_id = '{InvoiceID.InvID}'";

            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(invoice_details);
            dataGridView1.DataSource = invoice_details;
            db.CloseConnection();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void printinvoicebtn_Click(object sender, EventArgs e)
        {

        }
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.DisplayRectangle.Location;
        }
    }
}
