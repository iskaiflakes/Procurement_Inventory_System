﻿using System;
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
using MailKit;
using MimeKit;
using MailKit.Security;

namespace Procurement_Inventory_System
{
    public partial class AddInvoiceWindow : Form
    {
        private InvoicePage invoicePage;
        public AddInvoiceWindow(InvoicePage invoicePage)
        {
            InitializeComponent();
            this.invoicePage = invoicePage;
        }

        public void InitializePurchaseOrderCB()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";

            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                if (((CurrentUserDetails.BranchId == "MOF") && (userRole == "11")) || ((CurrentUserDetails.BranchId == "MOF") && (userRole == "16")))   // if the user is an admin and accountant and is from MOF, all Fulfilled PO options are loaded
                {
                    query = "SELECT DISTINCT PO.purchase_order_id\r\nFROM Purchase_Order PO\r\nINNER JOIN Purchase_Order_Item POI ON PO.purchase_order_id = POI.purchase_order_id\r\nINNER JOIN Purchase_Request_Item PRI ON PRI.purchase_request_item_id = POI.purchase_request_item_id\r\nINNER JOIN Item_List IL ON IL.item_id = PRI.item_id\r\nWHERE PO.purchase_order_status = 'FULFILLED'\r\nAND NOT EXISTS (\r\n    SELECT 1\r\n    FROM Invoice I\r\n    WHERE I.purchase_order_id = PO.purchase_order_id\r\n)\r\nAND EXISTS (\r\n    SELECT 1\r\n    FROM Purchase_Order_Item POI2\r\n    WHERE POI2.purchase_order_id = PO.purchase_order_id\r\n    AND POI2.order_item_status <> 'cancelled'\r\n);";
                }
                else
                {
                    if (userRole == "11")   // if the user is an admin, Fulfilled PO options are loaded within your branch only
                    {
                        query = $"SELECT DISTINCT PO.purchase_order_id\r\nFROM Purchase_Order PO\r\nINNER JOIN Purchase_Order_Item POI ON PO.purchase_order_id = POI.purchase_order_id\r\nINNER JOIN Purchase_Request_Item PRI ON PRI.purchase_request_item_id = POI.purchase_request_item_id\r\nINNER JOIN Item_List IL ON IL.item_id = PRI.item_id\r\nINNER JOIN DEPARTMENT DEP ON DEP.DEPARTMENT_ID = IL.department_id\r\nWHERE PO.purchase_order_status = 'FULFILLED' AND DEP.BRANCH_ID = '{CurrentUserDetails.BranchId}'\r\nAND NOT EXISTS (\r\n    SELECT 1\r\n    FROM Invoice I\r\n    WHERE I.purchase_order_id = PO.purchase_order_id\r\n)\r\nAND EXISTS (\r\n    SELECT 1\r\n    FROM Purchase_Order_Item POI2\r\n    WHERE POI2.purchase_order_id = PO.purchase_order_id\r\n    AND POI2.order_item_status <> 'cancelled'\r\n);";
                    }
                }

                SqlDataAdapter da = db.GetMultipleRecords(query);
                DataTable dt = new DataTable();
                da.Fill(dt);

                itemName.DataSource = null;
                itemName.DataSource = dt;
                itemName.DisplayMember = "purchase_order_id";
                itemName.ValueMember = "purchase_order_id";

                itemName.SelectedItem = null;

