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
        string[] RolesPermission = { "11", "12", "14" };
        string[] DateRangeItems = { "TODAY", "Last 7 days", "Last Month", "6 Months Ago", "Year Ago", "Custom Range", "Show All" };
        string User_Branch;
        string User_Role;
        bool isMOF;
        string query;
        DateTime today, startDate,endDate;


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
        private void PriceDynamicReport()
        {
            if(isMOF) 
            {
                query = "HELOO3";
            }
            else
            {
                query = "yes filter1";
            }


        }
        private void InventoryValueReport()
        {
            if (isMOF)
            {
                query = "HELOO2";
            }
            else
            {
                query = "yes filter2";
            }


        }
        private void PurchaseReport()
        {
            if (isMOF)
            {
                query = "HELOO1";
            }
            else
            {
                query = "yes filter3";
            }

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
            LoadReports();
            LoadDateRange();
            CheckDateRange();
            CheckReportType();
            if (User_Role == "14")
            {
                PurchasingDeptReport();
            }
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
                    startDate =endDate=today;
                    break;
                case 1:
                    ShowDateLabels(true);
                    DatePickerManager(true, false);
                    startDate =today.AddDays(-7);
                    break;
                case 2:
                    ShowDateLabels(true);
                    DatePickerManager(true, false);
                    startDate = today.AddMonths(-1);
                    break;
                case 3:
                    ShowDateLabels(true);
                    DatePickerManager(true, false);
                    startDate = today.AddMonths(-6);
                    break;
                case 4:
                    ShowDateLabels(true);
                    DatePickerManager(true, false);
                    startDate = today.AddYears(-1);
                    break;
                case 5:
                    ShowDateLabels(true);
                    DatePickerManager(true, true);
                    break;
                default:
                    ShowDateLabels(false);
                    DatePickerManager(false, false);
                    break;
            }
            dateTimePicker1.Value = startDate;
            dateTimePicker2.Value = endDate;

        }

        private void PurchasingDeptReport()
        {
            itemName.SelectedIndex = 2;
            itemName.Enabled = false;
        }

        private void itemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckReportType();
        }

        private void ClearFilters_Click(object sender, EventArgs e)
        {
            LoadReports();
            LoadDateRange();
        }

        private void DateRangebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckDateRange();
        }

        private void ApplyButton(object sender, EventArgs e)
        {
            CheckDateRange();
            CheckReportType();
            MessageBox.Show(isMOF.ToString());
            MessageBox.Show(query);
        }
    }
}


    public static class CurrentReport
    {
        public static string[] All_Reports = { "Inventory Value Report", "Purchase Report", "Price Dynamic Report" };
        public static string ReportQuery { get; set; }
        public static string ReportType { get; set; }
    }
