using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procurement_Inventory_System
{
    class Purchase_Order
    {
        public string Id { get; set; }
        public double Total_Price { get; set; }
        public string Payment_Type { get; set; }
        public string Date {  get; set; }
        public string Status { get; set; }

        //Foreign Keys

        public string PurchaseRequestId {  get; set; }
        public string SupplierId { get; set; }
        public string OrderUserId { get; set; }

        //Foreign Keys Reference
        public Employee OrderUser { get; set; }
        public Supplier Supplier { get; set; }
        public Purchase_Request Purchase_Request { get; set; }


    }
}
