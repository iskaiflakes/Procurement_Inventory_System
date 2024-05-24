using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procurement_Inventory_System
{
    public partial class AuditLogPage : UserControl
    {
        public AuditLogPage()
        {
            InitializeComponent();

            DataTable acc_table = new DataTable();

            acc_table.Columns.Add("EMPLOYEE ID", typeof(string));
            acc_table.Columns.Add("NAME", typeof(string));
            acc_table.Columns.Add("DEPARTMENT", typeof(string));
            acc_table.Columns.Add("ACCOUNT STATUS", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = acc_table;
        }

        private void viewlogsbtn_Click(object sender, EventArgs e)
        {
            AuditLogWindow form = new AuditLogWindow();
            form.ShowDialog();
        }
    }
}
