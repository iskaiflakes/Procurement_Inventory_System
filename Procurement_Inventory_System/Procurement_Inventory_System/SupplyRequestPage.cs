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
    public partial class SupplyRequestPage : UserControl
    {
        public SupplyRequestPage()
        {
            InitializeComponent();
        }

        private void SupplyRequestPage_Load(object sender, EventArgs e)
        {
            UpdateSupplierReqTable();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            string[] status = { "PENDING", "APPROVED", "REJECTED", "RELEASE" };
            selectStatus.Items.Clear();
            selectStatus.Items.AddRange(status);


        }

        private void supplyrqstbtn_Click(object sender, EventArgs e)
        {
            SupplyRequestWindow form = new SupplyRequestWindow(this);
            form.ShowDialog();
        }

        private void approverqstbtn_Click(object sender, EventArgs e)
        {
            //the user must select an instance first to the table to approve the request
            //the table must be refreshed after pressing the button
        }

        private void notifyrqstrbtn_Click(object sender, EventArgs e)
        {
            NotifyWindow form = new NotifyWindow();
            form.ShowDialog();
        }

        public void UpdateSupplierReqTable()
        {
            DataTable supplyreq_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT supply_request_id AS 'REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', supply_request_date AS 'DATE', supply_request_status AS 'STATUS' FROM Supply_Request pr JOIN Employee e ON pr.supply_request_user_id=e.emp_id ORDER BY supply_request_date";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(supplyreq_table);
            dataGridView1.DataSource = supplyreq_table;
            db.CloseConnection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            SupplierRequest_ID.SR_ID = val;
        }

        private void selectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public static class SupplierRequest_ID
    {
        public static string SR_ID { get;set; }

    }
}
