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
    public partial class UpdateAccWindow : Form
    {
        public UpdateAccWindow()
        {
            InitializeComponent();
        }

        private void updateaccbtn_Click(object sender, EventArgs e)
        {
            //
            //verify user input...
            //

            //the table must be refreshed after pressing the button
            //to reflect the updated account record instance in the table

            //call this when verified
            UpdateAccPrompt form = new UpdateAccPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editbtn_CheckedChanged(object sender, EventArgs e)
        {
            //Current all fields are disable
            //add code here to enable all fields for editing...
            if (editbtn.Checked == true)
            {
                personalinfo.Enabled = true;
                companyinfo.Enabled = true;
                accountinfo.Enabled = true;
            }
            else
            {
                personalinfo.Enabled = false;
                companyinfo.Enabled = false;
                accountinfo.Enabled = false;
            }
        }

        private void UpdateAccWindow_Load(object sender, EventArgs e)
        {
            LoadUserDetails();
            //PopulateBranch();
            //PopulateDepartment();
            //PopulateRole();
        }
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.DisplayRectangle.Location;
        }
        private void PopulateBranch()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "SELECT DISTINCT branch_id, branch_name FROM Branch"; // Use DISTINCT to get unique values
            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Clear existing items to avoid duplication if this method is called more than once
            branchbox.DataSource = null;
            branchbox.DataSource = dt;
            branchbox.DisplayMember = "branch_name";
            branchbox.ValueMember = "branch_id";

            db.CloseConnection();
        }
        private void PopulateDepartment()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT DISTINCT department_id, department_name FROM Department WHERE branch_id='{branchbox.SelectedValue}'"; // Use DISTINCT to get unique values
            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Clear existing items to avoid duplication if this method is called more than once
            department_box.DataSource = null;
            department_box.DataSource = dt;
            department_box.DisplayMember = "department_name";
            department_box.ValueMember = "department_id";

            db.CloseConnection();
        }
        private void PopulateSection()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT DISTINCT section_id, section_name FROM Section WHERE department_id='{department_box.SelectedValue}'"; // Use DISTINCT to get unique values
            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Clear existing items to avoid duplication if this method is called more than once
            sectionbox.DataSource = null;
            sectionbox.DataSource = dt;
            sectionbox.DisplayMember = "section_name";
            sectionbox.ValueMember = "section_id";

            db.CloseConnection();
        }
        private void PopulateRole()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT DISTINCT role_id, role_name FROM Emp_Role"; // Use DISTINCT to get unique values
            SqlDataAdapter da = db.GetMultipleRecords(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Clear existing items to avoid duplication if this method is called more than once
            selectRole.DataSource = null;
            selectRole.DataSource = dt;
            selectRole.DisplayMember = "role_name";
            selectRole.ValueMember = "role_id";

            db.CloseConnection();
        }

        private void branchbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDepartment();
        }

        private void department_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSection();
        }
        private void LoadUserDetails()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "SELECT * FROM Employee WHERE emp_id = @empId";
            SqlCommand cmd = new SqlCommand(query, db.GetSqlConnection());
            cmd.Parameters.AddWithValue("@empId", SelectedEmployee.emp_id);

            SqlDataReader dr = db.GetRecordCommand(cmd);
            if (dr.Read())
            {
                fname.Text = dr["emp_fname"].ToString();
                middleName.Text = dr["middle_initial"].ToString();
                lname.Text = dr["emp_lname"].ToString();
                suffix.Text = dr["suffix"].ToString();
                emailAdd.Text = dr["email_address"].ToString();
                contactNum.Text = dr["mobile_no"].ToString();
                address.Text = dr["house_no"].ToString();
                brgy.Text = dr["barangay"].ToString();
                city.Text = dr["city"].ToString();
                province.Text = dr["province"].ToString();
                zipCode.Text = dr["zip_code"].ToString();
                PopulateBranch();
                branchbox.SelectedValue = dr["branch_id"].ToString();
                PopulateDepartment();
                department_box.SelectedValue = dr["department_id"].ToString();
                PopulateSection();
                sectionbox.SelectedValue = dr["section_id"].ToString();
                PopulateRole();
                selectRole.SelectedValue = dr["role_id"].ToString();
            }

            dr.Close();
        
        }
    }
}
