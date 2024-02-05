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
            DataTable acc_table = new DataTable();

            acc_table.Columns.Add("Employee ID",typeof(string));
            acc_table.Columns.Add("Name", typeof(string));
            acc_table.Columns.Add("Department", typeof(string));
            acc_table.Columns.Add("Account Status", typeof(string));
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
