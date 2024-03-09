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
    public partial class AddNewItemWindow : Form
    {
        private ItemListPage itemListPage;
        public AddNewItemWindow(ItemListPage itemListPage)
        {
            InitializeComponent();
            this.itemListPage = itemListPage;
        }

        private void addnewitembtn_Click(object sender, EventArgs e)
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

            SqlTransaction transaction = db.GetSqlConnection().BeginTransaction();

            try
            {
                // Insert into Item_List
                string insertItemQuery = $"INSERT INTO Item_List (item_id, item_name, item_description, supplier_id, department_id, section, active) " +
                                        $"VALUES (@ItemId, @ItemName, @ItemDesc, @SuppId, @DepId, @DeptSection, 1)";
                using (SqlCommand insertItemCmd = new SqlCommand(insertItemQuery, db.GetSqlConnection(), transaction))
                {
                    insertItemCmd.Parameters.AddWithValue("@ItemId", nextItemId);
                    insertItemCmd.Parameters.AddWithValue("@ItemName", itemName.Text);
                    insertItemCmd.Parameters.AddWithValue("@ItemDesc", itemDesc.Text);
                    insertItemCmd.Parameters.AddWithValue("@SuppId", supplierName.SelectedValue);
                    insertItemCmd.Parameters.AddWithValue("@DepId", CurrentUserDetails.DepartmentId);
                    insertItemCmd.Parameters.AddWithValue("@DeptSection", CurrentUserDetails.DepartmentSection);

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
            }
            catch (Exception ex)
            {
                // If an error occurs, roll back the transaction
                transaction.Rollback();
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            RefreshItemListTable();
            AddNewItemPrompt form = new AddNewItemPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddItemWindow_Load(object sender, EventArgs e)
        {
            PopulateItemCategory();
            PopulateItemSupplier();
        }

        private void itemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PopulateItemCategory()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT DISTINCT section FROM Employee WHERE department_id='{CurrentUserDetails.DepartmentId}'"; // Use DISTINCT to get unique values
            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            itemCategory.Items.Clear();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string category = dr["section"].ToString();
                itemCategory.Items.Add(category);
            }

            dr.Close();
            db.CloseConnection();
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

    }
}
