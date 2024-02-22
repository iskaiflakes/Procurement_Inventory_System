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
    public partial class InvoicePage : UserControl
    {
        public InvoicePage()
        {
            InitializeComponent();
        }

        private void addinvoicebtn_Click(object sender, EventArgs e)
        {
            AddInvoiceWindow form = new AddInvoiceWindow(this);
            form.ShowDialog();
        }

        private void viewinvoicebtn_Click(object sender, EventArgs e)
        {
            ViewInvoiceWindow form = new ViewInvoiceWindow();
            form.ShowDialog();
        }

        public void PopulateInvoiceTable()
        {
            DataTable purchase_request_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT Invoice.invoice_id as [INVOICE ID], Invoice.supplier_id as [SUPPLIER ID], Invoice.purchase_order_id as [PURCHASE ORDER ID], Invoice.total_amount as [TOTAL AMOUNT], Invoice.invoice_date [INVOICE DATE] FROM Invoice INNER JOIN Employee on Invoice.invoice_user_id = Employee.emp_id WHERE Employee.department_id = '{CurrentUserDetails.DepartmentId}' AND Employee.section = '{CurrentUserDetails.DepartmentSection}'";
            
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(purchase_request_table);
            dataGridView1.DataSource = purchase_request_table;
            db.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            MessageBox.Show(val);
            InvoiceID.InvID = val;
        }

        private void InvoicePage_Load(object sender, EventArgs e)
        {
            PopulateInvoiceTable();
        }
    }

    public static class InvoiceID
    {
        public static string InvID { get; set; }
    }
}
