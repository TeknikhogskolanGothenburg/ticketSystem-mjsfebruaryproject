using System;
using System.Collections.Generic;
using System.Text;

namespace TicketEngineClassLibrary
{
   public  class Customer
    {

        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public int IsVaild { get; set; }
    }
}
