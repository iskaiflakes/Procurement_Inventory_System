using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Procurement_Inventory_System
{
    public class Account_Management_Module
    {
        protected DatabaseClass db;

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
        protected int getEmployeeNum()
        {
            int count= 0;
            db.ConnectDatabase();

            string query = "select DEPARTMENT_NAME from DEPARTMENT"; // select all department name
            SqlDataReader dr = db.GetRecord(query);

            while (dr.Read())
            {
                count++;
                
            }
            // Don't forget to close the SqlDataReader and the database connection when done
            dr.Close();
            db.CloseConnection();
            return count;

        }

        public string getEmployeeID(string role)
        {
            string roleID = getRoleID(role);
            int count = getEmployeeNum();

            return $"{roleID}{count.ToString("D3")}24";
        }
        //First_Name, Middle_Name, Last_Name, Email,ContactNumber,Department,Role, Address1, Brgy,City,Prov,ZipCode,Username,UserPassword;
        public void CreateAccount(string fname, string mname, string lname, string email, string contact, 
            string dept, string role, string brgy, string city, string zipcode, string username, string password)
        {
            db.ConnectDatabase();
            string query = "";

            db.CloseConnection();
        }
            

    }
}
