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

            supply_rqst_tbl.Columns.Add("Request ID", typeof(string));
            supply_rqst_tbl.Columns.Add("Requestor", typeof(string));
            supply_rqst_tbl.Columns.Add("Date", typeof(string));
            supply_rqst_tbl.Columns.Add("Request Status", typeof(string));
            supply_rqst_tbl.Columns.Add("Details", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = supply_rqst_tbl;
        }

        private void supplyrqstbtn_Click(object sender, EventArgs e)
        {
            SupplyRequestWindow form = new SupplyRequestWindow();
            form.ShowDialog();
        }
    }
}
