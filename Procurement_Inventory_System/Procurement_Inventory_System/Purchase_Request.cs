using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procurement_Inventory_System
{
    class Purchase_Request
    {
        public string Id { get; set; }

        public string Date {  get; set; }
        public string Status { get; set; }

        //Foreign Keys

        public string PurchaseRequest_User_ID { get; set; }
        public string Approver_User_ID { get; set; }

        //Foreign Keys Reference
        public Purchase_Request purchase_Request { get; set; }
        public Employee Approver {  get; set; }
    }
}
