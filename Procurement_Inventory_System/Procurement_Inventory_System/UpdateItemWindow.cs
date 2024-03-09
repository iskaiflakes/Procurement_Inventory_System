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

        private void updateitembtn_Click(object sender, EventArgs e)
        {
            string isActive = "";
            if (radioButton1.Checked == true) { isActive = "1"; } else { isActive = "0"; };
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string updateQuery = $"UPDATE Item_List SET item_description = @itemDescription, active=@isActive WHERE item_id = @itemId";
            using (SqlCommand updateCmd = new SqlCommand(updateQuery, db.GetSqlConnection()))
            {
                updateCmd.Parameters.AddWithValue("@ItemId", itemID.Text);
                updateCmd.Parameters.AddWithValue("@itemDescription", itemDesc.Text);
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
            itemID.Text = itemId;
            itemName.Text = itmName;
            //itemSection.Text = section;
            //supplierName.Text = supplier;
            itemDesc.Text = itemDescription;
            if (active == "1") { radioButton1.Checked = true; } else { radioButton2.Checked = true; };
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