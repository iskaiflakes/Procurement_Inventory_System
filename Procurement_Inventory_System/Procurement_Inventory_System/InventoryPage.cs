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
            LoadInventoryList();
        }

        private void updateinventorybtn_Click(object sender, EventArgs e)
        {
            UpdateInventoryWindow form = new UpdateInventoryWindow(this);
            form.ShowDialog();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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
        public void LoadInventoryList()
        {
            DataTable supply_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string department = CurrentUserDetails.DepartmentId;
            string section = CurrentUserDetails.DepartmentSection;
            string query = $"SELECT ii.item_id AS 'ITEM ID', il.item_name AS 'ITEM NAME', ii.available_quantity AS 'QUANTITY', ii.unit AS 'UNIT', il.active AS 'ACTIVE', il.item_description AS 'DESCRIPTION' FROM Item_Inventory ii JOIN Item_List il ON ii.item_id = il.item_id WHERE il.department_id='{department}' AND il.section_id='{section}' AND il.active=1 ORDER BY il.active, il.item_name;";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(supply_table);
            dataGridView1.DataSource = supply_table;
            db.CloseConnection();
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void searchUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Item Name] LIKE '%{0}%'", searchUser.Text);
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
