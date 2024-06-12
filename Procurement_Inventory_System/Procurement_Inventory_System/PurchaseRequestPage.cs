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
        private const int PageSize = 15; // Number of records per page
        private int currentPage = 1;
        private DataTable purchase_request_table;

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
            if (PurchaseRequestIDNum.PurchaseReqID != null)
            {

                UpdatePurchaseRqstWindow form = new UpdatePurchaseRqstWindow(this);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["PURCHASE REQUEST ID"].Value.ToString() == PurchaseRequestIDNum.PurchaseReqID)
                    {
                        if (row.Cells["STATUS"].Value.ToString() == "COMPLETE")
                        {
                            form.HideAllButtons();
                        }
                        else
                        {
                            form.ShowAll();
                        }
                    }
                }
                form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Select a purchase request first.");
            }            
        }

        private void PurchaseRequestPage_Load(object sender, EventArgs e)
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            // will only load if the users are either admin, approver, requestor or purchasing department
            if ((userRole == "11") || (userRole == "12") || (userRole == "13") || (userRole == "14") || (userRole == "17"))
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
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            // will only load if the users are either admin, approver, requestor or purchasing department
            if ((userRole == "11") || (userRole == "12") || (userRole == "13") || (userRole == "14") || (userRole == "17"))
            {
                purchase_request_table = new DataTable();
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string query = "";

                if (((CurrentUserDetails.BranchId == "MOF") && (userRole == "11")) || ((CurrentUserDetails.BranchId == "MOF") && (userRole == "14")) || ((CurrentUserDetails.BranchId == "CAL") && (userRole == "14")) || ((CurrentUserDetails.BranchId == "MOF") && (userRole == "12")))  // if the Branch is Main Office/Caloocan and an ADMIN/Purchasing department/Approver, all of the PR is displayed
                {
                    query = "SELECT purchase_request_id AS 'PURCHASE REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', purchase_request_date AS 'DATE', purchase_request_status AS 'STATUS' FROM Purchase_Request pr JOIN Employee e ON pr.purchase_request_user_id=e.emp_id ORDER BY purchase_request_date";
                }
                else if((CurrentUserDetails.BranchId == "MOF") && (userRole == "17"))
                {
                    // only showing PRs that cost more than 50000 pesos
                    query = "SELECT \r\n    pr.purchase_request_id AS 'PURCHASE REQUEST ID', \r\n    (e.emp_fname + ' ' + COALESCE(e.middle_initial + ' ', '') + e.emp_lname) AS 'REQUESTOR', \r\n    purchase_request_date AS 'DATE', \r\n    purchase_request_status AS 'STATUS'\r\nFROM \r\n    Purchase_Request pr \r\nJOIN \r\n    Employee e ON pr.purchase_request_user_id = e.emp_id \r\nJOIN \r\n    Purchase_Request_Item PRI ON pr.purchase_request_id = PRI.purchase_request_id\r\nJOIN \r\n    Quotation Q ON PRI.quotation_id = Q.quotation_id\r\nJOIN \r\n    Item_Quotation IQ ON Q.quotation_id = IQ.quotation_id\r\nGROUP BY \r\n    pr.purchase_request_id, \r\n    e.emp_fname, \r\n    e.middle_initial, \r\n    e.emp_lname, \r\n    pr.purchase_request_date, \r\n    pr.purchase_request_status\r\nHAVING \r\n    SUM(PRI.item_quantity * IQ.unit_price) > 50000\r\nORDER BY \r\n    pr.purchase_request_date;";
                }
                else // if the branch is not MOF or CAL, three authorized users will have an access (admin, approver and requestor)
                {
                    if ((userRole == "11"))  // if your role is admin, custodian or approver, you will be able to view all the PR within your branch only
                    {
                        query = $"SELECT DISTINCT PR.purchase_request_id AS 'PURCHASE REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', \r\npurchase_request_date AS 'DATE', purchase_request_status AS 'STATUS' FROM Purchase_Request PR\r\nJOIN Employee e ON pr.purchase_request_user_id=e.emp_id\r\nJOIN Purchase_Request_Item PRI ON PRI.purchase_request_id=PR.purchase_request_id\r\nJOIN Item_List IL ON IL.item_id=PRI.item_id\r\nJOIN DEPARTMENT D ON D.DEPARTMENT_ID=IL.department_id\r\nWHERE D.BRANCH_ID = '{CurrentUserDetails.BranchId}'\r\nORDER BY purchase_request_date";
                    }
                    else if ((userRole == "13"))   // if your role is requestor or approver, you'll be able to see the PRs within your department section
                    {
                        query = $"SELECT DISTINCT PR.purchase_request_id AS 'PURCHASE REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', \r\npurchase_request_date AS 'DATE', purchase_request_status AS 'STATUS' FROM Purchase_Request PR\r\nJOIN Employee e ON pr.purchase_request_user_id=e.emp_id\r\nJOIN Purchase_Request_Item PRI ON PRI.purchase_request_id=PR.purchase_request_id\r\nJOIN Item_List IL ON IL.item_id=PRI.item_id\r\nWHERE IL.section_id = '{CurrentUserDetails.DepartmentSection}'\r\nORDER BY purchase_request_date";
                    }   
                    else if (userRole == "12")
                    {
                        query = $"SELECT DISTINCT PR.purchase_request_id AS 'PURCHASE REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', \r\npurchase_request_date AS 'DATE', purchase_request_status AS 'STATUS' FROM Purchase_Request PR\r\nJOIN Employee e ON pr.purchase_request_user_id=e.emp_id\r\nJOIN Purchase_Request_Item PRI ON PRI.purchase_request_id=PR.purchase_request_id\r\nJOIN Item_List IL ON IL.item_id=PRI.item_id\r\nWHERE IL.department_id = '{CurrentUserDetails.DepartmentId}'\r\nORDER BY purchase_request_date";
                    }
                }

                SqlDataAdapter da = db.GetMultipleRecords(query);
                da.Fill(purchase_request_table);
                DisplayCurrentPage();
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
                
        }
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, purchase_request_table.Rows.Count - 1);

            DataTable pageTable = purchase_request_table.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(purchase_request_table.Rows[i]);
            }

            dataGridView1.DataSource = purchase_request_table;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (purchase_request_table != null)
            {
                if (currentPage < (purchase_request_table.Rows.Count + PageSize - 1) / PageSize)
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
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void searchUser_TextChanged(object sender, EventArgs e)
        {
            FilterData();
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
                string searchFilter = !string.IsNullOrEmpty(searchUser.Text) && searchUser.Text != "purchase request id, requestor" ? searchUser.Text : null;

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

                if (!string.IsNullOrEmpty(searchFilter))
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"([Purchase Request ID] LIKE '%{searchFilter}%' OR [Requestor] LIKE '%{searchFilter}%')");
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

        private void ClearFilters_Click(object sender, EventArgs e)
        {
            searchUser.Text = "purchase request id, requestor";
            searchUser.ForeColor = Color.Silver;
            SelectStatus.SelectedIndex = 0;
            SelectDate.Value = SelectDate.MinDate;
            this.ActiveControl = ClearFilters;
            FilterData();
        }
    }

    public static class PurchaseRequestIDNum
    {
        public static string PurchaseReqID { get; set; }
    }
}
