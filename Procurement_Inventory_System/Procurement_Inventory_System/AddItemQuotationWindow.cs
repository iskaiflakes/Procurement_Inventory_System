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
        public AddItemQuotationWindow()
        {
            InitializeComponent();
        }

        private void additemqtnbtn_Click(object sender, EventArgs e)
        {
            StoreAddedItemQuotation();
            RefreshItemListTable();
        }

        public void StoreAddedItemQuotation()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string quoID = GetQuotationID.QuotationID;
            string insertCmd = $"INSERT INTO Item_Quotation (quotation_id, item_id, quantity, unit_price) VALUES('{quoID}', '{itemName.SelectedValue}', '{itemQuant.Text}', '{itemUnitPrice.Text}');";
            int returnRow = db.insDelUp(insertCmd);

            if (returnRow > 0)
            {
                db.CloseConnection();
            }
        }

        private void savequotationbtn_Click(object sender, EventArgs e)
        {
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
            query = $"SELECT Item_List.item_name, Item_List.item_id FROM Purchase_Request INNER JOIN Purchase_Request_Item on Purchase_Request.purchase_request_id = Purchase_Request_Item.purchase_request_id INNER JOIN Item_List on Item_List.item_id = Purchase_Request_Item.item_id WHERE Purchase_Request.purchase_request_id = 'PR-20240101-001';";

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

        public void LoadSelectedItemQuotation() // loading the item quotation details
        {
            DataTable quotation_item = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT Item_List.item_id, Item_List.item_name, Item_Quotation.quantity, Item_Quotation.unit_price FROM Item_Quotation INNER JOIN Quotation ON Item_Quotation.quotation_id = Quotation.quotation_id INNER JOIN Item_List ON Item_List.item_id = Item_Quotation.item_id WHERE Quotation.quotation_id = '{GetQuotationID.QuotationID}'";

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
                string query = $"SELECT Purchase_Request_Item.item_quantity FROM Purchase_Request INNER JOIN Purchase_Request_Item on Purchase_Request.purchase_request_id = Purchase_Request_Item.purchase_request_id INNER JOIN Item_List on Item_List.item_id = Purchase_Request_Item.item_id WHERE Purchase_Request.purchase_request_id = 'PR-20240101-001' AND Item_List.item_id = '{itemName.SelectedValue}';";
                SqlDataReader quantRec = db.GetRecord(query);

                if (quantRec.HasRows)
                {
                    quantRec.Read();

                    itemQuant.Text = quantRec["item_quantity"].ToString();
                }

                db.CloseConnection();
            }
        }
    }
}
