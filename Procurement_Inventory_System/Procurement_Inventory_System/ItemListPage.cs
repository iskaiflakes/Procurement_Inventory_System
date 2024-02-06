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
            UpdateItemWindow form = new UpdateItemWindow();
            form.ShowDialog();
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
            string query = $"SELECT il.item_id AS 'ITEM ID', il.item_name AS 'ITEM NAME', il.item_description AS 'DESCRIPTION', il.category AS 'SECTION', il.active AS 'ACTIVE' FROM Item_List il JOIN Supplier su ON il.supplier_id=su.supplier_id WHERE il.department_id='{department}' AND il.category='{section}' ORDER BY il.item_name";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(item_table);
            dataGridView1.DataSource = item_table;
            db.CloseConnection();
        }
    }
}
