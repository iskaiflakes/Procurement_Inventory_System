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
            if(InvoiceID.InvID != null)
            {
                ViewInvoiceWindow form = new ViewInvoiceWindow();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select Invoice ID first.");
            }
                
        }

        public void PopulateInvoiceTable()
        {
            DataTable invoice_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT Invoice.invoice_id as [INVOICE ID], Invoice.supplier_id as [SUPPLIER], Invoice.purchase_order_id as [PURCHASE ORDER ID], Invoice.total_amount as [SUB TOTAL], Invoice.vat_amount as [VAT AMOUNT], Invoice.invoice_date [INVOICE DATE] FROM Invoice INNER JOIN Employee on Invoice.invoice_user_id = Employee.emp_id WHERE Employee.department_id = '{CurrentUserDetails.DepartmentId}' AND Employee.section_id = '{CurrentUserDetails.DepartmentSection}'";
            
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(invoice_table);
            dataGridView1.DataSource = invoice_table;
            db.CloseConnection();
            invoice_table.Columns.Add("DATE_ONLY", typeof(DateTime));
            foreach (DataRow row in invoice_table.Rows)
            {
                row["DATE_ONLY"] = ((DateTime)row["INVOICE DATE"]).Date;
            } //kasi pag may time di nafifilter pero di naman visible ito
            dataGridView1.Columns["DATE_ONLY"].Visible = false;
            PopulateSupplier();
            SelectDate.Value = SelectDate.MinDate;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["INVOICE ID"].Value.ToString();
                InvoiceID.InvID = val;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void InvoicePage_Load(object sender, EventArgs e)
        {
            PopulateInvoiceTable();
        }

        private void searchUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("([Invoice ID] LIKE '%{0}%' OR [Supplier ID] LIKE '%{0}%' OR [Purchase Order ID] LIKE '%{0}%')", searchUser.Text);
        }

        private void SelectSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectDate_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        public void PopulateSupplier()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            var distinctValues = dt.AsEnumerable()
                                   .Select(row => row.Field<string>("SUPPLIER"))
                                   .Distinct()
                                   .ToList();

            distinctValues.Insert(0, "(Supplier)"); // Add placeholder

            SelectSupplier.DataSource = distinctValues;
            SelectSupplier.SelectedIndex = 0; // Ensure no default selection
        }
        private void FilterData()
        {
            DataTable dt = (dataGridView1.DataSource as DataTable);

            if (dt != null)
            {
                string supplierFilter = SelectSupplier.SelectedIndex > 0 ? SelectSupplier.SelectedItem.ToString() : null;

                StringBuilder filter = new StringBuilder();

                if (!string.IsNullOrEmpty(supplierFilter))
                {
                    filter.Append($"[SUPPLIER] = '{supplierFilter}'");
                }
                if (SelectDate.Value != SelectDate.MinDate)
                {
                    DateTime selectedDate = SelectDate.Value.Date;
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"[DATE_ONLY] = #{selectedDate.ToString("MM/dd/yyyy")}#");
                }


                dt.DefaultView.RowFilter = filter.ToString();
            }
        }

        private void searchUser_Enter(object sender, EventArgs e)
        {
            if (searchUser.Text == "invoice id, supplier id, purchase id")
            {
                searchUser.Text = "";
                searchUser.ForeColor = Color.Black;
            }
        }

        private void searchUser_Leave(object sender, EventArgs e)
        {
            if (searchUser.Text == "")
            {
                searchUser.Text = "invoice id, supplier id, purchase id";
                searchUser.ForeColor = Color.Silver;
            }
        }
    }

    public static class InvoiceID
    {
        public static string InvID { get; set; }
    }
}
