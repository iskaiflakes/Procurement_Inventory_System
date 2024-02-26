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
    public partial class UpdatePurchaseOrderWindow : Form
    {
        public UpdatePurchaseOrderWindow()
        {
            InitializeComponent();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updatepostatusbtn_Click(object sender, EventArgs e)
        {

            //display this once done
            UpdatePurchaseOrderWindow form = new UpdatePurchaseOrderWindow();
            form.ShowDialog();
        }
    }
}
