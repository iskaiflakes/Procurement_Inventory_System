using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Procurement_Inventory_System
{
    public partial class ProfilePage : UserControl
    {
        protected bool goUpdateAcc;
        public bool textchangevar = false;
        public ProfilePage()
        {
            InitializeComponent();
            /*
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"SELECT * FROM Employee WHERE emp_id = {CurrentUserDetails.UserID}";
            SqlDataReader dr = db.GetRecord(query);
            
            while (dr.Read())
            {
                fname.Text = (string)dr["emp_fname"];
                middleName.Text = (string)dr["middle_initial"];
                lname.Text = (string)dr["emp_lname"];
                suffix.Text = (string)dr["suffix"];
                emailAdd.Text = (string)dr["email_address"];
                contactNum.Text = (string)dr["mobile_no"];
                address.Text = (string)dr["house_no"];
                brgy.Text = (string)dr["barangay"];
                province.Text = (string)dr["province"];
                city.Text = (string)dr["city"];
                zipCode.Text = (string)dr["zip_code"];
            }
            dr.Close();
            db.CloseConnection();

            fname.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            middleName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            lname.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            suffix.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            emailAdd.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            contactNum.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            address.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            brgy.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            province.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            city.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            zipCode.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            */
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            textchangevar = true;
            saveprofilebtn.Enabled = true;
        }

        private void editprofilebtn_Click(object sender, EventArgs e)
        {
            editprofilebtn.Enabled = false;
            logoutbtn.Enabled = false;

            fname.Enabled = true;
            middleName.Enabled = true;
            lname.Enabled = true;
            suffix.Enabled = true;
            emailAdd.Enabled = true;
            contactNum.Enabled = true;
            address.Enabled = true;
            brgy.Enabled = true;
            city.Enabled = true;
            province.Enabled = true;
            zipCode.Enabled = true;

            bottomcontrols.Visible = true;
            saveprofilebtn.Enabled = false;
        }

        //credits @jelly
        #region Boolean validations
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
        private void fname_validated(object sender, EventArgs e)
        {
            if (isValidInput(fname.Text))
            {
                FixName(fname.Text);
                errorProvider1.SetError(fname, string.Empty);
                middleName.Focus();
                goUpdateAcc = true;
            }
            else
            {
                errorProvider1.SetError(fname, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
        }
        #endregion

        #region Middle Name
        private void Mname_validated(object sender, EventArgs e)
        {
            if (isValidMiddleInitial(middleName.Text))
            {
                middleName.Text.ToUpper();
                errorProvider1.SetError(middleName, string.Empty);
                lname.Focus();
                goUpdateAcc = true;
            }
            else
            {
                errorProvider1.SetError(middleName, "Invalid middle initial");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
        }
        #endregion

        #region Last Name
        private void Lname_validated(object sender, EventArgs e)
        {
            if (isValidInput(lname.Text))
            {
                FixName(lname.Text);
                errorProvider1.SetError(lname, string.Empty);
                suffix.Focus();
                goUpdateAcc = true;
            }
            else
            {
                errorProvider1.SetError(lname, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
        }
        #endregion

        #region Suffix
        private void suffix_validated(object sender, EventArgs e)
        {
            if (suffix.Text != "")
            {
                //Employee[3] = suffix.Text.ToUpper();
            }
            else
            {
                //Employee[3] = "";
            }
            emailAdd.Focus();
        }
        #endregion

        #region Email
        private void email_validated(object sender, EventArgs e)
        {
            if (isValidEmail(emailAdd.Text))
            {
                errorProvider1.SetError(emailAdd, string.Empty);
                contactNum.Focus();
                goUpdateAcc = true;
            }
            else if (!isValidInput(emailAdd.Text))
            {
                errorProvider1.SetError(emailAdd, "This field is required.");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
            else
            {
                errorProvider1.SetError(emailAdd, "Invalid email.");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
        }
        #endregion

        #region Contact Number
        private void contactNum_validated(object sender, EventArgs e)
        {
            if (isValidContact(contactNum.Text))
            {
                errorProvider1.SetError(contactNum, string.Empty);
                address.Focus(); goUpdateAcc = true;
            }
            else if (!isValidInput(contactNum.Text))
            {
                errorProvider1.SetError(contactNum, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
            else
            {
                errorProvider1.SetError(contactNum, "Invalid number.");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
        }
        #endregion

        #region Address
        private void address1_validated(object sender, EventArgs e)
        {
            if (isValidInput(address.Text))
            {
                errorProvider1.SetError(address, string.Empty);
                brgy.Focus();
                goUpdateAcc = true;
            }
            else
            {
                errorProvider1.SetError(address, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
        }
        private void brgy_validated(object sender, EventArgs e)
        {
            if (isValidInput(brgy.Text))
            {
                errorProvider1.SetError(brgy, string.Empty);
                city.Focus();
                goUpdateAcc = true;
            }
            else
            {
                errorProvider1.SetError(brgy, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
        }
        private void city_validated(object sender, EventArgs e)
        {
            if (isValidInput(city.Text))
            {
                errorProvider1.SetError(city, string.Empty);
                province.Focus();
                goUpdateAcc = true;
            }
            else
            {
                errorProvider1.SetError(city, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
        }
        private void prov_validated(object sender, EventArgs e)
        {
            if (isValidInput(province.Text))
            {
                errorProvider1.SetError(province, string.Empty);
                zipCode.Focus();
                goUpdateAcc = true;
            }
            else
            {
                errorProvider1.SetError(province, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
        }
        private void zipcode_validated(object sender, EventArgs e)
        {
            if (isValidZipCode(zipCode.Text))
            {
                errorProvider1.SetError(zipCode, string.Empty);
                goUpdateAcc = true;
            }
            else if (isValidInput(zipCode.Text))
            {
                errorProvider1.SetError(zipCode, "Invalid zip code.");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
            else
            {
                errorProvider1.SetError(zipCode, "This field is required");
                errorProvider1.BlinkRate = 0;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                goUpdateAcc = false;
            }
        }
        #endregion

        private void saveprofilebtn_Click(object sender, EventArgs e)
        {
            if (goUpdateAcc)
            {
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string query = $"UPDATE Employee SET emp_fname = '{fname.Text}', middle_initial = '{middleName.Text}', emp_lname = '{lname.Text}', suffix = '{suffix.Text}', email_address = '{emailAdd.Text}', mobile_no = '{contactNum.Text}', house_no = '{address.Text}', barangay = '{brgy.Text}', province = '{province.Text}', city = '{city.Text}', zip_code = '{zipCode.Text}' WHERE emp_id = {CurrentUserDetails.UserID}";
                db.insDelUp(query);
                SqlCommand insertCmd = new SqlCommand(query, db.GetSqlConnection());

                insertCmd.ExecuteNonQuery();

                EditProfilePrompt form = new EditProfilePrompt();
                form.ShowDialog();
            }

            editprofilebtn.Enabled = true;
            logoutbtn.Enabled = true;

            fname.Enabled = false;
            middleName.Enabled = false;
            lname.Enabled = false;
            suffix.Enabled = false;
            emailAdd.Enabled = false;
            contactNum.Enabled = false;
            address.Enabled = false;
            brgy.Enabled = false;
            city.Enabled = false;
            province.Enabled = false;
            zipCode.Enabled = false;

            bottomcontrols.Visible = false;
        }
        private void cancelbtn_Click(object sender, EventArgs e)
        {
            editprofilebtn.Enabled = true;
            logoutbtn.Enabled = true;

            fname.Enabled = false;
            middleName.Enabled = false;
            lname.Enabled = false;
            suffix.Enabled = false;
            emailAdd.Enabled = false;
            contactNum.Enabled = false;
            address.Enabled = false;
            brgy.Enabled = false;
            city.Enabled = false;
            province.Enabled = false;
            zipCode.Enabled = false;

            bottomcontrols.Visible = false;
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
