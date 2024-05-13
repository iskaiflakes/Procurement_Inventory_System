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
    public partial class InventoryPage : UserControl
    {
        public InventoryPage()
        {
            InitializeComponent();
        }

        private void InventoryPage_Load(object sender, EventArgs e)
        {
            LoadInventoryList();
        }

        private void updateinventorybtn_Click(object sender, EventArgs e)
        {
            UpdateInventoryWindow form = new UpdateInventoryWindow(this);
            form.ShowDialog();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                InventoryIDNum.InventoryItemID = dataGridView1.Rows[e.RowIndex].Cells["ITEM ID"].Value.ToString();
                InventoryIDNum.InventoryItemName = dataGridView1.Rows[e.RowIndex].Cells["ITEM NAME"].Value.ToString();
                InventoryIDNum.InventoryItemQuantity = dataGridView1.Rows[e.RowIndex].Cells["QUANTITY"].Value.ToString();
                InventoryIDNum.InventoryItemUnit = dataGridView1.Rows[e.RowIndex].Cells["UNIT"].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void LoadInventoryList()
        {
            DataTable inventory_table = new DataTable();
            inventory_table.Columns.Add("ITEM ID", typeof(string));
            inventory_table.Columns.Add("ITEM NAME", typeof(string));
            inventory_table.Columns.Add("QUANTITY", typeof(int));
            inventory_table.Columns.Add("UNIT", typeof(string));
            inventory_table.Columns.Add("ACTIVE", typeof(string)); // Make STATUS column a string
            inventory_table.Columns.Add("DESCRIPTION", typeof(string));

            // Populate the new DataTable with data from the database
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string department = CurrentUserDetails.DepartmentId;
            string section = CurrentUserDetails.DepartmentSection;
            string query = $"SELECT ii.item_id, il.item_name, ii.available_quantity, ii.unit, il.active, il.item_description FROM Item_Inventory ii JOIN Item_List il ON ii.item_id = il.item_id WHERE il.department_id='{department}' AND il.section_id='{section}' ORDER BY il.active, il.item_name";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable temp_table = new DataTable();
            da.Fill(temp_table);
            db.CloseConnection();

            // Convert ACTIVE column values from 0/1 to Inactive/Active and import rows
            foreach (DataRow row in temp_table.Rows)
            {
                DataRow newRow = inventory_table.NewRow();
                newRow["ITEM ID"] = row["item_id"].ToString();
                newRow["ITEM NAME"] = row["item_name"].ToString();
                newRow["QUANTITY"] = Convert.ToInt32(row["available_quantity"]);
                newRow["UNIT"] = row["unit"].ToString();
                newRow["ACTIVE"] = row["active"].ToString() == "1" ? "Active" : "Inactive";
                newRow["DESCRIPTION"] = row["item_description"].ToString();
                inventory_table.Rows.Add(newRow);
            }

            dataGridView1.DataSource = inventory_table;

            // Populate filter dropdowns
            PopulateStatus();
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void searchUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("([Item ID] LIKE '%{0}%' OR [Item Name] LIKE '%{0}%')", searchUser.Text);
        }

        private void SelectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        private void FilterData()
        {
            DataTable dt = (dataGridView1.DataSource as DataTable);

            if (dt != null)
            {
                string statusFilter = SelectStatus.SelectedIndex > 0 ? SelectStatus.SelectedItem.ToString() : null;

                StringBuilder filter = new StringBuilder();

                if (SelectStatus.SelectedIndex > 0)
                {
                    filter.Append($"[ACTIVE] = '{statusFilter}'");
                }

                dt.DefaultView.RowFilter = filter.ToString();
            }
        }

        public void PopulateStatus()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            var distinctValues = dt.AsEnumerable()
                                   .Select(row => row.Field<string>("ACTIVE"))
                                   .Distinct()
                                   .ToList();

            distinctValues.Insert(0, "(Status)"); // Add placeholder

            SelectStatus.DataSource = distinctValues;
            SelectStatus.SelectedIndex = 0; // Ensure no default selection
        }
    }
    public static class InventoryIDNum
    {
        public static string InventoryItemID { get; set; }
        public static string InventoryItemName { get; set; }
        public static string InventoryItemQuantity { get; set; }
        public static string InventoryItemUnit { get; set; }
    }
}
