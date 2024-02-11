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
    public partial class SupplierQuotationPage : UserControl
    {
        
        public SupplierQuotationPage()
        {
            InitializeComponent();
        }

        private void addquotationbtn_Click(object sender, EventArgs e)
        {
            
            SupplierQuotationWindow form = new SupplierQuotationWindow(this);
            form.ShowDialog();
        }

        private void SupplierQuotationPage_Load(object sender, EventArgs e)
        {
            LoadQuotationData();    // called the method for loading quotation data
        }

        public void LoadQuotationData() // Method for loading the quotations
        {
            DataTable quotation_data = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            // restricting user to only see the quotations unders what department and section
            string department = CurrentUserDetails.DepartmentId;
            string section = CurrentUserDetails.DepartmentSection;
            string query = ""; 

            if (department == "MOFHOF") // head office can only view all quotations collected 
            {
                query = "SELECT Quotation.quotation_id AS [QUOTATION ID], Supplier.supplier_name AS [SUPPLIER], Quotation.quotation_date AS [DATE ADDED], Quotation.quotation_validity AS[VALIDITY], Quotation.vat_status AS[VAT STATUS] FROM Quotation INNER JOIN Supplier ON Quotation.supplier_id = Supplier.supplier_id ";
            }
            else   // restricting user to only see the quotations unders what department and section
            {
                query = $"SELECT DISTINCT Quotation.quotation_id AS [QUOTATION ID], Supplier.supplier_name AS [SUPPLIER], Quotation.quotation_date AS [DATE ADDED], Quotation.quotation_validity AS[VALIDITY], Quotation.vat_status AS[VAT STATUS] FROM Quotation INNER JOIN Supplier ON Quotation.supplier_id = Supplier.supplier_id INNER JOIN Employee ON Employee.emp_id = Quotation.quotation_user_id INNER JOIN DEPARTMENT ON DEPARTMENT.DEPARTMENT_ID = Employee.department_id INNER JOIN SECTION ON SECTION.DEPARTMENT_ID = DEPARTMENT.DEPARTMENT_ID WHERE DEPARTMENT.DEPARTMENT_ID = '{department}' AND SECTION.SECTION_NAME = '{section}'; ";
            }
            
            // loading the data in the datagridview
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(quotation_data);
            dataGridView1.DataSource = quotation_data;
            db.CloseConnection();

        }
        
    }
}
