using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procurement_Inventory_System
{
    public partial class SupplierQuotationPage : UserControl
    {
        public SupplierQuotationPage()
        {
            InitializeComponent();

            DataTable supplier_qtn_tbl = new DataTable();

            supplier_qtn_tbl.Columns.Add("QUOTATION ID", typeof(string));
            supplier_qtn_tbl.Columns.Add("SUPPLIER", typeof(string));
            supplier_qtn_tbl.Columns.Add("DATE ADDED", typeof(string));
            supplier_qtn_tbl.Columns.Add("VALIDITY", typeof(string));
            supplier_qtn_tbl.Columns.Add("VAT STATUS", typeof(string));
            //supply_rqst_tbl.Columns.Add("Details", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = supplier_qtn_tbl;
        }

        private void addquotationbtn_Click(object sender, EventArgs e)
        {
            SupplierQuotationWindow form = new SupplierQuotationWindow();
            form.ShowDialog();
        }
    }
}
