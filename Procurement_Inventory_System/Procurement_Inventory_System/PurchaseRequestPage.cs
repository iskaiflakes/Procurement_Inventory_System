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
            PopulateRequestTable();
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
            string query = $"SELECT purchase_request_id AS 'PURCHASE REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', purchase_request_date AS 'DATE', purchase_request_status AS 'STATUS' FROM Purchase_Request pr JOIN Employee e ON pr.purchase_request_user_id=e.emp_id WHERE e.section_id = '{CurrentUserDetails.DepartmentSection}' AND e.department_id = '{CurrentUserDetails.DepartmentId}' ORDER BY purchase_request_date;";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(purchase_request_table);
            dataGridView1.DataSource = purchase_request_table;
            db.CloseConnection();
            LoadComboBoxes();
            SelectDate.Value = SelectDate.MinDate;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["REQUEST ID"].Value.ToString();
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
        private void LoadComboBoxes()
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
                    filter.Append($"[DATE] = #{selectedDate.ToString("MM/dd/yyyy")}#");
                }

                dt.DefaultView.RowFilter = filter.ToString();
            }
        }
    }

    public static class PurchaseRequestIDNum
    {
        public static string PurchaseReqID { get; set; }
    }
}
