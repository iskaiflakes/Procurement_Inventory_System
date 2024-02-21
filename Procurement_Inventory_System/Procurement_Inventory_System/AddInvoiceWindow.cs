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
    public partial class AddInvoiceWindow : Form
    {
        public AddInvoiceWindow()
        {
            InitializeComponent();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addinvoicebtn_Click(object sender, EventArgs e)
        {
            AddInvoiceWindow form = new AddInvoiceWindow();
            form.ShowDialog();
        }
    }
}
