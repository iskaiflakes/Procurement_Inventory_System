using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procurement_Inventory_System
{
    class Quotation
    {
        public string Id {  get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public string VAT_Status { get; set; }
        public string Date { get; set; }
        public string Validity { get; set; }

        //Foreign Keys
        public string SupplierId { get; set; }
        public string ItemId { get; set; }

        //Foreign Keys Reference
        public Supplier supplier { get; set; }
        public Item_List item { get; set; }
    }
}
