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
        public AddNewItemWindow()
        {
            InitializeComponent();
        }

        private void addnewitembtn_Click(object sender, EventArgs e)
        {
            //the table must be refreshed after pressing the button
            //to reflect the supply record instance in the table
            DatabaseClass db = new DatabaseClass();
            string idPrefix = "IL-" + DateTime.Now.ToString("yyyyMMdd");
            string lastIdQuery = $"SELECT TOP 1 item_id FROM Item_List WHERE item_id LIKE '{idPrefix}-%' ORDER BY item_id DESC";
            string nextItemId = $"{idPrefix}-001"; // Default if no items found for today
            db.ConnectDatabase();
            SqlDataReader dr = db.GetRecord(lastIdQuery);
            if (dr != null)
            {
                string lastId = dr["item_id"].ToString();
                int lastNumber = int.Parse(lastId.Split('-')[2]);
                nextItemId = $"{idPrefix}-{(lastNumber + 1):D3}";
            }
            string insertQuery = $"INSERT INTO Item_List VALUES (@ItemId, @ItemName, @ItemDesc, @SuppId, @DepId,@DeptSection, 1)";
            using (SqlCommand insertCmd = new SqlCommand(insertQuery, db.GetSqlConnection()))
            {
                insertCmd.Parameters.AddWithValue("@ItemId", nextItemId);
                insertCmd.Parameters.AddWithValue("@ItemName", itemName.Text);
                insertCmd.Parameters.AddWithValue("@ItemDesc", itemDesc.Text);
                insertCmd.Parameters.AddWithValue("@SuppId", supplierName.SelectedValue);
                insertCmd.Parameters.AddWithValue("@DepId", CurrentUserDetails.DepartmentId);
                insertCmd.Parameters.AddWithValue("@DeptSection", CurrentUserDetails.DepartmentSection);

                insertCmd.ExecuteNonQuery();
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
        }

        private void itemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PopulateItemCategory()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "SELECT DISTINCT category FROM Item_List"; // Use DISTINCT to get unique values
            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            itemCategory.Items.Clear();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string category = dr["category"].ToString();
                itemCategory.Items.Add(category);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();
        }
        private void PopulateItemSupplier()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "SELECT DISTINCT supplier_name FROM Supplier su JOIN Item_List il ON su.supplier_id=il.supplier_id"; // Use DISTINCT to get unique values
            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            itemCategory.Items.Clear();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string category = dr["category"].ToString();
                itemCategory.Items.Add(category);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();
        }
        public void RefreshItemListTable()
        {

        }

    }
}
