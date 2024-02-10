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
    public partial class RequestorWindow : Form
    {
        public RequestorWindow()
        {
            InitializeComponent();
        }
        private void profile_tab(object sender, EventArgs e)
        {
            //sidebarTimer.Start();

            profilePage1.BringToFront();
        }

        private void inventorybtn_Click(object sender, EventArgs e)
        {
            inventoryPage1.BringToFront();

        }

        private void supplyrqstbtn_Click(object sender, EventArgs e)
        {
            supplyRequestPage1.BringToFront();
        }

        private void supplyqtnbtn_Click(object sender, EventArgs e)
        {
            supplierQuotationPage1.BringToFront();
        }

        private void purchaserqstbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
