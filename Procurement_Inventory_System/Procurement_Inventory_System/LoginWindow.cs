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
using System.Security.Cryptography;

namespace Procurement_Inventory_System
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();

        }

        
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (show_password.Checked)
            {
                password.PasswordChar = '\0';
            }
            else
            {
                password.PasswordChar = '*';
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            LoginAccount();
        }

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoginAccount();
            }
        }

        public void LoginAccount()
        {
            string uname = username.Text;
            string pword = password.Text;
            string hashedPassword = HashPassword(pword);

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "SELECT E.emp_fname, E.emp_lname, E.branch_id, E.department_id, E.section_id, E.emp_id FROM Account A INNER JOIN Employee E ON A.emp_id = E.emp_id WHERE A.username = @username AND A.user_pw = @password";

            SqlCommand cmd = new SqlCommand(query, db.GetSqlConnection());
            cmd.Parameters.AddWithValue("@username", uname);
            cmd.Parameters.AddWithValue("@password", hashedPassword);

            SqlDataReader dr = db.GetRecordCommand(cmd);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string empFname = dr["emp_fname"].ToString();
                    string empLname = dr["emp_lname"].ToString();
                    CurrentUserDetails.BranchId = dr["branch_id"].ToString(); 
                    CurrentUserDetails.DepartmentId = dr["department_id"].ToString(); 
                    CurrentUserDetails.DepartmentSection = dr["section_id"].ToString(); 
                    CurrentUserDetails.FName = dr["emp_fname"].ToString();
                    CurrentUserDetails.LName = dr["emp_lname"].ToString();
                    MessageBox.Show($"Welcome, {empFname} {empLname}!");
                }
                AdminWindow form = new AdminWindow();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }

            db.CloseConnection();
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
        private void Forget_Pass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPassWindow form = new ForgetPassWindow();
            form.Show();
        }
    }
    public static class CurrentUserDetails
    {
        public static string BranchId { get; set; }
        public static string DepartmentId { get; set; }
        public static string DepartmentSection { get; set; }
        public static string UserID { get; set; }
        public static string FName { get; set; }
        public static string LName { get; set; }
    }
}
