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
    public partial class AddItemWindow : Form
    {
        public AddItemWindow()
        {
            InitializeComponent();
        }
        
        private void addnewitembtn_Click(object sender, EventArgs e)
        {
            AddItemPrompt form = new AddItemPrompt();
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
