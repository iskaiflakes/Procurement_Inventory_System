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
        protected string[] reports = { "Inventory Value Report", "Purchase Report", "Price Dynamic Report" };
        private const int PageSize = 10; // Number of records per page
        private int currentPage = 1;
        private DataTable dataTable;
        protected string fromDate;
        protected string toDate;

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
            string query;
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
                    query = $"WITH CTE AS (SELECT *,ROW_NUMBER() OVER (PARTITION BY item_id ORDER BY date DESC, unit_price DESC) AS RowNum FROM LatestInventoryValues WHERE date >= '{fromDate}' AND date <= '{toDate}') SELECT item_id,item_name,supplier_name,unit_price,Quantity, (unit_price*Quantity) as [Total Price], date FROM CTE WHERE RowNum = 1 Order by item_name";
                    FillPage(query);
                    currentPage = 1;
                    break;
                case 1:
                    query = $"select item_id as [Item ID],quotation_id as [Quotation ID], item_name as [Item Name],supplier_name as [Supplier], unit_price as [Unit Price], total_quantity as [Total Quantity], [Total Item Price],[Latest Order Date] from purchaseReportView WHERE [Latest Order Date] >= '{fromDate}' AND [Latest Order Date] <= '{toDate}'";
                    FillPage(query);
                    currentPage = 1;
                    break;
                case 2:
                    query = $"select item_id as [Item ID],quotation_id as [Quotation ID], item_name as [Item Name],supplier_name as [Supplier], unit_price as [Unit Price], item_quantity as [Quantity], purchase_order_date as [Order Date] from price_dynamics_all WHERE purchase_order_date >= '{fromDate}' AND purchase_order_date <= '{toDate}'";
                    FillPage(query);
                    currentPage = 1;
                    break;

            }
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
    }
}
