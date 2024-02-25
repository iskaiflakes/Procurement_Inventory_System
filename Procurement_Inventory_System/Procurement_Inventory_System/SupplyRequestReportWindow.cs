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
    public partial class SupplyRequestReportWindow : Form
    {
        public SupplyRequestReportWindow()
        {
            InitializeComponent();
            loadEmployee();
            loadHeader();

            label14.Text = convertDate(CurrentReport.dateFrom);
            label16.Text = convertDate(CurrentReport.dateTo);

            DateTime currentDateAndTime = DateTime.Now;
            string currentDate = currentDateAndTime.ToShortDateString();
            string currentTime = currentDateAndTime.ToLongTimeString();

            label23.Text = currentDate;
            label18.Text = currentTime;

        }
        private void loadEmployee()
        {
            DatabaseClass db = new DatabaseClass();
            db.ConnectDatabase();

            string query = $"SELECT CASE WHEN Employee.suffix IS NOT NULL THEN (Employee.emp_lname + ' '+Employee.suffix + ', ' + Employee.emp_fname + ' ' + ISNULL(Employee.middle_initial + '.', '')) ELSE (Employee.emp_lname + ', ' + Employee.emp_fname + ' ' + ISNULL(Employee.middle_initial + '.', '')) END AS [Employee Name], BRANCH.BRANCH_NAME AS Branch, DEPARTMENT.DEPARTMENT_NAME AS Department, ROLE_NAME AS Position FROM Employee INNER JOIN BRANCH ON Employee.branch_id = BRANCH.BRANCH_ID INNER JOIN DEPARTMENT ON DEPARTMENT.DEPARTMENT_ID = Employee.department_id INNER JOIN EMP_ROLE ON EMP_ROLE.ROLE_ID = Employee.role_id WHERE Employee.emp_id = '{CurrentUserDetails.UserID}';";

            SqlDataReader dr = db.GetRecord(query);
            if (dr.Read())
            {
                label8.Text = dr["Employee Name"].ToString();
                label2.Text = dr["Branch"].ToString();
                label3.Text = dr["Department"].ToString();
                label4.Text = dr["Position"].ToString();
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
    }
    }

