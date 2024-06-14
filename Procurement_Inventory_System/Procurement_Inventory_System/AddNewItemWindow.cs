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
using static Procurement_Inventory_System.Procurement_Inventory_SystemDataSet;

namespace Procurement_Inventory_System
{
    public partial class AddNewItemWindow : Form
    {
        private ItemListPage itemListPage;
        public AddNewItemWindow(ItemListPage itemListPage)
        {
            InitializeComponent();
            this.itemListPage = itemListPage;
        }

        private void AddItemWindow_Load(object sender, EventArgs e)
        {
            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);
                if ((userRole == "11") || (userRole == "15"))
                {
                    PopulateDepartmentSect();
                    PopulateItemSupplier();
                }
            }
        }

        private void itemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PopulateDepartmentSect()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";

            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                if ((CurrentUserDetails.BranchId == "MOF") & (userRole == "11"))
                {
                    query = "SELECT DISTINCT SECTION_ID FROM SECTION"; // Use DISTINCT to get unique values
                }
                else
                {
                    if ((userRole == "15") || (userRole == "11"))
                    {
                        query = $"SELECT DISTINCT SECTION_ID FROM SECTION S\r\nINNER JOIN Department D ON S.department_id=D.department_id\r\nINNER JOIN BRANCH B ON D.branch_id=B.branch_id\r\nWHERE B.branch_id = '{CurrentUserDetails.BranchId}'";
                    }
                }

                SqlDataAdapter da = db.GetMultipleRecords(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // Clear existing items to avoid duplication if this method is called more than once
                deptSection.DataSource = null;
                deptSection.DataSource = dt;
                deptSection.DisplayMember = "SECTION_ID";
                deptSection.ValueMember = "SECTION_ID";

                db.CloseConnection();
            }
        }
        private void PopulateItemSupplier()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "SELECT DISTINCT supplier_id, supplier_name FROM Supplier"; // Use DISTINCT to get unique values
            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Clear existing items to avoid duplication if this method is called more than once
            supplierName.DataSource = null;
            supplierName.DataSource = dt;
            supplierName.DisplayMember = "supplier_name";
            supplierName.ValueMember = "supplier_id";

            db.CloseConnection();
        }
        public void RefreshItemListTable()
        {
            if (itemListPage != null)
            {
                itemListPage.LoadItemList();
            }
        }

        private void AddNewItemBtnClick(object sender, EventArgs e)
        {
            
            if ((SupplierValidated())&&(ItemNameValidated())&&(ItemQuantityValidated())&&(UnitValidated()))
            {

                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();

                string idPrefix = "IL-" + DateTime.Now.ToString("yyyyMMdd");
                string lastIdQuery = $"SELECT TOP 1 item_id FROM Item_List WHERE item_id LIKE '{idPrefix}-%' ORDER BY item_id DESC";

                string nextItemId = $"{idPrefix}-001"; // Default if no items found for today

                SqlDataReader dr = db.GetRecord(lastIdQuery);
                if (dr.Read())
                {
                    string lastId = dr["item_id"].ToString();
                    int lastNumber = int.Parse(lastId.Split('-')[2]);
                    nextItemId = $"{idPrefix}-{(lastNumber + 1):D3}";
                }
                dr.Close();

                string deptQuery = $"SELECT DISTINCT department_id FROM SECTION \r\nWHERE section_id = '{deptSection.SelectedValue}'";
                SqlDataReader dr1 = db.GetRecord(deptQuery);
                string dept = "";

                if (dr1.Read())
                {
                    dept = dr1["department_id"].ToString();
                }
                dr1.Close();

                SqlTransaction transaction = db.GetSqlConnection().BeginTransaction();

                try
                {
                    // Insert into Item_List
                    string insertItemQuery = $"INSERT INTO Item_List (item_id, item_name, item_description, supplier_id, department_id, section_id, active) " +
                                            $"VALUES (@ItemId, @ItemName, @ItemDesc, @SuppId, @DepId, @DeptSection, 1)";
                    using (SqlCommand insertItemCmd = new SqlCommand(insertItemQuery, db.GetSqlConnection(), transaction))
                    {
                        insertItemCmd.Parameters.AddWithValue("@ItemId", nextItemId);
                        insertItemCmd.Parameters.AddWithValue("@ItemName", itemName.Text);
                        insertItemCmd.Parameters.AddWithValue("@ItemDesc", itemDesc.Text);
                        insertItemCmd.Parameters.AddWithValue("@SuppId", supplierName.SelectedValue);
                        insertItemCmd.Parameters.AddWithValue("@DepId", dept);
                        insertItemCmd.Parameters.AddWithValue("@DeptSection", deptSection.SelectedValue);

                        insertItemCmd.ExecuteNonQuery();
                    }

                    // para sa Item_Inventory
                    string insertInventoryQuery = $"INSERT INTO Item_Inventory (item_id, available_quantity, unit, date_added, last_updated) " +
                                                 $"VALUES (@ItemId, @ItemQty, @ItemUnit, GETDATE(), NULL)";
                    using (SqlCommand insertInventoryCmd = new SqlCommand(insertInventoryQuery, db.GetSqlConnection(), transaction))
                    {
                        insertInventoryCmd.Parameters.AddWithValue("@ItemId", nextItemId);
                        insertInventoryCmd.Parameters.AddWithValue("@ItemQty", itemQuantity.Text);
                        insertInventoryCmd.Parameters.AddWithValue("@ItemUnit", itemUnit.Text);
                        insertInventoryCmd.ExecuteNonQuery();
                    }

                    // If both inserts succeed, commit the transaction
                    transaction.Commit();
                    AuditLog auditLog = new AuditLog();
                    auditLog.LogEvent(CurrentUserDetails.UserID, "Item List", "Insert", nextItemId, "Added an item to item list");
                }
                catch (Exception ex)
                {
                    // If an error occurs, roll back the transaction
                    MessageBox.Show("An error occurred: " + ex.Message);
                    transaction.Rollback();
                }
                finally
                {
                    db.CloseConnection();
                }

                RefreshItemListTable();
                AddNewItemPrompt form = new AddNewItemPrompt();
                form.ShowDialog();
                itemName.Clear();
                itemDesc.Clear();
                itemQuantity.Clear();
                itemUnit.Clear();
            }
            else
            {
                MessageBox.Show("Check all your fields");
            }
        }

        private void supplier_enter(object sender, EventArgs e)
        {
            supplierName.DroppedDown = true;
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a control key (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Suppress the key press event
                e.Handled = true;
            }
        }
        private void CancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        private bool IsValidQuantity(string input)
        {
            int quantity;
            return int.TryParse(input, out quantity) && quantity >= 0;
        }

        private bool SupplierValidated()
        {
            if (IsValidInput(supplierName.Text))
            {
                errorProvider1.SetError(supplierName, string.Empty);
                return true;
            }
            else
            {
                errorProvider1.SetError(supplierName, "This field is required");
                return false;
            }
        }

        private bool ItemNameValidated()
        {
            if (IsValidInput(itemName.Text))
            {
                errorProvider1.SetError(itemName, string.Empty);
                return true;
            }
            else
            {
                errorProvider1.SetError(itemName, "This field is required");
                return false;
            }
        }

        private bool ItemQuantityValidated()
        {
            if (IsValidQuantity(itemQuantity.Text))
            {
                errorProvider1.SetError(itemQuantity, string.Empty);
                return true;
            }
            else
            {
                errorProvider1.SetError(itemQuantity, "Please enter a non-negative integer");
                return false;
            }
        }

        private bool UnitValidated()
        {
            if (IsValidInput(itemUnit.Text))
            {
                errorProvider1.SetError(itemUnit, string.Empty);
                return true;
            }
            else
            {
                errorProvider1.SetError(itemUnit, "This field is required");
                return false;
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
