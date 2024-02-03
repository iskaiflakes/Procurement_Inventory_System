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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void login_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //this.Hide();
            //AdminPage form = new AdminPage();
            //form.Show();
            string uname = username.Text;
            string pword = password.Text;
            string hashedPassword = HashPassword(pword);

            //Connecting the database using DatabaseClass (still unfinished)
            //DatabaseClass sql = new DatabaseClass();
            //sql.ConnectDatabase("DESKTOP-OO08JTF");


            string connectionString = "Data Source=DESKTOP-OO08JTF\\SQLEXPRESS;Initial Catalog=Procurement_Inventory_System;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            string sqlQuery = "SELECT E.emp_fname, E.emp_lname FROM Account A INNER JOIN Employee E ON A.emp_id = E.emp_id WHERE A.username = @username AND A.user_pw = @password";

            conn.Open();
            SqlCommand sc = new SqlCommand(sqlQuery, conn);
            sc.Parameters.AddWithValue("@username", uname);
            sc.Parameters.AddWithValue("@password", hashedPassword);
            using (SqlDataReader reader = sc.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string empFname = reader["emp_fname"].ToString();
                        string empLname = reader["emp_lname"].ToString();
                        MessageBox.Show($"Welcome, {empFname} {empLname}!");
                    }
                    AdminWindow form = new AdminWindow();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }
        private string HashPassword(string password)
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
        private void forget_pass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ForgetPassWindow form = new ForgetPassWindow();
            //form.Show();
        }
    }
}
