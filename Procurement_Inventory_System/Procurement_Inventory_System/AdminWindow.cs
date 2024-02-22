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
            resetSelection();
            adminLandingPage1.BringToFront();
        }

        private void profile_tab(object sender, EventArgs e)
        {
            //sidebarTimer.Start();

            resetSelection();
            highlightSelection(profilebtn);

            profilePage1.BringToFront();
        }

        private void users_tab(object sender, EventArgs e)
        {
            //sidebarTimer.Start();

            resetSelection();
            highlightSelection(usermngmtbtn);

            userManagement1.BringToFront();
        }

        private void inventory_tab(object sender, EventArgs e)
        {
            //sidebarTimer.Start();

            resetSelection();
            highlightSelection(inventorybtn);

            inventoryPage1.BringToFront();
        }

        private void supplyrqstbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            highlightSelection(supplyrqstbtn);

            supplyRequestPage1.BringToFront();
        }

        private void itemlistbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            highlightSelection(itemlistbtn);

            itemListPage1.BringToFront();
        }

        private void supplyqtnbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            highlightSelection(supplyqtnbtn);

            supplierQuotationPage1.BringToFront();
            supplierQuotationPage1.LoadQuotationData();
        }

        private void purchaserqstbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            highlightSelection(purchaserqstbtn);

            purchaseRequestPage1.BringToFront();
        }

        private void purchaseordrbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            highlightSelection(purchaseordrbtn);

            purchaseOrderPage1.BringToFront();
        }

        private void invoicebtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            highlightSelection(invoicebtn);

            invoicePage1.BringToFront();
        }        
        private void transactionbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            highlightSelection(transactionbtn);

            transactionPage1.BringToFront();
        }
        private void reportsbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            highlightSelection(reportsbtn);

            reportsPage1.BringToFront();
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
        private void highlightSelection(Button btn)
        {
            btn.BackColor = Color.Black;
        }
    }
}
