using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Procurement_Inventory_System.GenerateReportWindow;

namespace Procurement_Inventory_System
{
    public partial class InventoryReportWindow : Form
    {
        public InventoryReportWindow()
        {
            InitializeComponent();


        }


        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
