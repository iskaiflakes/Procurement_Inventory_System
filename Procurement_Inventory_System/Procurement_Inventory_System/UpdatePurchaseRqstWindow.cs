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

            // Attach the DataError event to the corresponding event handler.
            this.dataGridView1.DataError +=
                new DataGridViewDataErrorEventHandler(dataGridView1_DataError);

            DataTable item_rqst_tbl = new DataTable();

            item_rqst_tbl.Columns.Add("Item ID", typeof(string));
            item_rqst_tbl.Columns.Add("Name", typeof(string));
            item_rqst_tbl.Columns.Add("Quantity", typeof(string));
            item_rqst_tbl.Columns.Add("Selected", typeof(bool)); //this will show checkboxes

            //sample row
            for (int i = 1; i <= 3; i++)
            {
                DataRow row = item_rqst_tbl.NewRow();
                row["Item ID"] = "44324422";
                row["Name"] = "Kane";
                row["Quantity"] = "33";
                row["Selected"] = false; // This is getting displayed as System.Windows.Forms.CheckBox,CheckState=0

                item_rqst_tbl.Rows.Add(row);
            }

            //add rows here from the database...

            dataGridView1.DataSource = item_rqst_tbl;
        }
        private void dataGridView1_DataError(object sender,
        DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is
            // commited, display an error message.
            if (e.Exception != null &&
                e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("CustomerID value must be unique.");
            }
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
