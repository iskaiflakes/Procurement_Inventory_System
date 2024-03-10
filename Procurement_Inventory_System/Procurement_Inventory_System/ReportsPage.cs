using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procurement_Inventory_System
{
    public partial class ReportsPage : UserControl
    {
        protected string[] reports = { "Inventory Value Report", "Purchase Report", "Price Dynamic Report" };
        private const int PageSize = 10; // Number of records per page
        private int currentPage = 1;
        private DataTable dataTable;
        protected string fromDate;
        protected string toDate;
        string query;

        public ReportsPage()
        {
            InitializeComponent();
            LoadReports();
            LoadData();
            itembox.Visible = false;
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
            CurrentReports.report_query = query;
            
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
            GenerateReportWindow generateReport = new GenerateReportWindow();
            generateReport.ShowDialog();
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
            if (itemName.SelectedIndex == -1)
            {
                itemName.SelectedIndex = 0;
                DateTime currentDate = DateTime.Today;

                // Get the first day of the month
                DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
                dateTimePicker1.Text = firstDayOfMonth.ToString();

                // Get the last day of the month + 1 day
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1);
                dateTimePicker2.Text = lastDayOfMonth.ToString();

                if (firstDayOfMonth <= lastDayOfMonth)
                {
                    fromDate = firstDayOfMonth.ToString("yyyy-MM-dd");
                    toDate = lastDayOfMonth.ToString("yyyy-MM-dd");
                }
            }
            switch (itemName.SelectedIndex)
            {
                case 0:
                    query = $"select InventoryValueReport.item_id as [Item ID], InventoryValueReport.item_name as [Item Name],  CONCAT(InventoryValueReport.Quantity, ' '+Item_Inventory.unit) as [Quantity], InventoryValueReport.unit_price as [Unit Price (₱)], total_price as [Total Price (₱)], consumption_rate as [Consumption Rate (%)], supplier_name as [Supplier], latest_order_date as [Latest Order Date] from InventoryValueReport inner join Item_Inventory on Item_Inventory.item_id=InventoryValueReport.item_id WHERE latest_order_date >= '{fromDate}' AND latest_order_date <= '{toDate}' order by InventoryValueReport.item_name";
                    FillPage(query);
                    currentPage = 1;
                    itembox.Visible = false;
                    break;
                case 1:
                    query = $"select quotation_id as [Quotation ID],purchaseReportView.item_id as [Item ID], item_name as [Item Name], unit_price as [Unit Price(₱)], Concat(total_quantity, ' '+Item_Inventory.unit) as [Quantity],  [TOTAL ITEM PRICE] as [Total Item Price (₱)],supplier_name as [Supplier],[Latest Order Date] from purchaseReportView inner join Item_Inventory on purchaseReportView.item_id=Item_Inventory.item_id where [LATEST ORDER DATE] >= '{fromDate}' AND [LATEST ORDER DATE] <= '{toDate}' order by [LATEST ORDER DATE] desc";
                    FillPage(query);
                    currentPage = 1;
                    itembox.Visible = false;
                    break;
                case 2:
                    query = $"select item_id as [Item ID], item_name as [Item Name], unit_price as [Current Price (₱)], previous_price as[Previous Price (₱)], price_change as [Price Change (₱)], percentage_change as [Price Change (%)], purchase_order_date as [Latest Order Date] from Price_Dynamic_Report WHERE purchase_order_date >= '{fromDate}' AND purchase_order_date <= '{toDate}' order by purchase_order_date desc";
                    FillPage(query);
                    LoadItemBox();
                    currentPage = 1;
                    break;
            }
            CurrentReports.report_index=itemName.SelectedIndex;
        }
        private string ToSqlDateTime(DateTime dateTime)
        {
            // Convert the DateTime object to SQL Server datetime format
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void itemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value != DateTime.MinValue) // Check if a date is selected
            {
                // Get the selected date from the DateTimePicker control
                DateTime selectedDate = dateTimePicker1.Value;
                toDate = ToSqlDateTime(selectedDate);

                // Get the first day of the month
                DateTime nextMonthDate = selectedDate.AddMonths(1);
                dateTimePicker2.Text = nextMonthDate.ToString();

                if (selectedDate <= nextMonthDate)
                {
                    fromDate = selectedDate.ToString("yyyy-MM-dd");
                    toDate = nextMonthDate.ToString("yyyy-MM-dd");
                }

                // Now 'selectedDate' contains the value of the selected date
            }
            else
            {
                MessageBox.Show("error");
            }
            
            LoadData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value != DateTime.MinValue) // Check if a date is selected
            {
                // Get the selected date from the DateTimePicker control
                DateTime selectedDate = dateTimePicker2.Value;
                DateTime nextDay = selectedDate.AddDays(1);
                toDate = ToSqlDateTime(nextDay); ;

                // Now 'selectedDate' contains the value of the selected date
            }
            else
            {
                MessageBox.Show("error");
            }
            
            LoadData();
        }

        private void LoadItemBox()
        {
            itembox.Visible = true;
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "select distinct item_name from Price_Dynamic_Report order by item_name "; // select all department name
            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            itembox.Items.Clear();


            // Add each category to the ComboBox
            while (dr.Read())
            {
                string items = dr["item_name"].ToString();
                itembox.Items.Add(items);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();
            itembox.SelectedItem = null;
            itembox.SelectedText = null;
        }

        private void itembox_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = $"select item_id as [Item ID], item_name as [Item Name], unit_price as [Current Price (₱)], previous_price as[Previous Price (₱)], price_change as [Price Change (₱)], percentage_change as [Price Change (%)], purchase_order_date as [Latest Order Date] from Price_Dynamic_Report WHERE item_name = '{itembox.Text}' and purchase_order_date >= '{fromDate}' AND purchase_order_date <= '{toDate}' order by purchase_order_date desc";
            FillPage(query);
            currentPage = 1;
        }
    }

    public static class CurrentReports
    {
        public static string[] report_type ={ "Inventory Value Report", "Purchase Report", "Price Dynamic Report" };
        public static int report_index { get; set; }
        public static string report_query { get; set;}

    }
}
