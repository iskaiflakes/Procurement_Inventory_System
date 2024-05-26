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
        private SupplyRequestPage supplyRequestPage;
        private Dictionary<string, string> itemsToUpdate = new Dictionary<string, string>();
        private Dictionary<string, string> originalStatuses = new Dictionary<string, string>(); // for audit logs
        bool approvalFlag;

        public UpdateSupplyRequestWindow(SupplyRequestPage supplyRequestPage)
        {
            InitializeComponent();
            this.supplyRequestPage = supplyRequestPage;
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            // Handle dashboard click event here
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


        private void approverqstbtn_Click(object sender, EventArgs e)
        {
            if (SupplyRequestItemIDNum.RequestedItemID == null)
            {
                MessageBox.Show("Click supply request item id first.");
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Requested Item ID"].Value.ToString() == SupplyRequestItemIDNum.RequestedItemID && row.Cells["Status"].Value.ToString() == "PENDING")
                    {
                        row.Cells["Status"].Value = "APPROVED";
                        itemsToUpdate[SupplyRequestItemIDNum.RequestedItemID] = "APPROVED";
                        break;
                    }
                    else if (row.Cells["Requested Item ID"].Value.ToString() == SupplyRequestItemIDNum.RequestedItemID && row.Cells["Status"].Value.ToString() != "PENDING")
                    {
                        MessageBox.Show("Item must be pending for approval");
                        break;
                    }
                }
                RefreshSupplyRequestTable();
            }
        }

        private void rejectrqstbtn_Click(object sender, EventArgs e)
        {
            if (SupplyRequestItemIDNum.RequestedItemID == null)
            {
                MessageBox.Show("Click supply request item id first.");
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Requested Item ID"].Value.ToString() == SupplyRequestItemIDNum.RequestedItemID && row.Cells["Status"].Value.ToString() == "PENDING")
                    {
                        row.Cells["Status"].Value = "REJECTED";
                        itemsToUpdate[SupplyRequestItemIDNum.RequestedItemID] = "REJECTED";
                        break;
                    }
                    else if (row.Cells["Requested Item ID"].Value.ToString() == SupplyRequestItemIDNum.RequestedItemID && row.Cells["Status"].Value.ToString() != "PENDING")
                    {
                        MessageBox.Show("Item must be pending for rejection");
                        break;
                    }
                }
                RefreshSupplyRequestTable();
            }
        }

        private void updaterqstbtn_Click(object sender, EventArgs e)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            SqlTransaction transaction = db.GetSqlConnection().BeginTransaction();
            try
            {
                approvalFlag = false;
                foreach (var item in itemsToUpdate)
                {
                    if (item.Value == "APPROVED")
                    {
                        approvalFlag = true;
                    }
                    string updateQuery = $"UPDATE Supply_Request_Item SET supply_item_status = @Status WHERE requested_item_id = @ItemID";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, db.GetSqlConnection(), transaction))
                    {
                        cmd.Parameters.AddWithValue("@Status", item.Value);
                        cmd.Parameters.AddWithValue("@ItemID", item.Key);
                        cmd.ExecuteNonQuery();
                        AuditLog auditLog = new AuditLog();
                        string oldValue = originalStatuses[item.Key];
                        string newValue = item.Value;
                        auditLog.LogEvent(CurrentUserDetails.UserID, "Supply Request", "Update", SupplyRequest_ID.SR_ID, $"Status of {item.Key} changed from {oldValue} to {newValue}");
                    }
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("The transaction was cancelled. An error occurred: " + ex.Message);
            }
            finally
            {
                itemsToUpdate.Clear();
                db.CloseConnection();
                this.Close();
                RefreshSupplyRequestTable();
                if (approvalFlag)
                {
                    string purchasingDetailsQuery = @"SELECT TOP 1 emp_fname, emp_lname, email_address 
                                    FROM Employee 
                                    WHERE role_id=11 AND 
                                    branch_id=@BranchId AND 
                                    department_id=@DepartmentId AND 
                                    section_id=@Section";
                    // change to role of custodian, temporarily placed admin role in the role id
                    SqlCommand cmd = new SqlCommand(purchasingDetailsQuery, db.GetSqlConnection());
                    cmd.Parameters.AddWithValue("@BranchId", CurrentUserDetails.BranchId);
                    cmd.Parameters.AddWithValue("@DepartmentId", CurrentUserDetails.DepartmentId);
                    cmd.Parameters.AddWithValue("@Section", CurrentUserDetails.DepartmentSection);

                    db.GetSqlConnection().Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    string purchasingEmail = "";
                    string purchasingFullName = "";

                    if (reader.Read())
                    {
                        purchasingFullName = $"{reader["emp_fname"].ToString()} {reader["emp_lname"].ToString()}";
                        purchasingEmail = reader["email_address"].ToString();
                    }

                    db.GetSqlConnection().Close();

                    if (!string.IsNullOrEmpty(purchasingEmail))
                    {
                        SendEmailToPurchasingDepartment(purchasingEmail, purchasingFullName);
                    }
                }
            }
        }

        public void RefreshSupplyRequestTable()
        {
            supplyRequestPage.DisplaySupplierReqTable();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells["Requested Item ID"].Value.ToString();
                SupplyRequestItemIDNum.RequestedItemID = val;
            }
        }

        private void SendEmailToPurchasingDepartment(string purchasingEmail, string purchasingName)
        {
            string body = $"Hello {purchasingName}! \n\nItem/s were approved in {SupplyRequest_ID.SR_ID} and requires your release. Please review the supply request at your earliest convenience.\n\nSupply Request ID: {SupplyRequest_ID.SR_ID}";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Approval Notification [NOREPLY]", "procurementinventory27@gmail.com"));
            message.To.Add(new MailboxAddress("Purchasing Department", purchasingEmail));
            message.Subject = "New Item/s Approved";
            message.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                client.Authenticate("procurementinventory27@gmail.com", "urdm dgrf imzq gpam");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public static class SupplyRequestItemIDNum
    {
        public static string RequestedItemID { get; set; }
    }
}
