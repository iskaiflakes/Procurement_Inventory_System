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
        private const int PageSize = 20; // Number of records per page
        private int currentPage = 1;
        private DataTable acc_table;

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
                LoadAuditLogs();
            }
                
        }

        public void LoadAuditLogs()
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            if (userRole == "11")
            {
                acc_table = new DataTable();
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
            if (acc_table != null)
            {
                if (currentPage < (acc_table.Rows.Count + PageSize - 1) / PageSize)
                {
                    currentPage++;
                    DisplayCurrentPage();
                }
            }
            else
            {
                MessageBox.Show("No data to show.");
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
        private void ViewLogsBtnClick(object sender, EventArgs e)
        {
            if (SelectedAuditEmployee.emp_id != null)
            {
                AuditLogWindow form = new AuditLogWindow();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select an employee first.");
            }
            
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
        private void SearchUser_TextChanged(object sender, EventArgs e)
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
                string searchFilter = !string.IsNullOrEmpty(SearchUser.Text) && SearchUser.Text != "audit id, employee name" ? SearchUser.Text : null;

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

        private void ClearFilters_Click(object sender, EventArgs e)
        {
            SelectAccStatus.SelectedIndex = 0;
            SelectDepartment.SelectedIndex = 0;
            SelectSection.SelectedIndex = 0;
            SearchUser.Text = "audit id, employee name";
            SearchUser.ForeColor = Color.Silver;
            this.ActiveControl = ClearFilters;
            FilterData();
        }
    }
    public static class SelectedAuditEmployee
    {
        public static string emp_id { get; set; }

    }
}
