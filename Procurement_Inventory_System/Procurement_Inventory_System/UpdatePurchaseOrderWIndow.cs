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
    public partial class UpdatePurchaseOrderWindow : Form
    {
        private PurchaseOrderPage purchaseOrderPage;
        public UpdatePurchaseOrderWindow(PurchaseOrderPage purchaseOrderPage)
        {
            InitializeComponent();
            this.purchaseOrderPage = purchaseOrderPage;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updatepostatusbtn_Click(object sender, EventArgs e)
        {

            //display this once done
            UpdatePurchaseOrderPrompt form = new UpdatePurchaseOrderPrompt();
            form.ShowDialog();
        }

        private void UpdatePurchaseOrderWindow_Load(object sender, EventArgs e)
        {

        }
        private void RefreshPurchaseOrderTable()
        {
            purchaseOrderPage.PopulatePurchaseOrder();
        }
    }
}
