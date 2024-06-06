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
    public partial class PurchaseOrderPage : UserControl
    {
        public PurchaseOrderPage()
        {
            InitializeComponent();
        }
        private bool HasInvoice()
        {
            bool match = false;

            // Check if PurchaseOrderID is not null
            if (PurchaseOrderIDNum.PurchaseOrderID != null)
            {
                // Initialize the database connection
                DatabaseClass db = new DatabaseClass();
                try
                {
                    db.ConnectDatabase();
                    string query = $"SELECT * FROM Invoice WHERE purchase_order_id = '{PurchaseOrderIDNum.PurchaseOrderID}'";

                    // Execute the query and get the SqlDataReader
                    SqlDataReader dr = db.GetRecord(query);

                    // Check if the data reader has any rows
                    if (dr.HasRows)
                    {
                        match = true;
                    }

                    // Close the data reader
                    dr.Close();
                }
                catch (Exception ex)
                {
                    // Handle any potential exceptions (logging, rethrowing, etc.)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Ensure the database connection is always closed
                    db.CloseConnection();
                }
            }

            return match;
        }


        private void purchaseordrbtn_Click(object sender, EventArgs e)
        {
            AddPurchaseOrderWindow form = new AddPurchaseOrderWindow(this);
            form.ShowDialog();
        }

        private void updateorderbtn_Click(object sender, EventArgs e)
        {
            UpdatePurchaseOrderWindow form = new UpdatePurchaseOrderWindow(this);
            if (HasInvoice())
            {
                form.HideButtons();
            }
            else
            {
                form.ShowButtons();
            }
            form.ShowDialog();
        }

        private void PurchaseOrderPage_Load(object sender, EventArgs e)
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            // will only load if the users are either admin, custodian or purchasing department
            if ((userRole == "11") || (userRole == "14") || (userRole == "15"))
            {
                PopulatePurchaseOrder();
            }
                
        }
        public void PopulatePurchaseOrder()
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            // will only load if the users are either admin, custodian or purchasing department
            if ((userRole == "11") || (userRole == "14") || (userRole == "15"))
            {
                DataTable purchaseOrderTable = new DataTable();
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string query = "";

                if (((CurrentUserDetails.BranchId == "MOF") && (userRole == "11")) || ((CurrentUserDetails.BranchId == "MOF") && (userRole == "14")) || ((CurrentUserDetails.BranchId == "CAL") && (userRole == "14")))  // if the Branch is Main Office/Caloocan and an ADMIN/Purchasing department, all of the PO are displayed
                {
                    query = "SELECT purchase_order_id AS 'PURCHASE ORDER ID', supplier_id AS 'SUPPLIER', order_user_id AS 'ORDER BY', \r\npurchase_order_date AS 'ORDER DATE', purchase_order_status AS 'STATUS' FROM Purchase_Order \r\nINNER JOIN Employee ON Purchase_Order.order_user_id = Employee.emp_id ";
                }
                else // if the branch is not MOF or CAL, three authorized users will have an access (admin and custodian)
                {
                    if ((userRole == "11") || (userRole == "15"))  // if your role is admin and custodian, you will be able to view all the PO within your branch only
                    {
                        query = $"SELECT purchase_order_id AS 'PURCHASE ORDER ID', supplier_id AS 'SUPPLIER', order_user_id AS 'ORDER BY', \r\npurchase_order_date AS 'ORDER DATE', purchase_order_status AS 'STATUS' FROM Purchase_Order \r\nINNER JOIN Employee ON Purchase_Order.order_user_id = Employee.emp_id \r\nWHERE Employee.branch_id = '{CurrentUserDetails.BranchId}'";
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(query, db.GetSqlConnection());

                da.Fill(purchaseOrderTable);
                dataGridView1.DataSource = purchaseOrderTable;

                db.CloseConnection();
                purchaseOrderTable.Columns.Add("DATE_ONLY", typeof(DateTime));
                foreach (DataRow row in purchaseOrderTable.Rows)
                {
                    row["DATE_ONLY"] = ((DateTime)row["ORDER DATE"]).Date;
                } //kasi pag may time di nafifilter pero di naman visible ito
                dataGridView1.Columns["DATE_ONLY"].Visible = false;
                PopulateStatus();
                PopulateSupplier();
                SelectDate.Value = SelectDate.MinDate;
            }
                
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Check that the click is not on a header
            {
                try
                {
                    string val = dataGridView1.Rows[e.RowIndex].Cells["Purchase Order ID"].Value.ToString();
                    PurchaseOrderIDNum.PurchaseOrderID = val;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("([Purchase Order ID] LIKE '%{0}%' OR [Supplier] LIKE '%{0}%')", searchUser.Text);
        }

        private void SelectSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        private void PopulateStatus()
        {
            string[] statusOptions = { "(STATUS)", "TO BE DELIVERED", "FULFILLED", "PARTIALLY FULFILLED" };
            SelectStatus.Items.Clear();
            SelectStatus.Items.AddRange(statusOptions);
            SelectStatus.SelectedIndex = 0; // Ensure no default selection
        }
        public void PopulateSupplier()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            var distinctValues = dt.AsEnumerable()
                                   .Select(row => row.Field<string>("SUPPLIER"))
                                   .Distinct()
                                   .ToList();

            distinctValues.Insert(0, "(Supplier)"); // Add placeholder

            SelectSupplier.DataSource = distinctValues;
            SelectSupplier.SelectedIndex = 0; // Ensure no default selection
        }
        private void FilterData()
        {
            DataTable dt = (dataGridView1.DataSource as DataTable);

            if (dt != null)
            {
                string supplierFilter = SelectSupplier.SelectedIndex > 0 ? SelectSupplier.SelectedItem.ToString() : null;
                string statusFilter = SelectStatus.SelectedIndex > 0 ? SelectStatus.SelectedItem.ToString() : null;

                StringBuilder filter = new StringBuilder();

                if (!string.IsNullOrEmpty(supplierFilter))
                {
                    filter.Append($"[SUPPLIER] = '{supplierFilter}'");
                }
                if (!string.IsNullOrEmpty(statusFilter))
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
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


        private void SelectDate_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void searchUser_Enter(object sender, EventArgs e)
        {
            if (searchUser.Text == "purchase order id, supplier name")
            {
                searchUser.Text = "";
                searchUser.ForeColor = Color.Black;
            }
        }

        private void searchUser_Leave(object sender, EventArgs e)
        {
            if (searchUser.Text == "")
            {
                searchUser.Text = "purchase order id, supplier name";
                searchUser.ForeColor = Color.Silver;
            }
        }
    }
    public static class PurchaseOrderIDNum
    {
        public static string PurchaseOrderID { get; set; }
    }
}
