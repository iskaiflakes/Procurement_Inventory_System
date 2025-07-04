﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Procurement_Inventory_System
{

    public partial class UpdateAccWindow : Form
    {
        private UserManagementPage userManagementPage;
        protected bool goCreateAcc, goCreate = true;
        private bool isFormLoaded = false, isDeactBefore = false;
        string branchId = "", departmentId = "", roleId = "";

        public UpdateAccWindow(UserManagementPage userManagementPage)
        {
            InitializeComponent();
            this.userManagementPage = userManagementPage;
            selectRole.Visible = false;
            label15.Visible = false;

            if (deactRadBtn.Checked)
            {
                isDeactBefore = true;
            }
        }

        private void updateaccbtn_Click(object sender, EventArgs e)
        {
            if(editbtn.Checked == true)
            {
                if (Mname_validated() && Lname_validated() && email_validated() && contactNum_validated() && fname_validated() && address1_validated() && brgy_validated() && city_validated() && prov_validated() && zipcode_validated() && branch_validated() && dept_validated() && section_validated() && role_validated())
                {
                    string fname = this.fname.Text;
                    string middleInitial = this.middleName.Text;
                    string lname = this.lname.Text;
                    string suffix = this.suffix.Text;
                    string email = this.emailAdd.Text;
                    string contactNum = this.contactNum.Text;
                    string address = this.address.Text;
                    string barangay = this.brgy.Text;
                    string city = this.city.Text;
                    string province = this.province.Text;
                    string zipCode = this.zipCode.Text;
                    branchId = branchbox.SelectedValue.ToString();
                    departmentId = department_box.SelectedValue.ToString();
                    string sectionId = sectionbox.SelectedValue.ToString();
                    roleId = selectRole.SelectedValue.ToString();
                    string accountStatus = "";

                    if (activeRadBtn.Checked)
                    {
                        accountStatus = "ACTIVATED";
                        
                    }
                    else if (deactRadBtn.Checked)
                    {
                        accountStatus = "DEACTIVATED";
                    }

                    if (goCreate)
                    {
                        // Create the SQL update query
                        string query = $"UPDATE Employee SET emp_fname = @fname, middle_initial = @middleInitial, emp_lname = @lname, " +
                                       $"suffix = @suffix, email_address = @Email, mobile_no = @contactNum, house_no = @address, barangay = @barangay, " +
                                       $"city = @city, province = @province, zip_code = @zipCode, branch_id = @branchId, department_id = @departmentId, section_id = @sectionId, " +
                                       $"role_id = @roleId  WHERE emp_id = @empId";

                        // Execute the query
                        try
                        {
                            DatabaseClass db = new DatabaseClass();
                            db.ConnectDatabase();
                            using (SqlCommand cmd = new SqlCommand(query, db.GetSqlConnection()))
                            {
                                // Add parameters to avoid SQL injection
                                cmd.Parameters.AddWithValue("@fname", fname);
                                cmd.Parameters.AddWithValue("@middleInitial", middleInitial);
                                cmd.Parameters.AddWithValue("@lname", lname);
                                cmd.Parameters.AddWithValue("@suffix", suffix);
                                cmd.Parameters.AddWithValue("@Email", email);
                                cmd.Parameters.AddWithValue("@contactNum", contactNum);
                                cmd.Parameters.AddWithValue("@address", address);
                                cmd.Parameters.AddWithValue("@barangay", barangay);
                                cmd.Parameters.AddWithValue("@city", city);
                                cmd.Parameters.AddWithValue("@province", province);
                                cmd.Parameters.AddWithValue("@zipCode", zipCode);
                                cmd.Parameters.AddWithValue("@branchId", branchId);
                                cmd.Parameters.AddWithValue("@departmentId", departmentId);
                                cmd.Parameters.AddWithValue("@sectionId", sectionId);
                                cmd.Parameters.AddWithValue("@roleId", roleId);
                                cmd.Parameters.AddWithValue("@account_status", accountStatus);
                                cmd.Parameters.AddWithValue("@empId", SelectedEmployee.emp_id);

                                cmd.ExecuteNonQuery();
                            }

                            query = "UPDATE Account SET account_status=@account_status WHERE emp_id = @empId";

                            using (SqlCommand cmd1 = new SqlCommand(query, db.GetSqlConnection()))
                            {
                                // Add parameters to avoid SQL injection
                                cmd1.Parameters.AddWithValue("@account_status", accountStatus);
                                cmd1.Parameters.AddWithValue("@empId", SelectedEmployee.emp_id);

                                cmd1.ExecuteNonQuery();
                            }

                            this.Close();
                            db.CloseConnection();
                            userManagementPage.LoadAccounts();
                            AuditLog auditLog = new AuditLog();
                            auditLog.LogEvent(CurrentUserDetails.UserID, "Employee", "Update", SelectedEmployee.emp_id, "Updated account details");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating profile: " + ex.Message);
                        }
                        //the table must be refreshed after pressing the button
                        //to reflect the updated account record instance in the table

                        //call this when verified
                        UpdateAccPrompt form = new UpdateAccPrompt();
                        form.ShowDialog();

                        SelectedEmployee.emp_id = null;
                    }
                    else
                    {
                        MessageBox.Show("There is an account that is already existing.");
                    }

                }
                else
                {
                    MessageBox.Show("Invalid input fields. Must ensure first that all of the data inputted are valid.");
                }
            }
            else
            {
                MessageBox.Show("Enable edit option first.");
            }
            
        }

        private bool CheckAccount(string branchId, string deptId, string roleId)
        {
            string query = "";

            if ((roleId == "14") || (roleId == "15"))
            {
                query = $"SELECT COUNT(E.role_id) as [total_role] FROM Employee E \r\n INNER JOIN Account A ON E.emp_id=A.emp_id\r\n INNER JOIN BRANCH B ON E.branch_id=B.BRANCH_ID\r\n INNER JOIN DEPARTMENT D ON E.department_id=D.DEPARTMENT_ID\r\n INNER JOIN EMP_ROLE R ON E.role_id=R.ROLE_ID\r\n WHERE B.branch_id='{branchId}' AND R.role_id='{roleId}'\r\n AND A.account_status='ACTIVATED' GROUP BY E.role_id;";
            }
            else
            {
                query = $"SELECT COUNT(E.role_id) as [total_role] FROM Employee E \r\n INNER JOIN Account A ON E.emp_id=A.emp_id\r\n INNER JOIN BRANCH B ON E.branch_id=B.BRANCH_ID\r\n INNER JOIN DEPARTMENT D ON E.department_id=D.DEPARTMENT_ID\r\n INNER JOIN EMP_ROLE R ON E.role_id=R.ROLE_ID\r\n WHERE B.branch_id='{branchId}' AND D.department_id='{deptId}' AND R.role_id='{roleId}'\r\n AND A.account_status='ACTIVATED' GROUP BY E.role_id;";
            }

            bool allValid = false;
            int roleTotalNum = 0;

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();


            SqlDataReader dr = db.GetRecord(query);

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string roleTotal = dr["total_role"].ToString();
                roleTotalNum = Convert.ToInt32(roleTotal);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();

            if(roleTotalNum != 1)
            {
                allValid = true;
            }

            return allValid;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            SelectedEmployee.emp_id = null;
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
                accountStatus.Enabled = true;
            }
            else
            {
                personalinfo.Enabled = false;
                companyinfo.Enabled = false;
                accountStatus.Enabled = false;
            }
        }

        private void UpdateAccWindow_Load(object sender, EventArgs e)
        {
            LoadUserDetails();

            if (deactRadBtn.Checked)
            {
                isDeactBefore = true;
            }
        }
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.DisplayRectangle.Location;
        }
        private void PopulateBranch()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "";

            if (CurrentUserDetails.BranchId == "MOF")
            {
                query = "select distinct BRANCH_NAME, BRANCH_ID from BRANCH";   // select all branch name
            }
            else
            {
                query = $"select distinct BRANCH_NAME, BRANCH_ID from BRANCH WHERE BRANCH_ID='{CurrentUserDetails.BranchId}'"; // only allowing creating user account within that branch if the currently logged in user account is not from MOF
            }
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
            string query = "SELECT * FROM Employee E INNER JOIN Account A ON E.emp_id=A.emp_id WHERE E.emp_id = @empId";
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

                if (dr["account_status"].ToString() == "ACTIVATED")
                {
                    activeRadBtn.Checked = true;
                }
                else
                {
                    deactRadBtn.Checked = true;
                }
            }

            dr.Close();
        
        }

        #region Boolean validations
        private bool isValidMiddleInitial(string name)
        {
            string pattern = @"^[A-Za-z]{0,2}$";
            if (!Regex.IsMatch(name, pattern)) { return false; }
            else { return true; }
        }
        private bool isValidEmail(string email)
        {
            bool isValid;
            // Define a regular expression pattern for a simple email validation
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            // Use Regex.IsMatch to check if the input matches the pattern
            if (!isValidInput(email) || !Regex.IsMatch(email, emailPattern)) { isValid = false; }
            else { isValid = true; }
            return isValid;
        }

        private bool isValidInput(string name)
        {
            if (name == "") { return false; }
            else { return true; }
        }
        private bool isValidContact(string contact)
        {
            string phonePattern = @"^09\d{9}$";

            if (!isValidInput(contact) || !Regex.IsMatch(contact, phonePattern))
            {
                return false;
            }
            else { return true; }
        }
        private bool isValidZipCode(string zipcode)
        {
            string pattern = @"^\d{4}$";

            if (!isValidInput(zipcode) || !Regex.IsMatch(zipcode, pattern))
            {
                return false;
            }
            else { return true; }
        }
        #endregion

        #region First Name
        private bool fname_validated()
        {
            if (isValidInput(fname.Text))
            {
                errorProvider1.SetError(fname, string.Empty);
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(fname, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }

            return goCreateAcc;
        }
        #endregion

        #region Middle Name
        public bool Mname_validated()
        {
            if (isValidMiddleInitial(middleName.Text))
            {
                errorProvider1.SetError(middleName, string.Empty);
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(middleName, "Invalid middle initial");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        #endregion

        #region Last Name
        public bool Lname_validated()
        {
            if (isValidInput(lname.Text))
            {
                errorProvider1.SetError(lname, string.Empty);
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(lname, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        #endregion



        #region Email
        private bool email_validated()
        {
            if (isValidEmail(emailAdd.Text))
            {
                errorProvider1.SetError(emailAdd, string.Empty);
                goCreateAcc = true;
            }
            else if (!isValidInput(emailAdd.Text))
            {
                errorProvider1.SetError(emailAdd, "This field is required.");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            else
            {
                errorProvider1.SetError(emailAdd, "Invalid email.");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        #endregion

        #region Contact Number
        private bool contactNum_validated()
        {
            if (isValidContact(contactNum.Text))
            {
                errorProvider1.SetError(contactNum, string.Empty);
                goCreateAcc = true;
            }
            else if (!isValidInput(contactNum.Text))
            {
                errorProvider1.SetError(contactNum, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            else
            {
                errorProvider1.SetError(contactNum, "Invalid number.");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        #endregion

        #region Address
        private bool address1_validated()
        {
            if (isValidInput(address.Text))
            {
                errorProvider1.SetError(address, string.Empty);
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(address, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        private bool brgy_validated()
        {
            if (isValidInput(brgy.Text))
            {
                errorProvider1.SetError(brgy, string.Empty);
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(brgy, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        private bool city_validated()
        {
            if (isValidInput(city.Text))
            {
                errorProvider1.SetError(city, string.Empty);
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(city, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        private bool prov_validated()
        {
            if (isValidInput(province.Text))
            {
                errorProvider1.SetError(province, string.Empty);
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(province, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        private bool zipcode_validated()
        {
            if (isValidZipCode(zipCode.Text))
            {
                errorProvider1.SetError(zipCode, string.Empty);
                goCreateAcc = true;
            }
            else if (isValidInput(zipCode.Text))
            {
                errorProvider1.SetError(zipCode, "Invalid zip code.");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            else
            {
                errorProvider1.SetError(zipCode, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        #endregion

        #region Branch

        private bool branch_validated()
        {
            if (isValidInput(branchbox.Text))
            {
                errorProvider1.SetError(branchbox, string.Empty);
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(branchbox, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        private void branch_enter(object sender, EventArgs e)
        {
            branchbox.DroppedDown = true;
        }
        #endregion

        #region Department
        private bool dept_validated()
        {
            if (isValidInput(department_box.Text))
            {
                errorProvider1.SetError(department_box, string.Empty);
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(department_box, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        private void dep_enter(object sender, EventArgs e)
        {
            department_box.DroppedDown = true;
        }
        #endregion

        #region Section
        private bool section_validated()
        {
            if (isValidInput(sectionbox.Text))
            {
                errorProvider1.SetError(sectionbox, string.Empty);
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(sectionbox, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;
        }
        private void section_enter(object sender, EventArgs e)
        {
            sectionbox.DroppedDown = true;
        }
        #endregion

        #region Role 
        private bool role_validated()
        {
            if (isValidInput(selectRole.Text))
            {
                errorProvider1.SetError(selectRole, string.Empty);
                goCreateAcc = true;

            }
            else
            {
                errorProvider1.SetError(selectRole, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            return goCreateAcc;

        }
        private void role_enter(object sender, EventArgs e)
        {
            selectRole.DroppedDown = true;
        }
        #endregion

        private void combobox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // This suppresses all key presses
        }

        private void activeRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (isDeactBefore)
            {
                if (activeRadBtn.Checked)
                {
                    branchId = branchbox.SelectedValue.ToString();
                    departmentId = department_box.SelectedValue.ToString();
                    roleId = selectRole.SelectedValue.ToString();

                    goCreate = CheckAccount(branchId, departmentId, roleId);
                }
            }
        }

        private void UpdateEmpPasswordClick(object sender, EventArgs e)
        {
            UpdatePasswordWindow form = new UpdatePasswordWindow();
            form.ShowDialog();
        }
    }
}
