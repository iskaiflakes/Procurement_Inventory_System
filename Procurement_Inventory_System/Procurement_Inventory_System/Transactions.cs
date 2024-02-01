using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procurement_Inventory_System
{
    class Transaction
    {
        //properties of Transaction
        public string Id { get; set; }
        
        public double Amount_Paid { get; set; }
        public string UserId { get; set; }

        // Foreign Keys
        public string InvoiceId { get; set; }
        public string PurchaseOrderId { get; set; }

        // Foreign Keys Reference
        public Invoice Invoice { get; set; }
        public Purchase_Order Purchase_Order { get; set; }
        public Employee TransactionUser { get; set; }

    }
}
