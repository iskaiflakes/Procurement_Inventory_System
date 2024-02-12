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
    public partial class PurchaseRequestWindow : Form
    {
        public PurchaseRequestWindow()
        {
            InitializeComponent();
        }

        private void additemrqstbtn_Click(object sender, EventArgs e)
        {
            using (AddRequestItemWindow addItemForm = new AddRequestItemWindow())
            {
                if (addItemForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the new item data
                    ItemData newItem = addItemForm.NewItem;
                    if (newItem != null)
                    {
                        // Now you can add the newItem to the DataGridView
                        DataTable dt = (DataTable)dataGridView1.DataSource ?? new DataTable();

                        if (dt.Columns.Count == 0)
                        {
                            // Assuming the DataTable doesn't have columns defined
                            dt.Columns.Add("Item ID", typeof(string));
                            dt.Columns.Add("Item Name", typeof(string));
                            dt.Columns.Add("Quantity", typeof(int));
                            dt.Columns.Add("Remarks", typeof(string));
                        }

                        dt.Rows.Add(newItem.ItemId, newItem.ItemName, newItem.Quantity, newItem.Remarks);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void createnewrqstbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            RequestPrompt form = new RequestPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PurchaseRequestWindow_Load(object sender, EventArgs e)
        {

        }
        private void PopulateItemRequests()
        {

        }
    }
}
