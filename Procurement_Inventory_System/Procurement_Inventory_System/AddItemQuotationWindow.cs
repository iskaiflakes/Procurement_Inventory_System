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

            DataTable item_qtn_tbl = new DataTable();

            item_qtn_tbl.Columns.Add("Item ID", typeof(string));
            item_qtn_tbl.Columns.Add("Name", typeof(string));
            item_qtn_tbl.Columns.Add("Quantity", typeof(string));
            item_qtn_tbl.Columns.Add("Unit Price", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = item_qtn_tbl;
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
            DataTable supply_table = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string department = CurrentUserDetails.DepartmentId;
            string section = CurrentUserDetails.DepartmentSection;
            string query = "";

            if (department == "MOFHOF") // displays everything (head office)
            {
                query = "SELECT DISTINCT item_id, item_name FROM Item_List WHERE active = 1;"; // Use DISTINCT to get unique values
                
            }
            else  // only visible what is needed (employee account is not from head office)
            {
                query = $"SELECT il.item_id, il.item_name FROM Item_Inventory ii JOIN Item_List il ON ii.item_id = il.item_id WHERE il.department_id = '{department}' AND il.section = '{section}' AND il.active = 1 ORDER BY il.item_name; ";
            }

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

        public void LoadSelectedItemQuotation()
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
    }
}
