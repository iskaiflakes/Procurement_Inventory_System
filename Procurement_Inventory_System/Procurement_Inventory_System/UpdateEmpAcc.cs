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
    public partial class UpdateEmpAcc : Form
    {
        public UpdateEmpAcc()
        {
            InitializeComponent();
        }

        private void updateaccbtn_Click(object sender, EventArgs e)
        {
            //
            //verify user input...
            //

            //call this when verified
            UpdatePrompt form = new UpdatePrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editbtn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
