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
            DataTable supply_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "SELECT ii.item_id AS 'ITEM ID', il.item_name AS 'ITEM NAME', ii.available_quantity AS 'QUANTITY', il.active AS 'ACTIVE', il.item_description AS 'DESCRIPTION' FROM Item_Inventory ii JOIN Item_List il ON ii.item_id = il.item_id ORDER BY il.active, il.item_name;";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(supply_table);
            dataGridView1.DataSource = supply_table;
            db.CloseConnection();
        }

        private void addinventorybtn_Click(object sender, EventArgs e)
        {
            
        }

        private void updateinventorybtn_Click(object sender, EventArgs e)
        {
            
        }

        private void notifyrqstrbtn_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
