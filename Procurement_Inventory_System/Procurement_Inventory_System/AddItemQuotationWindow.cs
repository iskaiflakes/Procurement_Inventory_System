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
    
    public partial class AddItemQuotationWindow : Form
    {
        public ItemQuotation NewQuotationItem { get; private set; } = null;
        DataTable item_qtn_tbl;
        public SupplierQuotation NewSupQuo { get; private set; } = null;

        public AddItemQuotationWindow()
        {
            InitializeComponent();

            item_qtn_tbl = new DataTable();

            item_qtn_tbl.Columns.Add("Item ID", typeof(string));
            item_qtn_tbl.Columns.Add("Quantity", typeof(string));
            item_qtn_tbl.Columns.Add("Unit Price", typeof(string));
        }

        private void additemqtnbtn_Click(object sender, EventArgs e)
        {
            NewQuotationItem = new ItemQuotation
            {
                ItemId = itemName.SelectedValue.ToString(),
                quantity = Convert.ToInt32(itemQuant.Text),
                unit_price = itemUnitPrice.Text
            };

            // update datagridview
            LoadTable();

            // reset and removing the selected combobox to prevent choosing it again
            itemQuant.Text = null;
            itemUnitPrice.Text = null;
            itemName.SelectedItem = null;

            //RefreshItemListTable();
        }

        public void LoadTable()
        {
            item_qtn_tbl.Rows.Add(NewQuotationItem.ItemId, NewQuotationItem.quantity, NewQuotationItem.unit_price);
            dataGridView1.DataSource = item_qtn_tbl;
        }

        private void savequotationbtn_Click(object sender, EventArgs e)
        {
            // saves quotation data to quotation tbl
            StoreQuotation();
            StoreItemQuotation();

            // update datagridview in SupplierQuotationPage (stil figuring it out)

            SupplierQuotationPrompt form = new SupplierQuotationPrompt();
            form.ShowDialog();
            this.Close();
        }

        private void cancelbtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        public void LoadItemName()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";

            // will use purchase_request_id variable (depending on what purchase request is selected)
            query = $"SELECT Item_List.item_id, Item_List.item_name FROM Purchase_Request_Item INNER JOIN Item_List ON Purchase_Request_Item.item_id = Item_List.item_id INNER JOIN Supplier ON Item_List.supplier_id = Supplier.supplier_id WHERE Supplier.supplier_id = '{GetQuotationDetails.SupplierID}' AND Purchase_Request_Item.purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}'; ";

            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Clear existing items to avoid duplication if this method is called more than once
            itemName.DataSource = null;
            itemName.DataSource = dt;
            itemName.DisplayMember = "item_name";
            itemName.ValueMember = "item_id";

            itemName.SelectedItem = null;

            db.CloseConnection();
        }

        public void StoreQuotation()    // method for storing quotation details
        {
            // variables used for ID formattiing
            string idPrefix = "QUO-" + DateTime.Now.ToString("yyyyMMdd");
            string lastIdQuery = $"SELECT TOP 1 quotation_id FROM Quotation WHERE quotation_id LIKE '{idPrefix}-%' ORDER BY quotation_id DESC";
            string nextQuotationId = $"{idPrefix}-001"; // Default if no items found for today (this will be used when no record inside the table yet)

            // variables used for storing the data about the quotation
            string userID = CurrentUserDetails.UserID;

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            SqlDataReader dr = db.GetRecord(lastIdQuery);
            if (dr.Read())  // checks if there is a record inside the table
            {
                string lastId = dr["quotation_id"].ToString();
                int lastNumber = int.Parse(lastId.Split('-')[2]);
                nextQuotationId = $"{idPrefix}-{(lastNumber + 1):D3}";
            }
            dr.Close();

            // saving the latest quotation ID
            GetQuotationDetails.QuotationID = nextQuotationId;


            // performs insert operation 
            string insertCmd = $"INSERT INTO Quotation (quotation_id, supplier_id, vat_status, quotation_date, quotation_validity, quotation_user_id) VALUES('{nextQuotationId}', '{GetQuotationDetails.SupplierID}', '{GetQuotationDetails.VatStatus}', GETDATE(), '{GetQuotationDetails.Validity}', '{userID}');";
            int returnRow = db.insDelUp(insertCmd);

            if (returnRow > 0)  // checks if the insertion was done successfully
            {
                db.CloseConnection();   // closes the db connection to prevent the app from crashing
            }

            NewSupQuo = new SupplierQuotation
            {
                QuotationID = nextQuotationId,
                Supplier = GetQuotationDetails.SupplierID,
                Validity = GetQuotationDetails.Validity,
                Vat_Status = GetQuotationDetails.VatStatus
            };
        }

        public void StoreItemQuotation()    // for storing item quotation
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string itemId = row.Cells[0].Value.ToString();
                    double unitPrice = Convert.ToDouble(row.Cells[2].Value);
                    string quoID = GetQuotationDetails.QuotationID;

                    string insertCmd = $"INSERT INTO Item_Quotation (quotation_id, item_id, unit_price) VALUES('{quoID}', '{itemId}', '{unitPrice}');";
                    int returnRow = db.insDelUp(insertCmd);
                    // Update Purchase_Request_Item with the new QuotationId
                    string updateCmd = $"UPDATE Purchase_Request_Item SET quotation_id = '{quoID}' WHERE purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}' AND item_id = '{itemId}';";
                    db.insDelUp(updateCmd);
                }
            }
            db.CloseConnection();
        }

        public void LoadSelectedItemQuotation() // loading the item quotation details
        {
            DataTable quotation_item = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT Item_List.item_id, Item_List.item_name, Item_Quotation.quantity, Item_Quotation.unit_price FROM Item_Quotation INNER JOIN Quotation ON Item_Quotation.quotation_id = Quotation.quotation_id INNER JOIN Item_List ON Item_List.item_id = Item_Quotation.item_id WHERE Quotation.quotation_id = '{GetQuotationDetails.QuotationID}'";

            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(quotation_item);
            dataGridView1.DataSource = quotation_item;
            db.CloseConnection();
        }

        private void AddItemQuotationWindow_Load(object sender, EventArgs e)
        {
            LoadItemName();
        }

        public void RefreshItemListTable()
        {
            LoadSelectedItemQuotation();
        }

        private void itemName_SelectedValueChanged(object sender, EventArgs e)
        {
            // if there is no selected item in the item name combobox, the quantity textbox should be null as well
            if (itemName.SelectedItem == null)
            {
                itemQuant.Text = null;
            }
            else
            {
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string query = $"SELECT Purchase_Request_Item.item_quantity FROM Purchase_Request INNER JOIN Purchase_Request_Item on Purchase_Request.purchase_request_id = Purchase_Request_Item.purchase_request_id INNER JOIN Item_List on Item_List.item_id = Purchase_Request_Item.item_id WHERE Purchase_Request.purchase_request_id = '{PurchaseRequestIDNum.PurchaseReqID}' AND Item_List.item_id = '{itemName.SelectedValue}';";
                SqlDataReader quantRec = db.GetRecord(query);

                if (quantRec.HasRows)
                {
                    quantRec.Read();

                    itemQuant.Text = quantRec["item_quantity"].ToString();  // displays the quantity of the selected item
                }

                db.CloseConnection();
            }
        }
    }

    public class ItemQuotation
    {
        public string ItemId { get; set; }
        public int quantity { get; set; }
        public string unit_price { get; set; }
    }

    public class SupplierQuotation
    {
        public string QuotationID { get; set; }
        public string Supplier { get; set; }
        public string Validity { get; set; }
        public string Vat_Status { get; set; }
    }
}
