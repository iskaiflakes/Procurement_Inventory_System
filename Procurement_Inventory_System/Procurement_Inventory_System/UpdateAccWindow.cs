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
    public partial class UpdateAccWindow : Form
    {
        public UpdateAccWindow()
        {
            InitializeComponent();
        }

        private void updateaccbtn_Click(object sender, EventArgs e)
        {
            //
            //verify user input...
            //

            //the table must be refreshed after pressing the button
            //to reflect the updated account record instance in the table

            //call this when verified
            UpdateAccPrompt form = new UpdateAccPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editbtn_CheckedChanged(object sender, EventArgs e)
        {
            //Current all fields are disable
            //add code here to enable all fields for editing...
        }

        private void UpdateAccWindow_Load(object sender, EventArgs e)
        {

        }
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.DisplayRectangle.Location;
        }
    }
}
