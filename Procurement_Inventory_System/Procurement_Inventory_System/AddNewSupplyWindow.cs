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

namespace Procurement_Inventory_System
{
    public partial class AddNewSupplyWindow : Form
    {
        public AddNewSupplyWindow()
        {
            InitializeComponent();
        }
        
        private void addnewitembtn_Click(object sender, EventArgs e)
        {
            //the table must be refreshed after pressing the button
            //to reflect the supply record instance in the table

            AddNewSupplyPrompt form = new AddNewSupplyPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddItemWindow_Load(object sender, EventArgs e)
        {
            PopulateItemCategory();
        }

        private void itemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PopulateItemCategory()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase("DESKTOP-OO08JTF");

            string query = "SELECT DISTINCT category FROM Item_List"; // Use DISTINCT to get unique values
            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            itemCategory.Items.Clear();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string category = dr["category"].ToString();
                itemCategory.Items.Add(category);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();
        }
        private void PopulateItemSupplier()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase("DESKTOP-OO08JTF");

            string query = "SELECT DISTINCT supplier_name FROM Supplier su JOIN Item_List il ON su.supplier_id=il.supplier_id"; // Use DISTINCT to get unique values
            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            itemCategory.Items.Clear();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string category = dr["category"].ToString();
                itemCategory.Items.Add(category);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();
        }
        private void PopulateItemDepartment()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase("DESKTOP-OO08JTF");

            string query = "SELECT DISTINCT department_name FROM Item_List"; // Use DISTINCT to get unique values
            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            itemCategory.Items.Clear();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string category = dr["category"].ToString();
                itemCategory.Items.Add(category);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();
        }
        private void PopulateItemUnit()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase("DESKTOP-OO08JTF");

            string query = "SELECT DISTINCT supplier_id FROM Item_List"; // Use DISTINCT to get unique values
            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            itemCategory.Items.Clear();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string category = dr["category"].ToString();
                itemCategory.Items.Add(category);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();
        }
    }
}
