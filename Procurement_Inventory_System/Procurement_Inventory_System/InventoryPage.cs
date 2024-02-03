using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            supply_table.Columns.Add("Item ID", typeof(string));
            supply_table.Columns.Add("Name", typeof(string));
            supply_table.Columns.Add("Supplier", typeof(string));
            supply_table.Columns.Add("Item Status", typeof(string));
            supply_table.Columns.Add("Details", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = supply_table;
        }
    }
}
