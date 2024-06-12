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

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoginAccount();
            }
        }

        public void LoginAccount()
        {
            //this.Hide();
            //this.Hide();
            //AdminPage form = new AdminPage();
            //form.Show();
            string uname = username.Text;
            string pword = password.Text;
            string hashedPassword = HashPassword(pword);

            //Connecting the database using DatabaseClass (still unfinished)
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "SELECT E.emp_fname, E.emp_lname, E.branch_id, E.department_id, E.section_id, E.emp_id, E.role_id, E.email_address, E.mobile_no FROM Account A INNER JOIN Employee E ON A.emp_id = E.emp_id WHERE A.username = @username AND A.user_pw = @password";

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
                    CurrentUserDetails.BranchId = dr["branch_id"].ToString(); // Store branch
                    CurrentUserDetails.DepartmentId = dr["department_id"].ToString(); // Store department ID
                    CurrentUserDetails.DepartmentSection = dr["section_id"].ToString(); // Store department section
                    CurrentUserDetails.UserID = dr["emp_id"].ToString(); // Store USER ID who's login
                    CurrentUserDetails.FName = dr["emp_fname"].ToString();
                    CurrentUserDetails.LName = dr["emp_lname"].ToString();
                    CurrentUserDetails.Role = dr["role_id"].ToString();
                    CurrentUserDetails.Email = dr["email_address"].ToString();
                    CurrentUserDetails.MobileNum = dr["mobile_no"].ToString();
                    MessageBox.Show($"Welcome, {empFname} {empLname}!");
                    AuditLog auditLog = new AuditLog();
                    auditLog.LogLoginEvent(CurrentUserDetails.UserID, "User logged in successfully.");
                }
                string userRole = CurrentUserDetails.UserID.Substring(0, 2);

                switch (userRole)
                {
                    case "11":
                        AdminWindow admin = new AdminWindow();
                        admin.Show(); this.Hide();
                        break;
                    case "12":
                        ApproverWindow manager = new ApproverWindow();
                        manager.Show(); this.Hide();
                        break;
                    case "13":
                        RequestorWindow requestor = new RequestorWindow();
                        requestor.Show(); this.Hide();
                        break;
                    case "14":
                        ApproverWindow approver = new ApproverWindow();
                        approver.Show(); this.Hide();
                        break;
                    case "15":
                        PurchasingWindow purchasing = new PurchasingWindow();
                        purchasing.Show(); this.Hide();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
                AuditLog auditLog = new AuditLog();
                auditLog.LogLoginEvent(null, $"Failed login attempt with username: {uname}");
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

        private void CheckBoxCheckedChanged(object sender, EventArgs e)
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

        private void LoginClick(object sender, EventArgs e)
        {
            LoginAccount();
        }

        private void ForgetPassLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
        public static string Role { get; set; }
        public static string Email { get; set; }
        public static string MobileNum { get; set; }
    }
}
