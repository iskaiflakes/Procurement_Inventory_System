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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Procurement_Inventory_System.Procurement_Inventory_SystemDataSet;
using System.Xml.Linq;

namespace Procurement_Inventory_System
{
    public partial class UpdateInventoryWindow : Form
    {
        private InventoryPage inventoryPage;
        private bool goUpdateItem;
        public UpdateInventoryWindow(InventoryPage inventoryPage)
        {
            InitializeComponent();
            this.inventoryPage = inventoryPage;
            itemQuant.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
        }
        private bool isValidInput(string name)
        {
            if (name == "") { return false; }
            else { return true; }
        }

        private void updateinventorybtn_Click(object sender, EventArgs e)
        {
            if (goUpdateItem)
            {
                int newQuantity;
                bool isQuantityValid = int.TryParse(itemQuant.Text, out newQuantity);
                string newUnit = itemUnit.Text;

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
                        db.CloseConnection();
                        RefreshInventoryTable();
                        this.Close(); // Close the update form
                        UpdateInventoryPrompt form = new UpdateInventoryPrompt();
                        form.ShowDialog();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("An error occurred while updating the inventory: " + ex.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Check updated information");
            }
            
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
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a control key (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Suppress the key press event
                e.Handled = true;
            }
        }
        public void Unit_Validated(object sender, EventArgs e)
        {
            if (isValidInput(itemUnit.Text))
            {
                errorProvider1.SetError(itemUnit, string.Empty);
                goUpdateItem = true;
            }
            else
            {
                errorProvider1.SetError(itemUnit, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateItem = false;
            }
        }
    }

}
