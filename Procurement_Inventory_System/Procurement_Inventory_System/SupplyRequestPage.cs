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
    public partial class SupplyRequestPage : UserControl
    {
        public SupplyRequestPage()
        {
            InitializeComponent();
        }

        private void SupplyRequestPage_Load(object sender, EventArgs e)
        {
            DataTable supply_rqst_tbl = new DataTable();

            supply_rqst_tbl.Columns.Add("REQUEST ID", typeof(string));
            supply_rqst_tbl.Columns.Add("REQUESTOR", typeof(string));
            supply_rqst_tbl.Columns.Add("DATE", typeof(string));
            supply_rqst_tbl.Columns.Add("REQUEST STATUS", typeof(string));
            //supply_rqst_tbl.Columns.Add("Details", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = supply_rqst_tbl;
        }

        private void supplyrqstbtn_Click(object sender, EventArgs e)
        {
            SupplyRequestWindow form = new SupplyRequestWindow();
            form.ShowDialog();
        }

        private void approverqstbtn_Click(object sender, EventArgs e)
        {
            //the user must select an instance first to the table to approve the request
            //the table must be refreshed after pressing the button
        }

        private void notifyrqstrbtn_Click(object sender, EventArgs e)
        {
            NotifyWindow form = new NotifyWindow();
            form.ShowDialog();
        }
    }
}
