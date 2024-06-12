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

namespace Procurement_Inventory_System
{
    public partial class ViewQuoDetails : Form
    {
        private const int PageSize = 15; // Number of records per page
        private int currentPage = 1;
        private DataTable quoDetailsTable;

        public ViewQuoDetails()
        {
            InitializeComponent();
        }

        private void CancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewQuoDetails_Load(object sender, EventArgs e)
        {
            quoDetailsTable = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();
            string query = $"select Item_List.item_name, Item_Quotation.unit_price  from quotation \r\ninner join Item_Quotation on quotation.quotation_id = Item_Quotation.quotation_id\r\ninner join Item_List on Item_List.item_id = Item_Quotation.item_id\r\nWHERE Quotation.quotation_id = '{SelectedSupplierQuotation.quoID}'";

            SqlDataAdapter da = db.GetMultipleRecords(query);
            da.Fill(quoDetailsTable);

            // Assuming you have another DataGridView to show the audit logs
            dataGridView1.DataSource = quoDetailsTable;
            db.CloseConnection();
        }
        private void DisplayCurrentPage()
        {
            int startIndex = (currentPage - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, quoDetailsTable.Rows.Count - 1);

            DataTable pageTable = quoDetailsTable.Clone();

            for (int i = startIndex; i <= endIndex; i++)
            {
                pageTable.ImportRow(quoDetailsTable.Rows[i]);
            }

            dataGridView1.DataSource = pageTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage < (quoDetailsTable.Rows.Count + PageSize - 1) / PageSize)
            {
                currentPage++;
                DisplayCurrentPage();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }

        }
    }
}
