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
    public partial class ViewInvoiceWindow : Form
    {
        public ViewInvoiceWindow()
        {
            InitializeComponent();

            DataTable invoice_item_tbl = new DataTable();

            invoice_item_tbl.Columns.Add("Item ID", typeof(string));
            invoice_item_tbl.Columns.Add("Description", typeof(string));
            invoice_item_tbl.Columns.Add("", typeof(string));
            invoice_item_tbl.Columns.Add("Quantity", typeof(string));
            invoice_item_tbl.Columns.Add("Price", typeof(string));
            invoice_item_tbl.Columns.Add("Amount", typeof(string));

            //sample row
            for (int i = 1; i <= 3; i++)
            {
                DataRow row = invoice_item_tbl.NewRow();
                row["Item ID"] = "44324422";
                row["Description"] = "Steel Bars";
                row["Quantity"] = "4";
                row["Price"] = "250.00";
                row["Amount"] = "1,0000.00";

                invoice_item_tbl.Rows.Add(row);
            }

            //add rows here from the database...

            dataGridView1.DataSource = invoice_item_tbl;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
