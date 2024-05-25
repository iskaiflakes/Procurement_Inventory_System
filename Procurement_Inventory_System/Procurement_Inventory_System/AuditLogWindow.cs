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

namespace Procurement_Inventory_System
{
    public partial class AuditLogWindow : Form
    {
        public AuditLogWindow()
        {
            InitializeComponent();

            DataTable acc_table = new DataTable();

            acc_table.Columns.Add("AUDIT ID", typeof(string));
            acc_table.Columns.Add("TABLE NAME", typeof(string));
            acc_table.Columns.Add("RECORD ID", typeof(string));
            acc_table.Columns.Add("OPERATION", typeof(string));
            acc_table.Columns.Add("DATE", typeof(string));
            acc_table.Columns.Add("DESCRIPTION", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = acc_table;
        }

        private void CancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AuditLogWindow_Load(object sender, EventArgs e)
        {
            {
                DataTable auditLogTable = new DataTable();
                DatabaseClass db = new DatabaseClass();
                db.ConnectDatabase();
                string query = $"SELECT Audit_ID AS 'AUDIT ID', Emp_ID AS 'EMP ID', Table_Name AS 'TABLE', Record_ID AS 'RECORD ID', Operation, Change_DateTime AS 'DATE & TIME', Action_Desc AS 'DESCRIPTION' FROM Audit_Log WHERE Emp_ID = '{SelectedAuditEmployee.emp_id}' ORDER BY Change_DateTime DESC";

                SqlDataAdapter da = db.GetMultipleRecords(query);
                da.Fill(auditLogTable);

                // Assuming you have another DataGridView to show the audit logs
                dataGridView1.DataSource = auditLogTable;
                db.CloseConnection();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }
    }
}
