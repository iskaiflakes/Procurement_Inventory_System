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
    public partial class ProfilePage : UserControl
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void editprofilebtn_Click(object sender, EventArgs e)
        {
            fname.Enabled = true;
            middleName.Enabled = true;
            lname.Enabled = true;
            suffix.Enabled = true;
            emailAdd.Enabled = true;
            contactNum.Enabled = true;
            address.Enabled = true;
            brgy.Enabled = true;
            city.Enabled = true;
            province.Enabled = true;
            zipCode.Enabled = true;

            bottomcontrols.Visible = true;
        }

        private void saveprofilebtn_Click(object sender, EventArgs e)
        {
            //validate input fields...

            fname.Enabled = false;
            middleName.Enabled = false;
            lname.Enabled = false;
            suffix.Enabled = false;
            emailAdd.Enabled = false;
            contactNum.Enabled = false;
            address.Enabled = false;
            brgy.Enabled = false;
            city.Enabled = false;
            province.Enabled = false;
            zipCode.Enabled = false;

            bottomcontrols.Visible = false;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            fname.Enabled = false;
            middleName.Enabled = false;
            lname.Enabled = false;
            suffix.Enabled = false;
            emailAdd.Enabled = false;
            contactNum.Enabled = false;
            address.Enabled = false;
            brgy.Enabled = false;
            city.Enabled = false;
            province.Enabled = false;
            zipCode.Enabled = false;

            bottomcontrols.Visible = false;
        }
    }
}
