using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static Procurement_Inventory_System.UpdateSupplyRequestWindow;

namespace Procurement_Inventory_System
{
    public partial class SupplyRequestPage : UserControl
    {
        private const int PageSize = 23; // Number of records per page
        private int currentPage = 1;
        private DataTable supplyreq_table;

        public SupplyRequestPage()
        {
            InitializeComponent();
        }

        private void SupplyRequestPage_Load(object sender, EventArgs e)
        {
            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                // will only load if the users are either admin, approver, requestor or custodian
                if ((userRole == "11") || (userRole == "12") || (userRole == "13") || (userRole == "15"))
                {
                    DisplaySupplierReqTable();
                    PopulateRequestor();
                }

                if ((userRole == "12") || (userRole == "15"))
                {
                    supplyrqstbtn.Visible = false;
                    viewsrdeetsbtn.Location = supplyrqstbtn.Location;
                }

                LoadComboBoxes();
                SelectDate.Value = DateTime.Now; // Set default value to current date
                SelectDate.Enabled = FilterbyDate.Checked;
            }
        }

        private void LoadComboBoxes()
        {
            string[] status = { "(STATUS)", "PENDING", "INCOMPLETE", "COMPLETE", "RELEASE" };
            SelectStatus.Items.Clear();
            SelectStatus.Items.AddRange(status);
            SelectStatus.SelectedIndex = 0;

        }

        private void supplyrqstbtn_Click(object sender, EventArgs e)
        {
            SupplyRequestWindow form = new SupplyRequestWindow(this);
            form.ShowDialog();
        }

        private bool ValidateStatus(string status)
        {
            bool match = false;
            if (SupplyRequest_ID.SR_ID != null)
            {
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                SqlDataReader dr = db.GetRecord($"select supply_request_status from Supply_Request where supply_request_id ='{SupplyRequest_ID.SR_ID}'");
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


        public void DisplaySupplierReqTable()
        {
            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                // will only load if the users are either admin, approver, requestor or custodian
                if ((userRole == "11") || (userRole == "12") || (userRole == "13") || (userRole == "15"))
                {
                    supplyreq_table = new DataTable();
                    DatabaseClass db = new DatabaseClass();
                    db.ConnectDatabase();
                    string query = "";

                    if (((CurrentUserDetails.BranchId == "MOF") && (userRole == "11"))) // if the Branch is Main Office and an ADMIN or an Approver, all of the SR is displayed
                    {
                        query = "SELECT supply_request_id AS 'SUPPLY REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', supply_request_date AS 'DATE', supply_request_status AS 'STATUS' FROM Supply_Request pr JOIN Employee e ON pr.supply_request_user_id=e.emp_id ORDER BY supply_request_date";
                    }
                    else // if the branch is not MOF, two authorized users will have an access (admin, custodian, approver and requestor)
                    {
                        if ((userRole == "11") || (userRole == "15")) // if your role is admin or custodian, you will be able to view all the SR within your branch only
                        {
                            query = $"SELECT DISTINCT SR.supply_request_id AS 'SUPPLY REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', \r\nsupply_request_date AS 'DATE', supply_request_status AS 'STATUS' FROM Supply_Request SR \r\nJOIN Employee e ON e.emp_id=SR.supply_request_user_id\r\nJOIN Supply_Request_Item SRI ON SR.supply_request_id=SRI.supply_request_id\r\nJOIN Item_List IL ON IL.item_id=SRI.item_id\r\nJOIN DEPARTMENT D ON D.DEPARTMENT_ID=IL.department_id\r\nWHERE D.BRANCH_ID = '{CurrentUserDetails.BranchId}'\r\nORDER BY supply_request_date";
                        }
                        else if ((userRole == "13")) // if your role is requestor or approver, you'll be able to see the SRs within your department section
                        {
                            query = $"SELECT DISTINCT SR.supply_request_id AS 'SUPPLY REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', \r\nsupply_request_date AS 'DATE', supply_request_status AS 'STATUS' FROM Supply_Request SR \r\nJOIN Employee e ON e.emp_id=SR.supply_request_user_id\r\nJOIN Supply_Request_Item SRI ON SR.supply_request_id=SRI.supply_request_id\r\nJOIN Item_List IL ON IL.item_id=SRI.item_id\r\nWHERE IL.section_id = '{CurrentUserDetails.DepartmentSection}'\r\nORDER BY supply_request_date";
                        }
                        else if (userRole == "12")
                        {
                            query = $"SELECT DISTINCT SR.supply_request_id AS 'SUPPLY REQUEST ID', (e.emp_fname + ' '+ e.middle_initial+ ' ' +e.emp_lname) AS 'REQUESTOR', \r\nsupply_request_date AS 'DATE', supply_request_status AS 'STATUS' FROM Supply_Request SR \r\nJOIN Employee e ON e.emp_id=SR.supply_request_user_id\r\nJOIN Supply_Request_Item SRI ON SR.supply_request_id=SRI.supply_request_id\r\nJOIN Item_List IL ON IL.item_id=SRI.item_id\r\nWHERE IL.department_id = '{CurrentUserDetails.DepartmentId}'\r\nORDER BY supply_request_date";
                        }
                    }

                    SqlDataAdapter da = db.GetMultipleRecords(query);
                    da.Fill(supplyreq_table);
                    db.CloseConnection();
                    if (!supplyreq_table.Columns.Contains("DATE_ONLY"))
                    {
                        supplyreq_table.Columns.Add("DATE_ONLY", typeof(DateTime));
                        foreach (DataRow row in supplyreq_table.Rows)
                        {
                            row["DATE_ONLY"] = ((DateTime)row["DATE"]).Date;
                        }
                    }
                    dataGridView1.DataSource = supplyreq_table;
                    DisplayCurrentPage();
                    if (dataGridView1.Columns.Contains("DATE_ONLY"))
                    {
                        dataGridView1.Columns["DATE_ONLY"].Visible = false;
                    }

                    SelectDate.Value = DateTime.Now; // Set default value to current date
                    SelectDate.Enabled = FilterbyDate.Checked;
                }
            }
        }

        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, supplyreq_table.Rows.Count - 1);

