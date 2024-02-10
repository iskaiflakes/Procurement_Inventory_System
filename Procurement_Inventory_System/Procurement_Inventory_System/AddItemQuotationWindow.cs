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
    public partial class AddItemQuotationWindow : Form
    {
        public AddItemQuotationWindow()
        {
            InitializeComponent();

            DataTable item_qtn_tbl = new DataTable();

            item_qtn_tbl.Columns.Add("Item ID", typeof(string));
            item_qtn_tbl.Columns.Add("Name", typeof(string));
            item_qtn_tbl.Columns.Add("Quantity", typeof(string));
            item_qtn_tbl.Columns.Add("Unit Price", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = item_qtn_tbl;
        }

        private void additemqtnbtn_Click(object sender, EventArgs e)
        {

        }

        private void savequotationbtn_Click(object sender, EventArgs e)
        {
            SupplierQuotationPrompt form = new SupplierQuotationPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
