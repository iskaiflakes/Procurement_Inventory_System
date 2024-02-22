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
            this.Close();
            string vatStat = "VAT EXCLUDED";

            if (vatStatus.SelectedIndex == 0)
            {
                vatStat = "VAT INCLUDED";

            }

            // saves quotation details
            GetQuotationDetails.SupplierID = spplrName.SelectedValue.ToString();
            GetQuotationDetails.VatStatus = vatStat;
            GetQuotationDetails.Validity = validityDate.Text;

            AddItemQuotationWindow form = new AddItemQuotationWindow(updatePurchaseRqstWindow);
            form.ShowDialog();
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
            string query1 = $"SELECT DISTINCT Supplier.supplier_id, Supplier.supplier_name FROM Purchase_Request_Item INNER JOIN Item_List ON Purchase_Request_Item.item_id = Item_List.item_id INNER JOIN Supplier ON Item_List.supplier_id = Supplier.supplier_id WHERE Purchase_Request_Item.purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}'"; // Use DISTINCT to get unique values
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
