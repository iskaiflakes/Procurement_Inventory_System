using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
