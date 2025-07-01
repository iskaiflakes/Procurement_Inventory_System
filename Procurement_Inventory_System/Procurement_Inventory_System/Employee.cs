using System.Runtime.InteropServices;

namespace Procurement_Inventory_System
{
    class Employee
    {
        // properties of Employee
        public int UserID { get; set; }
        public string Fname { get; set; }
        public string Middle_initial { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Mobile_num { get; set; }
        public string Address { get; set; }
        public string Section { get; set; }

        // foreign keys
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }

        //Foreign Keys Reference
        //public Branch Branch { get; set; }
        //public Department Department { get; set; }

        
    }
}
