using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procurement_Inventory_System
{
    class Item_Inventory
    {
        
        public string Available_Quantity {  get; set; }
        public string Date_added { get; set; }
        public string Date_updated { get; set;}

        //Foreign Keys
        public string Item_ID { get; set; }

        //Foreign Keys Reference
        public Item_List Item_List { get; set; }
    }
}
