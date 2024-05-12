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

            string query = $"SELECT purchase_order_id AS 'PURCHASE ORDER ID', supplier_id AS 'SUPPLIER', order_user_id AS 'ORDER BY', purchase_order_date AS 'ORDER DATE', purchase_order_status AS 'STATUS' FROM Purchase_Order INNER JOIN Employee ON Purchase_Order.order_user_id = Employee.emp_id WHERE Employee.section_id = '{CurrentUserDetails.DepartmentSection}' AND Employee.department_id = '{CurrentUserDetails.DepartmentId}'";
            SqlDataAdapter da = new SqlDataAdapter(query, db.GetSqlConnection());

            da.Fill(purchaseOrderTable);
            dataGridView1.DataSource = purchaseOrderTable;

            db.CloseConnection();
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Check that the click is not on a header
            {
                try
                {
                    string val = dataGridView1.Rows[e.RowIndex].Cells["Purchase Order ID"].Value.ToString();
                    PurchaseOrderIDNum.PurchaseOrderID = val;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("([Purchase Order ID] LIKE '%{0}%' OR [Supplier] LIKE '%{0}%')", searchUser.Text);
        }
    }
    public static class PurchaseOrderIDNum
    {
        public static string PurchaseOrderID { get; set; }
    }
}
