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
    public partial class SupplierQuotationWindow : Form
    {
        private SupplierQuotationPage quotationListPage;
        public SupplierQuotationWindow(SupplierQuotationPage quotationListPage)
        {
            InitializeComponent();
            this.quotationListPage = quotationListPage;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addquotationbtn_Click(object sender, EventArgs e)
        {
            this.Close();

            // called when saving the user inputs
            StoreDataInput();
            RefreshItemListTable(); // refreshes datagridview in SupplierQuotationPage
        }

        private void SupplierQuotationWindow_Load(object sender, EventArgs e)
        {
            PopulateSupplier(); // called everytime SupplierQuotationWindow Loads
        }

        public void PopulateSupplier()  // populating suppliers in the combobox
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            // populating supplier names in the combobox
            string query1 = "SELECT DISTINCT supplier_id, supplier_name FROM Supplier"; // Use DISTINCT to get unique values
            SqlDataAdapter da = db.GetMultipleRecords(query1);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Clear existing items to avoid duplication if this method is called more than once
            spplrName.DataSource = null;
            spplrName.DataSource = dt;
            spplrName.DisplayMember = "supplier_name";
            spplrName.ValueMember = "supplier_id";

            spplrName.SelectedItem = null;

            db.CloseConnection();
        }

        public void StoreDataInput()    // method for storing user inputs
        {   
            // variables used for ID formattiing
            string idPrefix = "QUO-" + DateTime.Now.ToString("yyyyMMdd");
            string lastIdQuery = $"SELECT TOP 1 quotation_id FROM Quotation WHERE quotation_id LIKE '{idPrefix}-%' ORDER BY quotation_id DESC";
            string nextQuotationId = $"{idPrefix}-001"; // Default if no items found for today (this will be used when no record inside the table yet)

            // variables used for storing the data about the quotation
            string statusVat = "VAT EXCLUDED";
            string userID = CurrentUserDetails.UserID;

            if (vatStatus.SelectedIndex == 0)
            {
                statusVat = "VAT INCLUDED";
            }

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlDataReader dr = db.GetRecord(lastIdQuery);
            if (dr.Read())  // checks if there is a record inside the table
            {
                string lastId = dr["quotation_id"].ToString();
                int lastNumber = int.Parse(lastId.Split('-')[2]);
                nextQuotationId = $"{idPrefix}-{(lastNumber + 1):D3}";
            }
            dr.Close();

            // saving the latest quotation ID
            GetQuotationID.QuotationID = nextQuotationId;

            // performs insert operation 
            string insertCmd = $"INSERT INTO Quotation (quotation_id, supplier_id, vat_status, quotation_date, quotation_validity, quotation_user_id) VALUES('{nextQuotationId}', '{spplrName.SelectedValue}', '{statusVat}', GETDATE(), '{validityDate.Text}', '{userID}');";
            int returnRow = db.insDelUp(insertCmd);

            if (returnRow > 0)  // checks if the insertion was done successfully
            {
                db.CloseConnection();   // closes the db connection to prevent the app from crashing
                AddItemQuotationWindow form = new AddItemQuotationWindow();
                form.ShowDialog();  // goes to another form
            }
        }

        public void RefreshItemListTable()
        {
            if (quotationListPage != null)
            {
                quotationListPage.LoadQuotationData();
            }
        }    
    }
    public static class GetQuotationID
    {
        public static string QuotationID { get; set; }
    }
}
