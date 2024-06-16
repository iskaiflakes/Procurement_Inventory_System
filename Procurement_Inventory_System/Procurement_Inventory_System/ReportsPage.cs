 using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Procurement_Inventory_System.GenerateReportWindow;

namespace Procurement_Inventory_System
{
    public partial class ReportsPage : UserControl
    {
        string[] RolesPermission = { "11", "12", "14" };
        string[] DateRangeItems = { "TODAY", "Last 7 days", "Last Month", "6 Months Ago", "Year Ago", "Custom Range", "Show All" };
        string User_Branch;
        string User_Role;
        bool isMOF;
        string query;
        DateTime today, startDate,endDate;
        DataTable dataTable;
        private const int PageSize = 10; // Number of records per page
        private int currentPage = 1;


        public ReportsPage()
        {
            InitializeComponent();
            GetUserBranch();
            GetUserRole();
            LoadReports();
            LoadDateRange();
            RefreshPage();

        }
        private void GetUserBranch()
        {
            if (CurrentUserDetails.BranchId != null && RolesPermission.Contains(CurrentUserDetails.Role))
            {
                User_Branch = CurrentUserDetails.BranchId;
                if(User_Branch == "MOF") 
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
            label4.Visible  = status;
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
            if(isMOF)
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
            AddDate();

        }
        private void PriceDynamicReport()
        {
            if (isMOF)
            {
                query = "select Price_Dynamic_Report.item_id as [Item ID], Price_Dynamic_Report.item_name as [Item Name], unit_price as [Current Price (₱)], previous_price as [Previous Price (₱)], price_change as [Price Change (₱)], percentage_change as [Price Change (%)], Supplier.supplier_id as Supplier, purchase_order_date as [Latest Order Date] from Price_Dynamic_Report inner join Item_List on Price_Dynamic_Report.item_id = Item_List.item_id inner join Supplier on Item_List.supplier_id = Supplier.supplier_id [date] order by purchase_order_date desc";
            }
            else
            {
                query = $"select Price_Dynamic_Report.item_id as [Item ID], Price_Dynamic_Report.item_name as [Item Name], unit_price as [Current Price (₱)], previous_price as [Previous Price (₱)], price_change as [Price Change (₱)], percentage_change as [Price Change (%)], Supplier.supplier_id as Supplier, purchase_order_date as [Latest Order Date] from Price_Dynamic_Report inner join Item_List on Price_Dynamic_Report.item_id = Item_List.item_id inner join Supplier on Item_List.supplier_id = Supplier.supplier_id where LEFT(Item_List.department_id, 3)='{User_Branch}' [date] order by purchase_order_date desc";
            }
            AddDate();
        }
        
        private void PurchaseReport()
        {
            if (isMOF)
            {
                query = "select quotation_id as [Quotation ID],purchaseReportView.item_id as [Item ID], purchaseReportView.item_name as [Item Name], unit_price as [Unit Price(₱)], Concat(total_quantity, ' '+Item_Inventory.unit) as [Quantity],  [TOTAL ITEM PRICE] as [Total Item Price (₱)],supplier_name as [Supplier],[Latest Order Date] from purchaseReportView inner join Item_Inventory on purchaseReportView.item_id=Item_Inventory.item_id [date] order by [LATEST ORDER DATE] desc";
            }
            else
            {
                query = $"select quotation_id as [Quotation ID],purchaseReportView.item_id as [Item ID], purchaseReportView.item_name as [Item Name], unit_price as [Unit Price(₱)], Concat(total_quantity, ' ' + Item_Inventory.unit) as [Quantity],  [TOTAL ITEM PRICE] as [Total Item Price(₱)],supplier_name as [Supplier],[Latest Order Date] from purchaseReportView inner join Item_Inventory on purchaseReportView.item_id = Item_Inventory.item_id inner join Item_List on Item_List.item_id=purchaseReportView.item_id where LEFT(Item_List.department_id, 3)='{User_Branch}' [date] order by [LATEST ORDER DATE] desc";
            }
            AddDate() ;

        }
        private void CheckReportType()
        {
            switch(itemName.SelectedIndex)
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
                    break;

            }
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
            dateRangebox.DropDownStyle= ComboBoxStyle.DropDownList;
            dateRangebox.SelectedIndex = DateRangeItems.Length - 1;
        }
        private void ShowDateLabels(bool status)
        {
            label1.Visible = status;
            label2.Visible = status;
            label3.Visible = status;
        }
        private void DatePickerManager(bool visible,bool enable)
        {
            dateTimePicker1.Visible = visible;
            dateTimePicker2.Visible = visible;
            dateTimePicker1.Enabled = enable;
            dateTimePicker2.Enabled = enable;
        }
        private void CheckDateRange()
        {
            today= DateTime.Today;
            startDate=endDate=today;
            switch(dateRangebox.SelectedIndex)
            {
                case 0:
                    ShowDateLabels(true);
                    DatePickerManager(true, false);
                    ShowFilterBtn(false);
                    startDate =endDate=today;
                    dateTimePicker1.Value = startDate;
                    dateTimePicker2.Value = endDate;
                    break;
                case 1:
                    ShowDateLabels(true);
                    DatePickerManager(true, false);
                    ShowFilterBtn(false);
                    startDate =today.AddDays(-7);
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
            RefreshPage();
        }
        private void FillPage()
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
    }
}


    public static class CurrentReport
    {
        public static string[] All_Reports = { "Inventory Value Report", "Purchase Report", "Price Dynamic Report" };
        public static string ReportQuery { get; set; }
        public static string ReportType { get; set; }
    }
