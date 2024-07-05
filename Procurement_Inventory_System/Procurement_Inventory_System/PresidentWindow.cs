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
    public partial class PresidentWindow : Form
    {
        public PresidentWindow()
        {
            InitializeComponent();
        }

        private void profilebtn_Click(object sender, EventArgs e)
        {
            highlightSelection(profilebtn);

            profilePage2.LoadProfile();
            profilePage2.BringToFront();
        }

        private void purchaserqstbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(purchaserqstbtn);

            purchaseRequestPage1.PopulateRequestTable();
            purchaseRequestPage1.BringToFront();
        }

        private void reportsbtn_Click(object sender, EventArgs e)
        {
            highlightSelection(reportsbtn);

            reportsPage1.BringToFront();
        }
        private void resetSelection()
        {
            profilebtn.BackColor = Color.Maroon;
            purchaserqstbtn.BackColor = Color.Maroon;
            reportsbtn.BackColor = Color.Maroon;
        }
        private void highlightSelection(Button btn)
        {
            resetSelection();
            btn.BackColor = Color.Black;
        }

        private void PresidentWindow_Load(object sender, EventArgs e)
        {
            profilebtn.BackColor = Color.Black;
        }

        private void PresidentWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
