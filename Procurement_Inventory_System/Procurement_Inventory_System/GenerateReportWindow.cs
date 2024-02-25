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
    public partial class GenerateReportWindow : Form
    {
        protected string[] reports = { "Inventory Report", "Purchase Report", "Issuance Report" };
        public GenerateReportWindow()
        {
            InitializeComponent();
            LoadReports();
        }
        
        private void LoadReports()
        {
            itemName.Items.Clear();
            itemName.Items.AddRange(reports);

        }

        private void generaterptbtn_Click(object sender, EventArgs e)
        {
            CurrentReport.dateFrom = textBox1.Text;
            CurrentReport.dateTo = textBox2.Text;

            MessageBox.Show($"{reports[itemName.SelectedIndex]}, Date Range:{textBox1.Text} - {textBox2.Text} ");
            switch (itemName.SelectedIndex)
            {
                case 0: InventoryReportWindow inventoryReportWindow = new InventoryReportWindow(); inventoryReportWindow.Show(); break;
                case 1: ProcurementReportWindow procurementReportWindow = new ProcurementReportWindow(); procurementReportWindow.Show(); break;
                case 2: ViewSupplyRequestWindow supplyRequestReportWindow = new ViewSupplyRequestWindow(); supplyRequestReportWindow.Show(); break;
            }
            

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void itemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public static class CurrentReport
        {
            public static string dateFrom {  get; set; }
            public static string dateTo { get; set;}
        }
    }
}
