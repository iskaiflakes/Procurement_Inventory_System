using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Procurement_Inventory_System
{
    public partial class UpdatePasswordWindow : Form
    {
        public UpdatePasswordWindow()
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

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdatePassword_Click(object sender, EventArgs e)
        {
            if (isValidInput(UpdateNewPass.Text) && isValidPassword(UpdateNewPass.Text))
            {
                if (UpdateNewPass.Text == UpdateConfirmPass.Text)
                {
                    string hashedPassword = HashPassword(UpdateNewPass.Text);

                    DatabaseClass db = new DatabaseClass();
                    db.ConnectDatabase();

                    try
                    {
                        string query = "UPDATE Account SET user_pw = @Password WHERE emp_id = @UserId";
                        using (SqlCommand cmd = new SqlCommand(query, db.GetSqlConnection()))
                        {
                            cmd.Parameters.AddWithValue("@Password", hashedPassword);
                            cmd.Parameters.AddWithValue("@UserId", SelectedEmployee.emp_id);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AuditLog auditLog = new AuditLog();
                        auditLog.LogEvent(CurrentUserDetails.UserID, "User Account", "Update", SelectedEmployee.emp_id, "Updated password");
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
                else
                {
                    MessageBox.Show("Passwords do not match. Try again.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateConfirmPass.Clear();
                    UpdateConfirmPass.Focus();
                }
            }
            else if (!isValidPassword(UpdateNewPass.Text))
            {
                MessageBox.Show("Password must have:\n- at least 8 characters\n- at least 1 uppercase letter\n- at least 1 number", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateNewPass.Clear();
                UpdateConfirmPass.Clear();
            }
            else
            {
                MessageBox.Show("This field is required", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPass.Checked)
            {
                UpdateNewPass.PasswordChar = '\0';
                UpdateConfirmPass.PasswordChar = '\0';
            }
            else
            {
                UpdateNewPass.PasswordChar = '*';
                UpdateConfirmPass.PasswordChar = '*';
            }
        }
    }
}
