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
    public partial class UpdateInventoryWindow : Form
    {
        public UpdateInventoryWindow()
        {
            InitializeComponent();
        }

        private void updateinventorybtn_Click(object sender, EventArgs e)
        {
            UpdateInventoryPrompt form = new UpdateInventoryPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateInventoryWindow_Load(object sender, EventArgs e)
        {
            PopulateItemName();
        }
        private void PopulateItemName()
        {
            itemName.Text = InventoryIDNum.InventoryItemName;
        }
    }
}
