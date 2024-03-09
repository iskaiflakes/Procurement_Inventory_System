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
    public partial class ItemListPage : UserControl
    {
        public ItemListPage()
        {
            InitializeComponent();
        }

        private void addnewsplybtn_Click(object sender, EventArgs e)
        {
            AddNewItemWindow form = new AddNewItemWindow(this);
            form.ShowDialog();
        }

        private void updatesplybtn_Click(object sender, EventArgs e)
        {
            if (ItemListValues.ItemID == null)
            {
                MessageBox.Show("Click an item first.");
            }
            else
            {
                UpdateItemWindow form = new UpdateItemWindow(this, ItemListValues.ItemID, ItemListValues.ItemName, ItemListValues.ItemDescription, ItemListValues.ItemSection, ItemListValues.ItemSupplier, ItemListValues.ItemActive);
                form.ShowDialog();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ItemListPage_Load(object sender, EventArgs e)
        {
            LoadItemList();
        }
        public void LoadItemList()
        {
            DataTable item_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string department = CurrentUserDetails.DepartmentId;
            string section = CurrentUserDetails.DepartmentSection;
            string query = $"SELECT il.item_id AS 'ITEM ID', il.item_name AS 'ITEM NAME', il.item_description AS 'DESCRIPTION', il.section AS 'SECTION', su.supplier_name AS SUPPLIER, il.active AS 'ACTIVE' FROM Item_List il JOIN Supplier su ON il.supplier_id=su.supplier_id WHERE il.department_id='{department}' AND il.section='{section}' ORDER BY il.item_name";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(item_table);
            dataGridView1.DataSource = item_table;
            db.CloseConnection();
        }


        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            //
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ItemListValues.ItemID = dataGridView1.Rows[e.RowIndex].Cells["ITEM ID"].Value.ToString();
                ItemListValues.ItemName = dataGridView1.Rows[e.RowIndex].Cells["ITEM NAME"].Value.ToString();
                ItemListValues.ItemDescription = dataGridView1.Rows[e.RowIndex].Cells["DESCRIPTION"].Value.ToString();
                ItemListValues.ItemSection = dataGridView1.Rows[e.RowIndex].Cells["SECTION"].Value.ToString();
                ItemListValues.ItemSupplier = dataGridView1.Rows[e.RowIndex].Cells["SUPPLIER"].Value.ToString();
                ItemListValues.ItemActive = dataGridView1.Rows[e.RowIndex].Cells["ACTIVE"].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
}
