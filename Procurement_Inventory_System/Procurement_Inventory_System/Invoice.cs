using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procurement_Inventory_System
{
    class Invoice
    {
        public string Id { get; set; }
        public double Total_Amount {  get; set; }
        public double Tax_Amount { get; set; }
        public string Payment_Due_Date { get; set; }

        //Foreign Keys
        public string SupplierId {  get; set; }
        public string PurchaseOrderId { get; set; }

        //Foreign Keys Reference
        public Supplier Supplier { get; set; }
        public Purchase_Order Purchase_Order { get; set; }

    }
}
