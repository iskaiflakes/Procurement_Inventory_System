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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Procurement_Inventory_System.Procurement_Inventory_SystemDataSet;

namespace Procurement_Inventory_System
{
    public partial class AddRequestItemWindow : Form
    {
        public ItemData NewItem { get; private set; } = null;

        public AddRequestItemWindow()
        {
            InitializeComponent();
        }

        private void AddRequestItemWindow_Load(object sender, EventArgs e)
        {
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);
            if ((userRole == "11") || (userRole == "13"))
            {
                PopulateBranch();
            }   
        }

        private void PopulateItem(string selectedBranchId)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            if (CurrentUserDetails.BranchId == "MOF" && userRole == "11") // if the Branch is Main Office and an ADMIN, all of the item lists are loaded
            {
                query = $"SELECT item_id, item_name FROM Item_List INNER JOIN DEPARTMENT ON Item_List.department_id=DEPARTMENT.DEPARTMENT_ID WHERE DEPARTMENT.BRANCH_ID = '{selectedBranchId}' ORDER BY item_name"; 
            }
            else // if the branch is not MOF, two authorized users will have access (admin and requestor)
            {
                if (userRole == "11") // if the user is admin, inventory items within their branch are loaded
                {
                    query = $"SELECT item_id, item_name FROM Item_List INNER JOIN DEPARTMENT ON Item_List.department_id=DEPARTMENT.DEPARTMENT_ID WHERE DEPARTMENT.BRANCH_ID = '{CurrentUserDetails.BranchId}' ORDER BY item_name";
                }
                else if (userRole == "13") // if the user is a requestor, only inventor items within their department section are loaded
                {
                    query = $"SELECT item_id, item_name FROM Item_List WHERE department_id='{CurrentUserDetails.DepartmentId}' AND section_id='{CurrentUserDetails.DepartmentSection}' ORDER BY item_name";
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
            itemName.Text = "";
            itemName.Focus();
            db.CloseConnection();
        }

        private void PopulateBranch()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";

            if (CurrentUserDetails.BranchId == "MOF")
            {
                query = "SELECT DISTINCT BRANCH_NAME, BRANCH_ID FROM BRANCH"; // select all branch names
            }
            else
            {
                query = $"SELECT DISTINCT BRANCH_NAME, BRANCH_ID FROM BRANCH WHERE BRANCH_ID='{CurrentUserDetails.BranchId}'"; // only allowing creating user account within that branch if the currently logged in user account is not from MOF
                branchFilter.Enabled = false;
            }

            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Clear existing items to avoid duplication if this method is called more than once
            branchFilter.DataSource = null;
            branchFilter.DisplayMember = "BRANCH_NAME";
            branchFilter.ValueMember = "BRANCH_ID";
            branchFilter.DataSource = dt;

            // Set the selected value after data source is assigned
            branchFilter.SelectedValue = CurrentUserDetails.BranchId;

            db.CloseConnection();
        }

        private void AddNewItemBtnClick(object sender, EventArgs e)
        {
            // The table must be refreshed after pressing the button
            // to reflect the item record instance in the table
            bool isInteger = int.TryParse(itemQuant.Text, out int result);
            if (itemName.Text == "")
            {
                errorProvider1.SetError(itemName, "Select an item");
                itemName.Focus();
            }
            else
            {
                errorProvider1.SetError(itemName, string.Empty);
            }

            if (!isInteger)
            {
                errorProvider1.SetError(itemQuant, "Enter a valid number.");
            }
            else
            {
                int quantity = int.Parse(itemQuant.Text);

                if (quantity <= 0)
                {
                    errorProvider1.SetError(itemQuant, "The value must be greater than 0.");
                    return; // Exit the method if the quantity is not valid
                }
                else
                {
                    errorProvider1.SetError(itemQuant, string.Empty);
                }
            }

            if (itemName.Text != "" && isInteger)
            {
                errorProvider1.SetError(itemQuant, string.Empty);
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
        }


        private void CancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void branchFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedBranchId = branchFilter.SelectedValue.ToString();
            PopulateItem(selectedBranchId);
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
