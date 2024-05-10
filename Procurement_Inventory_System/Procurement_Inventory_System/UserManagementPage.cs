using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }
        public void LoadAccounts()
        {
            DataTable acc_table = new DataTable();

            acc_table.Columns.Add("EMPLOYEE ID", typeof(string));
            acc_table.Columns.Add("NAME", typeof(string));
            acc_table.Columns.Add("DEPARTMENT", typeof(string));
            acc_table.Columns.Add("ACCOUNT STATUS", typeof(string));
            //acc_table.Columns.Add("Details", typeof(string));



            //add rows here from the database...
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "select Employee.emp_id as [Employee ID], emp_fname+' '+middle_initial+'. '+emp_lname as Name, DEPARTMENT_NAME as Department,\r\naccount_status as [Account Status] from Employee inner join Account on Account.emp_id = Employee.emp_id inner join DEPARTMENT on DEPARTMENT.DEPARTMENT_ID=Employee.department_id";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(acc_table);


            dataGridView1.DataSource = acc_table;
            db.CloseConnection();
        }

        private void createaccbtn_Click(object sender, EventArgs e)
        {
            CreateAccWindow form = new CreateAccWindow(this);
            form.Show();
        }

        private void editaccbtn_Click(object sender, EventArgs e)
        {
            if (SelectedEmployee.emp_id == null)
            {
                MessageBox.Show("Click employee id first.");
            }
            else
            {
                UpdateAccWindow form = new UpdateAccWindow(this);
                form.Show();
            }
        }

        private void searchUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", searchUser.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(SelectedEmployee.emp_id == null)
            {
                MessageBox.Show("Click employee id first.");
            }
            else
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["Employee ID"].Value.ToString();
                SelectedEmployee.emp_id = val;
            }
            
        }
    }
    public static class SelectedEmployee
    {
        public static string emp_id { get; set; }

    }
}
