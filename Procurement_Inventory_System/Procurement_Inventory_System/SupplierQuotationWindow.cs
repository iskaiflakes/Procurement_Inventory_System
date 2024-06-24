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
        private UpdatePurchaseRqstWindow updatePurchaseRqstWindow;
        public SupplierQuotationWindow(UpdatePurchaseRqstWindow updatePurchaseRqstWindow)
        {
            InitializeComponent();
            this.updatePurchaseRqstWindow = updatePurchaseRqstWindow;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addquotationbtn_Click(object sender, EventArgs e)
        {
            // Check if the validity date is less than or equal to the current date
            if (validityDate.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("The validity date must be a future date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(vatStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Select a VAT Status.", "Invalid VAT Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Close the current form
            this.Close();
            string vatStat = "VAT EXCLUDED";

            if (vatStatus.SelectedIndex == 0)
            {
                vatStat = "VAT INCLUDED";
            }

            // Save quotation details
            GetQuotationDetails.SupplierID = supplier.SelectedValue.ToString();
            GetQuotationDetails.VatStatus = vatStat;
            GetQuotationDetails.Validity = validityDate.Value.ToString("yyyy-MM-dd");

            // Open the Add Item Quotation Window
            AddItemQuotationWindow form = new AddItemQuotationWindow(updatePurchaseRqstWindow);
            form.ShowDialog();

            // clear fields
            supplier.Text = null;
            vatStatus.SelectedIndex = -1;
        }


        private void SupplierQuotationWindow_Load(object sender, EventArgs e)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "SELECT supplier_id, supplier_name FROM Supplier";
            SqlDataAdapter da = new SqlDataAdapter(query, db.GetSqlConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            supplier.DisplayMember = "supplier_name";
            supplier.ValueMember = "supplier_id";
            supplier.DataSource = dt;

            db.CloseConnection();
        }

        public void RefreshPurchaseRequestTable()
        {
            if (updatePurchaseRqstWindow != null)
            {
                updatePurchaseRqstWindow.PopulatePurchaseRequestItem();
            }
        }

    }
    public static class GetQuotationDetails
    {
        public static string QuotationID { get; set; }
        public static string SupplierID { get; set; }
        public static string VatStatus { get; set; }
        public static string Validity { get; set; }
    }
}
