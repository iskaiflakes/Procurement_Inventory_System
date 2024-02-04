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
    public partial class UserManagementPage : UserControl
    {
        
        public UserManagementPage()
        {
            InitializeComponent();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            DataTable acc_table = new DataTable();

            acc_table.Columns.Add("Employe ID",typeof(string));
            acc_table.Columns.Add("Name", typeof(string));
            acc_table.Columns.Add("Department", typeof(string));
            acc_table.Columns.Add("Account Status", typeof(string));
            acc_table.Columns.Add("Details", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = acc_table;
        }

        private void SearchUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void createaccbtn_Click(object sender, EventArgs e)
        {
            CreateAccWindow form = new CreateAccWindow();
            form.Show();
        }

        private void editaccbtn_Click(object sender, EventArgs e)
        {
            UpdateAccWindow form = new UpdateAccWindow();
            form.Show();
        }
    }
}
