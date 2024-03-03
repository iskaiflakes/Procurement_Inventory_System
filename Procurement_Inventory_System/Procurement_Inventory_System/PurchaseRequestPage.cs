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
    public partial class PurchaseRequestPage : UserControl
    {
        public PurchaseRequestPage()
        {
            InitializeComponent();

            /*DataTable purchase_rqst_tbl = new DataTable();

            purchase_rqst_tbl.Columns.Add("REQUEST ID", typeof(string));
            purchase_rqst_tbl.Columns.Add("REQUESTOR", typeof(string));
            purchase_rqst_tbl.Columns.Add("DATE", typeof(string));
            purchase_rqst_tbl.Columns.Add("REQUEST STATUS", typeof(string));
            //supply_rqst_tbl.Columns.Add("Details", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = purchase_rqst_tbl;*/
        }

        private void purchaserqstbtn_Click(object sender, EventArgs e)
        {
            PurchaseRequestWindow form = new PurchaseRequestWindow(this);
            form.ShowDialog();
        }

        private void updaterqstbtn_Click(object sender, EventArgs e)
        {
            if (PurchaseRequestIDNum.PurchaseReqID == null)
            {
                MessageBox.Show("Click purchase request id first.");
            }
            else
            {
                UpdatePurchaseRqstWindow form = new UpdatePurchaseRqstWindow(this);
                form.ShowDialog();
            }
            
        }

        private void PurchaseRequestPage_Load(object sender, EventArgs e)
        {
            PopulateRequestTable();
        }
        public void PopulateRequestTable()
        {
            DataTable purchase_request_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT purchase_request_id AS 'REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', purchase_request_date AS 'DATE', purchase_request_status AS 'STATUS' FROM Purchase_Request pr JOIN Employee e ON pr.purchase_request_user_id=e.emp_id ORDER BY purchase_request_date;";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(purchase_request_table);
            dataGridView1.DataSource = purchase_request_table;
            db.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["REQUEST ID"].Value.ToString();
                PurchaseRequestIDNum.PurchaseReqID = val;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public static class PurchaseRequestIDNum
    {
        public static string PurchaseReqID { get; set; }
    }
}
