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
    public partial class CustodianWindow : Form
    {
        public CustodianWindow()
        {
            InitializeComponent();
        }

        private void profilebtn_Click(object sender, EventArgs e)
        {
            highlightSelection(profilebtn);

            profilePage1.LoadProfile();
            profilePage1.BringToFront();
        }

        private void itemlistbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(itemlistbtn);

            itemListPage1.LoadItemList();
            itemListPage1.BringToFront();
        }

        private void inventorybtn_Click(object sender, EventArgs e)
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

        private void purchaseordrbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(purchaseordrbtn);

            purchaseOrderPage1.PopulatePurchaseOrder();
            purchaseOrderPage1.BringToFront();
        }
        private void resetSelection()
        {
            profilebtn.BackColor = Color.Maroon;
            itemlistbtn.BackColor = Color.Maroon;
            inventorybtn.BackColor = Color.Maroon;
            supplyrqstbtn.BackColor = Color.Maroon;
            purchaseordrbtn.BackColor = Color.Maroon;
        }
        private void highlightSelection(Button btn)
        {
            resetSelection();
            btn.BackColor = Color.Black;
        }
    }
}
