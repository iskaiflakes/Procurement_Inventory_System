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
    public partial class InvoicePage : UserControl
    {
        private const int PageSize = 15; // Number of records per page
        private int currentPage = 1;
        private DataTable invoice_table;

        public InvoicePage()
        {
            InitializeComponent();
        }

        public void PopulateInvoiceTable()
        {
            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                // will only load if the users are either admin or purchasing department
                if ((userRole == "11") || (userRole == "16"))
                {
                    invoice_table = new DataTable();
                    DatabaseClass db = new DatabaseClass();
                    db.ConnectDatabase();
                    string query = "";

                    if (((CurrentUserDetails.BranchId == "MOF") && (userRole == "11")) || ((CurrentUserDetails.BranchId == "MOF") && (userRole == "16")))   // if the user is an admin and accountant and is from MOF, all invoice records are displayed
                    {
                        query = "SELECT Invoice.invoice_id as [INVOICE ID], Invoice.supplier_id as [SUPPLIER], Invoice.purchase_order_id as [PURCHASE ORDER ID], \r\nInvoice.total_amount as [SUB TOTAL], Invoice.vat_amount as [VAT AMOUNT], Invoice.invoice_date [INVOICE DATE] \r\nFROM Invoice";
                    }
                    else // if the user is not from MOF, authorized users can view the invoice records
                    {
                        if ((userRole == "11") || (userRole == "16"))   // if the user is an admin, you will be able to view all the invoice records within your branch only
                        {
                            query = $"SELECT DISTINCT Invoice.invoice_id as [INVOICE ID], Invoice.supplier_id as [SUPPLIER], Invoice.purchase_order_id as [PURCHASE ORDER ID], \r\nInvoice.total_amount as [SUB TOTAL], Invoice.vat_amount as [VAT AMOUNT], Invoice.invoice_date [INVOICE DATE] \r\nFROM Invoice INNER JOIN Purchase_Order PO ON PO.purchase_order_id=Invoice.purchase_order_id\r\nINNER JOIN Employee ON PO.order_user_id=Employee.emp_id\r\nINNER JOIN Purchase_Order_Item POI ON PO.purchase_order_id=POI.purchase_order_id\r\nINNER JOIN Purchase_Request_Item PRI ON POI.purchase_request_item_id=PRI.purchase_request_item_id\r\nINNER JOIN Item_List IL ON PRI.item_id=IL.item_id\r\nINNER JOIN DEPARTMENT D ON IL.department_id=D.DEPARTMENT_ID\r\nWHERE D.BRANCH_ID = '{CurrentUserDetails.BranchId}'";
                        }
                    }

                    SqlDataAdapter da = db.GetMultipleRecords(query);
                    da.Fill(invoice_table);
                    
                    db.CloseConnection();

                    if (!invoice_table.Columns.Contains("DATE_ONLY"))
                    {
                        invoice_table.Columns.Add("DATE_ONLY", typeof(DateTime));
                        foreach (DataRow row in invoice_table.Rows)
                        {
                            row["DATE_ONLY"] = ((DateTime)row["INVOICE DATE"]).Date;
                        } //kasi pag may time di nafifilter pero di naman visible ito
                    }

                    DisplayCurrentPage();
                    dataGridView1.DataSource = invoice_table;

                    if (dataGridView1.Columns.Contains("DATE_ONLY"))
                    {
                        dataGridView1.Columns["DATE_ONLY"].Visible = false;
                    }

                    PopulateSupplier();
                    SelectDate.Value = DateTime.Now; // Set default value to current date
                    SelectDate.Enabled = FilterbyDate.Checked;
                }
            }                
        }

        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, invoice_table.Rows.Count - 1);

            DataTable pageTable = invoice_table.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(invoice_table.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
            FilterData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (invoice_table != null)
            {
                if (currentPage < (invoice_table.Rows.Count + PageSize - 1) / PageSize)
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

        private void InvoicePage_Load(object sender, EventArgs e)
        {
            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                // will only load if the users are either admin or purchasing department
                if ((userRole == "11") || (userRole == "16"))
                {
                    PopulateInvoiceTable();
                }
            }
        }

        private void SelectSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectDate_ValueChanged(object sender, EventArgs e)
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
        private void FilterData()
        {
            DataTable dt = (dataGridView1.DataSource as DataTable);

            if (dt != null)
            {
                string searchFilter = searchUser.Text != "invoice id, supplier id, purchase id" ? searchUser.Text : null;
                string supplierFilter = SelectSupplier.SelectedIndex > 0 ? SelectSupplier.SelectedItem.ToString() : null;

                StringBuilder filter = new StringBuilder();

                if (!string.IsNullOrEmpty(searchFilter))
                {
                    filter.AppendFormat("([Invoice ID] LIKE '%{0}%' OR [Supplier] LIKE '%{0}%' OR [Purchase Order ID] LIKE '%{0}%')", searchFilter);
                }
                if (!string.IsNullOrEmpty(supplierFilter))
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"[SUPPLIER] = '{supplierFilter}'");
                }
                if (FilterbyDate.Checked)
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

        private void AddInvoiceBtnClick(object sender, EventArgs e)
        {
            AddInvoiceWindow form = new AddInvoiceWindow(this);
            form.ShowDialog();
        }

        private void ViewInvoiceBtnClick(object sender, EventArgs e)
        {
            if (InvoiceID.InvID != null)
            {
                ViewInvoiceWindow form = new ViewInvoiceWindow();
                form.ShowDialog();
                AuditLog auditLog = new AuditLog();
                auditLog.LogEvent(CurrentUserDetails.UserID, "Invoice", "View", InvoiceID.InvID, $"Viewed invoice");
            }
            else
            {
                MessageBox.Show("Select an invoice first.");
            }
        }

        private void DataGridViewCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["INVOICE ID"].Value.ToString();
                InvoiceID.InvID = val;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SearchUserTextChanged(object sender, EventArgs e)
        {
            FilterData();

        }

        private void SearchUserEnter(object sender, EventArgs e)
        {
            if (searchUser.Text == "invoice id, supplier id, purchase id")
            {
                searchUser.Text = "";
                searchUser.ForeColor = Color.Black;
            }
        }

        private void SearchUserLeave(object sender, EventArgs e)
        {
            if (searchUser.Text == "")
            {
                searchUser.Text = "invoice id, supplier id, purchase id";
                searchUser.ForeColor = Color.Silver;
            }
        }

        private void ClearFilters_Click(object sender, EventArgs e)
        {
            searchUser.Text = "invoice id, supplier id, purchase id";
            searchUser.ForeColor = Color.Silver;
            SelectSupplier.SelectedIndex = 0;
            FilterbyDate.Checked = false;
            this.ActiveControl = ClearFilters;
            FilterData();
        }

        private void FilterbyDate_CheckedChanged(object sender, EventArgs e)
        {
            SelectDate.Enabled = FilterbyDate.Checked;
            FilterData();
        }
    }

    public static class InvoiceID
    {
        public static string InvID { get; set; }
    }
}
