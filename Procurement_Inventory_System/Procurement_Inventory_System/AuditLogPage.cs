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
            DataTable acc_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query1 = $"SELECT Employee.emp_id AS [EMPLOYEE ID], Employee.emp_lname+', '+Employee.emp_fname as [NAME], DEPARTMENT.DEPARTMENT_NAME AS [DEPARTMENT], Account.account_status AS [ACCOUNT STATUS] from Employee \r\nINNER JOIN Department ON Department.DEPARTMENT_ID = Employee.department_id \r\nINNER JOIN Account ON Account.emp_id = Employee.emp_id WHERE Employee.branch_id = '{CurrentUserDetails.BranchId}'";
            string query2 = "SELECT Employee.emp_id AS [EMPLOYEE ID], Employee.emp_lname+', '+Employee.emp_fname as [NAME], DEPARTMENT.DEPARTMENT_NAME AS [DEPARTMENT], Account.account_status AS [ACCOUNT STATUS] from Employee \r\nINNER JOIN Department ON Department.DEPARTMENT_ID = Employee.department_id \r\nINNER JOIN Account ON Account.emp_id = Employee.emp_id";
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
    }
    public static class SelectedAuditEmployee
    {
        public static string emp_id { get; set; }

    }
}
