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
    public partial class ItemListPage : UserControl
    {
        public ItemListPage()
        {
            InitializeComponent();
        }

        private void addnewsplybtn_Click(object sender, EventArgs e)
        {
            AddNewItemWindow form = new AddNewItemWindow();
            form.ShowDialog();
        }

        private void updatesplybtn_Click(object sender, EventArgs e)
        {
            UpdateItemWindow form = new UpdateItemWindow();
            form.ShowDialog();
        }
    }
}
