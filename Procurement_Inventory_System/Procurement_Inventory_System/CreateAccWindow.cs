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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Procurement_Inventory_System
{
    public partial class CreateAccWindow : Form
    {
        //private string Fname, Mname, Lname, Email, Contactnum, Dept, add, brgy, city, province, zip_code, username, password;
        protected string First_Name, Middle_Name, Last_Name, Email,ContactNumber,Department, Address1, Brgy,City,Prov,ZipCode,Username,UserPassword;
        public CreateAccWindow()
        {
            InitializeComponent();
            LoadDepartmentBox();


            
        }
        private void CreateAccWindow_Load(object sender, EventArgs e)
        {
           
        }
        private bool isValidUsername(string username)
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase("DESKTOP-OO08JTF");

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
        private void LoadDepartmentBox()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase("DESKTOP-OO08JTF");

            string query = "select DEPARTMENT_NAME from DEPARTMENT"; // select all department name
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
        private string FixName(string name)
        {
            string[] words = name.Split(' ');
            for(int i=0; i<words.Length; i++)
            {
                words[i]= char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            return string.Join(" ", words);
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


        private void fname_validating(object sender, CancelEventArgs e)
        {
            if (!isValidInput(fname.Text)){
                MessageBox.Show("Please enter first name.");
                fname.Focus();
            }
            
            
        }
        private void fname_validated(object sender, EventArgs e)
        {
            if (isValidInput(fname.Text))
            {
                First_Name = FixName(fname.Text);
                middleName.Focus();
            }
            

        }
        private void Mname_validating(object sender, CancelEventArgs e)
        {
            if (!isValidInput(middleName.Text))
            {
                MessageBox.Show("Please enter middle name.");
                middleName.Focus();
            }

        }
        private void Mname_validated(object sender, EventArgs e)
        {
            if (isValidInput(middleName.Text))
            {
                Middle_Name = FixName(middleName.Text);
                lname.Focus();
            }


        }
        private void Lname_validating(object sender, CancelEventArgs e)
        {
            if (!isValidInput(lname.Text))
            {
                MessageBox.Show("Please enter last name.");
                lname.Focus();
            }

        }
        private void Lname_validated(object sender, EventArgs e)
        {
            if (isValidInput(lname.Text))
            {
                Last_Name = FixName(lname.Text);
                emailAdd.Focus();
            }


        }
        private void email_validating(object sender,CancelEventArgs e)
        {
            if (!isValidEmail(emailAdd.Text))
            {
                MessageBox.Show("Please enter a valid email address");
                emailAdd.Clear();
                emailAdd.Focus();
            }
            
        }
        private void email_validated(object sender, EventArgs e)
        {
            if (isValidEmail(emailAdd.Text)){
                Email=emailAdd.Text;
                contactNum.Focus();
            }
        }
        private void contactNum_validating(object sender, CancelEventArgs e)
        {
            if (!isValidContact(contactNum.Text))
            {
                MessageBox.Show("Please enter a valid phone number");
                contactNum.Clear();
                contactNum.Focus();
            }
            
        }
        private void contactNum_validated(object sender, EventArgs e)
        {
            if (isValidContact(contactNum.Text))
            {
                ContactNumber = contactNum.Text;
                department_box.Focus();
            }
        }
        private void dept_validating(object sender, CancelEventArgs e)
        {
            if (!isValidInput(department_box.Text))
            {
                MessageBox.Show("Choose a department");
                department_box.Focus();
            }
        }
        private void dept_validated(object sender, EventArgs e)
        {
            if (isValidInput(department_box.Text))
            {
                Department = department_box.Text;
                address.Focus();
            }
        }
        private void dep_enter(object sender, EventArgs e)
        {
            department_box.DroppedDown = true;
        }
        private void address1_validating(object sender, CancelEventArgs e)
        {
            if (!isValidInput(address.Text))
            {
                MessageBox.Show("Please enter your address");
                address.Focus();
            }
        }
        private void address1_validated(object sender, EventArgs e)
        {
            if (isValidInput(address.Text))
            {
                Address1 = address.Text;
                brgy.Focus();
            }
        }
        private void brgy_validating(object sender, CancelEventArgs e)
        {
            if (!isValidInput(brgy.Text))
            {
                MessageBox.Show("Please enter your address");
                brgy.Focus();
            }
        }
        private void brgy_validated(object sender, EventArgs e)
        {
            if (isValidInput(brgy.Text))
            {
                Brgy = brgy.Text;
                city.Focus();
            }
        }
        private void city_validating(object sender, CancelEventArgs e)
        {
            if (!isValidInput(city.Text))
            {
                MessageBox.Show("Please enter your address");
                city.Focus();
            }
        }
        private void city_validated(object sender, EventArgs e)
        {
            if (isValidInput(city.Text))
            {
                City = city.Text;
                province.Focus();
            }
        }

        private void zipCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void province_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void brgy_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void confirmPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void newPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void city_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void newUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void address_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void prov_validating(object sender, CancelEventArgs e)
        {
            if (!isValidInput(province.Text))
            {
                MessageBox.Show("Please enter your address");
                province.Focus();
            }
        }
        private void prov_validated(object sender, EventArgs e)
        {
            if (isValidInput(province.Text))
            {
                Prov = province.Text;
                zipCode.Focus();
            }
        }
        private void zipcode_validating(object sender,CancelEventArgs e)
        {
            if (!isValidZipCode(zipCode.Text))
            {
                MessageBox.Show("Please enter a valid zipcode");
                zipCode.Focus();
            }
        }
        private void zipcode_validated(object sender, EventArgs e)
        {
            if (isValidZipCode(zipCode.Text))
            {
                ZipCode = zipCode.Text;
                newUsername.Focus();
            }
        }
        private void username_validating(object sender, CancelEventArgs e)
        {
            if (!isValidInput(newUsername.Text))
            {
                MessageBox.Show("Enter a username"); newUsername.Focus();
                newUsername.Focus();
            }else if (!isValidUsername(newUsername.Text))
            {
                MessageBox.Show("Username is already being used. Try another.");
                newUsername.Clear();
                newUsername.Focus();
            }
        }
        private void username_validated(object sender,EventArgs e)
        {
            if (isValidInput(newUsername.Text) && isValidUsername(newUsername.Text))
            {
                Username = newUsername.Text;
                newPassword.Focus();
            }
        }
        private void newPassword_validating(Object sender, CancelEventArgs e)
        {
            if (!isValidInput(newPassword.Text))
            {
                MessageBox.Show("Enter a password.");
                newPassword.Focus();

            }else if (!isValidPassword(newPassword.Text))
            {
                MessageBox.Show("Password must have:\n- at least 8 characters \n-at least 1 uppercase letter \n- at least 1 number");
                newPassword.Clear();
                newPassword.Focus();
            }
        }
        private void newPassword_validated(object sender, EventArgs e)
        {
            if (!isValidInput(newPassword.Text) && isValidPassword(newPassword.Text))
            {
                confirmPass.Focus();
            }
        }
        private void confirmPassword_validating(object sender, CancelEventArgs e)
        {
            if (!isValidInput(confirmPass.Text))
            {
                MessageBox.Show("Please confirm password."); 
                confirmPass.Focus();

            } else if (newPassword.Text != confirmPass.Text)
            {

                MessageBox.Show($"{newPassword.Text},,{confirmPass.Text}\nPassword doesn't match. Try again.");
                confirmPass.Clear();
                confirmPass.Focus();
            }
        }
        private void confirmPassword_validated(object sender, EventArgs e)
        {
            if (isValidInput(confirmPass.Text) && newPassword.Text == confirmPass.Text)
            {
                createaccbtn.Focus();
                UserPassword = newPassword.Text;

            }
        }
        private void createaccbtn_Click(object sender, EventArgs e)
        {
            //
            //verify user input...
            MessageBox.Show($"{First_Name}, {Middle_Name}, {Last_Name}, {Email}, {ContactNumber}, {Department}, {Address1}, {Brgy}, {City}, {Prov}, {ZipCode}, {Username}, {UserPassword}");
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
