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
            string dataSource = "DESKTOP-OO08JTF";
            string connectionString = "Data Source=" + dataSource + "\\SQLEXPRESS;Initial Catalog=Procurement_Inventory_System;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT ii.item_id AS 'ITEM ID', il.item_name AS 'ITEM NAME', ii.available_quantity AS 'QUANTITY', il.active AS 'ACTIVE', il.item_description AS 'DESCRIPTION' FROM Item_Inventory ii JOIN Item_List il ON ii.item_id = il.item_id ORDER BY il.item_name;";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(supply_table);
            Console.WriteLine(supply_table);
            dataGridView1.DataSource = supply_table;

            conn.Close();
        }

        private void addnewsplybtn_Click(object sender, EventArgs e)
        {
            AddNewSupplyWindow form = new AddNewSupplyWindow();
            form.ShowDialog();
        }

        private void updatesplybtn_Click(object sender, EventArgs e)
        {
            UpdateSupplyWindow form = new UpdateSupplyWindow();
            form.ShowDialog();
        }

        private void notifyrqstrbtn_Click(object sender, EventArgs e)
        {
            NotifyWindow form = new NotifyWindow();
            form.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
