using Org.BouncyCastle.Ocsp;
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

            if (SupplierRequest_ID.SR_ID != null)
            {
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();

                string updateCmd = $"UPDATE Supply_Request SET date_updated = GETDATE(), approver_user_id = {CurrentUserDetails.UserID}, supply_request_status = 'APPROVED' WHERE supply_request_id = '{SupplierRequest_ID.SR_ID}'";

                int returnRow = db.insDelUp(updateCmd);

                if (returnRow > 0)  // checks if the insertion was done successfully
                {
                    db.CloseConnection();   // closes the db connection to prevent the app from crashing
                }
                UpdateSupplierReqTable();

                // Should also update the quantity in 

            }
            else
            {
                MessageBox.Show("Select Supply Request ID first!");
            }
        }

        public void UpdateSupplierReqTable()
        {
            DataTable supplyreq_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT supply_request_id AS 'SUPPLY REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', supply_request_date AS 'DATE', supply_request_status AS 'STATUS' FROM Supply_Request pr JOIN Employee e ON pr.supply_request_user_id=e.emp_id WHERE e.section_id = '{CurrentUserDetails.DepartmentSection}' ORDER BY supply_request_date";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(supplyreq_table);
            dataGridView1.DataSource = supplyreq_table;
            db.CloseConnection();
        }

        private void selectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rejectrqstrbtn_Click(object sender, EventArgs e)
        {
            if (SupplierRequest_ID.SR_ID != null)
            {
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();

                string updateCmd = $"UPDATE Supply_Request SET date_updated = GETDATE(), approver_user_id = {CurrentUserDetails.UserID}, supply_request_status = 'REJECTED' WHERE supply_request_id = '{SupplierRequest_ID.SR_ID}'";

                int returnRow = db.insDelUp(updateCmd);

                if (returnRow > 0)  // checks if the insertion was done successfully
                {
                    db.CloseConnection();   // closes the db connection to prevent the app from crashing
                }
                UpdateSupplierReqTable();
            }
            else
            {
                MessageBox.Show("Select Supply Request ID first!");
            }
        }

        private void viewsrdeetsbtn_Click(object sender, EventArgs e)
        {
            if (SupplierRequest_ID.SR_ID != null)
            {
                ViewSupplyRequestWindow form = new ViewSupplyRequestWindow();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select Supply Request ID first!");
            }
            
        }

        private void releaseitemsbtn_Click(object sender, EventArgs e)
        {
            if (SupplierRequest_ID.SR_ID != null)
            {
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();

                string updateCmd = $"UPDATE Supply_Request SET date_updated = GETDATE(), approver_user_id = {CurrentUserDetails.UserID}, supply_request_status = 'RELEASE' WHERE supply_request_id = '{SupplierRequest_ID.SR_ID}'";

                int returnRow = db.insDelUp(updateCmd);

                if (returnRow > 0)  // checks if the insertion was done successfully
                {
                    db.CloseConnection();   // closes the db connection to prevent the app from crashing
                }
                //dito ka magdeduct 
                deductItems();
                //
                UpdateSupplierReqTable();
            }
            else
            {
                MessageBox.Show("Select Supply Request ID first!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //SupplierRequest_ID.SR_ID = val;
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        { 
            try
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["REQUEST ID"].Value.ToString();
                SupplierRequest_ID.SR_ID = val;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void deductItems()
        {
            List<SupplyRequestItem> items = new List<SupplyRequestItem>();

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"select supply_request_id,Supply_Request_Item.item_id,request_quantity,available_quantity from Supply_Request_Item inner join Item_Inventory on Item_Inventory.item_id = Supply_Request_Item.item_id where supply_request_id='{SupplierRequest_ID.SR_ID}'";
            
            SqlDataReader reader = db.GetRecord(query);
            while (reader.Read())
            {
                SupplyRequestItem item = new SupplyRequestItem
                {
                    ItemId = reader["item_id"].ToString(),
                    RequestQuantity = Convert.ToInt32(reader["request_quantity"]),
                    AvailableQuantity = Convert.ToInt32(reader["available_quantity"])
                };

                // Add the item to the list
                items.Add(item);
            }
            reader.Close();
            foreach (var item in items)
            {
                // Calculate the new available quantity
                int newAvailableQuantity = item.AvailableQuantity - item.RequestQuantity;

                // Define your SQL update query
                string updateQuery = "UPDATE Item_Inventory SET available_quantity = @NewAvailableQuantity WHERE item_id = @ItemId";

                // Create a command to execute the update query
                SqlCommand updateCommand = new SqlCommand(updateQuery, db.GetSqlConnection());
                updateCommand.Parameters.AddWithValue("@NewAvailableQuantity", newAvailableQuantity);
                updateCommand.Parameters.AddWithValue("@ItemId", item.ItemId);
                updateCommand.ExecuteNonQuery();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("([Supply Request ID] LIKE '%{0}%' OR [Requestor] LIKE '%{0}%')", searchUser.Text);
        }
    }
    class SupplyRequestItem
    {
        public string ItemId { get; set; }
        public int RequestQuantity { get; set; }
        public int AvailableQuantity { get; set; }
    }
    public static class SupplierRequest_ID
    {
        public static string SR_ID { get;set; }

    }

}
