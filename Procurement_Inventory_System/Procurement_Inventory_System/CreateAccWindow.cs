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
        protected string First_Name, Middle_Name, Last_Name, Email,ContactNumber,Department,Role, Address1, Brgy,City,Prov,ZipCode,Username,UserPassword;
        public CreateAccWindow()
        {
            InitializeComponent();
            LoadDepartmentBox();
            LoadRoles();
        }
        private bool isValidUsername(string username)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "select username from Account"; // select all department name
            SqlDataReader dr = db.GetRecord(query);

            while (dr.Read())
            {
                if (username.ToLower() == dr["username"].ToString().ToLower())
                {
                    return false;

                }
            }
            return true;

        }
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
        }
        private void LoadDepartmentBox()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "select SUB_SECTION_NAME from SUB_SECTION"; // select all department name
            SqlDataReader dr = db.GetRecord(query);

            // Clear existing items to avoid duplication if this method is called more than once
            department_box.Items.Clear();

            // Add each category to the ComboBox
            while (dr.Read())
            {
                string dept_name = dr["SUB_SECTION_NAME"].ToString();
                department_box.Items.Add(dept_name);
            }

            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();

            department_box.Enter += dep_enter;
        }
        private string FixName(string name)
        {
            string[] words = name.Split(' ');
            for(int i=0; i<words.Length; i++)
            {
                words[i]= char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            return string.Join(" ", words);
        }
        private bool isValidMiddleInitial(string name)
        {
            string pattern = @"^[A-Za-z]{0,2}$";
            if (!isValidInput(name) || !Regex.IsMatch(name, pattern))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool isValidEmail(string email)
        {
            bool isValid;
            // Define a regular expression pattern for a simple email validation
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            // Use Regex.IsMatch to check if the input matches the pattern
            if (!isValidInput(email) || !Regex.IsMatch(email, emailPattern))
            {
                isValid = false;
            }
            else 
            {
                isValid = true;
            }
            
            return isValid;
        }
        
        private bool isValidInput(string name) {
            if(name == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private bool isValidContact(string contact)
        {
            string phonePattern = @"^09\d{9}$";
           
            if (!isValidInput(contact)||!Regex.IsMatch(contact, phonePattern))
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

        private void fname_validated(object sender, EventArgs e)
        {
            if (isValidInput(fname.Text))
            {
                First_Name = FixName(fname.Text);
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

        private void Mname_validated(object sender, EventArgs e)
        {
            if (isValidMiddleInitial(middleName.Text))
            {
                Middle_Name = FixName(middleName.Text);
                errorProvider1.SetError(middleName, string.Empty);
                lname.Focus();
                goCreateAcc = true;
            }else if (!isValidInput(middleName.Text))
            {
                errorProvider1.SetError(middleName, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }
            else
            {
                errorProvider1.SetError(middleName, "Invalid middle initial");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goCreateAcc = false;
            }


        }
        private void Lname_validated(object sender, EventArgs e)
        {
            if (isValidInput(lname.Text))
            {
                Last_Name = FixName(lname.Text);
                errorProvider1.SetError(lname, string.Empty);
                emailAdd.Focus();
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
        private void email_validated(object sender, EventArgs e)
        {
            if (isValidEmail(emailAdd.Text))
            {
                Email = emailAdd.Text;
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
        private void contactNum_validated(object sender, EventArgs e)
        {
            if (isValidContact(contactNum.Text))
            {
                ContactNumber = contactNum.Text;
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
        private void dept_validated(object sender, EventArgs e)
        {
            if (isValidInput(department_box.Text))
            {
                Department = department_box.Text;
                errorProvider1.SetError(department_box, string.Empty);
                selectRole.Focus();
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
        private void dep_enter(object sender, EventArgs e)
        {
            department_box.DroppedDown = true;
        }
        private void role_validated(object sender, EventArgs e)
        {
            if (isValidInput(selectRole.Text))
            {
                Role = selectRole.Text;
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
        private void address1_validated(object sender, EventArgs e)
        {
            if (isValidInput(address.Text))
            {
                Address1 = address.Text;
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
                Brgy = brgy.Text;
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
                City = city.Text;
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
                Prov = province.Text;
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
                ZipCode = zipCode.Text;
                errorProvider1.SetError(zipCode, string.Empty);
                department_box.Focus();
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

        private void username_validated(object sender,EventArgs e)
        {
            if (isValidInput(newUsername.Text) && isValidUsername(newUsername.Text))
            {
                Username = newUsername.Text;
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
        private void newPassword_validated(object sender, EventArgs e)
        {
            if (isValidInput(newPassword.Text) && isValidPassword(newPassword.Text))
            {
                UserPassword = newPassword.Text;
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
                UserPassword = newPassword.Text;
                goCreateAcc = true;

            }
            else if (newPassword.Text != confirmPass.Text)
            {

                MessageBox.Show($"{newPassword.Text},,{confirmPass.Text}\nPassword doesn't match. Try again.");
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
        private void createaccbtn_Click(object sender, EventArgs e)
        {
            //
            //verify user input...
            if (goCreateAcc)
            {
                MessageBox.Show($"{First_Name}, {Middle_Name}, {Last_Name}, {Email}, {ContactNumber}, {Department}, {Address1}, {Brgy}, {City}, {Prov}, {ZipCode}, {Username}, {UserPassword}");
            }
            else
            {
                MessageBox.Show("Complete all fields.");
            }
            Account_Management_Module acc = new Account_Management_Module();
            string roleID=acc.getEmployeeID(Role);
            MessageBox.Show(roleID);
            
            //

            //the table must be refreshed after pressing the button
            //to reflect the account record instance in the table

            //call this when verified
            CreateAccPrompt form = new CreateAccPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
