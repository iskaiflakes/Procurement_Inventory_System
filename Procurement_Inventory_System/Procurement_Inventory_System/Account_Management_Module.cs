using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Procurement_Inventory_System
{
    public class Account_Management_Module
    {
        protected DatabaseClass db;
        protected string empID;

        protected string getRoleID(string role)
        {
            string roleID="";
            db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"select ROLE_ID from EMP_ROLE where ROLE_NAME='{role}'"; // select all department name
            SqlDataReader dr = db.GetRecord(query);
            if (dr.Read())
            {
                roleID = dr["ROLE_ID"].ToString();
                
            }
            dr.Close();
            db.CloseConnection();
            return roleID;

        }
        public string getBranchID(string branch)
        {
            string branchID = "";
            db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"select BRANCH_ID from BRANCH where BRANCH_NAME='{branch}'"; // select all department name
            SqlDataReader dr = db.GetRecord(query);
            if (dr.Read())
            {
                branchID = dr["BRANCH_ID"].ToString();

            }
            dr.Close();
            db.CloseConnection();
            return branchID;
        }
        public string getDepartmentID(string department)
        {
            string deptID = "";
            db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"select DEPARTMENT_ID from DEPARTMENT where DEPARTMENT_NAME='{department}'"; // select all department name
            SqlDataReader dr = db.GetRecord(query);
            if (dr.Read())
            {
                deptID = dr["DEPARTMENT_ID"].ToString();

            }
            dr.Close();
            db.CloseConnection();
            return deptID;
        }

        protected int getEmployeeNum()
        {
            int count= 0;
            db = new DatabaseClass();
            db.ConnectDatabase();

            string query = "select emp_id from Employee"; // select all department name
            SqlDataReader dr = db.GetRecord(query);

            while (dr.Read())
            {
                count++;
                
            }
            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();
            return count+1;

        }

        public string getEmployeeID(string role)
        {
            string roleID = getRoleID(role);
            int count = getEmployeeNum();
            int currentYear = DateTime.Now.Year;

            return $"{roleID}{count.ToString("D3")}{currentYear % 100:00}";
        }
        public void goCreate(string[] Employee)
        {
            empID = getEmployeeID(Employee[14]);
            LogEmployee(Employee);
            CreateAccount(Employee);

        }
        private void CreateAccount(string[] Employee)
        {
            LoginWindow hash = new LoginWindow();
            string password = hash.HashPassword(Employee[16]);
            
            string acc_query = $"INSERT INTO Account (username, emp_id, user_pw, account_status) VALUES " +
                $"(@username, @empID, @password, 'ACTIVATED')";
            DatabaseClass db1 = new DatabaseClass();
            db1.ConnectDatabase();

            using(SqlCommand insertCmd = new SqlCommand(acc_query, db1.GetSqlConnection()))
            {
                insertCmd.Parameters.AddWithValue("@username", Employee[15]);
                insertCmd.Parameters.AddWithValue("@empID", empID );
                insertCmd.Parameters.AddWithValue("@password", password);

                insertCmd.ExecuteNonQuery();
            }
            
        }

        private void LogEmployee(string[] Employee)
        {
            DatabaseClass db1 = new DatabaseClass();
            db1.ConnectDatabase();
            string roleID = getRoleID(Employee[14]);
            string BranchID = getBranchID(Employee[12]);
            string DeptID = getDepartmentID(Employee[13]);

            string insertEmployee = $"INSERT INTO Employee VALUES (@empID, @empfname, @empMiddle, @empLname, " +
                $"@suffix, @role, @email, @contactnum, @address1, @prov, @brgy, @city, @zipcode, @section, @branch_id, @dept_id)";
            using (SqlCommand insertCmd = new SqlCommand(insertEmployee, db1.GetSqlConnection()))
            {
                insertCmd.Parameters.AddWithValue("@empID", empID);
                insertCmd.Parameters.AddWithValue("@empfname", Employee[0]);
                insertCmd.Parameters.AddWithValue("@empMiddle", Employee[1]);
                insertCmd.Parameters.AddWithValue("@empLname", Employee[2]);
                insertCmd.Parameters.AddWithValue("@suffix", Employee[3]);
                insertCmd.Parameters.AddWithValue("@role", roleID);
                insertCmd.Parameters.AddWithValue("@email", Employee[4]);
                insertCmd.Parameters.AddWithValue("@contactnum", Employee[5]);
                insertCmd.Parameters.AddWithValue("@address1", Employee[6]);
                insertCmd.Parameters.AddWithValue("@prov", Employee[7]);
                insertCmd.Parameters.AddWithValue("@brgy", Employee[8]);
                insertCmd.Parameters.AddWithValue("@city", Employee[9]);
                insertCmd.Parameters.AddWithValue("@zipcode", Employee[10]);
                insertCmd.Parameters.AddWithValue("@section", Employee[11]);
                insertCmd.Parameters.AddWithValue("@branch_id", BranchID);
                insertCmd.Parameters.AddWithValue("@dept_id", DeptID);


                insertCmd.ExecuteNonQuery();
            }
        }
            

    }
}
