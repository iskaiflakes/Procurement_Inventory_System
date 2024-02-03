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
        SqlConnection sqlConnection;
        string connectionString;
        SqlCommand sqlCom;

        public void ConnectDatabase(string dataSource)
        {
            connectionString = "Data Source="+dataSource+"\\SQLEXPRESS;Initial Catalog=Procurement_Inventory_System;Integrated Security=True";
            sqlConnection.Open();
        }

        public void CloseConnection()
        {
            sqlConnection.Close();
        }
    }
}