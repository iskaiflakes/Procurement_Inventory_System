using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procurement_Inventory_System
{
    public partial class GenerateReportWindow : Form
    {

        protected string reportPath = @"C:\Users\acct\Documents\GitHub Repos\Procurement_Inventory_System\Procurement_Inventory_System\Procurement_Inventory_System\Report1.rdlc";
        public GenerateReportWindow()
        {
            InitializeComponent();
            LoadFile();

        }
        private void LoadFile()
        {
            // Set the processing mode to local
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

            // Set the LocalReport property to load the report file
            reportViewer1.LocalReport.ReportPath = reportPath;

            // Refresh the report viewer to load the report
            reportViewer1.RefreshReport();
        }


        private void generaterptbtn_Click(object sender, EventArgs e)
        {
            
            

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

        private void GenerateReportWindow_Load(object sender, EventArgs e)
        {
            LoadFile();
            string queryString = "select * from price_dynamics_all";

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlDataAdapter adapter = db.GetMultipleRecords(queryString);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            reportViewer1.SetPageSettings(new PageSettings
            {
                Landscape = true // Set to false for portrait orientation
            });
            Margins margins = new Margins(50, 50, 50, 50); // Adjust margins as needed
            reportViewer1.SetPageSettings(new PageSettings
            {
                Margins = margins
            });
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dataTable);

            reportViewer1.LocalReport.ReportPath = reportPath;


            // Create a report data source and add it to the report viewer
            reportViewer1.LocalReport.DataSources.Add(source);


            // Refresh the report viewer
            reportViewer1.RefreshReport();
        }
    }
}
