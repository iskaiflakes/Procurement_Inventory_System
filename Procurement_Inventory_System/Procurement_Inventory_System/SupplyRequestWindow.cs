using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
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
    public partial class SupplyRequestWindow : Form
    {
        private const int PageSize = 15; // Number of records per page
        private int currentPage = 1;
        private DataTable dt;

        private SupplyRequestPage SupplyRequestPage;
        public SupplyRequestWindow(SupplyRequestPage SupplyRequestPage)
        {
            InitializeComponent();
            this.SupplyRequestPage = SupplyRequestPage;
        }

        private void CreateRequestWindow_Load(object sender, EventArgs e)
        {

        }

        private void additemrqstbtn_Click(object sender, EventArgs e)
        {
            using (AddRequestItemWindow addItemForm = new AddRequestItemWindow())
            {
                if (addItemForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the new item data
                    ItemData newItem = addItemForm.NewItem;
                    if (newItem != null)
                    {
                        dt = (DataTable)dataGridView1.DataSource ?? new DataTable(); // if there is no table, a new one is created

                        if (dt.Columns.Count == 0)
                        {
                            // Assuming the DataTable doesn't have columns defined
                            dt.Columns.Add("Item ID", typeof(string));
                            dt.Columns.Add("Item Name", typeof(string));
                            dt.Columns.Add("Quantity", typeof(int));
                            dt.Columns.Add("Remarks", typeof(string));
                        }

                        dt.Rows.Add(newItem.ItemId, newItem.ItemName, newItem.Quantity, newItem.Remarks);
                        DisplayCurrentPage();
                    }
                }
            }
        }
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, dt.Rows.Count - 1);

            DataTable pageTable = dt.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(dt.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dt != null && dt.Rows != null)
            {
                if (currentPage < (dt.Rows.Count + PageSize - 1) / PageSize)
                {
                    currentPage++;
                    DisplayCurrentPage();
                }
            }
            else
            {
                MessageBox.Show("No data to show.");
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
        private async void createnewrqstbtn_Click(object sender, EventArgs e)
        {
            //the table must be refreshed after pressing the button
            //to reflect the request record instance in the table
            if (dataGridView1.Rows.Count > 0)
            {
                this.Close();
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string datePrefix = DateTime.Now.ToString("yyyyMMdd");
                string lastIdQuery = @"SELECT TOP 1 supply_request_id FROM Supply_Request 
                    WHERE supply_request_id LIKE 'SR-" + datePrefix + "-%' ORDER BY supply_request_id DESC";
                string nextSrId = $"SR-{datePrefix}-001"; // Default if no items found for today
                SqlDataReader dr = db.GetRecord(lastIdQuery);
                if (dr.Read())
                {
                    string lastId = dr["supply_request_id"].ToString();
                    int lastNumber = int.Parse(lastId.Split('-')[2]);
                    nextSrId = $"SR-{datePrefix}-{(lastNumber + 1):D3}";
                }
                dr.Close();
                string srQuery = @"INSERT INTO Supply_Request (supply_request_id, supply_request_user_id,supply_request_status, supply_request_date) VALUES (@nextSrId,@userId,'PENDING',GETDATE())";
                using (SqlCommand cmd = new SqlCommand(srQuery, db.GetSqlConnection()))
                {
                    cmd.Parameters.AddWithValue("@nextSrId", nextSrId);
                    cmd.Parameters.AddWithValue("@userId", CurrentUserDetails.UserID);
                    cmd.ExecuteNonQuery();
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string itemId = row.Cells[0].Value.ToString();
                        int itemQty = Convert.ToInt32(row.Cells[2].Value);
                        string remarks = row.Cells[3].Value.ToString();

                        string nextItemId = GetNextItemId(datePrefix, db); // Assume GetNextItemId is a method that generates the next item ID

                        string priQuery = @"INSERT INTO Supply_Request_Item (requested_item_id, supply_request_id, item_id, request_quantity, remarks) VALUES (@sri_id, @srId, @itemId, @itemQty, @remarks)";
                        using (SqlCommand itemCmd = new SqlCommand(priQuery, db.GetSqlConnection()))
                        {
                            itemCmd.Parameters.AddWithValue("@sri_id", nextItemId);
                            itemCmd.Parameters.AddWithValue("@srId", nextSrId);
                            itemCmd.Parameters.AddWithValue("@itemId", itemId);
                            itemCmd.Parameters.AddWithValue("@itemQty", itemQty);
                            itemCmd.Parameters.AddWithValue("@remarks", remarks);
                            itemCmd.ExecuteNonQuery();
                        }
                    }
                }
                AuditLog auditLog = new AuditLog();
                auditLog.LogEvent(CurrentUserDetails.UserID, "Supply Request", "Insert", nextSrId, "Supply request created");

                string[] headers = {"Item Name","Quantity","Remarks"};
                string htmlHeader = EmailBuilder.TableHeaders(headers.ToList());
                string[] htmlTable = new string[dataGridView1.Rows.Count];
                int count = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string[] rows = new string[headers.Length];
                        for(int i = 0; i < rows.Length;i++)
                        {
                            rows[i] = row.Cells[i+1].Value.ToString();
                        }
                        htmlTable[count]=EmailBuilder.TableRow(rows.ToList());
                        count++;
                    }
                }
                string approverEmail = "";
                string approverQuery = @"SELECT email_address FROM Employee 
                                 WHERE department_id = @departmentId AND role_id = '12'";
                using (SqlCommand cmd = new SqlCommand(approverQuery, db.GetSqlConnection()))
                {
                    cmd.Parameters.AddWithValue("@departmentId", CurrentUserDetails.DepartmentId);
                    SqlDataReader approverDr = cmd.ExecuteReader();
                    if (approverDr.Read())
                    {
                        approverEmail = approverDr["email_address"].ToString();
                    }
                    approverDr.Close();
                }
                // EMAIL PART
                var emailSender = new EmailSender(
                smtpHost: "smtp.gmail.com",
                smtpPort: 587,
                smtpUsername: "procurementinventory27@gmail.com",
                smtpPassword: "mkhk qpla vgct dkqv",
                sslOptions: SecureSocketOptions.StartTls
                );

                string EmailStatus = await emailSender.SendEmail(
                    fromName: "SUPPLY REQUEST NOTIFICATION [NOREPLY]",
                    fromAddress: "procurementinventory27@gmail.com",
                    toName: "APPROVER",
                    toAddress: approverEmail,
                    subject: $"Approval Needed: Supply Request {nextSrId}",
                    htmlTable: EmailBuilder.ContentBuilder(
                        requestID:nextSrId,
                        Receiver:"Approver", 
                        Sender:$"{CurrentUserDetails.FName} {CurrentUserDetails.LName}",
                        UserAction:"SUBMITTED",
                        TypeOfRequest:"Supply Request",
                        TableTitle:"Requested Item",
                        Header:htmlHeader,
                        Body:htmlTable
                        )
                    );
                RefreshRequestListTable();
            }
            else
            {
                MessageBox.Show("No items");
            }

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteitemrqstbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // create a list to keep track of rows to delete
                List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

                // loop through selected cells and add their rows to the list
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    DataGridViewRow row = cell.OwningRow;
                    if (!row.IsNewRow && !rowsToDelete.Contains(row))
                    {
                        rowsToDelete.Add(row);
                    }
                }

                // remove the rows
                foreach (DataGridViewRow row in rowsToDelete)
                {
                    dataGridView1.Rows.Remove(row);
                }

                // refresh the DataGridView
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Delete Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private string GetNextItemId(string datePrefix, DatabaseClass db)
        {
            string lastItemIdQuery = @"SELECT top 1 requested_item_id FROM Supply_Request_Item
                     WHERE requested_item_id LIKE 'SRI-" + datePrefix + "-%' ORDER BY requested_item_id DESC";
            string nextItemId = $"SRI-{datePrefix}-001"; // Default if no items found for today
            SqlDataReader dr = db.GetRecord(lastItemIdQuery);
            if (dr.Read())
            {
                string lastId = dr["requested_item_id"].ToString();
                int lastNumber = int.Parse(lastId.Split('-')[2]);
                nextItemId = $"SRI-{datePrefix}-{(lastNumber + 1):D3}";
            }
            dr.Close();
            return nextItemId;
        }
        public void RefreshRequestListTable()
        {
            if (SupplyRequestPage != null)
            {
                SupplyRequestPage.DisplaySupplierReqTable();
            }
        }
    }
}
