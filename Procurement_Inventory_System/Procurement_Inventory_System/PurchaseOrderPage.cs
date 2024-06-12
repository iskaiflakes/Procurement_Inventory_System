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
        private const int PageSize = 15; // Number of records per page
        private int currentPage = 1;
        private DataTable purchaseOrderTable;

        public PurchaseOrderPage()
        {
            InitializeComponent();
        }
        private double CancelCounter()
        {
            int totalItems = 0;
            int cancelledItems = 0;

            // Check if PurchaseOrderID is not null
            if (PurchaseOrderIDNum.PurchaseOrderID != null)
            {
                // Initialize the database connection
                DatabaseClass db = new DatabaseClass();
                try
                {
                    db.ConnectDatabase();
                    string query = $"Select order_item_status from Purchase_Order_Item inner join Purchase_Order on Purchase_Order.purchase_order_id=Purchase_Order_Item.purchase_order_id where Purchase_Order.purchase_order_id='{PurchaseOrderIDNum.PurchaseOrderID}'";

                    // Execute the query and get the SqlDataReader
                    SqlDataReader dr = db.GetRecord(query);

                    // Check if the data reader has any rows
                    while (dr.Read())
                    {
                        // Increment total items count
                        totalItems++;

                        // Check if the status is "Cancelled"
                        if (dr["order_item_status"].ToString() == "CANCELLED")
                        {
                            // Increment cancelled items count
                            cancelledItems++;
                        }
                    }
                    // Close the data reader
                    dr.Close();

                }
                catch (Exception ex)
                {
                    // Handle any potential exceptions (logging, rethrowing, etc.)
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return 0;
                }
                finally
                {
                    // Ensure the database connection is always closed
                    db.CloseConnection();
                }
            }
            double cancelledPercentage = (double)cancelledItems / totalItems * 100;
            return cancelledPercentage;
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
            if(PurchaseOrderIDNum.PurchaseOrderID != null)
            {
                UpdatePurchaseOrderWindow form = new UpdatePurchaseOrderWindow(this);
                if (HasInvoice() || CancelCounter() == 100.00)
                {
                    form.HideButtons();
                }
                else
                {
                    form.ShowButtons();
                }
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a purchase order first.");
            }
            
        }

        private void PurchaseOrderPage_Load(object sender, EventArgs e)
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            // will only load if the users are either admin, custodian or purchasing department
            if ((userRole == "11") || (userRole == "14") || (userRole == "15"))
            {
                PopulatePurchaseOrder();
            }

            if(userRole == "15")
            {
                purchaseordrbtn.Visible = false;
            }
                
        }
        public void PopulatePurchaseOrder()
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            // will only load if the users are either admin, custodian or purchasing department
            if ((userRole == "11") || (userRole == "14") || (userRole == "15"))
            {
                purchaseOrderTable = new DataTable();
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string query = "";

                if (((CurrentUserDetails.BranchId == "MOF") && (userRole == "11")) || ((CurrentUserDetails.BranchId == "MOF") && (userRole == "14")) || ((CurrentUserDetails.BranchId == "CAL") && (userRole == "14")))  // if the Branch is Main Office/Caloocan and an ADMIN/Purchasing department, all of the PO are displayed
                {
                    query = "SELECT purchase_order_id AS 'PURCHASE ORDER ID', supplier_id AS 'SUPPLIER', (Employee.emp_fname + ' '+ Employee.middle_initial+ ' ' +Employee.emp_lname) AS 'ORDER BY', purchase_order_date AS 'ORDER DATE', purchase_order_status AS 'STATUS' FROM Purchase_Order INNER JOIN Employee ON Purchase_Order.order_user_id = Employee.emp_id";
                }
                else // if the branch is not MOF or CAL, three authorized users will have an access (admin and custodian)
                {
                    if ((userRole == "11") || (userRole == "15"))  // if your role is admin and custodian, you will be able to view all the PO within your branch only
                    {
                        query = $"SELECT DISTINCT PO.purchase_order_id AS 'PURCHASE ORDER ID', PO.supplier_id AS 'SUPPLIER', (Employee.emp_fname + ' '+ Employee.middle_initial+ ' ' +Employee.emp_lname) AS 'ORDER BY', \r\nPO.purchase_order_date AS 'ORDER DATE', PO.purchase_order_status AS 'STATUS' FROM Purchase_Order PO\r\nINNER JOIN Employee ON PO.order_user_id=Employee.emp_id\r\nINNER JOIN Purchase_Order_Item POI ON PO.purchase_order_id=POI.purchase_order_id\r\nINNER JOIN Purchase_Request_Item PRI ON POI.purchase_request_item_id=PRI.purchase_request_item_id\r\nINNER JOIN Item_List IL ON PRI.item_id=IL.item_id\r\nINNER JOIN DEPARTMENT D ON IL.department_id=D.DEPARTMENT_ID\r\nWHERE D.BRANCH_ID = '{CurrentUserDetails.BranchId}'";
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(query, db.GetSqlConnection());

                da.Fill(purchaseOrderTable);
                DisplayCurrentPage();

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
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, purchaseOrderTable.Rows.Count - 1);

            DataTable pageTable = purchaseOrderTable.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(purchaseOrderTable.Rows[i]);
            }

            dataGridView1.DataSource = purchaseOrderTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (purchaseOrderTable != null)
            {
                if (currentPage < (purchaseOrderTable.Rows.Count + PageSize - 1) / PageSize)
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
