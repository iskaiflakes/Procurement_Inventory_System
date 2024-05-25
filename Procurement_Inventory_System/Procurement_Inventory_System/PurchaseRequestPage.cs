using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Procurement_Inventory_System
{
    public partial class PurchaseRequestPage : UserControl
    {
        public PurchaseRequestPage()
        {
            InitializeComponent();
        }

        private void purchaserqstbtn_Click(object sender, EventArgs e)
        {
            PurchaseRequestWindow form = new PurchaseRequestWindow(this);
            form.ShowDialog();
        }

        private void updaterqstbtn_Click(object sender, EventArgs e)
        {
            if (PurchaseRequestIDNum.PurchaseReqID == null)
            {
                MessageBox.Show("Click purchase request id first.");
            }
            else
            {
                UpdatePurchaseRqstWindow form = new UpdatePurchaseRqstWindow(this);
                form.ShowDialog();
            }
            
        }

        private void PurchaseRequestPage_Load(object sender, EventArgs e)
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            // will only load if the users are either admin, approver, requestor or purchasing department
            if ((userRole == "11") || (userRole == "12") || (userRole == "13") || (userRole == "14"))
            {
                PopulateRequestTable();
            }
                
        }
        private void PurchaseRequestPage_Enter(object sender, EventArgs e)
        {
            //
        }
        public void PopulateRequestTable()
        {
            DataTable purchase_request_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            if (((CurrentUserDetails.BranchId == "MOF") && (userRole == "11"))||((CurrentUserDetails.BranchId == "MOF") && (userRole == "14"))||((CurrentUserDetails.BranchId == "CAL") && (userRole == "14")))  // if the Branch is Main Office/Caloocan and an ADMIN/Purchasing department, all of the PR is displayed
            {
                query = "SELECT purchase_request_id AS 'PURCHASE REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', purchase_request_date AS 'DATE', purchase_request_status AS 'STATUS' FROM Purchase_Request pr JOIN Employee e ON pr.purchase_request_user_id=e.emp_id ORDER BY purchase_request_date";
            }
            else // if the branch is not MOF or CAL, three authorized users will have an access (admin, approver and requestor)
            {
                if ((userRole == "11") || (userRole == "12"))  // if your role is admin, custodian or approver, you will be able to view all the PR within your branch only
                {
                    query = $"SELECT purchase_request_id AS 'PURCHASE REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', \r\npurchase_request_date AS 'DATE', purchase_request_status AS 'STATUS' FROM Purchase_Request pr \r\nJOIN Employee e ON pr.purchase_request_user_id=e.emp_id WHERE e.branch_id='{CurrentUserDetails.BranchId}' ORDER BY purchase_request_date";
                }
                else if (userRole == "13")   // if your role is requestor, you'll be able to see the PRs within your department section
                {
                    query = $"SELECT purchase_request_id AS 'PURCHASE REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', purchase_request_date AS 'DATE', purchase_request_status AS 'STATUS' FROM Purchase_Request pr JOIN Employee e ON pr.purchase_request_user_id=e.emp_id WHERE e.section_id = '{CurrentUserDetails.DepartmentSection}' AND e.department_id = '{CurrentUserDetails.DepartmentId}' ORDER BY purchase_request_date;";
                }
            }

            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(purchase_request_table);
            dataGridView1.DataSource = purchase_request_table;
            db.CloseConnection();
            purchase_request_table.Columns.Add("DATE_ONLY", typeof(DateTime));
            foreach (DataRow row in purchase_request_table.Rows)
            {
                row["DATE_ONLY"] = ((DateTime)row["DATE"]).Date;
            } //kasi pag may time di nafifilter pero di naman visible ito
            dataGridView1.Columns["DATE_ONLY"].Visible = false;
            PopulateStatus();
            SelectDate.Value = SelectDate.MinDate;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["PURCHASE REQUEST ID"].Value.ToString();
                PurchaseRequestIDNum.PurchaseReqID = val;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void searchUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("([Purchase Request ID] LIKE '%{0}%' OR [Requestor] LIKE '%{0}%')", searchUser.Text);
        }

        private void SelectDate_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        private void PopulateStatus()
        {
            string[] statusOptions = { "(STATUS)", "COMPLETE", "INCOMPLETE", "PENDING" };
            SelectStatus.Items.Clear();
            SelectStatus.Items.AddRange(statusOptions);
            SelectStatus.SelectedIndex = 0; // Ensure no default selection
        }

        private void FilterData()
        {
            DataTable dt = (dataGridView1.DataSource as DataTable);

            if (dt != null)
            {
                string statusFilter = SelectStatus.SelectedIndex > 0 ? SelectStatus.SelectedItem.ToString() : null;

                StringBuilder filter = new StringBuilder();

                if (!string.IsNullOrEmpty(statusFilter))
                {
                    filter.Append($"[STATUS] = '{statusFilter}'");
                }

                if (SelectDate.Value != SelectDate.MinDate)
                {
                    DateTime selectedDate = SelectDate.Value.Date;
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"[DATE_ONLY] = #{selectedDate.ToString("MM/dd/yyyy")}#");
                }

                dt.DefaultView.RowFilter = filter.ToString();
            }
        }

        private void searchUser_Enter(object sender, EventArgs e)
        {
            if (searchUser.Text == "purchase request id, requestor")
            {
                searchUser.Text = "";
                searchUser.ForeColor = Color.Black;
            }
        }

        private void searchUser_Leave(object sender, EventArgs e)
        {
            if (searchUser.Text == "")
            {
                searchUser.Text = "purchase request id, requestor";
                searchUser.ForeColor = Color.Silver;
            }
        }
    }

    public static class PurchaseRequestIDNum
    {
        public static string PurchaseReqID { get; set; }
    }
}
