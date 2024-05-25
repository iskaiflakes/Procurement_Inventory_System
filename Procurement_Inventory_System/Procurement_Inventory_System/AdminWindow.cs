using System;
using System.Drawing;
using System.Windows.Forms;

namespace Procurement_Inventory_System
{
    public partial class AdminWindow : Form
    {
        bool sidebarExpand;
        public AdminWindow()
        {
            InitializeComponent();

        }
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    profilePage1.Size = new Size(899, 700);
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    profilePage1.Size = new Size(759, 694);
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
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

            userManagementPage1.BringToFront();
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
        private void reportsbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            highlightSelection(reportsbtn);

            reportsPage1.BringToFront();
        }
        private void auditlogsbtn_Click(object sender, EventArgs e)
        {
            resetSelection();
            highlightSelection(auditlogsbtn);

            auditLogPage1.BringToFront();
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
            invoicebtn.BackColor = Color.Maroon;
            reportsbtn.BackColor = Color.Maroon;
            auditlogsbtn.BackColor = Color.Maroon;
        }
        private void highlightSelection(Button btn)
        {
            btn.BackColor = Color.Black;
        }
    }
}
