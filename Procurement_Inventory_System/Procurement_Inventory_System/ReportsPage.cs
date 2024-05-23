using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
        protected string query;

        public ReportsPage()
        {
            InitializeComponent();
            LoadReports();
            itemName.SelectedIndex = 0;

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
       
        private string ToSqlDateTime(DateTime dateTime)
        {
            // Convert the DateTime object to SQL Server datetime format
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void itemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            CurrentReports.report_index = itemName.SelectedIndex;
            defaultDate();
            switch(itemName.SelectedIndex)
            {
                case 0:
                    itembox.Enabled = true;
                    LoadBox();
                    label4.Visible = true;
                    label4.Text = "Filter Properties";
                    itembox.SelectedIndex = 0;
                    LoadInventoryValueReport_all();
                    break;
                case 1:
                    itembox.Visible = false;
                    itembox.Enabled = false;
                    label4.Visible = false;
                    dateTimePicker1.Visible = true;
                    dateTimePicker2.Visible = true;
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    LoadPurchaseReport();
                    break;
                case 2:
                    
                    label4.Visible = true;
                    label4.Text = "Filter by Item";
                    LoadItemBox();
                    itembox.Enabled = true;
                    itembox.Visible = true;
                    itembox.Text = string.Empty;
                    if(itembox.Text != string.Empty)
                    {
                        dateTimePicker1.Enabled = true;
                        dateTimePicker2.Enabled = true;
                        dateTimePicker1.Visible = true;
                        dateTimePicker2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        LoadPriceDynamic();
                    }
                    else
                    {
                        dateTimePicker1.Enabled = false;
                        dateTimePicker2.Enabled = false;
                        dateTimePicker1.Visible = false;
                        dateTimePicker2.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                        label3.Visible = false;
                        LoadAllPriceDynamic();
                    }
                    
                    
                    break;
            }
            RefreshReport();
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
                RefreshReport();
                // Now 'selectedDate' contains the value of the selected date
            }
            else
            {
                MessageBox.Show("error");
            }
            

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
                RefreshReport();
            }
            else
            {
                MessageBox.Show("error");
            }
            
        }
        private void defaultDate()
        {
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
        private void LoadBox()
        {
            itembox.SelectedText = string.Empty;
            string[] show = { "Show All", "Filter by Date" };
            itembox.Visible = true;
            itembox.Items.Clear();
            itembox.Items.AddRange(show);


        }

        private void LoadItemBox(string query ="")
        {

            itembox.Items.Clear();
            itembox.Visible = true;
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            if (CurrentUserDetails.BranchId == "MOF")
            {
                query = "select distinct item_name from Price_Dynamic_Report order by item_name "; // select all department name
            }
            else
            {
                query = $"select distinct Price_Dynamic_Report.item_name from Price_Dynamic_Report inner join Item_List on Item_List.item_id=Price_Dynamic_Report.item_id where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}' order by item_name "; // select all department name
            }
            
            SqlDataReader dr = db.GetRecord(query);



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
            itembox.SelectedText = string.Empty;
            itembox.Text = "";
        }

        private void itembox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentReports.report_index == 0)
            {
                if (itembox.Text == "Filter by Date")
                {
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    dateTimePicker1.Visible = true;
                    dateTimePicker2.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    LoadInventoryValueReport_filtered();
                }
                else
                {
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    label1.Visible = false;
                    label2.Visible=false;
                    label3.Visible=false;
                    LoadInventoryValueReport_all();
                }
            }
            else if (CurrentReports.report_index == 2)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                LoadAllPriceDynamic();

            }
            else
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
            }
            RefreshReport();

        }

        private void LoadLabel1(string title, string query, string column)
        {
            title1.Text = title;
            data1.Text = "";
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlDataReader dr = db.GetRecord(query);

            var dataContent = new List<string>();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                if (dr[column] != null)
                {
                    string items = dr[column].ToString();
                    dataContent.Add(items);
                }
                else
                {
                    break;
                }
                
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();
            foreach (var item in dataContent)
            {
                try
                {
                    float floatValue = float.Parse(item);
                    string formattedNumber = floatValue.ToString("0.00");
                    data1.Text += $"₱{formattedNumber}";
                }catch (Exception)
                {
                    data1.Text = $"₱0.00";
                }

                
            }
        }
        private void LoadLabel2(string title, string query, string column)
        {
            title2.Text = title;
            data2.Text = string.Empty;
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlDataReader dr = db.GetRecord(query);

            var dataContent = new List<string>();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string items = dr[column].ToString();
                dataContent.Add(items);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();

            foreach (var item in dataContent)
            {

                if (CurrentReports.report_index == 2)
                {
                    data2.Text = $"₱{item}";
                }
                else
                {
                    data2.Text += $"{item}\n";
                }
            }

        }
        private void LoadLabel3(string title, string query, string column)
        {
            title3.Text = title;
            data3.Text = "";
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlDataReader dr = db.GetRecord(query);

            var dataContent = new List<string>();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string items = dr[column].ToString();
                dataContent.Add(items);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();

            foreach (var item in dataContent)
            {
                if (CurrentReports.report_index == 2)
                {
                    data3.Text = $"₱{item}";
                }
                else
                {
                    data3.Text += $"{item}\n";
                }
                
            }

        }
        private void LoadInventoryValueReport_all()
        {
            string branchCondition = CurrentUserDetails.BranchId == "MOF" ? "" : $"inner join Item_List on Item_List.item_id=InventoryValueReport.item_id where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}'";

            query = $@"
        select 
            InventoryValueReport.item_id as [Item ID], 
            InventoryValueReport.item_name as [Item Name],  
            CONCAT(InventoryValueReport.Quantity, ' '+Item_Inventory.unit) as [Quantity], 
            InventoryValueReport.unit_price as [Unit Price (₱)], 
            total_price as [Total Price (₱)], 
            consumption_rate as [Consumption Rate (%)], 
            supplier_name as [Supplier], 
            coalesce(CONVERT(VARCHAR,latest_order_date),'-') as [Latest Order Date] 
        from 
            InventoryValueReport 
            inner join Item_Inventory on Item_Inventory.item_id=InventoryValueReport.item_id 
            {branchCondition}
        order by 
            InventoryValueReport.item_name";

            LoadLabel1("Total Inventory Value", $"select sum(total_price) as total_price from InventoryValueReport inner join Item_Inventory on Item_Inventory.item_id=InventoryValueReport.item_id {branchCondition}", "total_price");
            LoadLabel2("Fast Moving Item/s", $"SELECT InventoryValueReport.item_name+' - '+FORMAT(InventoryValueReport.consumption_rate, '0.00') + '%' as fast_moving FROM InventoryValueReport INNER JOIN Item_Inventory ON Item_Inventory.item_id = InventoryValueReport.item_id {branchCondition} AND InventoryValueReport.consumption_rate = (SELECT MAX(consumption_rate) FROM InventoryValueReport WHERE latest_order_date IS NOT NULL) AND latest_order_date IS NOT NULL;", "fast_moving");
            LoadLabel3("Slow Moving Item/s", $"SELECT InventoryValueReport.item_name+' - '+FORMAT(InventoryValueReport.consumption_rate, '0.00') + '%' as slow_moving FROM InventoryValueReport INNER JOIN Item_Inventory ON Item_Inventory.item_id = InventoryValueReport.item_id {branchCondition} AND InventoryValueReport.consumption_rate = (SELECT MIN(consumption_rate) FROM InventoryValueReport WHERE latest_order_date IS NOT NULL) AND latest_order_date IS NOT NULL;", "slow_moving");
        }

        private void LoadInventoryValueReport_filtered()
        {
            string commonCondition = $"latest_order_date >= '{fromDate}' AND latest_order_date<= '{toDate}'";
            string branchCondition = CurrentUserDetails.BranchId == "MOF" ? "" : $"inner join Item_List on Item_List.item_id=InventoryValueReport.item_id where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}' and ";

            query = $@"
        select 
            InventoryValueReport.item_id as [Item ID], 
            InventoryValueReport.item_name as [Item Name],  
            CONCAT(InventoryValueReport.Quantity, ' '+Item_Inventory.unit) as [Quantity], 
            InventoryValueReport.unit_price as [Unit Price (₱)], 
            total_price as [Total Price (₱)], 
            consumption_rate as [Consumption Rate (%)], 
            supplier_name as [Supplier], 
            coalesce(CONVERT(VARCHAR,latest_order_date),'-') as [Latest Order Date] 
        from 
            InventoryValueReport 
            inner join Item_Inventory on Item_Inventory.item_id=InventoryValueReport.item_id 
            {branchCondition}
            {commonCondition}
        order by 
            InventoryValueReport.item_name";

            LoadLabel1("Total Inventory Value", $"select sum(total_price) as total_price from InventoryValueReport inner join Item_Inventory on Item_Inventory.item_id=InventoryValueReport.item_id {branchCondition}{commonCondition}", "total_price");
            LoadLabel2("Fast Moving Item/s", $"SELECT InventoryValueReport.item_name+' - '+FORMAT(InventoryValueReport.consumption_rate, '0.00') + '%' as fast_moving FROM InventoryValueReport INNER JOIN Item_Inventory ON Item_Inventory.item_id = InventoryValueReport.item_id {branchCondition}InventoryValueReport.consumption_rate = (SELECT MAX(consumption_rate) FROM InventoryValueReport WHERE latest_order_date IS NOT NULL) AND latest_order_date IS NOT NULL and {commonCondition};", "fast_moving");
            LoadLabel3("Slow Moving Item/s", $"SELECT InventoryValueReport.item_name+' - '+FORMAT(InventoryValueReport.consumption_rate, '0.00') + '%' as slow_moving FROM InventoryValueReport INNER JOIN Item_Inventory ON Item_Inventory.item_id = InventoryValueReport.item_id {branchCondition}InventoryValueReport.consumption_rate = (SELECT MIN(consumption_rate) FROM InventoryValueReport WHERE latest_order_date IS NOT NULL) AND latest_order_date IS NOT NULL and {commonCondition};", "slow_moving");
        }

        private void LoadAllPriceDynamic()
        {
            string branchCondition = CurrentUserDetails.BranchId == "MOF" ? "" : $"where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}'";

            query = $@"
        select 
            Price_Dynamic_Report.item_id as [Item ID], 
            Price_Dynamic_Report.item_name as [Item Name], 
            unit_price as [Current Price (₱)], 
            previous_price as [Previous Price (₱)], 
            price_change as [Price Change (₱)], 
            percentage_change as [Price Change (%)], 
            Supplier.supplier_id as Supplier, 
            purchase_order_date as [Latest Order Date] 
        from 
            Price_Dynamic_Report 
            inner join Item_List on Price_Dynamic_Report.item_id = Item_List.item_id 
            inner join Supplier on Item_List.supplier_id = Supplier.supplier_id 
            {branchCondition} 
        order by 
            purchase_order_date desc";

            title1.Text = "Total Price Change";
            data1.Text = "-";
            title2.Text = "Highest Price of Item";
            data2.Text = "-";
            title3.Text = "Lowest Price of Item";
            data3.Text = "-";
        }

        private void LoadPriceDynamic()
        {
            if (CurrentUserDetails.BranchId == "MOF")
            {
                query = $"select Price_Dynamic_Report.item_id as [Item ID], Price_Dynamic_Report.item_name as [Item Name], unit_price as [Current Price (₱)], previous_price as[Previous Price (₱)], price_change as [Price Change (₱)], percentage_change as [Price Change (%)],Supplier.supplier_id as Supplier, purchase_order_date as [Latest Order Date] from Price_Dynamic_Report inner join Item_List on Price_Dynamic_Report.item_id=Item_List.item_id inner join Supplier on Item_List.supplier_id=Supplier.supplier_id WHERE Price_Dynamic_Report.item_name = '{itembox.Text}' and purchase_order_date >= '{fromDate}' AND purchase_order_date <= '{toDate}' order by purchase_order_date desc";
                LoadLabel1("Total Price Change of Item", $"select sum(price_change) as Price_change from (SELECT Price_Dynamic_Report.item_name, MAX(purchase_order_date) AS max_purchase_order_date, SUM(price_change) AS price_change FROM Price_Dynamic_Report WHERE Price_Dynamic_Report.item_name = '{itembox.Text}' AND purchase_order_date >= '{fromDate}' AND purchase_order_date <= '{toDate}' GROUP BY Price_Dynamic_Report.item_name) as PriceChange", "Price_change");
                LoadLabel2("Highest Price of Item", $"select FORMAT(MAX(unit_price), '0.00')  as price from Price_Dynamic_Report WHERE Price_Dynamic_Report.item_name='{itembox.Text}' AND purchase_order_date >= '{fromDate}' AND purchase_order_date <= '{toDate}'", "price");
                LoadLabel3("Lowest Price of Item", $"select FORMAT(MIN(unit_price), '0.00')  as price from Price_Dynamic_Report WHERE Price_Dynamic_Report.item_name='{itembox.Text}' AND purchase_order_date >= '{fromDate}' AND purchase_order_date <= '{toDate}' ", "price");

            }
            else
            {
                query = $"select Price_Dynamic_Report.item_id as [Item ID], Price_Dynamic_Report.item_name as [Item Name], unit_price as [Current Price (₱)], previous_price as[Previous Price (₱)], price_change as [Price Change (₱)], percentage_change as [Price Change (%)],Supplier.supplier_id as Supplier, purchase_order_date as [Latest Order Date] from Price_Dynamic_Report inner join Item_List on Price_Dynamic_Report.item_id=Item_List.item_id inner join Supplier on Item_List.supplier_id=Supplier.supplier_id where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}' and Price_Dynamic_Report.item_name = '{itembox.Text}' and purchase_order_date >= '{fromDate}' AND purchase_order_date <= '{toDate}' order by purchase_order_date desc";
                LoadLabel1("Total Price Change of Item", $"select sum(price_change) as Price_change from (SELECT Price_Dynamic_Report.item_name, MAX(purchase_order_date) AS max_purchase_order_date, SUM(price_change) AS price_change FROM Price_Dynamic_Report inner join Item_List on Item_List.item_id=Price_Dynamic_Report.item_id where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}' and Price_Dynamic_Report.item_name = '{itembox.Text}' AND purchase_order_date >= '{fromDate}' AND purchase_order_date <= '{toDate}' GROUP BY Price_Dynamic_Report.item_name) as PriceChange", "Price_change");
                LoadLabel2("Highest Price of Item", $"select FORMAT(MAX(unit_price), '0.00')  as price from Price_Dynamic_Report inner join Item_List on Item_List.item_id=Price_Dynamic_Report.item_id where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}' and Price_Dynamic_Report.item_name='{itembox.Text}' AND purchase_order_date >= '{fromDate}' AND purchase_order_date <= '{toDate}'", "price");
                LoadLabel3("Lowest Price of Item", $"select FORMAT(MIN(unit_price), '0.00')  as price from Price_Dynamic_Report inner join Item_List on Item_List.item_id=Price_Dynamic_Report.item_id where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}' and Price_Dynamic_Report.item_name='{itembox.Text}' AND purchase_order_date >= '{fromDate}' AND purchase_order_date <= '{toDate}' ", "price");

            }

        }
        private void LoadPurchaseReport()
        {
            if (CurrentUserDetails.BranchId == "MOF")
            {
                query = $"select quotation_id as [Quotation ID],purchaseReportView.item_id as [Item ID], purchaseReportView.item_name as [Item Name], unit_price as [Unit Price(₱)], Concat(total_quantity, ' '+Item_Inventory.unit) as [Quantity],  [TOTAL ITEM PRICE] as [Total Item Price (₱)],supplier_name as [Supplier],[Latest Order Date] from purchaseReportView inner join Item_Inventory on purchaseReportView.item_id=Item_Inventory.item_id where [LATEST ORDER DATE] >= '{fromDate}' AND [LATEST ORDER DATE] <= '{toDate}' order by [LATEST ORDER DATE] desc";
                LoadLabel1("Total Expenses", $"SELECT SUM([TOTAL ITEM PRICE]) AS total_item_price FROM purchaseReportView INNER JOIN Item_Inventory ON purchaseReportView.item_id = Item_Inventory.item_id WHERE [LATEST ORDER DATE] >= '{fromDate}' AND [LATEST ORDER DATE] <= '{toDate}'", "total_item_price");
                LoadLabel2("Highest Order Item/s", $"SELECT Item_Name +' - '+CONVERT(NVARCHAR,ORDER_COUNT) as highest_orders FROM (SELECT Item_Name, COUNT(item_name) AS ORDER_COUNT, MAX([Latest Order Date]) as latest_order_date FROM purchaseReportView INNER JOIN Item_Inventory ON purchaseReportView.item_id = Item_Inventory.item_id GROUP BY Item_Name) AS OrderCounts WHERE ORDER_COUNT = (SELECT MAX(ORDER_COUNT) FROM (SELECT COUNT(item_name) AS ORDER_COUNT FROM purchaseReportView INNER JOIN Item_Inventory ON purchaseReportView.item_id = Item_Inventory.item_id GROUP BY Item_Name) AS MaxOrderCounts) and latest_order_date >= '{fromDate}' AND latest_order_date <= '{toDate}';", "highest_orders");
                LoadLabel3("Lowest Order Item/s", $"SELECT Item_Name +' - '+CONVERT(NVARCHAR,ORDER_COUNT) as lowest_orders FROM (SELECT Item_Name, COUNT(item_name) AS ORDER_COUNT, MAX([Latest Order Date]) as latest_order_date FROM purchaseReportView INNER JOIN Item_Inventory ON purchaseReportView.item_id = Item_Inventory.item_id GROUP BY Item_Name) AS OrderCounts WHERE ORDER_COUNT = (SELECT MIN(ORDER_COUNT) FROM (SELECT COUNT(item_name) AS ORDER_COUNT FROM purchaseReportView INNER JOIN Item_Inventory ON purchaseReportView.item_id = Item_Inventory.item_id GROUP BY Item_Name) AS MinOrderCounts) and latest_order_date >= '{fromDate}' AND latest_order_date <= '{toDate}'", "lowest_orders");
            }
            else
            {
                query = $"select quotation_id as [Quotation ID],purchaseReportView.item_id as [Item ID], purchaseReportView.item_name as [Item Name], unit_price as [Unit Price(₱)], Concat(total_quantity, ' '+Item_Inventory.unit) as [Quantity],  [TOTAL ITEM PRICE] as [Total Item Price (₱)],supplier_name as [Supplier],[Latest Order Date] from purchaseReportView inner join Item_Inventory on purchaseReportView.item_id=Item_Inventory.item_id inner join Item_List on Item_List.item_id=purchaseReportView.item_id where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}' and [LATEST ORDER DATE] >= '{fromDate}' AND [LATEST ORDER DATE] <= '{toDate}' order by [LATEST ORDER DATE] desc";
                LoadLabel1("Total Expenses", $"SELECT SUM([TOTAL ITEM PRICE]) AS total_item_price FROM purchaseReportView INNER JOIN Item_Inventory ON purchaseReportView.item_id = Item_Inventory.item_id inner join Item_List on Item_List.item_id=purchaseReportView.item_id where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}' and  [LATEST ORDER DATE] >= '{fromDate}' AND [LATEST ORDER DATE] <= '{toDate}'", "total_item_price");
                LoadLabel2("Highest Order Item/s", $"SELECT Item_Name +' - '+CONVERT(NVARCHAR,ORDER_COUNT) as highest_orders FROM (SELECT  purchaseReportView.item_name, COUNT( purchaseReportView.item_name) AS ORDER_COUNT, MAX([Latest Order Date]) as latest_order_date FROM purchaseReportView INNER JOIN Item_Inventory ON purchaseReportView.item_id = Item_Inventory.item_id inner join Item_List on Item_List.item_id=purchaseReportView.item_id where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}' GROUP BY  purchaseReportView.item_name) AS OrderCounts WHERE ORDER_COUNT = (SELECT MAX(ORDER_COUNT) FROM (SELECT COUNT(item_name) AS ORDER_COUNT FROM purchaseReportView INNER JOIN Item_Inventory ON purchaseReportView.item_id = Item_Inventory.item_id GROUP BY Item_Name) AS MaxOrderCounts) and latest_order_date >= '{fromDate}' AND latest_order_date <= '{toDate}';", "highest_orders");
                LoadLabel3("Lowest Order Item/s", $"SELECT Item_Name +' - '+CONVERT(NVARCHAR,ORDER_COUNT) as lowest_orders FROM (SELECT  purchaseReportView.item_name, COUNT( purchaseReportView.item_name) AS ORDER_COUNT, MAX([Latest Order Date]) as latest_order_date FROM purchaseReportView INNER JOIN Item_Inventory ON purchaseReportView.item_id = Item_Inventory.item_id inner join Item_List on Item_List.item_id=purchaseReportView.item_id where LEFT(Item_List.department_id, 3)='{CurrentUserDetails.BranchId}' GROUP BY  purchaseReportView.item_name) AS OrderCounts WHERE ORDER_COUNT = (SELECT MIN(ORDER_COUNT) FROM (SELECT COUNT(item_name) AS ORDER_COUNT FROM purchaseReportView INNER JOIN Item_Inventory ON purchaseReportView.item_id = Item_Inventory.item_id GROUP BY Item_Name) AS MinOrderCounts) and latest_order_date >= '{fromDate}' AND latest_order_date <= '{toDate}'", "lowest_orders");

            }

        }
        private void RefreshReport()
        {
            switch (itemName.SelectedIndex)
            {
                case 0:
                    if (itembox.Text == "Filter by Date")
                    {
                        LoadInventoryValueReport_filtered();
                    }
                    else
                    {
                        LoadInventoryValueReport_all();
                    }
                    break;
                case 1:
                    LoadPurchaseReport();
                    break;
                case 2:
                    if (itembox.Text != string.Empty)
                    {
                        LoadPriceDynamic();
                    }
                    else
                    {
                        itembox.Text = "Show All";
                        LoadAllPriceDynamic();
                    }
                    break;



            }
            FillPage(query);
            currentPage = 1;
        }

        public static class CurrentReports
        {
            public static string[] report_type = { "Inventory Value Report", "Purchase Report", "Price Dynamic Report" };
            public static int report_index { get; set; }
            public static string report_query { get; set; }

        }
    }
}
