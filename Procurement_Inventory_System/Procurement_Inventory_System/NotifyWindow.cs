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
    public partial class NotifyWindow : Form
    {
        public NotifyWindow()
        {
            InitializeComponent();
        }

        private void sendemailbtn_Click(object sender, EventArgs e)
        {
            //
            //verify user input...
            //

            //call this when verified
            NotifyPrompt form = new NotifyPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
