﻿using System;
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
    public partial class ItemListPage : UserControl
    {
        private const int PageSize = 23; // Number of records per page
        private int currentPage = 1;
        private DataTable item_table;

        public ItemListPage()
        {
            InitializeComponent();
        }

        private void ItemListPage_Load(object sender, EventArgs e)
        {
            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                // will only load if the users are either admin, requestor or custodian
                if ((userRole == "11") || (userRole == "13") || (userRole == "15"))
                {
                    LoadItemList();
                }

                if (userRole == "15")
                {
                    updatesplybtn.Visible = false;
                }

                if (userRole == "13")
                {
                    addnewsplybtn.Visible = false;
                    updatesplybtn.Visible = false;
                }
            }
        }
        public void LoadItemList()
        {
            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                // will only load if the users are either admin, requestor or custodian
                if ((userRole == "11") || (userRole == "13") || (userRole == "15"))
                {
                    // Create a new DataTable with the desired schema
                    item_table = new DataTable();
                    item_table.Columns.Add("ITEM ID", typeof(string));
                    item_table.Columns.Add("ITEM NAME", typeof(string));
                    item_table.Columns.Add("DESCRIPTION", typeof(string));
                    item_table.Columns.Add("SECTION ID", typeof(string));
                    item_table.Columns.Add("SUPPLIER", typeof(string));
                    item_table.Columns.Add("ACTIVE", typeof(string)); // Make ACTIVE column a string

                    // Populate the new DataTable with data from the database
                    DatabaseClass db = new DatabaseClass();
                    db.ConnectDatabase();
                    string department = CurrentUserDetails.DepartmentId;
                    string section = CurrentUserDetails.DepartmentSection;

                    string query = "";

                    if ((CurrentUserDetails.BranchId == "MOF") && (userRole == "11"))  // if the Branch is Main Office and an ADMIN, all of the item lists are visible
                    {
                        query = "SELECT il.item_id, il.item_name, il.item_description, il.section_id, su.supplier_name, il.active FROM Item_List il JOIN Supplier su ON il.supplier_id=su.supplier_id ORDER BY il.item_name";
                    }
                    else // if the branch is not MOF, three authorized users will have an access (admin, custodian and requestor)
                    {
                        if ((userRole == "11") || (userRole == "15")) // if the user is admin or custodian, they will have the access to see all the item lists within the branch
                        {
                            query = $"SELECT il.item_id, il.item_name, il.item_description, il.section_id, su.supplier_name, il.active FROM Item_List il JOIN Supplier su ON il.supplier_id=su.supplier_id JOIN DEPARTMENT ON il.department_id = DEPARTMENT.DEPARTMENT_ID WHERE DEPARTMENT.BRANCH_ID = '{CurrentUserDetails.BranchId}' ORDER BY il.item_name";
                        }
                        else if (userRole == "13") // if the user is a requestor, he or she will only have the access to view their own section department inventory
                        {
                            query = $"SELECT il.item_id, il.item_name, il.item_description, il.section_id, su.supplier_name, il.active FROM Item_List il JOIN Supplier su ON il.supplier_id=su.supplier_id WHERE il.department_id='{department}' AND il.section_id='{section}' ORDER BY il.item_name";
                        }
                    }

                    SqlDataAdapter da = db.GetMultipleRecords(query);
                    DataTable temp_table = new DataTable();
                    da.Fill(temp_table);
                    db.CloseConnection();

                    // Convert ACTIVE column values from 0/1 to Inactive/Active and import rows
                    foreach (DataRow row in temp_table.Rows)
                    {
                        DataRow newRow = item_table.NewRow();
                        newRow["ITEM ID"] = row["item_id"].ToString();
                        newRow["ITEM NAME"] = row["item_name"].ToString();
                        newRow["DESCRIPTION"] = row["item_description"].ToString();
                        newRow["SECTION ID"] = row["section_id"].ToString();
                        newRow["SUPPLIER"] = row["supplier_name"].ToString();
                        newRow["ACTIVE"] = row["active"].ToString() == "1" ? "Active" : "Inactive";
                        item_table.Rows.Add(newRow);
                    }

                    DisplayCurrentPage();

                    // Populate filter dropdowns
                    PopulateStatus();
                    PopulateSupplier();
                }
            }
        }

        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, item_table.Rows.Count - 1);

            DataTable pageTable = item_table.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(item_table.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
            FilterData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (item_table != null)
            {
                if (currentPage < (item_table.Rows.Count + PageSize - 1) / PageSize)
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

        private void SelectDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        private void FilterData()
        {
            DataTable dt = (dataGridView1.DataSource as DataTable);

            if (dt != null)
            {
                string statusFilter = SelectStatus.SelectedIndex > 0 ? SelectStatus.SelectedItem.ToString() : null;
                string supplierFilter = SelectSupplier.SelectedIndex > 0 ? SelectSupplier.SelectedItem.ToString() : null;
                string searchFilter = searchUser.Text != "item id, item name" && !string.IsNullOrEmpty(searchUser.Text) ? searchUser.Text : null;

                StringBuilder filter = new StringBuilder();

                if (!string.IsNullOrEmpty(statusFilter))
                {
                    filter.Append($"[ACTIVE] = '{statusFilter}'");
                }

                if (!string.IsNullOrEmpty(supplierFilter))
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"SUPPLIER = '{supplierFilter}'");
                }
                if (!string.IsNullOrEmpty(searchFilter))
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"([ITEM ID] LIKE '%{searchFilter}%' OR [ITEM NAME] LIKE '%{searchFilter}%')");
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

        private void AddNewSplyBtnClick(object sender, EventArgs e)
        {
            AddNewItemWindow form = new AddNewItemWindow(this);
            form.ShowDialog();
        }

        private void UpdateSplyBtnClick(object sender, EventArgs e)
        {
            if (ItemListValues.ItemID == null)
            {
                MessageBox.Show("Select an item first.");
            }
            else
            {
                UpdateItemWindow form = new UpdateItemWindow(this, ItemListValues.ItemID, ItemListValues.ItemName, ItemListValues.ItemDescription, ItemListValues.ItemActive);
                form.ShowDialog();
            }
        }

        private void DataGridViewCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ItemListValues.ItemID = dataGridView1.Rows[e.RowIndex].Cells["ITEM ID"].Value.ToString();
                ItemListValues.ItemName = dataGridView1.Rows[e.RowIndex].Cells["ITEM NAME"].Value.ToString();
                ItemListValues.ItemDescription = dataGridView1.Rows[e.RowIndex].Cells["DESCRIPTION"].Value.ToString();
                ItemListValues.ItemSection = dataGridView1.Rows[e.RowIndex].Cells["SECTION ID"].Value.ToString();
                ItemListValues.ItemSupplier = dataGridView1.Rows[e.RowIndex].Cells["SUPPLIER"].Value.ToString();
                ItemListValues.ItemActive = dataGridView1.Rows[e.RowIndex].Cells["ACTIVE"].Value.ToString();
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
            SelectSupplier.SelectedIndex = 0;
            FilterData();
        }
    }
}
    public static class ItemListValues //itemId, itemName, itemDescription, section, supplier, active
    {
        public static string ItemID { get; set; }
        public static string ItemName { get; set; }
        public static string ItemDescription { get; set; }
        public static string ItemSection { get; set; }
        public static string ItemSupplier { get; set; }
        public static string ItemActive { get; set; }
    }

