using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Procurement_Inventory_System
{
    public partial class UpdatePurchaseOrderWindow : Form
    {
        private PurchaseOrderPage purchaseOrderPage;
        public UpdatePurchaseOrderWindow(PurchaseOrderPage purchaseOrderPage)
        {
            InitializeComponent();
            this.purchaseOrderPage = purchaseOrderPage;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updatepostatusbtn_Click(object sender, EventArgs e)
        {

            //display this once done
            UpdatePurchaseOrderPrompt form = new UpdatePurchaseOrderPrompt();
            form.ShowDialog();
        }

        private void UpdatePurchaseOrderWindow_Load(object sender, EventArgs e)
        {
            PopulatePurchaseOrderItem();
            
        }
        public void PopulatePurchaseOrderItem()
        {
            DataTable purchase_order_item_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT poi.purchase_order_id AS 'Purchase Order ID', poi.purchase_request_item_id AS 'Purchase Order Item ID', il.item_name AS 'Item Name', pri.item_quantity AS 'Quantity', ISNULL(CONVERT(varchar, iq.unit_price), 'N/A') AS 'Unit Price', poi.order_item_status AS 'Status' FROM Purchase_Order_Item poi JOIN Purchase_Request_Item pri ON poi.purchase_request_item_id=pri.purchase_request_item_id JOIN Item_List il ON pri.item_id=il.item_id LEFT JOIN Item_Quotation iq ON iq.quotation_id=pri.quotation_id WHERE poi.purchase_order_id = '{PurchaseOrderIDNum.PurchaseOrderID}'";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(purchase_order_item_table);
            dataGridView1.DataSource = purchase_order_item_table;
            db.CloseConnection();
            purchase_order_item_table.Columns.Add("Select", typeof(bool));
            foreach (DataRow row in purchase_order_item_table.Rows)
            {
                row["Select"] = false; // This will be the checkbox state
            }
            dataGridView1.DataSource = purchase_order_item_table;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void RefreshPurchaseOrderTable()
        {
            purchaseOrderPage.PopulatePurchaseOrder();
        }
    }
}
