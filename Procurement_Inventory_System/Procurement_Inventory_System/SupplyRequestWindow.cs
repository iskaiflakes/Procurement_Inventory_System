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
    public partial class SupplyRequestWindow : Form
    {
        public SupplyRequestWindow()
        {
            InitializeComponent();
        }

        private void CreateRequestWindow_Load(object sender, EventArgs e)
        {
            DataTable item_rqst_tbl = new DataTable();

            item_rqst_tbl.Columns.Add("Item ID", typeof(string));
            item_rqst_tbl.Columns.Add("Name", typeof(string));
            item_rqst_tbl.Columns.Add("Quantity", typeof(string));

            //add rows here from the database...

            dataGridView1.DataSource = item_rqst_tbl;
        }

        private void additemrqstbtn_Click(object sender, EventArgs e)
        {
            AddRequestItemWindow form = new AddRequestItemWindow();
            form.ShowDialog();
        }

        private void createnewrqstbtn_Click(object sender, EventArgs e)
        {
            //the table must be refreshed after pressing the button
            //to reflect the request record instance in the table

            this.Close();
            RequestPrompt form =  new RequestPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteitemrqstbtn_Click(object sender, EventArgs e)
        {
            //the user must select an instance first to the table to delete an item
            //the table must be refreshed after pressing the button
        }
    }
}
