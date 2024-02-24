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
    public partial class AddPurchaseOrderWindow : Form
    {
        private bool _isFiltered = false;
        public AddPurchaseOrderWindow()
        {
            InitializeComponent();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addorderbtn_Click(object sender, EventArgs e)
        {
            AddPurchaseOrderPrompt form = new AddPurchaseOrderPrompt();
            form.ShowDialog();
        }

        private void AddPurchaseOrderWindow_Load(object sender, EventArgs e)
        {
            PopulateApprovedItems();
        }
        private void PopulateApprovedItems()
        {
            DataTable purchase_request_item_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = @"SELECT su.supplier_name AS 'Supplier', purchase_request_item_id AS 'Purchase Request Item ID', 
                     item_name AS 'Item Name', pri.item_quantity AS 'Quantity', 
                     ISNULL(CONVERT(varchar, iq.unit_price), 'N/A') AS 'Unit Price', 
                     pri.purchase_item_status AS 'Status' 
                     FROM Purchase_Request_Item pri 
                     JOIN Item_List il ON pri.item_id=il.item_id 
                     LEFT JOIN Item_Quotation iq ON iq.quotation_id=pri.quotation_id 
                     JOIN Quotation qu ON iq.quotation_id=qu.quotation_id 
                     JOIN Supplier su ON su.supplier_id=qu.supplier_id 
                     WHERE pri.purchase_item_status = 'APPROVED'";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(purchase_request_item_table);
            // Check if the checkbox column already exists
            // Add a Boolean column for checkboxes before setting the DataSource of dataGridView1
            purchase_request_item_table.Columns.Add("Select", typeof(bool));
            foreach (DataRow row in purchase_request_item_table.Rows)
            {
                row["Select"] = false; // This will be the checkbox state
            }
            dataGridView1.DataSource = purchase_request_item_table;
            dataGridView1.AllowUserToAddRows = false;
            db.CloseConnection();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on a checkbox column
            if (e.ColumnIndex == dataGridView1.Columns["Select"].Index && e.RowIndex != -1)
            {
                // Toggle the checkbox
                bool isChecked = (bool)dataGridView1[e.ColumnIndex, e.RowIndex].Value;
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = !isChecked;

                // Filter the DataGridView based on the checked state of the checkbox
                FilterDataGridView();
            }
        }
        private void FilterDataGridView()
        {
            // Determine if any checkbox is checked
            _isFiltered = dataGridView1.Rows.Cast<DataGridViewRow>()
                          .Any(row => (bool?)row.Cells["Select"].Value == true);

            // If at least one checkbox is checked, filter the items for that supplier only
            if (_isFiltered)
            {
                string selectedSupplier = dataGridView1.Rows.Cast<DataGridViewRow>()
                                           .Where(row => (bool?)row.Cells["Select"].Value == true)
                                           .Select(row => row.Cells["Supplier"].Value.ToString())
                                           .FirstOrDefault();

                if (!string.IsNullOrEmpty(selectedSupplier))
                {
                    // This is a LINQ query to filter the DataTable based on the supplier
                    // You might need to adjust this according to how you're retrieving data
                    var filteredData = ((DataTable)dataGridView1.DataSource).AsEnumerable()
                                        .Where(row => row.Field<string>("Supplier") == selectedSupplier);

                    // Set the DataSource to the filtered data
                    dataGridView1.DataSource = filteredData.CopyToDataTable();
                }
            }
            else
            {
                // If no checkboxes are checked, show all approved purchase items
                PopulateApprovedItems();
            }
        }
    }
}
