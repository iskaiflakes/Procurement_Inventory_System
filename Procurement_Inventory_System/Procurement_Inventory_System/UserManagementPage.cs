using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "select Employee.emp_id as [Employee ID], emp_fname+' '+middle_initial+'. '+emp_lname as Name, DEPARTMENT_NAME as Department,\r\naccount_status as [Account Status] from Employee inner join Account on Account.emp_id = Employee.emp_id inner join DEPARTMENT on DEPARTMENT.DEPARTMENT_ID=Employee.department_id";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(acc_table);


            dataGridView1.DataSource = acc_table;
            db.CloseConnection();
            PopulateAccountStatus();
            PopulateDepartment();
            
        }

        private void CreateAccBtn_Click(object sender, EventArgs e)
        {
            CreateAccWindow form = new CreateAccWindow(this);
            form.Show();
        }

        private void EditAccBtn_Click(object sender, EventArgs e)
        {
            if (SelectedEmployee.Emp_id == null)
            {
                MessageBox.Show("Click employee id first.");
            }
            else
            {
                UpdateAccWindow form = new UpdateAccWindow(this);
                form.Show();
            }
        }

        private void SearchUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%' OR [Employee ID] LIKE '%{0}%'", searchUser.Text);
        }

        private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {   
            try
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["Employee ID"].Value.ToString();
                SelectedEmployee.Emp_id = val;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SelectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectDepartment_SelectedIndexChanged(object sender, EventArgs e)
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

            distinctValues.Insert(0, "(Account Status)"); 
            selectStatus.DataSource = distinctValues;
            selectStatus.SelectedIndex = 0; 
        }

        public void PopulateDepartment()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            var distinctValues = dt.AsEnumerable()
                                   .Select(row => row.Field<string>("Department"))
                                   .Distinct()
                                   .ToList();

            distinctValues.Insert(0, "(Department)");
            selectDepartment.DataSource = distinctValues;
            selectDepartment.SelectedIndex = 0; 
        }
    }
    public static class SelectedEmployee
    {
        public static string Emp_id { get; set; }
    }
}
