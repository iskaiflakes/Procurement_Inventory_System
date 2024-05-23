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
        public ItemData NewItem { get; private set; } = null;
        public AddRequestItemWindow()
        {
            InitializeComponent();
        }

        private void addnewitembtn_Click(object sender, EventArgs e)
        {
            //the table must be refreshed after pressing the button
            //to reflect the item record instance in the table
            NewItem = new ItemData
            {
                ItemId = itemName.SelectedValue.ToString(),
                ItemName = itemName.Text,
                Quantity = Convert.ToInt32(itemQuant.Text), 
                Remarks = remarks.Text
            };

            this.DialogResult = DialogResult.OK; // Set dialog result to OK to indicate success
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
            string query = "";
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            if ((CurrentUserDetails.BranchId == "MOF")&&(userRole == "11")) // if the Branch is Main Office and an ADMIN, all of the item lists are loaded
            {
                query = "SELECT item_id, item_name FROM Item_List ORDER BY item_name";
            }
            else // if the branch is not MOF, two authorized users will have an access (admin and requestor)
            {
                if (userRole == "11")   // if the user is admin, inventory items within the their branch is loaded
                {
                    query = $"SELECT item_id, item_name FROM Item_List INNER JOIN DEPARTMENT ON Item_List.department_id=DEPARTMENT.DEPARTMENT_ID\r\nWHERE DEPARTMENT.BRANCH_ID = '{CurrentUserDetails.BranchId}' ORDER BY item_name";
                }
                else if (userRole == "13")  // if the user is a requestor, only inventor items within their department section is loaded
                {
                    query = $"SELECT item_id, item_name FROM Item_List WHERE department_id='{CurrentUserDetails.DepartmentId}' AND section_id='{CurrentUserDetails.DepartmentSection}' ORDER BY item_name;";
                }
            }
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
    public class ItemData
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
    }
}
