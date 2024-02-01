using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procurement_Inventory_System
{
    class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        // Foreign Keys
        public string UserId { get; set; }

        //Foreign Keys Reference
        public Employee AccountUser { get; set; }
    }
}
