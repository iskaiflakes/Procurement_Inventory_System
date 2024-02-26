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
            AddPurchaseOrderWindow form = new AddPurchaseOrderWindow();
            form.ShowDialog();
        }

        private void updateorderbtn_Click(object sender, EventArgs e)
        {
            UpdatePurchaseOrderWindow form = new UpdatePurchaseOrderWindow();
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

            string query = "SELECT purchase_order_id, supplier_id, order_user_id, purchase_order_date, purchase_order_status FROM Purchase_Order";
            SqlDataAdapter da = new SqlDataAdapter(query, db.GetSqlConnection());

            da.Fill(purchaseOrderTable);
            dataGridView1.DataSource = purchaseOrderTable;

            db.CloseConnection();
        }
    }
}