            DataTable pageTable = supplyreq_table.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(supplyreq_table.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
            FilterData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage < (supplyreq_table.Rows.Count + PageSize - 1) / PageSize)
            {
                currentPage++;
                DisplayCurrentPage();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }

        }
        private void selectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private async void rejectrqstrbtn_Click(object sender, EventArgs e)
        {

            if (SupplyRequest_ID.SR_ID != null)
            {
                if (ValidateStatus("PENDING"))
                {
                    DatabaseClass db = new DatabaseClass();
                    db.ConnectDatabase();

                    string updateCmd = $"UPDATE Supply_Request SET date_updated = GETDATE(), approver_user_id = {CurrentUserDetails.UserID}, supply_request_status = 'REJECTED' WHERE supply_request_id = '{SupplyRequest_ID.SR_ID}'";

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
                    string EmailStatus = await emailSender.SendEmail(
                        fromName: "SUPPLY REQUEST NOTIFICATION [NOREPLY]",
                        fromAddress: "procurementinventory27@gmail.com",
                        toName: CurrentUserDetails.DepartmentId.ToString(),
                        toAddress: "yelliarchives@gmail.com",
                        subject: $"Supply Request: {SupplyRequest_ID.SR_ID} has been REJECTED",
                        htmlTable: EmailBuilder.ContentBuilder(
                            requestID: SupplyRequest_ID.SR_ID,
                            Receiver: "Approver",
                            Sender: $"{CurrentUserDetails.FName} {CurrentUserDetails.LName}",
                            UserAction: "REJECTED",
                            TypeOfRequest: "Supply Request"
                        )
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

        private async void releaseitemsbtn_Click(object sender, EventArgs e)
        {
            if (SupplyRequest_ID.SR_ID != null)
            {
                if (ValidateStatus("APPROVED"))
                {
                    DatabaseClass db = new DatabaseClass();
                    db.ConnectDatabase();

                    string updateCmd = $"UPDATE Supply_Request SET date_updated = GETDATE(), approver_user_id = {CurrentUserDetails.UserID}, supply_request_status = 'RELEASE' WHERE supply_request_id = '{SupplyRequest_ID.SR_ID}'";

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

                    string EmailStatus = await emailSender.SendEmail(
                        fromName: "SUPPLY REQUEST NOTIFICATION [NOREPLY]",
                        fromAddress: "procurementinventory27@gmail.com",
                        toName: CurrentUserDetails.DepartmentId.ToString(),
                        toAddress: "yelliarchives@gmail.com",
                        subject: $"[FOR RELEASE] Supply Request: {SupplyRequest_ID.SR_ID}",
                        htmlTable: EmailBuilder.ContentBuilder(
                            requestID: SupplyRequest_ID.SR_ID,
                            Receiver: $"{CurrentUserDetails.FName} {CurrentUserDetails.LName}",
                            Sender: "Approver",
                            UserAction: "RELEASED",
                            TypeOfRequest: "Supply Request")
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
                SupplyRequest_ID.SR_ID = val;

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

            string query = $"select supply_request_id,Supply_Request_Item.item_id,request_quantity,available_quantity from Supply_Request_Item inner join Item_Inventory on Item_Inventory.item_id = Supply_Request_Item.item_id where supply_request_id='{SupplyRequest_ID.SR_ID}'";

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
            FilterData();
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
            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                // will only load if the users are either admin, approver, requestor or custodian
                if ((userRole == "11") || (userRole == "12") || (userRole == "13") || (userRole == "15"))
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
            }
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
                if (FilterbyDate.Checked)
                {
                    DateTime selectedDate = SelectDate.Value.Date;
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"[DATE_ONLY] = #{selectedDate.ToString("MM/dd/yyyy")}#");
                }
                if (!string.IsNullOrEmpty(searchUser.Text) && searchUser.Text != "supply request id, requestor")
                {
                    if (filter.Length > 0)
                    {
                        filter.Append(" AND ");
                    }
                    filter.Append($"([Supply Request ID] LIKE '%{searchUser.Text}%' OR [Requestor] LIKE '%{searchUser.Text}%')");
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

        private double CancelCounter()
        {
            int totalItems = 0;
            int cancelledItems = 0;

            // Check if PurchaseOrderID is not null
            if (SupplyRequest_ID.SR_ID != null)
            {
                // Initialize the database connection
                DatabaseClass db = new DatabaseClass();
                try
                {
                    db.ConnectDatabase();
                    string query = $"select supply_item_status from Supply_Request_Item inner join Supply_Request on Supply_Request.supply_request_id = Supply_Request_Item.supply_request_id where Supply_Request.supply_request_id='{SupplyRequest_ID.SR_ID}'";

                    // Execute the query and get the SqlDataReader
                    SqlDataReader dr = db.GetRecord(query);

                    // Check if the data reader has any rows
                    while (dr.Read())
                    {
                        // Increment total items count
                        totalItems++;

                        // Check if the status is "Cancelled"
                        if (dr["supply_item_status"].ToString() == "REJECTED")
                        {
                            // Increment cancelled items count
                            cancelledItems++;
                        }
                    }
                    // Close the data reader
                    dr.Close();

                }
                catch (Exception ex)
                {
                    // Handle any potential exceptions (logging, rethrowing, etc.)
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return 0;
                }
                finally
                {
                    // Ensure the database connection is always closed
                    db.CloseConnection();
                }
            }
            double cancelledPercentage = (double)cancelledItems / totalItems * 100;
            return cancelledPercentage;
        }

        private void UpdateSupplyRequest(object sender, EventArgs e)
        {
            if (SupplyRequest_ID.SR_ID != null)
            {

                UpdateSupplyRequestWindow form = new UpdateSupplyRequestWindow(this);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["SUPPLY REQUEST ID"].Value.ToString() == SupplyRequest_ID.SR_ID)
                    {
                        if (row.Cells["STATUS"].Value.ToString() == "COMPLETE" )
                        {
                           
                            if (CancelCounter() == 100.00)
                            {
                                
                                form.ViewDetails();
                            }
                            else
                            {
                                form.HideButtons();
                            }

                            if (CurrentUserDetails.Role == "12")
                            {
                                form.ViewDetails();
                            }
                            
                        }
                        else if(row.Cells["STATUS"].Value.ToString() == "RELEASE")
                        {
                            form.ViewDetails();
                        }
                        else
                        {
                            form.ShowButtons();
                            form.HideRelease();

                        }
                    }
                }
                form.ShowDialog();

            }
            else
            {
                MessageBox.Show("Select a supply request first.");
            }
        }

        private void ClearFilters_Click(object sender, EventArgs e)
        {
            searchUser.Text = "supply request id, requestor";
            searchUser.ForeColor = Color.Silver;
            this.ActiveControl = ClearFilters;
            SelectStatus.SelectedIndex = 0;
            SelectRequestor.SelectedIndex = 0;
            FilterbyDate.Checked = false;
            FilterData();
        }

        private void FilterbyDate_CheckedChanged(object sender, EventArgs e)
        {
            SelectDate.Enabled = FilterbyDate.Checked;
            FilterData(); 
        }
    }
    class SupplyRequestItem
    {
        public string ItemId { get; set; }
        public int RequestQuantity { get; set; }
        public int AvailableQuantity { get; set; }
    }
    public static class SupplyRequest_ID
    {
        public static string SR_ID { get;set; }

    }

    

}
