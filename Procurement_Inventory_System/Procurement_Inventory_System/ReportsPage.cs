using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Procurement_Inventory_System.GenerateReportWindow;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Procurement_Inventory_System
{
    public partial class ReportsPage : UserControl
    {
        string[] RolesPermission = { "11", "12", "14" };
        string[] DateRangeItems = { "TODAY", "Last 7 days", "Last Month", "6 Months Ago", "Year Ago", "Custom Range", "Show All" };
        string User_Branch;
        string User_Role;
        bool isMOF;
        private bool selectItem = false;
        string query;
        DateTime today, startDate, endDate;
        DataTable dataTable;
        private const int PageSize = 11; // Number of records per page
        private int currentPage = 1;
        private const double FastMovingThreshold = 1.0; // Adjust this value as needed


        public ReportsPage()
        {
            InitializeComponent();
            GetUserBranch();
            GetUserRole();
            LoadReports();
            LoadDateRange();
            LoadItemBox();
            RefreshPage();

        }
        private void GetUserBranch()
        {
            if (CurrentUserDetails.BranchId != null && RolesPermission.Contains(CurrentUserDetails.Role))
            {
                User_Branch = CurrentUserDetails.BranchId;
                if (User_Branch == "MOF")
                {
                    isMOF = true;
                }
                else
                {
                    isMOF = false;
                }
            }
        }
        private void GetUserRole()
        {
            if (CurrentUserDetails.Role != null && RolesPermission.Contains(CurrentUserDetails.Role))
            {
                User_Role = CurrentUserDetails.Role;
            }
        }
        private void ShowLabelBox(bool status)
        {
            label4.Visible = status;
            label4.Text = "Select Item";
            itembox.Visible = status;
            itembox.Enabled = status;
        }
        private void NextBtn(object sender, EventArgs e)
        {
            if (dataTable != null)
            {
                if (currentPage < (dataTable.Rows.Count + PageSize - 1) / PageSize)
                {
                    currentPage++;
                    DisplayCurrentPage();
                }
            }
            else
            {
                MessageBox.Show("No data to show.");
            }
        }
        private void PreviousBtn(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ValidateDates();
        }

        private bool ValidateDates()
        {
            // Retrieve the selected dates
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            // Compare the dates
            if (startDate > endDate)
            {
                // Display validation message
                MessageBox.Show("The start date should not be greater than the end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                // Optionally, you can provide feedback for valid dates
                return true;
            }
        }
        private void ShowFilterBtn(bool status)
        {
            ClearFilters.Visible = status;
            button3.Visible = status;
        }



        private string GetDateQuery()
        {
            string date_query = "";
            switch (itemName.SelectedIndex)
            {
                case 0:
                    date_query = $"and latest_order_date >= '{startDate}' AND latest_order_date<= '{endDate}'"; // with branch filter
                    break;
                case 1:
                    date_query = $"and [LATEST ORDER DATE] >= '{startDate}' AND [LATEST ORDER DATE] <= '{endDate}'"; // with branch filter
                    break;
                case 2:
                    date_query = $"and purchase_order_date >= '{startDate}' AND purchase_order_date <= '{endDate}'"; // with branch filter
                    break;
            }
            if (isMOF)
            {
                date_query.Replace("and", "where");
            }
            return date_query;
        }
        private void AddDate()
        {
            if (dateRangebox.SelectedIndex != dateRangebox.Items.Count - 1)
            {
                query = query.Replace("[date]", GetDateQuery());
            }
            else
            {
                query = query.Replace("[date]", "");
            }

        }
        private void InventoryValueReport()
        {
            if (isMOF)
            {
                query = "select InventoryValueReport.item_id as [Item ID], InventoryValueReport.item_name as [Item Name],  CONCAT(InventoryValueReport.Quantity, ' '+Item_Inventory.unit) as [Quantity], InventoryValueReport.unit_price as [Unit Price (₱)], total_price as [Total Price (₱)], consumption_rate as [Consumption Rate (%)], supplier_name as [Supplier], coalesce(CONVERT(VARCHAR,latest_order_date),'-') as [Latest Order Date] from InventoryValueReport inner join Item_Inventory on Item_Inventory.item_id=InventoryValueReport.item_id [date] order by InventoryValueReport.item_name";
            }
            else
            {
                query = $"select InventoryValueReport.item_id as [Item ID], InventoryValueReport.item_name as [Item Name],  CONCAT(InventoryValueReport.Quantity, ' '+Item_Inventory.unit) as [Quantity], InventoryValueReport.unit_price as [Unit Price (₱)], total_price as [Total Price (₱)], consumption_rate as [Consumption Rate (%)], supplier_name as [Supplier], coalesce(CONVERT(VARCHAR,latest_order_date),'-') as [Latest Order Date] from InventoryValueReport inner join Item_Inventory on Item_Inventory.item_id=InventoryValueReport.item_id inner join Item_List on Item_List.item_id=InventoryValueReport.item_id where LEFT(Item_List.department_id, 3)='{User_Branch}' [date] order by InventoryValueReport.item_name";
            }

        }
        private void PriceDynamicReport()
        {
            if (isMOF)
            {
                query = "select Price_Dynamic_Report.item_id as [Item ID], Price_Dynamic_Report.item_name as [Item Name], unit_price as [Current Price (₱)], previous_price as [Previous Price (₱)], price_change as [Price Change (₱)], percentage_change as [Price Change (%)], Supplier.supplier_id as Supplier, purchase_order_date as [Latest Order Date] from Price_Dynamic_Report inner join Item_List on Price_Dynamic_Report.item_id = Item_List.item_id inner join Supplier on Item_List.supplier_id = Supplier.supplier_id [date][item] order by purchase_order_date desc";
            }
            else
            {
                query = $"select Price_Dynamic_Report.item_id as [Item ID], Price_Dynamic_Report.item_name as [Item Name], unit_price as [Current Price (₱)], previous_price as [Previous Price (₱)], price_change as [Price Change (₱)], percentage_change as [Price Change (%)], Supplier.supplier_id as Supplier, purchase_order_date as [Latest Order Date] from Price_Dynamic_Report inner join Item_List on Price_Dynamic_Report.item_id = Item_List.item_id inner join Supplier on Item_List.supplier_id = Supplier.supplier_id where LEFT(Item_List.department_id, 3)='{User_Branch}' [date][item] order by purchase_order_date desc";
            }

        }

        private void PurchaseReport()
        {
            if (isMOF)
            {
                query = "select quotation_id as [Quotation ID],purchaseReportView.item_id as [Item ID], purchaseReportView.item_name as [Item Name], unit_price as [Unit Price(₱)], Concat(total_quantity, ' '+Item_Inventory.unit) as [Quantity],  [TOTAL ITEM PRICE],supplier_name as [Supplier],[Latest Order Date] from purchaseReportView inner join Item_Inventory on purchaseReportView.item_id=Item_Inventory.item_id [date] order by [LATEST ORDER DATE] desc";
            }
            else
            {
                query = $"select quotation_id as [Quotation ID],purchaseReportView.item_id as [Item ID], purchaseReportView.item_name as [Item Name], unit_price as [Unit Price(₱)], Concat(total_quantity, ' ' + Item_Inventory.unit) as [Quantity],  [TOTAL ITEM PRICE],supplier_name as [Supplier],[Latest Order Date] from purchaseReportView inner join Item_Inventory on purchaseReportView.item_id = Item_Inventory.item_id inner join Item_List on Item_List.item_id=purchaseReportView.item_id where LEFT(Item_List.department_id, 3)='{User_Branch}' [date] order by [LATEST ORDER DATE] desc";
            }

        }
        private void CheckReportType()
        {
            switch (itemName.SelectedIndex)
            {
                case 0:
                    ShowLabelBox(false);
                    InventoryValueReport();
                    break;
                case 1:
                    ShowLabelBox(false);
                    PurchaseReport();
                    break;
                case 2:
                    ShowLabelBox(true);

                    PriceDynamicReport();
                    CheckItem();
                    break;

            }
        }
        private void ShowSummary()
        {
            switch (itemName.SelectedIndex)
            {
                case 0:
                    label10.Visible = false;
                    chart1.Visible = true;
                    GetTotalAmount("TOTAL INVENTORY VALUE", "Total Price (₱)");
                    GetSlowMovingItem();
                    GetFastMovingItem();
                    CreateChart();
                    break;
                case 1:
                    label10.Visible = false;
                    chart1.Visible = true;
                    GetTotalAmount("TOTAL EXPENSES", "TOTAL ITEM PRICE");
                    FindMostAndLeastOrderedItems();
                    Binning();
                    
                    break;
                case 2:
                    if (itembox.SelectedIndex == 0)
                    {
                        FindHighestAndLowestPriceChanges();
                        ShowMainOutput("PRICE CHANGE SUMMARY", $"as of {DateTime.Today}");
                        label10.Visible=true;
                        chart1.Visible = false;
                    }
                    else
                    {
                        label10.Visible = false;
                        chart1.Visible = true;
                        GetTotalPriceChange();
                        GetHighestLowestItemPriceChange();
                        CreateChart1();
                    }

                    break;
            }
        }
        private void Binning()
        {
            switch(dateRangebox.SelectedIndex)
            {
                case 0:
                    BinnedByDays(true);
                    break;
                case 1:
                    BinnedByDays(true);
                    break;
                case 2:
                    BinnedByWeeks(true);
                    break;
                case 3:
                    BinnedByMonths(true);
                    break;
                case 4:
                    BinnedByMonths(true);
                    break;
                case 5:
                    if (CountDays(true) ==0)
                    {
                        BinnedByDays(true);
                    }
                    else if(CountDays(true) < 8 && CountDays(true) > 0)
                    {
                        BinnedByDays(true);
                    }else if (CountDays(true) < 57 && CountDays(true) > 7)
                    {
                        BinnedByWeeks(true);
                    }else if (CountDays(true) >56)
                    {
                        BinnedByMonths(true);
                    }
                    break ;
                default:
                    if(CountDays(false)== 0)
                    {
                        BinnedByHour(false);
                    }
                    else if (CountDays(false) < 8 && CountDays(false) > 0)
                    {
                        BinnedByDays(false);
                    }
                    else if (CountDays(false) < 57 && CountDays(false) > 7)
                    {
                        BinnedByWeeks(false);
                    }
                    else if (CountDays(false) > 56)
                    {
                        BinnedByMonths(false);
                    }
                    break;

            }
        }
        public class ChartData
        {
            public string Date { get; set; }
            public decimal TotalPrice { get; set; }
        }
        private int CountDays(bool status)
        {
            DateTime minDate;
            DateTime maxDate;

            if (status)
            {
                minDate = startDate;
                maxDate = endDate;
            }
            else
            {
                minDate = dataTable.AsEnumerable().Min(row => row.Field<DateTime>("Latest Order Date"));
                maxDate = dataTable.AsEnumerable().Max(row => row.Field<DateTime>("Latest Order Date"));
            }
            TimeSpan difference = maxDate - minDate;
            int numberOfDays = (int)difference.TotalDays;
            return numberOfDays;
        }
        
        private string GetUnit(string itemName)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string unit = "";
            string query = $"select unit from Item_Inventory inner join Item_List on Item_List.item_id=Item_Inventory.item_id where Item_List.item_name='{itemName}'";

            SqlDataReader dr = db.GetRecord(query);
            if (dr.Read())
            {
                unit = dr["unit"].ToString();
            }
            dr.Close();
            db.CloseConnection();
            return unit;
        }

        private void RefreshPage()
        {
            CheckDateRange();
            CheckReportType();
            if (User_Role == "14")
            {
                PurchasingDeptReport();
            }
            AddDate();
            FillPage();
            ShowSummary();
        }
        private void LoadReports()
        {
            itemName.Items.Clear();
            itemName.Items.AddRange(CurrentReport.All_Reports);
            itemName.DropDownStyle = ComboBoxStyle.DropDownList;
            itemName.SelectedIndex = 0;
        }
        private void LoadDateRange()
        {
            dateRangebox.Items.Clear();
            dateRangebox.Items.AddRange(DateRangeItems);
            dateRangebox.DropDownStyle = ComboBoxStyle.DropDownList;
            dateRangebox.SelectedIndex = DateRangeItems.Length - 1;
        }
        private void ShowDateLabels(bool status)
        {
            label1.Visible = status;
            label2.Visible = status;
            label3.Visible = status;
        }
        private void DatePickerManager(bool visible, bool enable)
        {
            dateTimePicker1.Visible = visible;
            dateTimePicker2.Visible = visible;
            dateTimePicker1.Enabled = enable;
            dateTimePicker2.Enabled = enable;
        }
        private void CheckDateRange()
        {
            today = DateTime.Today;
            startDate = endDate = today;
            switch (dateRangebox.SelectedIndex)
            {
                case 0:
                    ShowDateLabels(true);
                    DatePickerManager(true, false);
                    ShowFilterBtn(false);
                    startDate = endDate = today;
                    dateTimePicker1.Value = startDate;
                    dateTimePicker2.Value = endDate;
                    break;
                case 1:
                    ShowDateLabels(true);
                    DatePickerManager(true, false);
                    ShowFilterBtn(false);
                    startDate = today.AddDays(-7);
                    dateTimePicker1.Value = startDate;
                    dateTimePicker2.Value = endDate;
                    break;
                case 2:
                    ShowDateLabels(true);
                    DatePickerManager(true, false);
                    ShowFilterBtn(false);
                    startDate = today.AddMonths(-1);
                    dateTimePicker1.Value = startDate;
                    dateTimePicker2.Value = endDate;
                    break;
                case 3:
                    ShowDateLabels(true);
                    DatePickerManager(true, false);
                    ShowFilterBtn(false);
                    startDate = today.AddMonths(-6);
                    dateTimePicker1.Value = startDate;
                    dateTimePicker2.Value = endDate;
                    break;
                case 4:
                    ShowDateLabels(true);
                    DatePickerManager(true, false);
                    ShowFilterBtn(false);
                    startDate = today.AddYears(-1);
                    dateTimePicker1.Value = startDate;
                    dateTimePicker2.Value = endDate;
                    break;
                case 5:
                    ShowDateLabels(true);
                    DatePickerManager(true, true);
                    ShowFilterBtn(true);
                    startDate = dateTimePicker1.Value;
                    endDate = dateTimePicker2.Value;
                    break;
                default:
                    ShowDateLabels(false);
                    DatePickerManager(false, false);
                    ShowFilterBtn(false);
                    break;
            }
        }

        private void PurchasingDeptReport()
        {
            itemName.SelectedIndex = 2;
            itemName.Enabled = false;
        }

        private void itemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void ClearFilters_Click(object sender, EventArgs e)
        {
            today = DateTime.Today;
            startDate = endDate = today;
            dateTimePicker1.Value = startDate;
            dateTimePicker2.Value = endDate;
            RefreshPage();
        }

        private void DateRangebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void ApplyButton(object sender, EventArgs e)
        {
            if (ValidateDates())
            {
                RefreshPage();
            }

        }
        private void FillPage()
        {
            try
            {
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();

                SqlDataAdapter adapter = db.GetMultipleRecords(query);

                dataTable = new DataTable();
                adapter.Fill(dataTable);
                DisplayCurrentPage();
            }catch(Exception)
            {
                return;
            }
            
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
        private void LoadItemBox()
        {
            itembox.Items.Clear();
            itembox.Visible = true;
            itembox.Items.Add("All");
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            SqlDataReader dr = db.GetRecord(ItemQueryManager());

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string items = dr["item_name"].ToString();
                itembox.Items.Add(items);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();
            itembox.DropDownStyle = ComboBoxStyle.DropDownList;
            itembox.SelectedIndex = 0;
        }

        private void itembox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectItem = true;
            CheckItem();
            RefreshPage();
        }
        private void CheckItem()
        {
            if (itembox.SelectedIndex != 0 && selectItem)
            {
                query = query.Replace("[item]", $"and Price_Dynamic_Report.item_name='{itembox.Text}'");
            }
            else
            {
                query = query.Replace("[item]", "");
            }
        }

        private string ItemQueryManager()
        {
            if (isMOF)
            {
                return "select distinct item_name from Price_Dynamic_Report order by item_name ";
            }
            else
            {
                return $"select distinct Price_Dynamic_Report.item_name from Price_Dynamic_Report inner join Item_List on Item_List.item_id=Price_Dynamic_Report.item_id where LEFT(Item_List.department_id, 3)='{User_Branch}' order by item_name ";
            }
        }


        private void GetTotalAmount(string title, string column_name)
        {
            try
            {
                double total = 0;

                // Iterate through each row in the DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    // Check if the column exists in the DataTable
                    if (dataTable.Columns.Contains(column_name))
                    {
                        // Attempt to convert the cell value to double
                        if (row[column_name] != DBNull.Value && row[column_name] != null)
                        {
                            total += Convert.ToDouble(row[column_name]);
                        }
                        else
                        {
                            // For example, if you want to skip rows with null or DBNull values
                            continue;
                        }
                    }
                    else
                    {
                        throw new ArgumentException($"Column '{column_name}' not found in the DataTable.");
                    }
                }

                // Display the total formatted as currency (using Filipino culture)
                ShowMainOutput(total.ToString("C", new CultureInfo("fil-PH")), title);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GetSlowMovingItem()
        {
            double lowestConsumptionRate = double.MaxValue;
            List<string> slowMovingItems = new List<string>();

            // Assuming your DataTable has columns named "Item Name" and "Consumption Rate (%)"
            foreach (DataRow row in dataTable.Rows)
            {
                double consumptionRate;
                if (double.TryParse(row["Consumption Rate (%)"].ToString(), out consumptionRate))
                {
                    if (consumptionRate < lowestConsumptionRate)
                    {
                        lowestConsumptionRate = consumptionRate;
                        slowMovingItems.Clear();
                        slowMovingItems.Add(row["Item Name"].ToString());
                    }
                    else if (consumptionRate == lowestConsumptionRate)
                    {
                        slowMovingItems.Add(row["Item Name"].ToString());
                    }
                }
            }

            if (slowMovingItems.Any())
            {
                string message = string.Join(", ", slowMovingItems.Take(2)); // Take the first two items

                if (slowMovingItems.Count > 2)
                {
                    int additionalItems = slowMovingItems.Count - 2;
                    message += $", + {additionalItems} more";
                }

                ShowOutput2($"{lowestConsumptionRate.ToString("F2")}%", message, "SLOW MOVING ITEM/S");
            }
            else
            {
                ShowOutput2("No Item", "", "SLOW MOVING ITEM/S");
            }
        }

        private void GetFastMovingItem()
        {
            double highestConsumptionRate = double.MinValue;
            List<string> fastMovingItems = new List<string>();

            // Assuming your DataTable has columns named "Item Name" and "Consumption Rate (%)"
            foreach (DataRow row in dataTable.Rows)
            {
                double consumptionRate;
                if (double.TryParse(row["Consumption Rate (%)"].ToString(), out consumptionRate))
                {
                    if (consumptionRate > highestConsumptionRate)
                    {
                        highestConsumptionRate = consumptionRate;
                        fastMovingItems.Clear();
                        fastMovingItems.Add(row["Item Name"].ToString());
                    }
                    else if (consumptionRate == highestConsumptionRate)
                    {
                        fastMovingItems.Add(row["Item Name"].ToString());
                    }
                }
            }

            if (fastMovingItems.Any())
            {
                string message = string.Join(", ", fastMovingItems.Take(2)); // Take the first two items

                if (fastMovingItems.Count > 2)
                {
                    int additionalItems = fastMovingItems.Count - 2;
                    message += $", + {additionalItems} more";
                }

                ShowOutput1($"{highestConsumptionRate.ToString("F2")}%", message, "FAST MOVING ITEM/S");
            }
            else
            {
                ShowOutput1("No Item", "", "FAST MOVING ITEM/S");
            }
        }

        private void FindMostAndLeastOrderedItems()
        {
            // Group by Item Name and sum quantities
            var grouped = from row in dataTable.AsEnumerable()
                          group row by row.Field<string>("Item Name") into grp
                          select new
                          {
                              ItemName = grp.Key,
                              TotalQuantity = grp.Sum(x => GetQuantity(x.Field<string>("Quantity"))), // Calculate total quantity for each item
                          };

            // Find the most ordered item (maximum total quantity)
            var mostOrderedItem = grouped.OrderByDescending(x => x.TotalQuantity).FirstOrDefault();

            // Find the least ordered item (minimum total quantity)
            var leastOrderedItem = grouped.OrderBy(x => x.TotalQuantity).FirstOrDefault();

            if (mostOrderedItem != null && leastOrderedItem != null)
            {
                // Format the results
                string mostOrderedResult = $"Most Ordered Item: {mostOrderedItem.ItemName} Total Quantity Purchased: {mostOrderedItem.TotalQuantity} {GetUnit(mostOrderedItem.ItemName)}";
                string leastOrderedResult = $"Least Ordered Item: {leastOrderedItem.ItemName} Total Quantity Purchased: {leastOrderedItem.TotalQuantity} {GetUnit(leastOrderedItem.ItemName)}";


                ShowOutput1($"{mostOrderedItem.TotalQuantity} {GetUnit(mostOrderedItem.ItemName)}", $"{mostOrderedItem.ItemName}", "MOST ORDERED ITEM");
                ShowOutput2($"{leastOrderedItem.TotalQuantity} {GetUnit(leastOrderedItem.ItemName)}", $"{leastOrderedItem.ItemName}", "LEAST ORDERED ITEM");
            }
            else
            {
                ShowOutput1($"No record found", $"", "MOST ORDERED ITEM");
                ShowOutput2($"No record found", $"", "LEAST ORDERED ITEM");
            }
        }

        // Helper method to extract quantity from a string like "50 piece"
        private int GetQuantity(string quantityString)
        {
            // Example logic to extract the quantity from the format "50 piece"
            // You need to implement a proper parsing logic based on your data structure
            // Here's a simplistic example assuming the format is consistent
            int quantity = 0;
            if (!string.IsNullOrEmpty(quantityString))
            {
                string[] parts = quantityString.Split(' ');
                if (parts.Length > 0 && int.TryParse(parts[0], out int parsedQuantity))
                {
                    quantity = parsedQuantity;
                }
            }
            return quantity;
        }
        public void FindHighestAndLowestPriceChanges()
        {
            Dictionary<string, double> priceChanges = new Dictionary<string, double>();
            Dictionary<string, double> initialPrices = new Dictionary<string, double>();

            // Populate dictionaries with item names, their cumulative price changes, and initial prices
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {

                    if (row["Item Name"] != DBNull.Value && row["Price Change (₱)"] != DBNull.Value &&
                        row["Previous Price (₱)"] != DBNull.Value && Convert.ToDouble(row["Previous Price (₱)"]) != 0.00)
                    {
                        string itemName = row["Item Name"].ToString();
                        double priceChange = Convert.ToDouble(row["Price Change (₱)"]);
                        double previousPrice = Convert.ToDouble(row["Previous Price (₱)"]);

                        if (!priceChanges.ContainsKey(itemName))
                        {
                            priceChanges[itemName] = priceChange;
                            initialPrices[itemName] = previousPrice;
                        }
                        else
                        {
                            // Aggregate if there are multiple entries for the same item
                            priceChanges[itemName] += priceChange;
                        }
                    }
                }

                // Find highest and lowest price changes
                double highestPriceChange = priceChanges.Values.Any() ? priceChanges.Values.Max() : 0.0;
                double lowestPriceChange = priceChanges.Values.Any() ? priceChanges.Values.Min() : 0.0;

                // Find items with highest and lowest price changes
                List<string> highestItems = new List<string>();
                List<string> lowestItems = new List<string>();

                foreach (var kvp in priceChanges)
                {
                    if (Math.Abs(kvp.Value - highestPriceChange) < 0.0001) // To handle floating point precision issues
                    {
                        highestItems.Add(kvp.Key);
                    }

                    if (Math.Abs(kvp.Value - lowestPriceChange) < 0.0001) // To handle floating point precision issues
                    {
                        lowestItems.Add(kvp.Key);
                    }
                }

                // Calculate percentage changes
                Dictionary<string, double> percentageChanges = new Dictionary<string, double>();
                foreach (var item in priceChanges)
                {
                    string itemName = item.Key;
                    double priceChange = item.Value;
                    double initialPrice = initialPrices[itemName];

                    if (initialPrice != 0.0)
                    {
                        double percentageChange = (priceChange / initialPrice) * 100;
                        percentageChanges[itemName] = percentageChange;
                    }
                    else
                    {
                        percentageChanges[itemName] = 0.0; // Handle division by zero or initial price being zero
                    }
                }

                // Find highest and lowest percentage changes
                double highestPercentageChange = percentageChanges.Values.Any() ? percentageChanges.Values.Max() : 0.0;
                double lowestPercentageChange = percentageChanges.Values.Any() ? percentageChanges.Values.Min() : 0.0;

                // Find items with highest and lowest percentage changes
                List<string> highestPercentageItems = new List<string>();
                List<string> lowestPercentageItems = new List<string>();

                foreach (var kvp in percentageChanges)
                {
                    if (Math.Abs(kvp.Value - highestPercentageChange) < 0.0001) // To handle floating point precision issues
                    {
                        highestPercentageItems.Add(kvp.Key);
                    }

                    if (Math.Abs(kvp.Value - lowestPercentageChange) < 0.0001) // To handle floating point precision issues
                    {
                        lowestPercentageItems.Add(kvp.Key);
                    }
                }

                // Format highest and lowest items text for price change
                string highestItemsText = GetItemsText(highestItems, priceChanges, initialPrices);
                string lowestItemsText = GetItemsText(lowestItems, priceChanges, initialPrices);

                // Format highest and lowest items text for percentage change
                string highestPercentageItemsText = GetItemsText(highestPercentageItems, percentageChanges);
                string lowestPercentageItemsText = GetItemsText(lowestPercentageItems, percentageChanges);

                // Display the highest and lowest price changes with percentage changes
                Console.WriteLine($"Highest Price Change:\nItem(s): {highestItemsText}\nPrice Change: {highestPriceChange:F2} ({highestPercentageItemsText})\n\nLowest Price Change:\nItem(s): {lowestItemsText}\nPrice Change: {lowestPriceChange:F2} ({lowestPercentageItemsText})");
                ShowOutput1($"₱{highestPriceChange.ToString("F2")} ({highestPercentageChange:F2}%)", $"{highestItemsText}", "HIGHEST PRICE CHANGE");
                ShowOutput2($"₱{lowestPriceChange.ToString("F2")} ({lowestPercentageChange:F2}%)", $"{lowestItemsText}", "LOWEST PRICE CHANGE");
            }
            else
            {
                ShowOutput1($"No record found", $"", "HIGHEST PRICE CHANGE");
                ShowOutput2($"No record found", $"", "LOWEST PRICE CHANGE");
            }
            
        }

        private string GetItemsText(List<string> items, Dictionary<string, double> priceChanges, Dictionary<string, double> initialPrices = null)
        {
            const int maxItemsToShow = 3; // Maximum items to show before adding "+ (count) more"

            if (items.Count == 0)
            {
                return "None";
            }

            if (items.Count <= maxItemsToShow)
            {
                return string.Join(", ", items);
            }
            else
            {
                List<string> itemsToShow = items.Take(maxItemsToShow).ToList();
                return string.Join(", ", itemsToShow) + $" + ({items.Count - maxItemsToShow} more)";
            }
        }

        private string GetItemsText(List<string> items, Dictionary<string, double> percentageChanges)
        {
            const int maxItemsToShow = 3; // Maximum items to show before adding "+ (count) more"

            if (items.Count == 0)
            {
                return "None";
            }

            if (items.Count <= maxItemsToShow)
            {
                List<string> itemsWithPercentage = new List<string>();
                foreach (var item in items)
                {
                    itemsWithPercentage.Add($"{item} ({percentageChanges[item]:F2}%)");
                }
                return string.Join(", ", itemsWithPercentage);
            }
            else
            {
                List<string> itemsToShow = items.Take(maxItemsToShow).ToList();
                List<string> itemsWithPercentage = new List<string>();
                foreach (var item in itemsToShow)
                {
                    itemsWithPercentage.Add($"{item} ({percentageChanges[item]:F2}%)");
                }
                return string.Join(", ", itemsWithPercentage) + $" + ({items.Count - maxItemsToShow} more)";
            }
        }

        private void GetTotalPriceChange()
        {
            decimal totalPriceChange = 0;
            if(dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    totalPriceChange += Convert.ToDecimal(row["Price Change (₱)"]);
                }

                // Calculate total price change percentage
                decimal totalPriceChangePercentage = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    decimal priceChangePercentage = Convert.ToDecimal(row["Price Change (%)"]);
                    totalPriceChangePercentage += priceChangePercentage;
                }
                ShowMainOutput($"₱{totalPriceChange:F2} ({totalPriceChangePercentage:F2}%)", "TOTAL PRICE CHANGE");
            }
            else
            {
                ShowMainOutput($"No Record Found", "TOTAL PRICE CHANGE");
            }
        }

        private void GetHighestLowestItemPriceChange()
        {
            if(dataTable.Rows.Count > 1)
            {
                var rows = dataTable.AsEnumerable().Take(dataTable.Rows.Count - 1);

                // Initialize variables to track highest and lowest price changes
                decimal highestPriceChange = decimal.MinValue;
                decimal lowestPriceChange = decimal.MaxValue;

                // Initialize variables to track dates for highest and lowest changes
                DateTime dateHighestChange = DateTime.MinValue;
                DateTime dateLowestChange = DateTime.MinValue;

                // Initialize variables to track highest and lowest percentage changes
                decimal highestPercentageChange = decimal.MinValue;
                decimal lowestPercentageChange = decimal.MaxValue;

                // Iterate through rows and find highest and lowest price and percentage changes
                foreach (var row in rows)
                {
                    decimal priceChange = row.Field<decimal>("Price Change (₱)");
                    decimal percentageChange = row.Field<decimal>("Price Change (%)");
                    DateTime orderDate = row.Field<DateTime>("Latest Order Date");

                    if (priceChange > highestPriceChange)
                    {
                        highestPriceChange = priceChange;
                        highestPercentageChange = percentageChange;
                        dateHighestChange = orderDate;
                    }
                    if (priceChange < lowestPriceChange)
                    {
                        lowestPriceChange = priceChange;
                        lowestPercentageChange = percentageChange;
                        dateLowestChange = orderDate;
                    }
                }
                ShowOutput1($"₱{highestPriceChange.ToString("F2")} ({highestPercentageChange.ToString("F2")}%)", $"on {dateHighestChange}", "HIGHEST PRICE CHANGE");
                ShowOutput2($"₱{lowestPriceChange.ToString("F2")} ({lowestPercentageChange.ToString("F2")}%)", $"on {dateLowestChange}", "LOWEST PRICE CHANGE");
            }
            else
            {
                ShowOutput1($"No data", "", "HIGHEST PRICE CHANGE");
                ShowOutput2($"No data", "", "LOWEST PRICE CHANGE");
            }
            
        }
        private void BinnedByDays(bool status)
        {
            // Check if the DataTable and required columns are not null or empty
            if (dataTable != null && dataTable.Columns.Contains("Latest Order Date") && dataTable.Columns.Contains("Total Item Price"))
            {
                DateTime minDate = DateTime.Today;
                DateTime maxDate = DateTime.Today;
                if (status)
                {
                    minDate = startDate;
                    maxDate = endDate.AddDays(1);
                }
                else
                {
                    minDate = dataTable.AsEnumerable().Min(row => row.Field<DateTime>("Latest Order Date"));
                    maxDate = dataTable.AsEnumerable().Max(row => row.Field<DateTime>("Latest Order Date")).AddDays(1);
                }

                // Generate a list of dates within the range
                List<DateTime> dateRange = Enumerable.Range(0, (maxDate - minDate).Days + 1)
                    .Select(offset => minDate.AddDays(offset))
                    .ToList();

                // Grouping and Summation using LINQ
                var groupedData = from row in dataTable.AsEnumerable()
                                  let orderDate = row.Field<DateTime>("Latest Order Date")
                                  where orderDate >= minDate && orderDate <= maxDate
                                  group row by orderDate.Date into grp
                                  select new
                                  {
                                      Date = grp.Key,
                                      TotalPrice = grp.Sum(r => r.Field<decimal>("Total Item Price"))
                                  };

                // Create a list of ChartData objects
                List<ChartData> chartDataList = new List<ChartData>();
                foreach (var date in dateRange)
                {
                    var dataForDate = groupedData.FirstOrDefault(g => g.Date == date.Date);
                    if (dataForDate != null)
                    {
                        chartDataList.Add(new ChartData { Date = dataForDate.Date.ToShortDateString(), TotalPrice = dataForDate.TotalPrice });
                    }
                    else
                    {
                        chartDataList.Add(new ChartData { Date = date.ToShortDateString(), TotalPrice = 0.00m });
                    }
                }
                // Clear existing chart areas and series
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();


                // Add new chart area
                ChartArea chartArea = new ChartArea();
                chart1.ChartAreas.Add(chartArea);


                Series totalPriceSeries = new Series("Total Price");
                totalPriceSeries.ChartType = SeriesChartType.Column;
                // Add series to the chart

                foreach (var data in chartDataList)
                {
                    string binnedDate = $"{data.Date}";
                    double totalPrice = Convert.ToDouble($"{data.TotalPrice:N2}");

                    totalPriceSeries.Points.AddXY(binnedDate, totalPrice);
                }
                chart1.Series.Add(totalPriceSeries);

                // Optionally customize chart appearance
                chart1.Titles.Clear();
                chart1.Titles.Add("Quantity vs. Total Price Analysis");

                // Refresh chart to display changes
                chart1.Refresh();
                chart1.Dock = DockStyle.Fill;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;

            }
            else
            {
                // Handle the case when the DataTable or required columns are null or empty
                Console.WriteLine("Invalid DataTable or columns.");
            }
            
        }
        private void BinnedByWeeks(bool status)
        {
            // Check if the DataTable and required columns are not null or empty
            if (dataTable != null && dataTable.Columns.Contains("Latest Order Date") && dataTable.Columns.Contains("Total Item Price"))
            {
                DateTime minDate;
                DateTime maxDate;

                if (status)
                {
                    minDate = startDate;
                    maxDate = endDate;
                }
                else
                {
                    minDate = dataTable.AsEnumerable().Min(row => row.Field<DateTime>("Latest Order Date"));
                    maxDate = dataTable.AsEnumerable().Max(row => row.Field<DateTime>("Latest Order Date"));
                }

                List<Item> items = new List<Item>();

                // Convert DataTable rows to a list of Item objects
                foreach (DataRow row in dataTable.Rows)
                {
                    Item item = new Item
                    {
                        Date = row.Field<DateTime>("Latest Order Date"),
                        TotalPrice = row.Field<decimal>("Total Item Price")
                    };
                    items.Add(item);
                }

                // Filter items by the specified date range
                var filteredItems = items.Where(item => item.Date >= minDate && item.Date <= maxDate).ToList();

                // Generate all week start dates within the range
                List<DateTime> weekStartDates = new List<DateTime>();
                DateTime currentWeekStartDate = GetWeekStartDate(minDate);
                while (currentWeekStartDate <= GetWeekStartDate(maxDate))
                {
                    weekStartDates.Add(currentWeekStartDate);
                    currentWeekStartDate = currentWeekStartDate.AddDays(7);
                }

                // Group by week start date and calculate total prices
                var groupedByWeek = filteredItems.GroupBy(
                    item => GetWeekStartDate(item.Date),  // Group by the week start date
                    (key, group) => new { WeekStartDate = key, TotalPrice = group.Sum(item => item.TotalPrice) }
                ).ToDictionary(g => g.WeekStartDate);

                // Clear existing chart areas and series
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();

                // Add new chart area
                ChartArea chartArea = new ChartArea();
                chart1.ChartAreas.Add(chartArea);

                Series totalPriceSeries = new Series("Total Price");
                totalPriceSeries.ChartType = SeriesChartType.Column;

                int weekNumber = 1;
                // Add series to the chart

                foreach (var weekStartDate in weekStartDates)
                {
                    string weekLabel = $"Week {weekNumber} ({weekStartDate.ToShortDateString()})";
                    decimal totalPrice = groupedByWeek.ContainsKey(weekStartDate) ? groupedByWeek[weekStartDate].TotalPrice : 0;


                    // Add points to the series
                    totalPriceSeries.Points.AddXY(weekLabel, Convert.ToDouble(totalPrice));

                    weekNumber++;
                }

                chart1.Series.Add(totalPriceSeries);

                // Optionally customize chart appearance
                chart1.Titles.Clear();
                chart1.Titles.Add("Quantity vs. Total Price Analysis");

                // Refresh chart to display changes
                chart1.Refresh();
                chart1.Dock = DockStyle.Fill;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            }
            else
            {
                // Handle the case when the DataTable or required columns are null or empty
                Console.WriteLine("Invalid DataTable or columns.");
            }
        }

        // Helper function to get the start of the week for a given date
        public static DateTime GetWeekStartDate(DateTime date)
        {
            DayOfWeek firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = date.DayOfWeek - firstDayOfWeek;
            DateTime weekStartDate = date.AddDays(-offset).Date;
            return weekStartDate;
        }
        private void BinnedByMonths(bool status)
        {
            // Check if the DataTable and required columns are not null or empty
            if (dataTable != null && dataTable.Columns.Contains("Latest Order Date") && dataTable.Columns.Contains("Total Item Price"))
            {
                DateTime minDate;
                DateTime maxDate;

                if (status)
                {
                    minDate = startDate;
                    maxDate = endDate;
                }
                else
                {
                    minDate = dataTable.AsEnumerable().Min(row => row.Field<DateTime>("Latest Order Date"));
                    maxDate = dataTable.AsEnumerable().Max(row => row.Field<DateTime>("Latest Order Date"));
                }

                List<Item> items = new List<Item>();

                // Convert DataTable rows to a list of Item objects
                foreach (DataRow row in dataTable.Rows)
                {
                    Item item = new Item
                    {
                        Date = row.Field<DateTime>("Latest Order Date"),
                        TotalPrice = row.Field<decimal>("Total Item Price")
                    };
                    items.Add(item);
                }

                // Generate all months within the date range
                List<DateTime> allMonths = new List<DateTime>();
                DateTime currentMonth = new DateTime(minDate.Year, minDate.Month, 1);
                while (currentMonth <= new DateTime(maxDate.Year, maxDate.Month, 1))
                {
                    allMonths.Add(currentMonth);
                    currentMonth = currentMonth.AddMonths(1);
                }

                // Group items by month and calculate total prices
                var groupedByMonth = items
                    .Where(item => item.Date >= minDate && item.Date <= maxDate)
                    .GroupBy(
                        item => new DateTime(item.Date.Year, item.Date.Month, 1),  // Group by the month (first day)
                        (key, group) => new { MonthStartDate = key, TotalPrice = group.Sum(item => item.TotalPrice) }
                    )
                    .ToDictionary(g => g.MonthStartDate);

                // Prepare data for chart
                Series totalPriceSeries = new Series("Total Price");
                totalPriceSeries.ChartType = SeriesChartType.Column;

                foreach (var month in allMonths)
                {
                    string monthLabel = $"{month.ToString("MMMM yyyy")}";
                    double totalPrice = groupedByMonth.ContainsKey(month) ? Convert.ToDouble(groupedByMonth[month].TotalPrice) : 0;

                    totalPriceSeries.Points.AddXY(monthLabel, totalPrice);
                }

                // Clear existing chart areas and series
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();

                // Add new chart area
                ChartArea chartArea = new ChartArea();
                chart1.ChartAreas.Add(chartArea);

                // Add series to the chart
                chart1.Series.Add(totalPriceSeries);

                // Optionally customize chart appearance
                chart1.Titles.Clear();
                chart1.Titles.Add("Total Sales by Month");

                // Refresh chart to display changes
                chart1.Refresh();
                chart1.Dock = DockStyle.Fill;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            }
            else
            {
                // Handle the case when the DataTable or required columns are null or empty
                Console.WriteLine("Invalid DataTable or columns.");
            }
        }
        private void CreateChart()
        {
            // Clear existing chart areas and series
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            

            // Add new chart area
            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);

            Series quantitySeries = new Series("Quantities");
            quantitySeries.ChartType = SeriesChartType.Column;

            Series totalPriceSeries = new Series("Total Price");
            totalPriceSeries.ChartType = SeriesChartType.Line;
            totalPriceSeries.YAxisType = AxisType.Secondary;
            // Add series to the chart
            foreach (DataRow row in dataTable.Rows)
            {
                string itemName = row["Item Name"].ToString();
                int quantity = Convert.ToInt32(GetQuantity(row["Quantity"].ToString()));
                double totalPrice = Convert.ToDouble(row["Total Price (₱)"]);

                quantitySeries.Points.AddXY(itemName, quantity);
                totalPriceSeries.Points.AddXY(itemName, totalPrice);
            }
            chart1.Series.Add(quantitySeries);
            chart1.Series.Add(totalPriceSeries);

            // Optionally customize chart appearance
            chart1.Titles.Clear();
            chart1.Titles.Add("Quantity vs. Total Price Analysis");

            // Refresh chart to display changes
            chart1.Refresh();
            chart1.Dock = DockStyle.Fill;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
        }
        private void BinnedByHour(bool status)
        {
            // Check if the DataTable and required columns are not null or empty
            if (dataTable != null && dataTable.Columns.Contains("Latest Order Date") && dataTable.Columns.Contains("Total Item Price"))
            {
                DateTime minDate;
                DateTime maxDate;

                if (status)
                {
                    minDate = startDate;
                    maxDate = endDate.AddDays(1);
                }
                else
                {
                    minDate = dataTable.AsEnumerable().Min(row => row.Field<DateTime>("Latest Order Date")).Date;
                    maxDate = dataTable.AsEnumerable().Max(row => row.Field<DateTime>("Latest Order Date")).Date.AddDays(1);
                }
                // Generate all hours within the date range
                List<DateTime> allHours = new List<DateTime>();
                DateTime currentHour = new DateTime(minDate.Year, minDate.Month, minDate.Day, 0, 0, 0);
                while (currentHour <= maxDate)
                {
                    allHours.Add(currentHour);
                    currentHour = currentHour.AddHours(1);
                }

                List<Item> items = new List<Item>();

                // Convert DataTable rows to a list of Item objects
                foreach (DataRow row in dataTable.Rows)
                {
                    MessageBox.Show($"{row.Field<DateTime>("Latest Order Date")}");
                    Item item = new Item
                    {
                        Date = row.Field<DateTime>("Latest Order Date"),
                        TotalPrice = row.Field<decimal>("Total Item Price")
                    };
                    items.Add(item);
                }

                // Group by hour and calculate total prices
                var groupedByHour = allHours
                    .GroupJoin(items,
                        hour => hour,
                        item => new DateTime(item.Date.Year, item.Date.Month, item.Date.Day, item.Date.Hour, 0, 0),
                        (hour, itemGroup) => new { Hour = hour, TotalPrice = itemGroup.Sum(item => item?.TotalPrice ?? 0) }
                    );

                // Clear existing chart areas and series
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();

                // Add new chart area
                ChartArea chartArea = new ChartArea();
                chart1.ChartAreas.Add(chartArea);

                Series totalPriceSeries = new Series("Total Price");
                totalPriceSeries.ChartType = SeriesChartType.Column;

                // Add series to the chart
                foreach (var group in groupedByHour)
                {
                    string hourLabel = $"{group.Hour.ToString("yyyy-MM-dd HH:00")}";
                    double totalPrice = Convert.ToDouble(group.TotalPrice);

                    MessageBox.Show($"{hourLabel} - {totalPrice}");
                    totalPriceSeries.Points.AddXY(hourLabel, totalPrice);
                }

                chart1.Series.Add(totalPriceSeries);

                // Optionally customize chart appearance
                chart1.Titles.Clear();
                chart1.Titles.Add("Total Sales by Hour");

                // Refresh chart to display changes
                chart1.Refresh();
                chart1.Dock = DockStyle.Fill;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            }
            else
            {
                // Handle the case when the DataTable or required columns are null or empty
                Console.WriteLine("Invalid DataTable or columns.");
            }
        }

        private void CreateChart1()
        {
            // Clear existing chart areas and series
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();


            // Add new chart area
            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);


            Series totalPriceSeries = new Series("Total Price");
            totalPriceSeries.ChartType = SeriesChartType.Column;
            totalPriceSeries.YAxisType = AxisType.Secondary;
            // Add series to the chart
            foreach (DataRow row in dataTable.Rows)
            {
                string itemName = row["Latest Order Date"].ToString();
                double totalPrice = Convert.ToDouble(row["Current Price (₱)"]);

                totalPriceSeries.Points.AddXY(itemName, totalPrice);
            }
            chart1.Series.Add(totalPriceSeries);

            // Optionally customize chart appearance
            chart1.Titles.Clear();
            chart1.Titles.Add($"{itembox.Text}");

            // Refresh chart to display changes
            chart1.Refresh();
            chart1.Dock = DockStyle.Fill;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
        }


        private void ShowMainOutput(string data, string title)
        {
            data1.Text = data;
            title1.Text = title;
        }
        private void ShowOutput1(string data, string items, string title)
        {
            data3.Text = data;
            label6.Text = items;
            title3.Text = title;
        }

        private void ShowOutput2(string data, string items, string title)
        {
            data2.Text = data;
            label5.Text = items;
            title2.Text = title;
        }



    }
    public class Item
    {
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }


    public static class CurrentReport
    {
        public static string[] All_Reports = { "Inventory Value Report", "Purchase Report", "Price Dynamic Report" };
        public static string ReportQuery { get; set; }
        public static string ReportType { get; set; }
    }
}

