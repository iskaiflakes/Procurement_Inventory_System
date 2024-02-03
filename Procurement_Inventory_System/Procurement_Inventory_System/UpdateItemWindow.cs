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
           AddItemPrompt form = new AddItemPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
