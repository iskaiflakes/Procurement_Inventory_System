using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procurement_Inventory_System
{
    public partial class CreateAccWindow : Form
    {
        protected bool goCreateAcc;
        // all values to be inserted in the db
        protected string[] Employee = new string[17];
        private UserManagementPage userpage;

        public CreateAccWindow(UserManagementPage userpage)
        {
            InitializeComponent(); // initialize everything
            LoadBranches(); // initialize the items inside the branches combo box
            LoadRoles(); // initialize all the items inside the role combo box
            this.userpage = userpage;
        }
        #region Boolean validations
        private bool isValidUsername(string username)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "select username from Account"; // select all username 
            SqlDataReader dr = db.GetRecord(query);

            while (dr.Read())
            {if (username.ToLower() == dr["username"].ToString().ToLower()){return false;}} // validates if there is an exisitng username
            return true;  // returns true if username is free to use
        }
        private string FixName(string name)
        {
            name = name.TrimEnd(' ');
            string[] words = name.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            return string.Join(" ", words);
        }
        private bool isValidMiddleInitial(string name)
        {
            string pattern = @"^[A-Za-z]{0,2}$";
            if (!Regex.IsMatch(name, pattern)){return false;}
            else{return true;}
        }
        private bool isValidEmail(string email)
        {
            bool isValid;
            // Define a regular expression pattern for a simple email validation
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            // Use Regex.IsMatch to check if the input matches the pattern
            if (!isValidInput(email) || !Regex.IsMatch(email, emailPattern)){isValid = false;}
            else{isValid = true;}
            return isValid;
        }

        private bool isValidInput(string name)
        {
            if (name == ""){return false;}
            else{return true;}
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
        public bool isValidPassword(string password)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*\d).{8,}$";

            if (!Regex.IsMatch(password, pattern))
            {
                return false;
            }
            else { return true; }
        }
        #endregion

        #region Loading Combo Boxes
        private void LoadRoles()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "select ROLE_NAME from emp_role"; // select all department name
            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            selectRole.Items.Clear();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string roles = dr["ROLE_NAME"].ToString();
                selectRole.Items.Add(roles);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();

            selectRole.Enter += role_enter;
            department_box.Enabled = false;
            sectionbox.Enabled = false;
        }
        private void LoadBranches()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();


            string query = "";

            if (CurrentUserDetails.BranchId == "MOF")
            {
                query = "select BRANCH_NAME from BRANCH";   // select all branch name
            }
            else
            {
                query = $"select BRANCH_NAME from BRANCH WHERE BRANCH_ID='{CurrentUserDetails.BranchId}'"; // only allowing creating user account within that branch if the currently logged in user account is not from MOF
            }

            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            branchbox.Items.Clear();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string roles = dr["BRANCH_NAME"].ToString();
                branchbox.Items.Add(roles);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();

            branchbox.Enter += branch_enter;
        }

        private void LoadDepartmentBox(string branch)
        {
            if (branch != "")
            {
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();

                string query ="select DISTINCT DEPARTMENT.DEPARTMENT_NAME from BRANCH " +
                    "inner join DEPARTMENT on DEPARTMENT.BRANCH_ID=BRANCH.BRANCH_ID " +
                    "inner join SECTION on SECTION.DEPARTMENT_ID=DEPARTMENT.DEPARTMENT_ID " +
                    $"where BRANCH.BRANCH_NAME='{branch}'"; // select all department name
                SqlDataReader dr = db.GetRecord(query);

                // Clear existing items to avoid duplication if this method is called more than once
                department_box.Items.Clear();

                // Add each category to the ComboBox
                while (dr.Read())
                {
                    string dept_name = dr["DEPARTMENT_NAME"].ToString();
                    department_box.Items.Add(dept_name);
                }

                // Don't forget to close the SqlDataReader and the database connection when done
                dr.Close();
                db.CloseConnection();

                department_box.Enter += dep_enter;
            }
            else
            {
                department_box.Enabled= false;
            }
            
        }
        private void LoadSection(string dept, string branch)
        {
            if (branch!="" && dept != "")
            {
                sectionbox.Enabled = true;
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();

                string query = "select distinct SECTION.SECTION_ID from BRANCH " +
                    "inner join DEPARTMENT on DEPARTMENT.BRANCH_ID=BRANCH.BRANCH_ID " +
                    "inner join SECTION on SECTION.DEPARTMENT_ID=DEPARTMENT.DEPARTMENT_ID " +
                    $"where BRANCH.BRANCH_NAME='{branch}'" +
                    $"and DEPARTMENT.DEPARTMENT_NAME ='{dept}'"; // select all department name
                SqlDataReader dr = db.GetRecord(query);

                // Clear existing items to avoid duplication if this method is called more than once
                sectionbox.Items.Clear();

                // Add each category to the ComboBox
                while (dr.Read())
                {
                    string roles = dr["SECTION_ID"].ToString();
                    sectionbox.Items.Add(roles);
                }

                // Don't forget to close the SqlDataReader and the database connection when done
                dr.Close();
                db.CloseConnection();

                sectionbox.Enter += section_enter;
            }
            else{sectionbox.Enabled = false;}
        }
        #endregion

        #region First Name
        private void fname_validated(object sender, EventArgs e)
        {
            if (isValidInput(fname.Text))
            {
                Employee[0] = FixName(fname.Text);
                errorProvider1.SetError(fname, string.Empty);
                middleName.Focus();
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(fname, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        #endregion

        #region Middle Name
        private void Mname_validated(object sender, EventArgs e)
        {
            if (isValidMiddleInitial(middleName.Text))
            {
                
                Employee[1]=middleName.Text.ToUpper(); 
                errorProvider1.SetError(middleName, string.Empty);
                lname.Focus();
                goCreateAcc = true;
            }   
            else
            {
                errorProvider1.SetError(middleName, "Invalid middle initial");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        #endregion

        #region Last Name
        private void Lname_validated(object sender, EventArgs e)
        {
            if (isValidInput(lname.Text))
            {
                Employee[2] = FixName(lname.Text);
                errorProvider1.SetError(lname, string.Empty);
                suffix.Focus();
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(lname, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        #endregion

        #region Suffix
        private void suffix_validated(object sender, EventArgs e)
        {
            if (suffix.Text != "")
            {
                Employee[3] = suffix.Text.ToUpper();
            }
            else
            {
                Employee[3] = "";
            }
            emailAdd.Focus();
        }
        #endregion

        #region Email
        private void email_validated(object sender, EventArgs e)
        {
            if (isValidEmail(emailAdd.Text))
            {
                Employee[4] = emailAdd.Text;
                errorProvider1.SetError(emailAdd, string.Empty);
                contactNum.Focus();
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
        }
        #endregion

        #region Contact Number
        private void contactNum_validated(object sender, EventArgs e)
        {
            if (isValidContact(contactNum.Text))
            {
                Employee[5] = contactNum.Text;
                errorProvider1.SetError(contactNum, string.Empty);
                address.Focus(); goCreateAcc = true;
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
        }
        #endregion

        #region Address
        private void address1_validated(object sender, EventArgs e)
        {
            if (isValidInput(address.Text))
            {
                Employee[6]=address.Text;
                errorProvider1.SetError(address, string.Empty);
                brgy.Focus();
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(address, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        private void brgy_validated(object sender, EventArgs e)
        {
            if (isValidInput(brgy.Text))
            {
                Employee[8]=brgy.Text;
                errorProvider1.SetError(brgy, string.Empty);
                city.Focus();
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(brgy, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        private void city_validated(object sender, EventArgs e)
        {
            if (isValidInput(city.Text))
            {
                Employee[9]=city.Text;
                errorProvider1.SetError(city, string.Empty);
                province.Focus();
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(city, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        private void prov_validated(object sender, EventArgs e)
        {
            if (isValidInput(province.Text))
            {
                Employee[7]=province.Text;
                errorProvider1.SetError(province, string.Empty);
                zipCode.Focus();
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(province, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        private void zipcode_validated(object sender, EventArgs e)
        {
            if (isValidZipCode(zipCode.Text))
            {
                Employee[10]=zipCode.Text;
                errorProvider1.SetError(zipCode, string.Empty);
                branchbox.Focus();
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
        }
        #endregion

        #region Branch

        private void branch_validated(object sender, EventArgs e)
        {
            if (isValidInput(branchbox.Text))
            {
                Employee[12]=branchbox.Text;
                errorProvider1.SetError(branchbox, string.Empty);
                department_box.Focus();
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(branchbox, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        private void branchbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDepartmentBox(branchbox.Text);
            department_box.Enabled = true;
        }

        private void branch_enter(object sender, EventArgs e)
        {
            branchbox.DroppedDown = true;
        }
        #endregion

        #region Department
        private void dept_validated(object sender, EventArgs e)
        {
            if (isValidInput(department_box.Text))
            {
                Employee[13]=department_box.Text;
                errorProvider1.SetError(department_box, string.Empty);
                sectionbox.Focus();
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(department_box, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        private void department_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSection(department_box.Text, branchbox.Text);
        }
        private void dep_enter(object sender, EventArgs e)
        {
            department_box.DroppedDown = true;
        }
        #endregion

        #region Section
        private void section_validated(object sender, EventArgs e)
        {
            if (isValidInput(sectionbox.Text))
            {
                Employee[11] = sectionbox.Text;
                errorProvider1.SetError(sectionbox, string.Empty);
                selectRole.Focus();
                goCreateAcc = true;
            }
            else
            {
                errorProvider1.SetError(sectionbox, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }

        }
        private void section_enter(object sender, EventArgs e)
        {
            sectionbox.DroppedDown = true;
        }
        #endregion

        #region Role 
        private void role_validated(object sender, EventArgs e)
        {
            if (isValidInput(selectRole.Text))
            {
                Employee[14] = selectRole.Text;
                errorProvider1.SetError(selectRole, string.Empty);
                newUsername.Focus();
                goCreateAcc = true;

            }
            else
            {
                errorProvider1.SetError(selectRole, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }

        }
        private void role_enter(object sender, EventArgs e)
        {
            selectRole.DroppedDown = true;
        }
        #endregion

        #region Username
        private void username_validated(object sender,EventArgs e)
        {
            if (isValidInput(newUsername.Text) && isValidUsername(newUsername.Text))
            {
                Employee[15] = newUsername.Text;
                errorProvider1.SetError(newUsername, string.Empty);
                newPassword.Focus();
                goCreateAcc = true;
            }
            else if (!isValidUsername(newUsername.Text))
            {
                MessageBox.Show("Username is already being used. Try another.");
                errorProvider1.SetError(newUsername, "Username is already being used. Try another.");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                newUsername.Clear();
                newUsername.Focus();
                goCreateAcc = false;
            }
            else
            {
                errorProvider1.SetError(newUsername, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        #endregion

        #region Password
        private void newPassword_validated(object sender, EventArgs e)
        {
            if (isValidInput(newPassword.Text) && isValidPassword(newPassword.Text))
            {
                Employee[16] = newPassword.Text;
                errorProvider1.SetError(newPassword, string.Empty);
                confirmPass.Focus();
                goCreateAcc = true;
            }
            else if (!isValidPassword(newPassword.Text))
            {
                MessageBox.Show("Password must have:\n- at least 8 characters \n-at least 1 uppercase letter \n- at least 1 number");
                errorProvider1.SetError(newPassword, "Password did not meet requirements.");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                newPassword.Clear();
                goCreateAcc = false;
            }
            else
            {
                errorProvider1.SetError(newPassword, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        private void confirmPassword_validated(object sender, EventArgs e)
        {
            if (isValidInput(confirmPass.Text) && newPassword.Text == confirmPass.Text)
            {
                createaccbtn.Focus();
                errorProvider1.SetError(newPassword, string.Empty);
                goCreateAcc = true;

            }
            else if (newPassword.Text != confirmPass.Text)
            {

                MessageBox.Show($"Password doesn't match. Try again.");
                errorProvider1.SetError(confirmPass, "Password doesn't match.");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
                confirmPass.Clear();
                confirmPass.Focus();
            }
            else
            {
                errorProvider1.SetError(confirmPass, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
        }
        #endregion

        private void ClearTextboxes()
        {
            goCreateAcc=false;
            fname.Clear();
            middleName.Clear();
            lname.Clear();
            suffix.Clear();
            emailAdd.Clear();
            contactNum.Clear();
            address.Clear();
            brgy.Clear();
            city.Clear();
            province.Clear();
            zipCode.Clear();
            branchbox.SelectedItem = null;
            department_box.SelectedItem = null;
            sectionbox.SelectedItem = null;
            selectRole.SelectedItem=null;
            newUsername.Clear();
            newPassword.Clear();
            confirmPass.Clear();
            fname.Focus();
        }


        private void createaccbtn_Click(object sender, EventArgs e)
        {
            //
            //verify user input...
            if (goCreateAcc)
            {
                Account_Management_Module acc = new Account_Management_Module();
                acc.goCreate(Employee);
                RefreshAccounts();
            }
            else
            {
                MessageBox.Show("Complete all fields.");
            }
            //

            //the table must be refreshed after pressing the button
            //to reflect the account record instance in the table

            //call this when verified
            CreateAccPrompt form = new CreateAccPrompt();
            form.ShowDialog();
            ClearTextboxes();


        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshAccounts()
        {
            if (userpage != null)
            {
                userpage.LoadAccounts();
            }
        }
    }
}
