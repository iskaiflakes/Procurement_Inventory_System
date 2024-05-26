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
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace Procurement_Inventory_System
{
    public partial class UpdateSupplyRequestWindow : Form
    {
        private Dictionary<string, string> itemsToUpdate = new Dictionary<string, string>();
        private Dictionary<string, string> originalStatuses = new Dictionary<string, string>(); // for audit logs
        public UpdateSupplyRequestWindow()
        {
            InitializeComponent();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {

        }
        private void UpdateSupplyRequestWindow_Load(object sender, EventArgs e)
        {
            PopulateSupplyRequestItem();
        }
        public void PopulateSupplyRequestItem()
        {
            DataTable supply_request_item_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT requested_item_id AS 'Requested Item ID', item_name AS 'Item Name', sri.request_quantity AS 'Quantity', " +
                           $"remarks AS 'Remarks', supply_item_status AS 'Status' " +
                           $"FROM Supply_Request_Item sri JOIN Item_List il ON sri.item_id = il.item_id " +
                           $"WHERE supply_request_id = '{SupplyRequest_ID.SR_ID}'";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(supply_request_item_table);
            dataGridView1.DataSource = supply_request_item_table;

            foreach (DataRow row in supply_request_item_table.Rows)
            {
                originalStatuses[row["Requested Item ID"].ToString()] = row["Status"].ToString();
            }

            db.CloseConnection();
        }
    }
}