                db.CloseConnection();
            }
        }

        public void StoreInvoiceDetails()
        {
            // variable for total_amount
            double totalAmount = 0;
            double vatAmount = 0;

            // query for determining the vat status of the supplier
            string vatStatus = $"SELECT Q.vat_status FROM Purchase_Request_Item PRI\r\nINNER JOIN Purchase_Order_Item POI ON PRI.purchase_request_item_id=POI.purchase_request_item_id\r\nINNER JOIN Quotation Q ON Q.quotation_id=PRI.quotation_id\r\nWHERE POI.purchase_order_id = '{itemName.SelectedValue}'\r\nGROUP BY Q.vat_status";
            string supID = "", supVatStatus = "", amountQuery = "";

            // variables used for ID formattiing
            string idPrefix = "INV-" + DateTime.Now.ToString("yyyyMMdd");
            string lastIdQuery = $"SELECT TOP 1 invoice_id FROM Invoice WHERE invoice_id LIKE '{idPrefix}-%' ORDER BY invoice_id DESC";
            string nextInvoiceId = $"{idPrefix}-001"; // Default if no items found for today (this will be used when no record inside the table yet)

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlDataReader dr = db.GetRecord(lastIdQuery);
            if (dr.Read())  // checks if there is a record inside the table
            {
                string lastId = dr["invoice_id"].ToString();
                int lastNumber = int.Parse(lastId.Split('-')[2]);
                nextInvoiceId = $"{idPrefix}-{(lastNumber + 1):D3}";
            }
            dr.Close();

            // gets the vat status of the supplier
            SqlDataReader dr1 = db.GetRecord(vatStatus);
            if (dr1.Read())
            {
                supVatStatus = dr1["vat_status"].ToString();
            }
            dr1.Close();

            // conditional statement for vat status
            if (supVatStatus == "VAT INCLUDED") // if VAT INCLUDED, then there is no VAT that the company will be paying
            {
                amountQuery = $"SELECT SUM(total_price) as total_amount, (SUM(total_price) * 0) as vat_amount, Purchase_Order.supplier_id \r\nFROM Purchase_Order INNER JOIN Purchase_Order_Item ON Purchase_Order.purchase_order_id = Purchase_Order_Item.purchase_order_id \r\ninner join Purchase_Request_Item on Purchase_Request_Item.purchase_request_item_id = Purchase_Order_Item.purchase_request_item_id \r\ninner join Item_List on Item_List.item_id = Purchase_Request_Item.item_id\r\nWHERE Purchase_Order.purchase_order_id = '{itemName.SelectedValue}' AND Purchase_Order_Item.order_item_status = 'DELIVERED' \r\nGROUP BY Purchase_Order.supplier_id";
            }
            else if (supVatStatus == "VAT EXCLUDED")    // if VAT INCLUDED, then there is VAT that the company will be paying
            {
                amountQuery = $"SELECT SUM(total_price) as total_amount, (SUM(total_price) * 0.12) as vat_amount, Purchase_Order.supplier_id \r\nFROM Purchase_Order INNER JOIN Purchase_Order_Item ON Purchase_Order.purchase_order_id = Purchase_Order_Item.purchase_order_id \r\ninner join Purchase_Request_Item on Purchase_Request_Item.purchase_request_item_id = Purchase_Order_Item.purchase_request_item_id \r\ninner join Item_List on Item_List.item_id = Purchase_Request_Item.item_id\r\nWHERE Purchase_Order.purchase_order_id = '{itemName.SelectedValue}' AND Purchase_Order_Item.order_item_status = 'DELIVERED' \r\nGROUP BY Purchase_Order.supplier_id";
            }

            // getting the computed total amount, vat amount and the supplier id
            SqlDataReader dr2 = db.GetRecord(amountQuery);
            if (dr2.Read())
            {
                totalAmount = Convert.ToDouble(dr2["total_amount"]);
                vatAmount = Convert.ToDouble(dr2["vat_amount"]);
                supID = dr2["supplier_id"].ToString();
            }
            dr2.Close();

            string query = $"SELECT Supplier_Term.supplier_term_id FROM Purchase_Order INNER JOIN Supplier  ON Purchase_Order.supplier_id = Supplier.supplier_id INNER JOIN Supplier_Term ON Supplier.supplier_term_id = Supplier_Term.supplier_term_id WHERE Purchase_Order.purchase_order_id = '{itemName.SelectedValue}'";
            string supTerm = "";

            // getting the supplier term
            SqlDataReader dr3 = db.GetRecord(query);
            if (dr3.Read())
            {
                supTerm = dr3["supplier_term_id"].ToString();
            }
            dr3.Close();

            DateTime invDate, dueDate;

            if ((supTerm == "COD") || (supTerm == "DPY"))
            {
                invDate = DateTime.Today;
                dueDate = invDate;
            }
            else if (supTerm == "30D")
            {
                invDate = DateTime.Today;
                dueDate = DateTime.Today.AddDays(30);
            }
            else
            {
                invDate = DateTime.Today;
                dueDate = DateTime.Today.AddDays(45);
            }


            string insertCmd = "INSERT INTO Invoice (invoice_id, supplier_id, purchase_order_id, invoice_user_id, total_amount, invoice_date, vat_amount, payment_due_date) " +
                   "VALUES (@nextInvoiceId, @supID, @purchaseOrderId, @userId, @totalAmount, @invDate, @vatAmount, @dueDate)";

            SqlCommand cmd = new SqlCommand(insertCmd, db.GetSqlConnection());

            // Add parameters to the command
            cmd.Parameters.AddWithValue("@nextInvoiceId", nextInvoiceId);
            cmd.Parameters.AddWithValue("@supID", supID);
            cmd.Parameters.AddWithValue("@purchaseOrderId", itemName.SelectedValue);
            cmd.Parameters.AddWithValue("@userId", CurrentUserDetails.UserID);
            cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
            cmd.Parameters.AddWithValue("@invDate", invDate);
            cmd.Parameters.AddWithValue("@vatAmount", vatAmount);
            cmd.Parameters.AddWithValue("@dueDate", dueDate);

            int returnRow = cmd.ExecuteNonQuery();


            if (returnRow > 0)  // checks if the insertion was done successfully
            {
                AuditLog auditLog = new AuditLog();
                auditLog.LogEvent(CurrentUserDetails.UserID, "Invoice", "Insert", nextInvoiceId, $"Added invoice");
                db.CloseConnection();   // closes the db connection to prevent the app from crashing

                // Send notification emails
                NotifyUsersOfDeliveredItems(itemName.SelectedValue.ToString());
            }
        }

        private async void NotifyUsersOfDeliveredItems(string purchaseOrderId)
        {
            DatabaseClass dbEmail = new DatabaseClass();
            dbEmail.ConnectDatabase();
            string requestorQuery = @"
                SELECT 
                    DISTINCT E.email_address, 
                    E.emp_fname, 
                    E.emp_lname,
                    PR.purchase_request_id
                FROM 
                    Purchase_Order PO
                    INNER JOIN Purchase_Order_Item POI ON PO.purchase_order_id = POI.purchase_order_id
                    INNER JOIN Purchase_Request_Item PRI ON POI.purchase_request_item_id = PRI.purchase_request_item_id
                    INNER JOIN Purchase_Request PR ON PRI.purchase_request_id = PR.purchase_request_id
                    INNER JOIN Employee E ON PR.purchase_request_user_id = E.emp_id
                WHERE 
                    PO.purchase_order_id = @purchaseOrderId
                    AND POI.order_item_status = 'DELIVERED'
            ";

            List<(string Email, string FullName, string PurchaseRequestId)> requestors = new List<(string Email, string FullName, string PurchaseRequestId)>();
            using (SqlCommand cmd = new SqlCommand(requestorQuery, dbEmail.GetSqlConnection()))
            {
                cmd.Parameters.AddWithValue("@purchaseOrderId", purchaseOrderId);
                SqlDataReader requestorDr = cmd.ExecuteReader();
                while (requestorDr.Read())
                {
                    requestors.Add((
                        requestorDr["email_address"].ToString(),
                        $"{requestorDr["emp_fname"]} {requestorDr["emp_lname"]}",
                        requestorDr["purchase_request_id"].ToString()
                    ));
                }
                requestorDr.Close();
            }

            string itemDetailsQuery = @"
                SELECT 
                    PRI.purchase_request_item_id AS 'Purchase Request Item ID', 
                    IL.item_name AS 'Item Name', 
                    PRI.item_quantity AS 'Quantity', 
                    ISNULL(CONVERT(varchar, IQ.unit_price), 'N/A') AS 'Unit Price'
                FROM 
                    Purchase_Request_Item PRI
                    JOIN Item_List IL ON PRI.item_id = IL.item_id
                    LEFT JOIN Item_Quotation IQ ON PRI.quotation_id = IQ.quotation_id AND PRI.item_id = IQ.item_id
                WHERE 
                    PRI.purchase_request_id = @purchaseRequestId
            ";

            var emailSender = new EmailSender(
                smtpHost: "smtp.gmail.com",
                smtpPort: 587,
                smtpUsername: "procurementinventory27@gmail.com",
                smtpPassword: "nxil kusg izwe gayx",
                sslOptions: SecureSocketOptions.StartTls
            );

            foreach (var requestor in requestors)
            {
                List<string> htmlTableRows = new List<string>();
                string[] headers = { "Purchase Request Item ID", "Item Name", "Quantity", "Unit Price" };
                string htmlHeader = EmailBuilder.TableHeaders(headers.ToList());

                using (SqlCommand itemCmd = new SqlCommand(itemDetailsQuery, dbEmail.GetSqlConnection()))
                {
                    itemCmd.Parameters.AddWithValue("@purchaseRequestId", requestor.PurchaseRequestId);
                    SqlDataReader itemDr = itemCmd.ExecuteReader();
                    while (itemDr.Read())
                    {
                        List<string> rowData = new List<string>
                        {
                            itemDr["Purchase Request Item ID"].ToString(),
                            itemDr["Item Name"].ToString(),
                            itemDr["Quantity"].ToString(),
                            itemDr["Unit Price"].ToString()
                        };
                        htmlTableRows.Add(EmailBuilder.TableRow(rowData));
                    }
                    itemDr.Close();
                }

                string emailStatus = await emailSender.SendEmail(
                    fromName: "Purchase Request Procurement Notification [NOREPLY]",
                    fromAddress: "procurementinventory27@gmail.com",
                    toName: requestor.FullName,
                    toAddress: requestor.Email,
                    subject: $"Purchase Request {requestor.PurchaseRequestId} Items Procured",
                    htmlTable: EmailBuilder.ContentBuilder(
                        requestID: requestor.PurchaseRequestId,
                        Receiver: requestor.FullName,
                        Sender: $"{CurrentUserDetails.FName} {CurrentUserDetails.LName}",
                        UserAction: "PROCURED",
                        TypeOfRequest: "PURCHASE REQUEST",
                        TableTitle: "Procured Items",
                        Header: htmlHeader,
                        Body: htmlTableRows.ToArray()
                    )
                );
            }

            dbEmail.CloseConnection();
        }
        public void RefreshRequestListTable()
        {
            if (invoicePage != null)
            {
                invoicePage.PopulateInvoiceTable();
            }
        }

        private void AddInvoiceWindowLoad(object sender, EventArgs e)
        {
            if (CurrentUserDetails.UserID != null)
            {
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                // will only load if the users are either admin or purchasing department
                if ((userRole == "11") || (userRole == "16"))
                {
                    InitializePurchaseOrderCB();
                }
            }
        }

        private void AddInvoiceBtnClick(object sender, EventArgs e)
        {
            if (itemName.SelectedValue != null)
            {
                StoreInvoiceDetails();
                RefreshRequestListTable();

                AddInvoicePrompt form = new AddInvoicePrompt();
                form.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Select a purchase order first.");
            }
                
        }

        private void CancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
