﻿using System;
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
using MailKit.Security;

namespace Procurement_Inventory_System
{
    public partial class PurchaseRequestWindow : Form
    {
        private const int PageSize = 20; // Number of records per page
        private int currentPage = 1;
        private DataTable dt;

        private PurchaseRequestPage purchaseRequestPage;
        public PurchaseRequestWindow(PurchaseRequestPage purchaseRequestPage)
        {
            InitializeComponent();
            this.purchaseRequestPage = purchaseRequestPage;
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
                    else
                    {
                        MessageBox.Show("nandito aq");
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
            if (dt != null)
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
            if (dataGridView1.Rows.Count > 0)
            {
                Branch.BranchId = null;
                Branch.DeptId = null;

                this.Close();
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string datePrefix = DateTime.Now.ToString("yyyyMMdd");
                string lastIdQuery = @"SELECT TOP 1 purchase_request_id FROM Purchase_Request 
                               WHERE purchase_request_id LIKE 'PR-" + datePrefix + "-%' ORDER BY purchase_request_id DESC";
                string nextPrId = $"PR-{datePrefix}-001"; // Default if no items found for today
                SqlDataReader dr = db.GetRecord(lastIdQuery);
                if (dr.Read())
                {
                    string lastId = dr["purchase_request_id"].ToString();
                    int lastNumber = int.Parse(lastId.Split('-')[2]);
                    nextPrId = $"PR-{datePrefix}-{(lastNumber + 1):D3}";
                }
                dr.Close();
                string prQuery = @"INSERT INTO Purchase_Request VALUES (@nextPrId,@userId,'PENDING',GETDATE())";
                using (SqlCommand cmd = new SqlCommand(prQuery, db.GetSqlConnection()))
                {
                    cmd.Parameters.AddWithValue("@nextPrId", nextPrId);
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

                        string nextItemId = GetNextItemId(datePrefix, db);

                        string priQuery = @"INSERT INTO Purchase_Request_Item (purchase_request_item_id, purchase_request_id, item_id, item_quantity, remarks) VALUES (@nextItemId, @prId, @itemId, @itemQty, @remarks)";
                        using (SqlCommand itemCmd = new SqlCommand(priQuery, db.GetSqlConnection()))
                        {
                            itemCmd.Parameters.AddWithValue("@nextItemId", nextItemId);
                            itemCmd.Parameters.AddWithValue("@prId", nextPrId);
                            itemCmd.Parameters.AddWithValue("@itemId", itemId);
                            itemCmd.Parameters.AddWithValue("@itemQty", itemQty);
                            itemCmd.Parameters.AddWithValue("@remarks", remarks);
                            itemCmd.ExecuteNonQuery();
                        }
                    }
                }

                string[] headers = { "Item Name", "Quantity", "Remarks" };
                string htmlHeader = EmailBuilder.TableHeaders(headers.ToList());
                string[] htmlTable = new string[dataGridView1.Rows.Count];
                int count = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string[] rows = new string[headers.Length];
                        for (int i = 0; i < rows.Length; i++)
                        {
                            rows[i] = row.Cells[i + 1].Value.ToString();
                        }
                        htmlTable[count] = EmailBuilder.TableRow(rows.ToList());
                        count++;
                    }
                }

                // Modified query to get all active purchasing department employees
                string purchasingDetailsQuery = @"SELECT emp_fname, emp_lname, email_address FROM Employee
                                          INNER JOIN Account ON Employee.emp_id = Account.emp_id
                                          WHERE Employee.role_id = '14' AND Account.account_status = 'ACTIVATED'";
                List<string> emailAddresses = new List<string>();
                List<string> fullNames = new List<string>();

                using (SqlCommand cmd = new SqlCommand(purchasingDetailsQuery, db.GetSqlConnection()))
                {
                    SqlDataReader approverDr = cmd.ExecuteReader();
                    while (approverDr.Read())
                    {
                        emailAddresses.Add(approverDr["email_address"].ToString());
                        fullNames.Add($"{approverDr["emp_fname"].ToString()} {approverDr["emp_lname"].ToString()}");
                    }
                    approverDr.Close();
                }

                var emailSender = new EmailSender(
                    smtpHost: "smtp.gmail.com",
                    smtpPort: 587,
                    smtpUsername: "procurementinventory27@gmail.com",
                    smtpPassword: "vkxg wsci roob nuif",
                    sslOptions: SecureSocketOptions.StartTls
                );

                for (int i = 0; i < emailAddresses.Count; i++)
                {
                    string email = emailAddresses[i];
                    string fullName = fullNames[i];

                    string EmailStatus = await emailSender.SendEmail(
                        fromName: "PURCHASE REQUEST NOTIFICATION [NOREPLY]",
                        fromAddress: "procurementinventory27@gmail.com",
                        toName: fullName,
                        toAddress: email,
                        subject: $"Quotation Needed: Purchase Request {nextPrId}",
                        htmlTable: EmailBuilder.ContentBuilder(
                            requestID: nextPrId,
                            Receiver: fullName,
                            Sender: $"{CurrentUserDetails.FName} {CurrentUserDetails.LName}",
                            UserAction: "CREATED",
                            TypeOfRequest: "Purchase Request",
                            TableTitle: "Requested Item",
                            Header: htmlHeader,
                            Body: htmlTable
                        )
                    );
                }

                AuditLog auditLog = new AuditLog();
                auditLog.LogEvent(CurrentUserDetails.UserID, "Purchase Request", "Insert", nextPrId, $"Added purchase request");
                RefreshRequestListTable();
            }
            else
            {
                MessageBox.Show("Add items to request for purchase first.");
            }
        }




        private void cancelbtn_Click(object sender, EventArgs e)
        {
            Branch.BranchId = null;
            Branch.DeptId = null;
            this.Close();
        }

        private void PurchaseRequestWindow_Load(object sender, EventArgs e)
        {

        }

        private string GetNextItemId(string datePrefix, DatabaseClass db)
        {
            string lastItemIdQuery = @"SELECT TOP 1 purchase_request_item_id FROM Purchase_Request_Item 
                     WHERE purchase_request_item_id LIKE 'PRI-" + datePrefix + "-%' ORDER BY purchase_request_item_id DESC";
            string nextItemId = $"PRI-{datePrefix}-001"; // Default if no items found for today
            SqlDataReader dr = db.GetRecord(lastItemIdQuery);
            if (dr.Read())
            {
                string lastId = dr["purchase_request_item_id"].ToString();
                int lastNumber = int.Parse(lastId.Split('-')[2]);
                nextItemId = $"PRI-{datePrefix}-{(lastNumber + 1):D3}";
            }
            dr.Close();
            return nextItemId;
        }
        public void RefreshRequestListTable()
        {
            if (purchaseRequestPage != null)
            {
                purchaseRequestPage.PopulateRequestTable();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
