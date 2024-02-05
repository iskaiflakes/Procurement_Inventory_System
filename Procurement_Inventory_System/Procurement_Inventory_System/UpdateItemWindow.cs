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
    public partial class UpdateItemWindow : Form
    {
        public UpdateItemWindow()
        {
            InitializeComponent();
        }

        private void editbtn_CheckedChanged(object sender, EventArgs e)
        {
            //Current all fields are disable
            //add code here to enable all fields for editing...
        }

        private void addnewitembtn_Click(object sender, EventArgs e)
        {
            //the table must be refreshed after pressing the button
            //to reflect the updated supply record instance in the table

            AddNewItemPrompt form = new AddNewItemPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateitembtn_Click(object sender, EventArgs e)
        {
            UpdateItemPrompt form = new UpdateItemPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
