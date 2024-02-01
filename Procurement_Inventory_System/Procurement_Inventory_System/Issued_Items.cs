using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procurement_Inventory_System
{
    class Issued_Items
    {
        public string Id { get; set; }
        public string Date { get; set; }

        //Foreign Keys
        public string Request_Item_Id { get; set; }
        public string Issuer_User_Id { get; set; }
        public string Approver_User_Id { get; set; }

        //Foreign Keys References
        public Employee Approver_Employee { get; set; }
        public Employee Issuer_Employee { get; set; }
        public Supply_Request_Item Request_Item { get; set; }

    }
}
