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
    public partial class PurchaseOrderPage : UserControl
    {
        public PurchaseOrderPage()
        {
            InitializeComponent();
        }

        private void purchaseordrbtn_Click(object sender, EventArgs e)
        {
            AddPurchaseOrderWindow form = new AddPurchaseOrderWindow();
            form.ShowDialog();
        }

        private void updateorderbtn_Click(object sender, EventArgs e)
        {
            UpdatePurchaseOrderWIndow form = new UpdatePurchaseOrderWIndow();
            form.ShowDialog();
        }

        private void PurchaseOrderPage_Load(object sender, EventArgs e)
        {

        }
        public void PopulatePurchaseOrder()
        {

        }
    }
}
