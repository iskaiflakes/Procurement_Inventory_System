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
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

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
            DisplaySupplierReqTable();
            LoadComboBoxes();
            SelectDate.Value = SelectDate.MinDate; // para di mafilter date
        }

        private void LoadComboBoxes()
        {
            string[] status = { "(STATUS)","PENDING", "APPROVED", "REJECTED", "RELEASE" };
            SelectStatus.Items.Clear();
            SelectStatus.Items.AddRange(status);
            PopulateRequestor();
        }

        private void supplyrqstbtn_Click(object sender, EventArgs e)
        {
            SupplyRequestWindow form = new SupplyRequestWindow(this);
            form.ShowDialog();
        }

        private bool ValidateStatus(string status)
        {
            bool match=false;
            if (SupplierRequest_ID.SR_ID != null)
            {
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                SqlDataReader dr = db.GetRecord($"select supply_request_status from Supply_Request where supply_request_id ='{SupplierRequest_ID.SR_ID}'");
                if (dr.Read())
                {
                    if ((dr["supply_request_status"].ToString()).Trim() == status.ToUpper())
                    {
                        match = true;
                    }
                }
                db.CloseConnection();
            }
            return match;
        }

        private void approverqstbtn_Click(object sender, EventArgs e)
        {
            

            if (SupplierRequest_ID.SR_ID != null)
            {
                if (ValidateStatus("PENDING"))
                {
                    DatabaseClass db = new DatabaseClass();
                    db.ConnectDatabase();

                    string updateCmd = $"UPDATE Supply_Request SET date_updated = GETDATE(), approver_user_id = {CurrentUserDetails.UserID}, supply_request_status = 'APPROVED' WHERE supply_request_id = '{SupplierRequest_ID.SR_ID}'";

                    int returnRow = db.insDelUp(updateCmd);

                    if (returnRow > 0)  // checks if the insertion was done successfully
                    {
                        db.CloseConnection();   // closes the db connection to prevent the app from crashing
                    }
                    DisplaySupplierReqTable();
                    var emailSender = new EmailSender(
                    smtpHost: "smtp.gmail.com",
                    smtpPort: 587,
                    smtpUsername: "procurementinventory27@gmail.com",
                    smtpPassword: "tyov yxim zcjx ynfp",
                    sslOptions: SecureSocketOptions.StartTls
                );

                    string EmailStatus = emailSender.SendEmail(
                        fromName: "SUPPLY REQUEST NOTIFICATION [NOREPLY]",
                        fromAddress: "procurementinventory27@gmail.com",
                        toName: CurrentUserDetails.DepartmentId.ToString(),
                        toAddress: "yelliarchives@gmail.com",
                        subject: "Approval Needed: Supply Request",
                        htmlTable: EmailBuilder.ContentBuilder("Approver", $"{CurrentUserDetails.FName} {CurrentUserDetails.LName}", "APPROVED", "Supply Request")
                    );
                    MessageBox.Show(EmailStatus);
                }
                else
                {
                    MessageBox.Show("Request must be PENDING!");
                }


            }
            else
            {
                MessageBox.Show("Select Supply Request ID first!");
            }
        }

        public void DisplaySupplierReqTable()
        {
            DataTable supplyreq_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            if ((CurrentUserDetails.BranchId == "MOF")&&(userRole == "11")) // if the Branch is Main Office and an ADMIN, all of the SR is displayed
            {
                query = "SELECT supply_request_id AS 'SUPPLY REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', supply_request_date AS 'DATE', supply_request_status AS 'STATUS' FROM Supply_Request pr JOIN Employee e ON pr.supply_request_user_id=e.emp_id ORDER BY supply_request_date";
            }
            else // if the branch is not MOF, two authorized users will have an access (admin, custodian, approver and requestor)
            {
                if((userRole == "11")||(userRole == "15")|| (userRole == "12")) // if your role is admin, custodian or approver, you will be able to view all the SR within your branch only
                {
                    query = $"SELECT supply_request_id AS 'SUPPLY REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', \r\nsupply_request_date AS 'DATE', supply_request_status AS 'STATUS' FROM Supply_Request pr JOIN Employee e \r\nON pr.supply_request_user_id=e.emp_id WHERE e.branch_id = '{CurrentUserDetails.BranchId}' ORDER BY supply_request_date";
                }
                else if (userRole == "13") // if your role is requestor, you'll be able to see the SRs within your department section
                {
                    query = $"SELECT supply_request_id AS 'SUPPLY REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', supply_request_date AS 'DATE', supply_request_status AS 'STATUS' FROM Supply_Request pr JOIN Employee e ON pr.supply_request_user_id=e.emp_id WHERE e.section_id = '{CurrentUserDetails.DepartmentSection}' ORDER BY supply_request_date";
                }
            }

            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(supplyreq_table);
            dataGridView1.DataSource = supplyreq_table;
            db.CloseConnection();
            supplyreq_table.Columns.Add("DATE_ONLY", typeof(DateTime));
            foreach (DataRow row in supplyreq_table.Rows)
            {
                row["DATE_ONLY"] = ((DateTime)row["DATE"]).Date;
            } //kasi pag may time di nafifilter pero di naman visible ito
            dataGridView1.Columns["DATE_ONLY"].Visible = false;
        }

        private void selectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void rejectrqstrbtn_Click(object sender, EventArgs e)
        {
            
            if (SupplierRequest_ID.SR_ID != null)
            {
                if (ValidateStatus("PENDING"))
                {
                    DatabaseClass db = new DatabaseClass();
                    db.ConnectDatabase();

                    string updateCmd = $"UPDATE Supply_Request SET date_updated = GETDATE(), approver_user_id = {CurrentUserDetails.UserID}, supply_request_status = 'REJECTED' WHERE supply_request_id = '{SupplierRequest_ID.SR_ID}'";

                    int returnRow = db.insDelUp(updateCmd);

                    if (returnRow > 0)  // checks if the insertion was done successfully
                    {
                        db.CloseConnection();   // closes the db connection to prevent the app from crashing
                    }
                    DisplaySupplierReqTable();
                    var emailSender = new EmailSender(
                    smtpHost: "smtp.gmail.com",
                    smtpPort: 587,
                    smtpUsername: "procurementinventory27@gmail.com",
                    smtpPassword: "tyov yxim zcjx ynfp",
                    sslOptions: SecureSocketOptions.StartTls
                );

                    string EmailStatus = emailSender.SendEmail(
                        fromName: "SUPPLY REQUEST NOTIFICATION [NOREPLY]",
                        fromAddress: "procurementinventory27@gmail.com",
                        toName: CurrentUserDetails.DepartmentId.ToString(),
                        toAddress: "yelliarchives@gmail.com",
                        subject: $"Supply Request: {SupplierRequest_ID.SR_ID} has been REJECTED",
                        htmlTable: EmailBuilder.ContentBuilder($"{CurrentUserDetails.FName} {CurrentUserDetails.LName}","Approver", "REJECTED", "Supply Request")
                    );
                    MessageBox.Show(EmailStatus);
                }
                else
                {
                    MessageBox.Show("Request must be PENDING!");
                }
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
                if (ValidateStatus("RELEASE") || ValidateStatus("REJECTED") || ValidateStatus("PENDING"))
                {
                    form.HideApprovedDetails();

                }
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
                if (ValidateStatus("APPROVED"))
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
                    DisplaySupplierReqTable();
                    var emailSender = new EmailSender(
                    smtpHost: "smtp.gmail.com",
                    smtpPort: 587,
                    smtpUsername: "procurementinventory27@gmail.com",
                    smtpPassword: "tyov yxim zcjx ynfp",
                    sslOptions: SecureSocketOptions.StartTls
                );

                    string EmailStatus = emailSender.SendEmail(
                        fromName: "SUPPLY REQUEST NOTIFICATION [NOREPLY]",
                        fromAddress: "procurementinventory27@gmail.com",
                        toName: CurrentUserDetails.DepartmentId.ToString(),
                        toAddress: "yelliarchives@gmail.com",
                        subject: $"[FOR RELEASE] Supply Request: {SupplierRequest_ID.SR_ID}",
                        htmlTable: EmailBuilder.ContentBuilder($"{CurrentUserDetails.FName} {CurrentUserDetails.LName}","Approver", "RELEASE", "Supply Request")
                    );
                    MessageBox.Show(EmailStatus);
                    
                }
                else
                {
                    MessageBox.Show("Request must be APPROVED!");
                }
                
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
                string val = dataGridView1.Rows[e.RowIndex].Cells["SUPPLY REQUEST ID"].Value.ToString();
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

        private void SelectDate_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void SelectRequestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        public void PopulateRequestor()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            var distinctValues = dt.AsEnumerable()
                                   .Select(row => row.Field<string>("REQUESTOR"))
                                   .Distinct()
                                   .ToList();

            distinctValues.Insert(0, "(Requestor)"); // Add placeholder

            SelectRequestor.DataSource = distinctValues;
            SelectRequestor.SelectedIndex = 0; // Ensure no default selection
        }
        private void FilterData()
        {
            DataTable dt = (dataGridView1.DataSource as DataTable);

            if (dt != null)
            {
                string statusFilter = SelectStatus.SelectedIndex > 0 ? SelectStatus.SelectedItem.ToString() : null;
                string requestorFilter = SelectRequestor.SelectedIndex > 0 ? SelectRequestor.SelectedItem.ToString() : null;

                StringBuilder filter = new StringBuilder();

                if (!string.IsNullOrEmpty(statusFilter))
                {
                    filter.Append($"[STATUS] = '{statusFilter}'");
                }

                if (!string.IsNullOrEmpty(requestorFilter))
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"[REQUESTOR] = '{requestorFilter}'");
                }
                if (SelectDate.Value != SelectDate.MinDate)
                {
                    DateTime selectedDate = SelectDate.Value.Date;
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"[DATE_ONLY] = #{selectedDate.ToString("MM/dd/yyyy")}#");
                }
                dt.DefaultView.RowFilter = filter.ToString();
            }
        }

        private void searchUser_Enter(object sender, EventArgs e)
        {
            if (searchUser.Text == "supply request id, requestor")
            {
                searchUser.Text = "";
                searchUser.ForeColor = Color.Black;
            }
        }

        private void searchUser_Leave(object sender, EventArgs e)
        {
            if (searchUser.Text == "")
            {
                searchUser.Text = "supply request id, requestor";
                searchUser.ForeColor = Color.Silver;
            }
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
