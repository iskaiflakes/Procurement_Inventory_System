using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Procurement_Inventory_System
{
    public partial class ChangePasswordWindow : Form
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
            ShowPass.CheckedChanged += new System.EventHandler(this.showPasswordCheckBox_CheckedChanged);
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool isValidInput(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        private bool isValidPassword(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsDigit);
        }

        private bool VerifyCurrentPassword(string enteredPassword)
        {
            string hashedPassword = HashPassword(enteredPassword);
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = "SELECT COUNT(*) FROM Account WHERE emp_id = @UserId AND user_pw = @Password";
            using (SqlCommand cmd = new SqlCommand(query, db.GetSqlConnection()))
            {
                cmd.Parameters.AddWithValue("@UserId", CurrentUserDetails.UserID);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                int result = (int)cmd.ExecuteScalar();
                return result > 0;
            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            if (!isValidInput(ChangeCurrPass.Text))
            {
                MessageBox.Show("Current password is required.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!VerifyCurrentPassword(ChangeCurrPass.Text))
            {
                MessageBox.Show("Current password is incorrect.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChangeCurrPass.Clear();
                return;
            }

            if (isValidInput(ChangeNewPass.Text) && isValidPassword(ChangeNewPass.Text) && ChangeNewPass.Text == ChangeConfirmPass.Text)
            {
                string hashedPassword = HashPassword(ChangeNewPass.Text);

                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();

                try
                {
                    string query = "UPDATE Account SET user_pw = @Password WHERE emp_id = @UserId";
                    using (SqlCommand cmd = new SqlCommand(query, db.GetSqlConnection()))
                    {
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@UserId", CurrentUserDetails.UserID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AuditLog auditLog = new AuditLog();
                    auditLog.LogEvent(CurrentUserDetails.UserID, "User Account", "Update", CurrentUserDetails.UserID, "Updated password");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
            else if (!isValidPassword(ChangeNewPass.Text))
            {
                MessageBox.Show("Password must have:\n- at least 8 characters\n- at least 1 uppercase letter\n- at least 1 number", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChangeNewPass.Clear();
            }
            else
            {
                MessageBox.Show("Please ensure the password meets the requirements and both fields match.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPass.Checked)
            {
                ChangeCurrPass.PasswordChar = '\0';
                ChangeNewPass.PasswordChar = '\0';
                ChangeConfirmPass.PasswordChar = '\0';
            }
            else
            {
                ChangeCurrPass.PasswordChar = '*';
                ChangeNewPass.PasswordChar = '*';
                ChangeConfirmPass.PasswordChar = '*';
            }
        }
    }
}
