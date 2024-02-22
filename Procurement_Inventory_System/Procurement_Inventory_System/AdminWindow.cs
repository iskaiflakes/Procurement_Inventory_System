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

            resetSelection();
            profilebtn.BackColor = Color.Black;

            profilePage1.BringToFront();
        }

        private void users_tab(object sender, EventArgs e)
        {
            //sidebarTimer.Start();

            resetSelection();
            usermngmtbtn.BackColor = Color.Black;

            userManagement1.BringToFront();
        }

        private void inventory_tab(object sender, EventArgs e)
        {
            //sidebarTimer.Start();

            resetSelection();
            inventorybtn.BackColor = Color.Black;

            inventoryPage1.BringToFront();
        }

        private void supplyrqstbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            supplyrqstbtn.BackColor = Color.Black;

            supplyRequestPage1.BringToFront();
        }

        private void itemlistbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            itemlistbtn.BackColor = Color.Black;

            itemListPage1.BringToFront();
        }

        private void supplyqtnbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            supplyqtnbtn.BackColor = Color.Black;

            supplierQuotationPage1.BringToFront();
            supplierQuotationPage1.LoadQuotationData();
        }

        private void purchaserqstbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            purchaserqstbtn.BackColor = Color.Black;

            purchaseRequestPage1.BringToFront();
        }

        private void purchaseordrbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            purchaseordrbtn.BackColor = Color.Black;

            purchaseOrderPage1.BringToFront();
        }

        private void invoicebtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            invoicebtn.BackColor = Color.Black;

            invoicePage1.BringToFront();
        }
        private void resetSelection()
        {
            profilebtn.BackColor = Color.Maroon;
            usermngmtbtn.BackColor = Color.Maroon;
            itemlistbtn.BackColor = Color.Maroon;
            inventorybtn.BackColor = Color.Maroon;
            supplyqtnbtn.BackColor = Color.Maroon;
            supplyrqstbtn.BackColor = Color.Maroon;
            purchaserqstbtn.BackColor = Color.Maroon;
            purchaseordrbtn.BackColor = Color.Maroon;
            msrifbtn.BackColor = Color.Maroon;
            invoicebtn.BackColor = Color.Maroon;
            transactionbtn.BackColor = Color.Maroon;
            reportsbtn.BackColor = Color.Maroon;
        }
    }
}
