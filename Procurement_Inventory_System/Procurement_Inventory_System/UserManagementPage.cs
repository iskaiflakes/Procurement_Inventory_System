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
        private const int PageSize = 15; // Number of records per page
        private int currentPage = 1;
        private DataTable acc_table;

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
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            if (userRole == "11")
            {
                acc_table = new DataTable();
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string query1 = $"SELECT Employee.emp_id AS [EMPLOYEE ID], Employee.emp_lname+', '+Employee.emp_fname as [NAME], DEPARTMENT.DEPARTMENT_NAME AS [DEPARTMENT], Section.section_name AS [SECTION], Account.account_status AS [ACCOUNT STATUS] from Employee \r\nINNER JOIN Department ON Department.DEPARTMENT_ID = Employee.department_id \r\nINNER JOIN Account ON Account.emp_id = Employee.emp_id INNER JOIN Section ON EMPLOYEE.section_id = Section.section_id  WHERE Employee.branch_id = '{CurrentUserDetails.BranchId}'";
                string query2 = "SELECT Employee.emp_id AS [EMPLOYEE ID], Employee.emp_lname+', '+Employee.emp_fname as [NAME], DEPARTMENT.DEPARTMENT_NAME AS [DEPARTMENT], Section.section_name AS [SECTION], Account.account_status AS [ACCOUNT STATUS] from Employee \r\nINNER JOIN Department ON Department.DEPARTMENT_ID = Employee.department_id \r\nINNER JOIN Account ON Account.emp_id = Employee.emp_id INNER JOIN Section ON EMPLOYEE.section_id = Section.section_id ";

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

                DisplayCurrentPage();
                db.CloseConnection();
                PopulateAccountStatus();
                PopulateDepartment();
                PopulateSection();
            }
        }
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, acc_table.Rows.Count - 1);

            DataTable pageTable = acc_table.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(acc_table.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage < (acc_table.Rows.Count + PageSize - 1) / PageSize)
            {
                currentPage++;
                DisplayCurrentPage();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }

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
                MessageBox.Show("Select an employee first.");
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
            FilterData();
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
                string accountStatusFilter = SelectAccStatus.SelectedIndex > 0 ? SelectAccStatus.SelectedItem.ToString() : null;
                string departmentFilter = SelectDepartment.SelectedIndex > 0 ? SelectDepartment.SelectedItem.ToString() : null;
                string sectionFilter = SelectSection.SelectedIndex > 0 ? SelectSection.SelectedItem.ToString() : null;
                string searchFilter = searchUser.Text != "name, employee id" && !string.IsNullOrEmpty(searchUser.Text) ? searchUser.Text : null;

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
                if (!string.IsNullOrEmpty(searchFilter))
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"(Name LIKE '%{searchFilter}%' OR [Employee ID] LIKE '%{searchFilter}%')");
                }

                dt.DefaultView.RowFilter = filter.ToString();
            }
        }
        public void PopulateAccountStatus()
        {
            List<string> accountStatuses = new List<string>
            {
                "(Account Status)", // No filter
                "ACTIVATED",
                "DEACTIVATED"
            };
            SelectAccStatus.DataSource = accountStatuses;
            SelectAccStatus.SelectedItem = "ACTIVATED"; // Set default selection to 'ACTIVATED'
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

        private void searchUser_Enter(object sender, EventArgs e)
        {
            if (searchUser.Text == "name, employee id")
            {
                searchUser.Text = "";
                searchUser.ForeColor = Color.Black;
            }
        }

        private void searchUser_Leave(object sender, EventArgs e)
        {
            if (searchUser.Text == "")
            {
                searchUser.Text = "name, employee id";
                searchUser.ForeColor = Color.Silver;
            }
        }

        private void SelectAccStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectDepartment_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void ClearFilters_Click(object sender, EventArgs e)
        {
            searchUser.Text = "";
            SelectAccStatus.SelectedIndex = 0;
            SelectDepartment.SelectedIndex = 0;
            SelectSection.SelectedIndex = 0;
            FilterData();
        }
    }
    public static class SelectedEmployee
    {
        public static string emp_id { get; set; }

    }
}
