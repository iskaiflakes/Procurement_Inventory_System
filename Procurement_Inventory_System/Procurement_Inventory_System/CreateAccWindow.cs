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
    public partial class CreateAccWindow : Form
    {
        public CreateAccWindow()
        {
            InitializeComponent();
        }

        private void createaccbtn_Click(object sender, EventArgs e)
        {
            //
            //verify user input...
            //

            //the table must be refreshed after pressing the button
            //to reflect the account record instance in the table

            //call this when verified
            CreateAccPrompt form = new CreateAccPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
