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
using System.Collections;

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
            if ((Branch.BranchId == null)&&(Branch.DeptId == null))
            {
                if ((userRole == "11") || (userRole == "13"))
                {
                    PopulateBranch();
                }
            }
            else
            {
                if ((userRole == "11") || (userRole == "13"))
                {
                    PopulateBranch();
                    branchFilter.SelectedValue = Branch.BranchId;
                    PopulateDepartment(Branch.BranchId); // Populate departments based on the selected branch
                    branchFilter.Enabled = false;
                    deptFilter.Enabled = false;
                }
            }
        }

        private void PopulateItem(string selectedBranchId, string selectedDepartmentId)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";
            string userRole = CurrentUserDetails.UserID.Substring(0, 2);

            if (CurrentUserDetails.BranchId == "MOF" && userRole == "11")
            {
                query = $"SELECT item_id, item_name FROM Item_List INNER JOIN DEPARTMENT ON Item_List.department_id=DEPARTMENT.DEPARTMENT_ID WHERE DEPARTMENT.BRANCH_ID = '{selectedBranchId}' AND DEPARTMENT.DEPARTMENT_ID = '{selectedDepartmentId}' AND Item_List.active = '1' ORDER BY item_name";
            }
            else
            {
                if (userRole == "11")
                {
                    query = $"SELECT item_id, item_name FROM Item_List INNER JOIN DEPARTMENT ON Item_List.department_id=DEPARTMENT.DEPARTMENT_ID WHERE DEPARTMENT.BRANCH_ID = '{CurrentUserDetails.BranchId}' AND DEPARTMENT.DEPARTMENT_ID = '{selectedDepartmentId}' AND Item_List.active = '1' ORDER BY item_name";
                }
                else if (userRole == "13")
                {
                    query = $"SELECT item_id, item_name FROM Item_List WHERE department_id='{CurrentUserDetails.DepartmentId}' AND section_id='{CurrentUserDetails.DepartmentSection}' AND Item_List.active = '1' ORDER BY item_name";
                }
            }

            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
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

            if ((CurrentUserDetails.BranchId == "MOF") && (CurrentUserDetails.Role == "11"))
            {
                query = "SELECT DISTINCT BRANCH_NAME, BRANCH_ID FROM BRANCH";
            }
            else
            {
                query = $"SELECT DISTINCT BRANCH_NAME, BRANCH_ID FROM BRANCH WHERE BRANCH_ID='{CurrentUserDetails.BranchId}'";
                branchFilter.Enabled = false;
            }

            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);

            branchFilter.DataSource = null;
            branchFilter.DisplayMember = "BRANCH_NAME";
            branchFilter.ValueMember = "BRANCH_ID";
            branchFilter.DataSource = dt;

            branchFilter.SelectedValue = CurrentUserDetails.BranchId;

            db.CloseConnection();
        }

        private void PopulateDepartment(string selectedBranchId)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";

            if (CurrentUserDetails.Role == "11")
            {
                query = $"SELECT DEPARTMENT_ID, DEPARTMENT_NAME FROM DEPARTMENT WHERE BRANCH_ID='{selectedBranchId}'";
            }
            else
            {
                query = $"SELECT DEPARTMENT_ID, DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID='{CurrentUserDetails.DepartmentId}'";
            }
             
            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);

            deptFilter.DataSource = null;
            deptFilter.DisplayMember = "DEPARTMENT_NAME";
            deptFilter.ValueMember = "DEPARTMENT_ID";
            deptFilter.DataSource = dt;

            deptFilter.Text = "";
            deptFilter.Focus();

            // Check if there are any items in the ComboBox
            if (deptFilter.Items.Count > 0)
            {
                // Select the first item in the ComboBox
                deptFilter.SelectedIndex = 0;
            }

            db.CloseConnection();
        }

        private void AddNewItemBtnClick(object sender, EventArgs e)
        {
            bool isInteger = int.TryParse(itemQuant.Text, out int result);
            if (itemName.Text == "")
            {
                errorProvider1.SetError(itemName, "Select an item.");
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
                    return;
                }
                else
                {
                    errorProvider1.SetError(itemQuant, string.Empty);
                }
            }

            if ((itemName.Text != "") && (isInteger))
            {
                errorProvider1.SetError(itemQuant, string.Empty);
                NewItem = new ItemData
                {
                    ItemId = itemName.SelectedValue.ToString(),
                    ItemName = itemName.Text,
                    Quantity = Convert.ToInt32(itemQuant.Text),
                    Remarks = remarks.Text
                };
                this.DialogResult = DialogResult.OK;
                this.Close();

                Branch.BranchId = branchFilter.SelectedValue.ToString();
                Branch.DeptId = deptFilter.SelectedValue.ToString();
            }
        }

        private void CancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void branchFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedBranchId = branchFilter.SelectedValue?.ToString();
            if (!string.IsNullOrEmpty(selectedBranchId))
            {
                PopulateDepartment(selectedBranchId);
            }
        }

        private void deptFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBranchId = branchFilter.SelectedValue?.ToString();
            string selectedDepartmentId = deptFilter.SelectedValue?.ToString();
            if (!string.IsNullOrEmpty(selectedBranchId) && !string.IsNullOrEmpty(selectedDepartmentId))
            {
                PopulateItem(selectedBranchId, selectedDepartmentId);
            }
        }
    }

    public class ItemData
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
    }

    public static class Branch
    {
        public static string BranchId { get; set; }
        public static string DeptId { get; set; }
    }
}
