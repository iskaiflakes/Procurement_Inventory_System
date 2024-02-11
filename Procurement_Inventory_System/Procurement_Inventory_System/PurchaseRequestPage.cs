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
    public partial class PurchaseRequestPage : UserControl
    {
        public PurchaseRequestPage()
        {
            InitializeComponent();

            DataTable purchase_rqst_tbl = new DataTable();

            purchase_rqst_tbl.Columns.Add("REQUEST ID", typeof(string));
            purchase_rqst_tbl.Columns.Add("REQUESTOR", typeof(string));
            purchase_rqst_tbl.Columns.Add("DATE", typeof(string));
            purchase_rqst_tbl.Columns.Add("REQUEST STATUS", typeof(string));
            //supply_rqst_tbl.Columns.Add("Details", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = purchase_rqst_tbl;
        }

        private void purchaserqstbtn_Click(object sender, EventArgs e)
        {
            PurchaseRequestWindow form = new PurchaseRequestWindow();
            form.ShowDialog();
        }

        private void updaterqstbtn_Click(object sender, EventArgs e)
        {
            UpdatePurchaseRqstWindow form = new UpdatePurchaseRqstWindow();
            form.ShowDialog();
        }
    }
}
