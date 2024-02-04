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
    public partial class AddNewSupplyWindow : Form
    {
        public AddNewSupplyWindow()
        {
            InitializeComponent();
        }
        
        private void addnewitembtn_Click(object sender, EventArgs e)
        {
            AddNewSupplyPrompt form = new AddNewSupplyPrompt();
            form.ShowDialog();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddItemWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
