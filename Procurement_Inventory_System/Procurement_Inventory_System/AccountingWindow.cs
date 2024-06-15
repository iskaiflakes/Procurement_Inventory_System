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
    public partial class AccountingWindow : Form
    {
        public AccountingWindow()
        {
            InitializeComponent();
        }

        private void profilebtn_Click(object sender, EventArgs e)
        {
            highlightSelection(profilebtn);

            profilePage1.LoadProfile();
            profilePage1.BringToFront();
        }
        private void invoicebtn_Click(object sender, EventArgs e)
        {
            highlightSelection(invoicebtn);

            invoicePage1.PopulateInvoiceTable();
            invoicePage1.BringToFront();
        }
        private void resetSelection()
        {
            profilebtn.BackColor = Color.Maroon;
            invoicebtn.BackColor = Color.Maroon;
        }
        private void highlightSelection(Button btn)
        {
            resetSelection();
            btn.BackColor = Color.Black;
        }   
    }
}
