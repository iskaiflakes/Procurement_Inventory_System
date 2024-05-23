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
    public partial class UpdateInventoryWindow : Form
    {
        private InventoryPage inventoryPage;
        public UpdateInventoryWindow(InventoryPage inventoryPage)
        {
            InitializeComponent();
            this.inventoryPage = inventoryPage;
        }

        private void updateinventorybtn_Click(object sender, EventArgs e)
        {
            int newQuantity;
            bool isQuantityValid = int.TryParse(itemQuant.Text, out newQuantity);
            string newUnit = itemUnit.Text;

            if (!isQuantityValid)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newUnit))
            {
                MessageBox.Show("Please enter a valid unit.");
                return;
            }
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string updateQuery = "UPDATE Item_Inventory SET available_quantity = @newQuantity, unit = @newUnit WHERE item_id = @selectedItemID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, db.GetSqlConnection()))
            {
                cmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                cmd.Parameters.AddWithValue("@newUnit", newUnit);
                cmd.Parameters.AddWithValue("@selectedItemID", InventoryIDNum.InventoryItemID);
                try
                {
                    cmd.ExecuteNonQuery();
                    AuditLog auditLog = new AuditLog();
                    auditLog.LogEvent(CurrentUserDetails.UserID, "Inventory", "Update", InventoryIDNum.InventoryItemID, "Updated an item in inventory");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred while updating the inventory: " + ex.Message);
                }
            }
            db.CloseConnection();
            RefreshInventoryTable();
            this.Close(); // Close the update form
            UpdateInventoryPrompt form = new UpdateInventoryPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateInventoryWindow_Load(object sender, EventArgs e)
        {
            PopulateItemUpdate();
        }
        private void PopulateItemUpdate()
        {
            itemName.Text = InventoryIDNum.InventoryItemName;
            itemQuant.Text = InventoryIDNum.InventoryItemQuantity;
            itemUnit.Text = InventoryIDNum.InventoryItemUnit;
        }
        private void RefreshInventoryTable()
        {
            inventoryPage.LoadInventoryList();
        }
    }
}
