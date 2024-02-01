using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procurement_Inventory_System
{
    class Purchase_Request_Items
    {
        public string PurchaseRequest_Item_ID {  get; set; }

        public string Item_Quantity { get; set; }
        public string Remarks { get; set; }

        public string PurchaseRequest_ID { get; set; }
        public string Quotation_ID { get; set; }
        public string Item_ID { get; set; }

        public Purchase_Request Purchase_Request { get; set; }
        public Quotation Quotation { get; set; }
        public Item_List Item {  get; set; }
    }
}
