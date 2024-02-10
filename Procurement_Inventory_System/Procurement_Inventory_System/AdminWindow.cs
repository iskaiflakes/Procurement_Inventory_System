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
    public partial class AdminWindow : Form
    {
        //bool sidebarExpand;
        public AdminWindow()
        {
            InitializeComponent();

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            adminLandingPage1.BringToFront();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            /**
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if(sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
            */
        }

        private void profile_tab(object sender, EventArgs e)
        {
            //sidebarTimer.Start();

            profilePage1.BringToFront();
        }

        private void users_tab(object sender, EventArgs e)
        {
            //sidebarTimer.Start();

            userManagement1.BringToFront();
        }

        private void inventory_tab(object sender, EventArgs e)
        {
            //sidebarTimer.Start();

            inventoryPage1.BringToFront();
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void supplyrqstbtn_Click(object sender, EventArgs e)
        {
            supplyRequestPage1.BringToFront();
        }

        private void itemlistbtn_Click(object sender, EventArgs e)
        {
            itemListPage1.BringToFront();
        }

        private void adminDashboard1_Load(object sender, EventArgs e)
        {

        }

        private void supplyqtnbtn_Click(object sender, EventArgs e)
        {
            supplierQuotationPage1.BringToFront();
        }

        private void purchaserqstbtn_Click(object sender, EventArgs e)
        {
            purchaseRequestPage1.BringToFront();
        }
    }
}
