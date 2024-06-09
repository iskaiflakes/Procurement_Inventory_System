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
    public partial class SupplierQuotationPage : UserControl
    {
        private const int PageSize = 15; // Number of records per page
        private int currentPage = 1;
        private DataTable quotation_data;

        public SupplierQuotationPage()
        {
            InitializeComponent();
        }

        private void addquotationbtn_Click(object sender, EventArgs e)
        {
            
            //SupplierQuotationWindow form = new SupplierQuotationWindow();
            //form.ShowDialog();
        }

        private void SupplierQuotationPage_Load(object sender, EventArgs e)
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            // will only load if the users are either admin or purchasing department
            if ((userRole == "11") || (userRole == "14"))
            {
                LoadQuotationData();    // called the method for loading quotation data
            }
                
        }

        public void LoadQuotationData() // Method for loading the quotations
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            // will only load if the users are either admin or purchasing department
            if ((userRole == "11") || (userRole == "14"))
            {
                quotation_data = new DataTable();
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string query = "";

                if (((CurrentUserDetails.BranchId == "MOF") && (userRole == "11")) || ((CurrentUserDetails.BranchId == "MOF") && (userRole == "14")) || ((CurrentUserDetails.BranchId == "CAL") && (userRole == "14")))  // if the Branch is Main Office/Caloocan and an ADMIN/Purchasing department, all of the Supplier's Quotations are displayed
                {
                    query = "SELECT Quotation.quotation_id AS [QUOTATION ID], Supplier.supplier_name AS [SUPPLIER], \r\nQuotation.quotation_date as [QUOTATION DATE], Quotation.quotation_validity AS[VALIDITY], \r\nQuotation.vat_status AS[VAT STATUS] FROM Quotation INNER JOIN Supplier ON Quotation.supplier_id = Supplier.supplier_id ";
                }
                else // if the branch is not MOF or CAL, three authorized users will have an access (admin)
                {
                    if (userRole == "11")  // if your role is admin, you will be able to view all the Supplier's Quotations within your branch only
                    {
                        query = $"SELECT DISTINCT Quotation.quotation_id AS [QUOTATION ID], Supplier.supplier_name AS [SUPPLIER], \r\nQuotation.quotation_date as [QUOTATION DATE], Quotation.quotation_validity AS[VALIDITY], \r\nQuotation.vat_status AS[VAT STATUS] FROM Quotation INNER JOIN Supplier ON Quotation.supplier_id = Supplier.supplier_id \r\nINNER JOIN Employee ON Employee.emp_id = Quotation.quotation_user_id \r\nWHERE Employee.branch_id = '{CurrentUserDetails.BranchId}'";
                    }
                }

                // loading the data in the datagridview
                SqlDataAdapter da = db.GetMultipleRecords(query);
                da.Fill(quotation_data);
                DisplayCurrentPage();
                db.CloseConnection();
                PopulateSupplier();
                PopulateValidity();
            }
                
        }
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, quotation_data.Rows.Count - 1);

            DataTable pageTable = quotation_data.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(quotation_data.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage < (quotation_data.Rows.Count + PageSize - 1) / PageSize)
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
        private void searchQuotation_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("([Quotation ID] LIKE '%{0}%' OR [Supplier] LIKE '%{0}%')", searchQuotation.Text);
        }

        private void SelectValidity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
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

        public void PopulateValidity()
        {
            string[] validityOptions = { "(Validity)", "Valid", "Expired" };
            SelectValidity.Items.Clear();
            SelectValidity.Items.AddRange(validityOptions);
            SelectValidity.SelectedIndex = 0; // Ensure no default selection
        }

        private void FilterData()
        {
            DataTable dt = (dataGridView1.DataSource as DataTable);

            if (dt != null)
            {
                string supplierFilter = SelectSupplier.SelectedIndex > 0 ? SelectSupplier.SelectedItem.ToString() : null;
                string validityFilter = SelectValidity.SelectedIndex > 0 ? SelectValidity.SelectedItem.ToString() : null;

                StringBuilder filter = new StringBuilder();

                if (!string.IsNullOrEmpty(supplierFilter))
                {
                    filter.Append($"[SUPPLIER] = '{supplierFilter}'");
                }

                if (!string.IsNullOrEmpty(validityFilter))
                {
                    DateTime currentDate = DateTime.Now.Date;

                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }

                    if (validityFilter == "Valid")
                    {
                        filter.Append($"[VALIDITY] >= #{currentDate.ToString("MM/dd/yyyy")}#");
                    }
                    else if (validityFilter == "Expired")
                    {
                        filter.Append($"[VALIDITY] < #{currentDate.ToString("MM/dd/yyyy")}#");
                    }
                }

                dt.DefaultView.RowFilter = filter.ToString();
            }
        }

        private void searchQuotation_Enter(object sender, EventArgs e)
        {
            if (searchQuotation.Text == "quotation id, supplier name")
            {
                searchQuotation.Text = "";
                searchQuotation.ForeColor = Color.Black;
            }
        }

        private void searchQuotation_Leave(object sender, EventArgs e)
        {
            if (searchQuotation.Text == "")
            {
                searchQuotation.Text = "quotation id, supplier name";
                searchQuotation.ForeColor = Color.Silver;
            }
        }

        private void ViewQuoDetails(object sender, EventArgs e)
        {
            if (SelectedSupplierQuotation.quoID != null)
            {
                ViewQuoDetails form = new ViewQuoDetails();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select Quotation ID first!");
            }
                
        }

        private void SelectDataFromDataGrid(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["QUOTATION ID"].Value.ToString();
                SelectedSupplierQuotation.quoID = val;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public static class SelectedSupplierQuotation
    {
        public static string quoID { get; set; }

    }
}
