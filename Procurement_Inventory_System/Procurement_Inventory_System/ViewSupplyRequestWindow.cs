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
    public partial class ViewSupplyRequestWindow : Form
    {
        public ViewSupplyRequestWindow()
        {
            InitializeComponent();
            

        }

        private void ViewSupplyRequestWindow_Load(object sender, EventArgs e)
        {
            loadEmployee();
            loadHeader();
            LoadSRDetails();
        }

        private void loadEmployee()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT (Employee.emp_fname + ' ' + Employee.emp_lname) as emp_name, BRANCH.BRANCH_NAME, DEPARTMENT.DEPARTMENT_NAME, Employee.section, EMP_ROLE.ROLE_NAME FROM Employee INNER JOIN Supply_Request ON Employee.emp_id = Supply_Request.supply_request_user_id INNER JOIN BRANCH ON BRANCH.BRANCH_ID = Employee.branch_id INNER JOIN EMP_ROLE ON EMP_ROLE.ROLE_ID = Employee.role_id INNER JOIN DEPARTMENT ON DEPARTMENT.DEPARTMENT_ID = Employee.department_id WHERE Supply_Request.supply_request_id = '{SupplierRequest_ID.SR_ID}'; ";

            SqlDataReader dr = db.GetRecord(query);
            if (dr.Read())
            {
                label8.Text = dr["emp_name"].ToString();
                label2.Text = dr["BRANCH_NAME"].ToString();
                label3.Text = dr["DEPARTMENT_NAME"].ToString();
                label4.Text = dr["section"].ToString();
                label17.Text = dr["ROLE_NAME"].ToString();
            }
            dr.Close();
            db.CloseConnection();
        }
        private void loadHeader()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT BRANCH_NAME, CITY, PROVINCE, ZIP_CODE FROM BRANCH WHERE BRANCH_ID = '{CurrentUserDetails.BranchId}'";

            SqlDataReader dr = db.GetRecord(query);
            if (dr.Read())
            {
                label9.Text = dr["BRANCH_NAME"].ToString();
                label7.Text = dr["CITY"].ToString();
                label6.Text = dr["PROVINCE"].ToString();
                label5.Text = dr["ZIP_CODE"].ToString();
            }
            dr.Close();
            db.CloseConnection();
        }
        private string convertDate(string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "MM-dd-yyyy", null);

            string formattedDate = date.ToString("MM/dd/yyyy");

            return formattedDate;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadSRDetails()
        {
            label14.Text = SupplierRequest_ID.SR_ID;

            DataTable supplyReqDetails = new DataTable();
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT Supply_Request.date_updated, Supply_Request.supply_request_date,  (Employee.emp_fname + ' ' + Employee.emp_lname) AS approver FROM Employee INNER JOIN Supply_Request ON Supply_Request.approver_user_id = Employee.emp_id WHERE Supply_Request.supply_request_id = '{SupplierRequest_ID.SR_ID}'; ";
            string supReqBreakdown = $"SELECT Item_List.item_name as [ITEM NAME], Supply_Request_Item.request_quantity as [QTY], Item_Inventory.unit as [UNIT], Supply_Request_Item.remarks as [REMARKS] FROM Item_List INNER JOIN Item_Inventory ON Item_List.item_id = Item_Inventory.item_id INNER JOIN Supply_Request_Item ON Item_List.item_id = Supply_Request_Item.item_id INNER JOIN Supply_Request ON Supply_Request.supply_request_id = Supply_Request_Item.supply_request_id WHERE Supply_Request.supply_request_id = '{SupplierRequest_ID.SR_ID}'; ";

            SqlDataAdapter da = db.GetMultipleRecords(supReqBreakdown);
            da.Fill(supplyReqDetails);
            dataGridView1.DataSource = supplyReqDetails;

            SqlDataReader dr = db.GetRecord(query);
            if (dr.Read())
            {
                label16.Text = dr["approver"].ToString();
                label23.Text = dr["supply_request_date"].ToString();
                label12.Text = dr["date_updated"].ToString();
            }
            dr.Close();
            db.CloseConnection();

        }
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.DisplayRectangle.Location;
        }
    }
 }

