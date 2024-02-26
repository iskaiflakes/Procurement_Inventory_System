using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procurement_Inventory_System
{
    public partial class ReportsPage : UserControl
    {
        protected string[] reports = { "Inventory Report", "Purchase Report", "Issuance Report" };
        private const int PageSize = 2; // Number of records per page
        private int currentPage = 1;
        private DataTable dataTable;

        public ReportsPage()
        {
            InitializeComponent();
            LoadReports();
            LoadData();
        }
        private void LoadReports()
        {
            itemName.Items.Clear();
            itemName.Items.AddRange(reports);

        }
        private void FillPage(string query)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlDataAdapter adapter = db.GetMultipleRecords(query);

            dataTable = new DataTable();
            adapter.Fill(dataTable);
            DisplayCurrentPage();
        }
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, dataTable.Rows.Count - 1);

            DataTable pageTable = dataTable.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(dataTable.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
        }

        private void generaterprtbtn_Click(object sender, EventArgs e)
        {
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage < (dataTable.Rows.Count + PageSize - 1) / PageSize)
            {
                currentPage++;
                DisplayCurrentPage();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }
        }
        private void LoadData()
        {
            string query;
            if (itemName.SelectedIndex == -1)
            {
                itemName.SelectedIndex = 0;
            }
            switch (itemName.SelectedIndex)
            {
                case 0:
                    query = $"select Item_List.item_id as [Item ID],Item_List.item_name as [Name],Item_List.item_description [Description],Supplier.supplier_name as [Supplier],Item_Inventory.available_quantity as [Stock Quantity] from Item_List inner join Item_Inventory on Item_Inventory.item_id = Item_List.item_id inner join Supplier on Supplier.supplier_id = Item_List.supplier_id inner join DEPARTMENT on DEPARTMENT.DEPARTMENT_ID = Item_List.department_id inner join SECTION on SECTION.SECTION_NAME = Item_List.section";
                    FillPage(query);
                    currentPage = 1;
                    break;
                case 1:
                    query = $"select * from Purchase_Order";
                    FillPage(query);
                    currentPage = 1;
                    break;
                case 2:
                    query = $"select * from Supply_Request_Item";
                    FillPage(query);
                    currentPage = 1;
                    break;

            }
        }

        private void itemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
