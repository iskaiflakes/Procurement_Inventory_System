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
using System.Xml;

namespace Procurement_Inventory_System
{
    public partial class AuditLogWindow : Form
    {
        private const int PageSize = 20; // Number of records per page
        private int currentPage = 1;
        private DataTable auditLogTable;

        public AuditLogWindow()
        {
            InitializeComponent();

            //add rows here from the database...

        }

        private void CancelBtnClick(object sender, EventArgs e)
        {
            SelectedAuditEmployee.emp_id = null;
            this.Close();
        }

        private void AuditLogWindow_Load(object sender, EventArgs e)
        {
            {
                auditLogTable = new DataTable();
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string query = $"SELECT Audit_ID AS 'AUDIT ID', Emp_ID AS 'EMP ID', Table_Name AS 'TABLE', Record_ID AS 'RECORD ID', Operation, Change_DateTime AS 'DATE & TIME', Action_Desc AS 'DESCRIPTION' FROM Audit_Log WHERE Emp_ID = '{SelectedAuditEmployee.emp_id}' ORDER BY Change_DateTime DESC";

                SqlDataAdapter da = db.GetMultipleRecords(query);
                da.Fill(auditLogTable);

                // Assuming you have another DataGridView to show the audit logs
                DisplayCurrentPage();
                db.CloseConnection();
            }
        }
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, auditLogTable.Rows.Count - 1);

            DataTable pageTable = auditLogTable.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(auditLogTable.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (auditLogTable != null)
            {
                if (currentPage < (auditLogTable.Rows.Count + PageSize - 1) / PageSize)
                {
                    currentPage++;
                    DisplayCurrentPage();
                }
            }
            else
            {
                MessageBox.Show("No data to show.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }
        }
    }
}
