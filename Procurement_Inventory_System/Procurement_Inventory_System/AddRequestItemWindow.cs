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
    public partial class AddRequestItemWindow : Form
    {
        public AddRequestItemWindow()
        {
            InitializeComponent();
        }

        private void addnewitembtn_Click(object sender, EventArgs e)
        {
            //the table must be refreshed after pressing the button
            //to reflect the item record instance in the table
            this.Close();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
