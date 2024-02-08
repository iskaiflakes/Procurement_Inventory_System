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
    public partial class UpdateItemWindow : Form
    {
        private ItemListPage itemListPage;
        //private InventoryPage itemInventoryPage;
        private string itemId;
        private string itmName;
        private string itemDescription;
        private string section;
        private string supplier;
        private string active;
        public UpdateItemWindow(ItemListPage itemListPage, string strItemId, string strItemName, string strItemDescription, string strSection, string strSupplier, string strActive)
        {
            InitializeComponent();
            itemId = strItemId;
            itmName = strItemName;
            itemDescription = strItemDescription;
            section = strSection;
            supplier = strSupplier;
            active = strActive;
            PopulateFields();
            this.itemListPage = itemListPage;
        }

        private void editbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (editbtn.Checked)
            {
                updateitembtn.Enabled = true;
                itemSection.Enabled = true;
                supplierName.Enabled = true;
                itemDesc.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else
            {
                updateitembtn.Enabled = false;
                itemSection.Enabled = false;
                supplierName.Enabled = false;
                itemDesc.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            //Current all fields are disable
            //add code here to enable all fields for editing...
        }

        private void addnewitembtn_Click(object sender, EventArgs e)
        {
            //the table must be refreshed after pressing the button
            //to reflect the updated supply record instance in the table

            AddNewItemPrompt form = new AddNewItemPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateitembtn_Click(object sender, EventArgs e)
        {
            string isActive = "";
            if (radioButton1.Checked == true) { isActive = "1"; } else { isActive = "0"; };
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string updateQuery = $"UPDATE Item_List SET item_description = @itemDescription, supplier_id = @supplierId, section=@DeptSection, active=@isActive WHERE item_id = @itemId";
            using (SqlCommand updateCmd = new SqlCommand(updateQuery, db.GetSqlConnection()))
            {
                updateCmd.Parameters.AddWithValue("@ItemId", itemID.Text);
                updateCmd.Parameters.AddWithValue("@itemDescription", itemDesc.Text);
                updateCmd.Parameters.AddWithValue("@supplierId", supplierName.SelectedValue);
                updateCmd.Parameters.AddWithValue("@DeptSection", itemSection.SelectedItem);
                updateCmd.Parameters.AddWithValue("@isActive", isActive);

                updateCmd.ExecuteNonQuery();
            }
            db.CloseConnection();
            RefreshItemListTable();
            UpdateItemPrompt form = new UpdateItemPrompt();
            form.ShowDialog();

        }

        private void cancelbtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateItemWindow_Load(object sender, EventArgs e)
        {

        }
        private void PopulateFields()
        {
            PopulateItemSection();
            PopulateItemSupplier();
            itemID.Text = itemId;
            itemName.Text = itmName;
            itemSection.Text = section;
            supplierName.Text = supplier;
            itemDesc.Text = itemDescription;
            if (active == "1") { radioButton1.Checked = true; } else { radioButton2.Checked = true; };
        }
        private void PopulateItemSection()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT DISTINCT section FROM Item_List WHERE department_id='{CurrentUserDetails.DepartmentId}' AND section='{CurrentUserDetails.DepartmentSection}'"; // Use DISTINCT to get unique values
            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            itemSection.Items.Clear();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string category = dr["section"].ToString();
                itemSection.Items.Add(category);
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