using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopProject.Data.Models;

namespace TicketShopProject.Data.Interfaces
{
  public  interface ITicketRepository
    {
        IEnumerable<Ticket> Tickets  { get; }
        IEnumerable<Ticket> PreferredTickets { get; }
        Ticket GetDrinkById(int TicketId );
    }
}
