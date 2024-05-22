using System;
using System.Collections;
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
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            if (userRole == "11")
            {
                LoadAccounts();
            }
        }
        public void LoadAccounts()
        {
            DataTable acc_table = new DataTable();

            acc_table.Columns.Add("EMPLOYEE ID", typeof(string));
            acc_table.Columns.Add("NAME", typeof(string));
            acc_table.Columns.Add("DEPARTMENT", typeof(string));
            acc_table.Columns.Add("ACCOUNT STATUS", typeof(string));

            //add rows here from the database...
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query1 = $"SELECT Employee.emp_id AS [EMPLOYEE ID], Employee.emp_lname+', '+Employee.emp_fname as [NAME], DEPARTMENT.DEPARTMENT_NAME AS [DEPARTMENT], Account.account_status AS [ACC STATUS] from Employee \r\nINNER JOIN Department ON Department.DEPARTMENT_ID = Employee.department_id \r\nINNER JOIN Account ON Account.emp_id = Employee.emp_id WHERE Employee.branch_id = '{CurrentUserDetails.BranchId}'";
            string query2 = "SELECT Employee.emp_id AS [EMPLOYEE ID], Employee.emp_lname+', '+Employee.emp_fname as [NAME], DEPARTMENT.DEPARTMENT_NAME AS [DEPARTMENT], Account.account_status AS [ACC STATUS] from Employee \r\nINNER JOIN Department ON Department.DEPARTMENT_ID = Employee.department_id \r\nINNER JOIN Account ON Account.emp_id = Employee.emp_id";

            if (CurrentUserDetails.BranchId == "MOF")
            {
                SqlDataAdapter da = db.GetMultipleRecords(query2);
                da.Fill(acc_table);
            }
            else
            {
                SqlDataAdapter da = db.GetMultipleRecords(query1);
                da.Fill(acc_table);
            }

            dataGridView1.DataSource = acc_table;
            db.CloseConnection();
            PopulateAccountStatus();
            PopulateDepartment();


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
                AuditLog auditLog = new AuditLog();
                auditLog.LogEvent(CurrentUserDetails.UserID, "Employee", "View", SelectedEmployee.emp_id, "Viewed account details");
            }
        }

        private void searchUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%' OR [Employee ID] LIKE '%{0}%'", searchUser.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["Employee ID"].Value.ToString();
                SelectedEmployee.emp_id = val;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void selectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void selectDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        private void FilterData()
        {
            DataTable dt = (dataGridView1.DataSource as DataTable);

            if (dt != null)
            {
                string accountStatusFilter = selectStatus.SelectedIndex > 0 ? selectStatus.SelectedItem.ToString() : null;
                string departmentFilter = selectDepartment.SelectedIndex > 0 ? selectDepartment.SelectedItem.ToString() : null;


                StringBuilder filter = new StringBuilder();

                if (!string.IsNullOrEmpty(accountStatusFilter))
                {
                    filter.Append($"[Account Status] = '{accountStatusFilter}'");
                }

                if (!string.IsNullOrEmpty(departmentFilter))
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"Department = '{departmentFilter}'");
                }

                dt.DefaultView.RowFilter = filter.ToString();
            }
        }
        public void PopulateAccountStatus()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            var distinctValues = dt.AsEnumerable()
                                   .Select(row => row.Field<string>("Account Status"))
                                   .Distinct()
                                   .ToList();

            distinctValues.Insert(0, "(Account Status)"); // Add placeholder

            selectStatus.DataSource = distinctValues;
            selectStatus.SelectedIndex = 0; // Ensure no default selection
        }

        public void PopulateDepartment()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            var distinctValues = dt.AsEnumerable()
                                   .Select(row => row.Field<string>("Department"))
                                   .Distinct()
                                   .ToList();

            distinctValues.Insert(0, "(Department)"); // Add placeholder

            selectDepartment.DataSource = distinctValues;
            selectDepartment.SelectedIndex = 0; // Ensure no default selection
        }
    }
    public static class SelectedEmployee
    {
        public static string emp_id { get; set; }

    }
}
