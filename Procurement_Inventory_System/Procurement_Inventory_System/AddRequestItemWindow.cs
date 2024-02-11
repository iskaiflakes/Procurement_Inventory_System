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
    public partial class AddRequestItemWindow : Form
    {
        public AddRequestItemWindow()
        {
            InitializeComponent();
        }

        private void addnewitembtn_Click(object sender, EventArgs e)
        {
            //the table must be refreshed after pressing the button
            //to reflect the item record instance in the table
            this.Close();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddRequestItemWindow_Load(object sender, EventArgs e)
        {
            PopulateItem();
        }
        private void PopulateItem()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT item_id, item_name FROM Item_List WHERE department_id='{CurrentUserDetails.DepartmentId}' AND section='{CurrentUserDetails.DepartmentSection}' ORDER BY item_name;";
            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Clear existing items to avoid duplication if this method is called more than once
            itemName.DataSource = null;
            itemName.DataSource = dt;
            itemName.DisplayMember = "item_name";
            itemName.ValueMember = "item_id";
            db.CloseConnection();
        }
    }
}
