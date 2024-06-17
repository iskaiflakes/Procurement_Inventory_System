using System;
using System.Drawing;
using System.Windows.Forms;

namespace Procurement_Inventory_System
{
    public partial class AdminWindow : Form
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            resetSelection();
            adminLandingPage1.BringToFront();
        }

        private void profile_tab(object sender, EventArgs e)
        {
            highlightSelection(profilebtn);

            profilePage2.LoadProfile();
            profilePage2.BringToFront();
        }

        private void users_tab(object sender, EventArgs e)
        {
            highlightSelection(usermngmtbtn);

            userManagementPage1.LoadAccounts();
            userManagementPage1.BringToFront();
        }

        private void inventory_tab(object sender, EventArgs e)
        {
            highlightSelection(inventorybtn);

            inventoryPage1.LoadInventoryList();
            inventoryPage1.BringToFront();
        }

        private void supplyrqstbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(supplyrqstbtn);

            supplyRequestPage1.DisplaySupplierReqTable();
            supplyRequestPage1.PopulateRequestor();
            supplyRequestPage1.BringToFront();
        }

        private void itemlistbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(itemlistbtn);

            itemListPage1.LoadItemList();
            itemListPage1.BringToFront();
        }

        private void supplyqtnbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(supplyqtnbtn);

            supplierQuotationPage1.LoadQuotationData();
            supplierQuotationPage1.BringToFront();
        }

        private void purchaserqstbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(purchaserqstbtn);

            purchaseRequestPage1.PopulateRequestTable();
            purchaseRequestPage1.BringToFront();
        }

        private void purchaseordrbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(purchaseordrbtn);

            purchaseOrderPage1.PopulatePurchaseOrder();
            purchaseOrderPage1.BringToFront();
        }

        private void invoicebtn_Click(object sender, EventArgs e)
        {
            highlightSelection(invoicebtn);

            invoicePage1.PopulateInvoiceTable();
            invoicePage1.BringToFront();
        }
        private void reportsbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(reportsbtn);

            reportsPage1.BringToFront();
        }
        private void auditlogsbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(auditlogsbtn);

            auditLogPage1.LoadAuditLogs();
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
            resetSelection();
            btn.BackColor = Color.Black;
        }

        private void AdminWindow_Load(object sender, EventArgs e)
        {
            profilebtn.BackColor= Color.Black;
        }
    }
}
