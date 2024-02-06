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
        
        public void CreateAccount(string[] Employee)
        {
            db = new DatabaseClass();
            db.ConnectDatabase();
            string empID = getEmployeeID(Employee[14]);
            string query = $"INSERT INTO EMPLOYEE VALUES(";
            int count=0;
            foreach(string value in Employee)
            {
                if(count == 0)
                {
                    query += $"'{empID}',";
                }else if (count == 4)
                {
                    query += $"'{getRoleID(Employee[14])}',";
                }else if (count == 12)
                {
                    break;
                }
                query += $"'{Employee[count]}',";
                count++;
            }
            query += $"'{getBranchID(Employee[12])}','{getDepartmentID(Employee[13])}')";

            string acc_query = $"INSERT INTO Account VALUES('{Employee[15]}','{empID}',{Employee[16]}','ACTIVATED')";
            db.insDelUp(query);
            db.insDelUp(acc_query);
            db.CloseConnection();
        }
            

    }
}
