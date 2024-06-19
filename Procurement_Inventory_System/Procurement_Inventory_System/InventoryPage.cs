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
        private const int PageSize = 15; // Number of records per page
        private int currentPage = 1;
        private DataTable inventory_table;

        public InventoryPage()
        {
            InitializeComponent();
        }

        private void InventoryPage_Load(object sender, EventArgs e)
        {
            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                // will only load if the users are either admin, requestor or custodian
                if ((userRole == "11") || (userRole == "13") || (userRole == "15"))
                {
                    LoadInventoryList();
                }

                if (userRole == "13")
                {
                    updateinventorybtn.Visible = false;
                }
            }
        }

        public void LoadInventoryList()
        {
            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                // will only load if the users are either admin, requestor or custodian
                if ((userRole == "11") || (userRole == "13") || (userRole == "15"))
                {
                    inventory_table = new DataTable();
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
                    string query = "";

                    if ((CurrentUserDetails.BranchId == "MOF") && (userRole == "11")) // if the Branch is Main Office and an ADMIN, all of the inventory items are visible
                    {
                        query = "SELECT ii.item_id, il.item_name, ii.available_quantity, ii.unit, il.active, il.item_description FROM Item_Inventory ii JOIN Item_List il ON ii.item_id = il.item_id ORDER BY il.active, il.item_name";
                    }
                    else // if the branch is not MOF, three authorized users will have an access (admin, custodian and requestor)
                    {
                        if ((userRole == "11") || (userRole == "15")) // if the user is admin or custodian, they will have the access to see all the inventory items within the branch
                        {
                            query = $"SELECT ii.item_id, il.item_name, ii.available_quantity, ii.unit, il.active, il.item_description FROM Item_Inventory ii \r\nJOIN Item_List il ON ii.item_id = il.item_id \r\nJOIN DEPARTMENT ON DEPARTMENT.DEPARTMENT_ID = il.department_id\r\nWHERE DEPARTMENT.BRANCH_ID = '{CurrentUserDetails.BranchId}'\r\nORDER BY il.active, il.item_name";
                        }
                        else if (userRole == "13")  // if the user is a requestor, he or she will only have the access to view their own section department inventory
                        {
                            query = $"SELECT ii.item_id, il.item_name, ii.available_quantity, ii.unit, il.active, il.item_description FROM Item_Inventory ii JOIN Item_List il ON ii.item_id = il.item_id WHERE il.department_id='{department}' AND il.section_id='{section}' ORDER BY il.active, il.item_name";
                        }
                    }

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
                    DisplayCurrentPage();

                    // Populate filter dropdowns
                    PopulateStatus();
                }
            }        
        }
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, inventory_table.Rows.Count - 1);

            DataTable pageTable = inventory_table.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(inventory_table.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inventory_table != null)
            {
                if (currentPage < (inventory_table.Rows.Count + PageSize - 1) / PageSize)
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

                if (!string.IsNullOrEmpty(statusFilter))
                {
                    filter.Append($"[ACTIVE] = '{statusFilter}'");
                }
                if (!string.IsNullOrEmpty(searchUser.Text) && searchUser.Text != "item id, item name")
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"([Item ID] LIKE '%{searchUser.Text}%' OR [Item Name] LIKE '%{searchUser.Text}%')");
                }
                dt.DefaultView.RowFilter = filter.ToString();
            }
        }

        public void PopulateStatus()
        {
            List<string> accountStatuses = new List<string>
            {
                "(Item Status)", // No filter
                "Active",
                "Inactive"
            };
            SelectStatus.DataSource = accountStatuses;
            SelectStatus.SelectedItem = "Active"; // Set default selection to 'ACTIVATED'
        }

        private void UpdateInventoryBtnClick(object sender, EventArgs e)
        {
            if (InventoryIDNum.InventoryItemID != null)
            {   
                UpdateInventoryWindow form = new UpdateInventoryWindow(this);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select an item first.");
            }

            
        }

        private void SearchUserTextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void DataGridViewCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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

        private void SearchUserEnter(object sender, EventArgs e)
        {
            if (searchUser.Text == "item id, item name")
            {
                searchUser.Text = "";
                searchUser.ForeColor = Color.Black;
            }
        }

        private void SearchUserLeave(object sender, EventArgs e)
        {
            if (searchUser.Text == "")
            {
                searchUser.Text = "item id, item name";
                searchUser.ForeColor = Color.Silver;
            }
        }

        private void ClearFilters_Click(object sender, EventArgs e)
        {
            searchUser.Text = "item id, item name";
            searchUser.ForeColor = Color.Silver;
            this.ActiveControl = ClearFilters;
            SelectStatus.SelectedIndex = 0;
            FilterData();
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
