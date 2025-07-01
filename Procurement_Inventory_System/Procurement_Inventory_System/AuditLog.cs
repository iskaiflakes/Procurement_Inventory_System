using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Procurement_Inventory_System
{
    public class AuditLog
    {
        public void LogEvent(string userID, string tableName, string operation, string recordID, string actionDescription)
        {
            string auditID = GenerateAuditID(CurrentUserDetails.BranchId);
            DateTime changeDateTime = GetPhilippineTime();

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            SqlConnection conn = db.GetSqlConnection();
            string query = "INSERT INTO Audit_Log (Audit_ID, Emp_ID, Table_Name, Record_ID, Operation, Change_DateTime, Action_Desc) " +
                            "VALUES (@Audit_ID, @Emp_ID, @Table_Name, @Record_ID, @Operation, @ChangeDateTime, @ActionDescription)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Audit_ID", auditID);
                cmd.Parameters.AddWithValue("@Emp_ID", userID);
                cmd.Parameters.AddWithValue("@Table_Name", tableName);
                cmd.Parameters.AddWithValue("@Record_ID", recordID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Operation", operation);
                cmd.Parameters.AddWithValue("@ChangeDateTime", changeDateTime);
                cmd.Parameters.AddWithValue("@ActionDescription", actionDescription);

                cmd.ExecuteNonQuery();
            }

            db.CloseConnection();
        }
        public void LogLoginEvent(string userID, string actionDescription)
        {
            string auditID = GenerateAuditID(CurrentUserDetails.BranchId); // Ensure unique ID per branch
            string tableName = "Login"; // Since this is a login event, it doesn't directly map to a specific table
            string operation = "Login";
            DateTime changeDateTime = GetPhilippineTime();

            // Insert into AuditLog table
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            SqlConnection conn = db.GetSqlConnection();
            string query = "INSERT INTO Audit_Log (Audit_ID, Emp_ID, Table_Name, Record_ID, Operation, Change_DateTime, Action_Desc) " +
                            "VALUES (@Audit_ID, @Emp_ID, @Table_Name, @Record_ID, @Operation, @ChangeDateTime, @ActionDescription)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Audit_ID", auditID);
                cmd.Parameters.AddWithValue("@Emp_ID", userID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Table_Name", tableName);
                cmd.Parameters.AddWithValue("@Record_ID", DBNull.Value);
                cmd.Parameters.AddWithValue("@Operation", operation);
                cmd.Parameters.AddWithValue("@ChangeDateTime", changeDateTime);
                cmd.Parameters.AddWithValue("@ActionDescription", actionDescription);

                cmd.ExecuteNonQuery();
            }

            db.CloseConnection();
        }

        private string GenerateAuditID(string branchID)
        {
            string datePart = DateTime.UtcNow.ToString("yyyyMMdd");
            string newID = "";

            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            SqlConnection conn = db.GetSqlConnection();

            string query = "SELECT TOP 1 Audit_ID FROM Audit_Log WHERE Audit_ID LIKE @BranchDatePattern ORDER BY Audit_ID DESC";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BranchDatePattern", $"{branchID}-{datePart}-%");
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastID = result.ToString();
                    string[] parts = lastID.Split('-');
                    int lastNumber = int.Parse(parts[2]);
                    newID = $"{branchID}-{datePart}-{(lastNumber + 1).ToString("D5")}";
                }
                else
                {
                    newID = $"{branchID}-{datePart}-00001";
                }
            }

            db.CloseConnection();
            return newID;
        }
        private DateTime GetPhilippineTime()
        {
            TimeZoneInfo philippineTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time"); 
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, philippineTimeZone);
        }
    }
}
