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
    public partial class AuditLogPage : UserControl
    {
        public AuditLogPage()
        {
            InitializeComponent();

            DataTable acc_table = new DataTable();

            acc_table.Columns.Add("EMPLOYEE ID", typeof(string));
            acc_table.Columns.Add("NAME", typeof(string));
            acc_table.Columns.Add("DEPARTMENT", typeof(string));
            acc_table.Columns.Add("ACCOUNT STATUS", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = acc_table;
        }

        private void AuditLogPage_Load(object sender, EventArgs e)
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            if (userRole == "11")
            {
                DataTable acc_table = new DataTable();
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string query1 = $@"SELECT 
                        Employee.emp_id AS [EMPLOYEE ID], 
                        Employee.emp_lname + ', ' + Employee.emp_fname AS [NAME], 
                        Department.department_name AS [DEPARTMENT], 
                        Section.section_name AS [SECTION], 
                        Account.account_status AS [ACCOUNT STATUS]
                      FROM Employee 
                      INNER JOIN Department ON Department.department_id = Employee.department_id 
                      INNER JOIN Account ON Account.emp_id = Employee.emp_id 
                      INNER JOIN Section ON EMPLOYEE.section_id = Section.section_id 
                      WHERE Employee.branch_id = '{CurrentUserDetails.BranchId}'";

                string query2 = @"SELECT 
                        Employee.emp_id AS [EMPLOYEE ID], 
                        Employee.emp_lname + ', ' + Employee.emp_fname AS [NAME], 
                        Department.department_name AS [DEPARTMENT], 
                        Section.section_name AS [SECTION], 
                        Account.account_status AS [ACCOUNT STATUS]
                      FROM Employee 
                      INNER JOIN Department ON Department.department_id = Employee.department_id 
                      INNER JOIN Account ON Account.emp_id = Employee.emp_id 
                      INNER JOIN Section ON EMPLOYEE.section_id = Section.section_id";
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
                PopulateSection();
            }
                
        }

        private void ViewLogsBtnClick(object sender, EventArgs e)
        {
            AuditLogWindow form = new AuditLogWindow();
            form.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["Employee ID"].Value.ToString();
                SelectedAuditEmployee.emp_id = val;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void SearchUserEnter(object sender, EventArgs e)
        {
            if (SearchUser.Text == "audit id, employee name")
            {
                SearchUser.Text = "";
                SearchUser.ForeColor = Color.Black;
            }
        }

        private void SearchUserLeave(object sender, EventArgs e)
        {
            if (SearchUser.Text == "")
            {
                SearchUser.Text = "audit id, employee name";
                SearchUser.ForeColor = Color.Silver;
            }
        }

        private void SelectAccStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        public void PopulateAccountStatus()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            var distinctValues = dt.AsEnumerable()
                                   .Select(row => row.Field<string>("Account Status"))
                                   .Distinct()
                                   .ToList();

            distinctValues.Insert(0, "(Account Status)"); // Add placeholder

            SelectAccStatus.DataSource = distinctValues;
            SelectAccStatus.SelectedIndex = 0; // Ensure no default selection
        }

        public void PopulateDepartment()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            var distinctValues = dt.AsEnumerable()
                                   .Select(row => row.Field<string>("Department"))
                                   .Distinct()
                                   .ToList();

            distinctValues.Insert(0, "(Department)"); // Add placeholder

            SelectDepartment.DataSource = distinctValues;
            SelectDepartment.SelectedIndex = 0; // Ensure no default selection
        }
        public void PopulateSection()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            var distinctValues = dt.AsEnumerable()
                                   .Select(row => row.Field<string>("Section"))
                                   .Distinct()
                                   .ToList();

            distinctValues.Insert(0, "(Section)"); // Add placeholder

            SelectSection.DataSource = distinctValues;
            SelectSection.SelectedIndex = 0; // Ensure no default selection
        }
        private void SearchUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%' OR [Employee ID] LIKE '%{0}%'", SearchUser.Text);
        }
        private void FilterData()
        {
            DataTable dt = (dataGridView1.DataSource as DataTable);

            if (dt != null)
            {
                string accountStatusFilter = SelectAccStatus.SelectedIndex > 0 ? SelectAccStatus.SelectedItem.ToString() : null;
                string departmentFilter = SelectDepartment.SelectedIndex > 0 ? SelectDepartment.SelectedItem.ToString() : null;
                string sectionFilter = SelectSection.SelectedIndex > 0 ? SelectSection.SelectedItem.ToString() : null;


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
                if (!string.IsNullOrEmpty(sectionFilter))
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"Section = '{sectionFilter}'");
                }

                dt.DefaultView.RowFilter = filter.ToString();
            }
        }
    }
    public static class SelectedAuditEmployee
    {
        public static string emp_id { get; set; }

    }
}
