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
    public partial class ApproverWindow : Form
    {
        public ApproverWindow()
        {
            InitializeComponent();
        }

        private void profilebtn_Click(object sender, EventArgs e)
        {
            highlightSelection(profilebtn);

            profilePage1.LoadProfile();
            profilePage1.BringToFront();
        }

        private void reportsbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(reportsbtn);

            reportsPage1.BringToFront();
        }

        private void supplyrqstbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(supplyrqstbtn);

            supplyRequestPage1.DisplaySupplierReqTable();
            supplyRequestPage1.PopulateRequestor();
            supplyRequestPage1.BringToFront();
        }
        private void purchaserqstbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(purchaserqstbtn);

            purchaseRequestPage1.PopulateRequestTable();
            purchaseRequestPage1.BringToFront();
        }
        private void resetSelection()
        {
            profilebtn.BackColor = Color.Maroon;
            reportsbtn.BackColor = Color.Maroon;
            supplyrqstbtn.BackColor = Color.Maroon;
            purchaserqstbtn.BackColor = Color.Maroon;
        }
        private void highlightSelection(Button btn)
        {
            resetSelection();
            btn.BackColor = Color.Black;
        } 
    }
}
