using System;
using TicketShopProject.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShopProject.ViewModels
{
    public class TicketListViewModel
    {
        public IEnumerable<Ticket> Tickets  { get; set; }
        public string CurrentCategory { get; set; }
    }
}
