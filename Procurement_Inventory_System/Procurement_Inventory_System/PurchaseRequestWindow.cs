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
    public partial class PurchaseRequestWindow : Form
    {
        public PurchaseRequestWindow()
        {
            InitializeComponent();
        }

        private void additemrqstbtn_Click(object sender, EventArgs e)
        {
            AddRequestItemWindow form = new AddRequestItemWindow();
            form.ShowDialog();
        }

        private void createnewrqstbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            RequestPrompt form = new RequestPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
