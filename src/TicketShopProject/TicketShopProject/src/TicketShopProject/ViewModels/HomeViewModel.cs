using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopProject.Data.Models;

namespace TicketShopProject.ViewModels
{
    public class HomeViewModel
    {
      public   IEnumerable<Ticket> PreferredTickets { get; set;  } 
    }
}
