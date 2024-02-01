using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procurement_Inventory_System
{
    class Supply_Request_Item
    {
        public string Id { get; set; }
        public string Request_Quantity { get; set; }
        public string Remarks { get; set; }

        //Foreign Keys
        public string SupplyRequestId {  get; set; }
        public string ItemId { get; set; }

        // Foreign Keys Reference
        public Supply_Request supply_Request { get; set; }
        public Item_List Item {  get; set; }
    }
}
