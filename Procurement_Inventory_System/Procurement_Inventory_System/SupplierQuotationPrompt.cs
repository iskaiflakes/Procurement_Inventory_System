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
    public partial class SupplierQuotationPrompt : Form
    {
        public SupplierQuotationPrompt()
        {
            InitializeComponent();
        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            //the table must be refreshed after pressing the button
            this.Close();
        }
    }
}
