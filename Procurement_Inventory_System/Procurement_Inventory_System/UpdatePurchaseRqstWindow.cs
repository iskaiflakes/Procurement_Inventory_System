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
    public partial class UpdatePurchaseRqstWindow : Form
    {
        public UpdatePurchaseRqstWindow()
        {
            InitializeComponent();

            DataTable item_rqst_tbl = new DataTable();

            item_rqst_tbl.Columns.Add("Item ID", typeof(string));
            item_rqst_tbl.Columns.Add("Name", typeof(string));
            item_rqst_tbl.Columns.Add("Quantity", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = item_rqst_tbl;
        }

        private void addsupplyqtnbtn_Click(object sender, EventArgs e)
        {
            if(PurchaseRequestIDNum.PurchaseReqID == null)
            {
                MessageBox.Show("Click purchase request id first.");
            }
            else
            {
                SupplierQuotationWindow form = new SupplierQuotationWindow();
                form.ShowDialog();
            }
                

        }

        private void updaterqstbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            UpdatePurchaseRqstPrompt form = new UpdatePurchaseRqstPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
