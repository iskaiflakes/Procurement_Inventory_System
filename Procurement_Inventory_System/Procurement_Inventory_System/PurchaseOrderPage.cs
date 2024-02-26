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
    public partial class PurchaseOrderPage : UserControl
    {
        public PurchaseOrderPage()
        {
            InitializeComponent();
        }

        private void purchaseordrbtn_Click(object sender, EventArgs e)
        {
            AddPurchaseOrderWindow form = new AddPurchaseOrderWindow(this);
            form.ShowDialog();
        }

        private void updateorderbtn_Click(object sender, EventArgs e)
        {
            UpdatePurchaseOrderWindow form = new UpdatePurchaseOrderWindow(this);
            form.ShowDialog();
        }

        private void PurchaseOrderPage_Load(object sender, EventArgs e)
        {
            PopulatePurchaseOrder();
        }
        public void PopulatePurchaseOrder()
        {
            DataTable purchaseOrderTable = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "SELECT purchase_order_id AS 'Purchase Order ID', supplier_id AS 'Supplier', order_user_id AS 'Ordered By', purchase_order_date AS 'Order Date', purchase_order_status AS 'Status' FROM Purchase_Order";
            SqlDataAdapter da = new SqlDataAdapter(query, db.GetSqlConnection());

            da.Fill(purchaseOrderTable);
            dataGridView1.DataSource = purchaseOrderTable;

            db.CloseConnection();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string val = dataGridView1.Rows[e.RowIndex].Cells["Purchase Order ID"].Value.ToString();
            PurchaseOrderIDNum.PurchaseOrderID = val;
        }
    }
    public static class PurchaseOrderIDNum
    {
        public static string PurchaseOrderID { get; set; }
    }
}
