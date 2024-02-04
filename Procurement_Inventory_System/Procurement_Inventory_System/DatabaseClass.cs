using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Procurement_Inventory_System
{
    public class DatabaseClass
    {
        private SqlConnection sqlConnection;
        private string connectionString;
        private SqlCommand sqlCom;
        private SqlDataReader sqlReader;

        public void ConnectDatabase(string dataSource)  // call this first every time we perform CRUD
        {
            connectionString = "Data Source="+dataSource+"\\SQLEXPRESS;Initial Catalog=Procurement_Inventory_System;Integrated Security=True";
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
            sqlConnection.Open();
        }

        public int insDelUp(string sqlStatement)    // method for insert, delete and update
        {
            sqlCom = new SqlCommand(sqlStatement, sqlConnection);   
            int x = sqlCom.ExecuteNonQuery();   
            CloseConnection();

            return x;   // returns a value of -1 if the CRUD operation is unsuccessful (used as an indicator to check if there is a duplication)
        }

        public SqlDataReader GetRecord(string sqlStatement) // method used to retrieve data
        {
            sqlCom = new SqlCommand(sqlStatement, sqlConnection);
            sqlReader = sqlCom.ExecuteReader();

            return sqlReader;   // returns one row from the table
        }

        public void CloseConnection()   // call this to close connection
        {
            sqlConnection.Close();
        }
    }
}