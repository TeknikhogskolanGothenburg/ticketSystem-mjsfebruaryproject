using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TicketShopProject.Data.Interfaces;
using TicketShopProject.Data.Models;

namespace TicketShopProject.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _appDbContext;

        public TicketRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Ticket> Tickets => _appDbContext.Tickets.Include(c => c.Category);

        public IEnumerable<Ticket> PreferredTickets => _appDbContext.Tickets.Where(p => p.IsPreferredTicket).Include(c => c.Category);

        public Ticket GetTicketkById(int ticketId ) => _appDbContext.Tickets.FirstOrDefault(p => p.TicketId == ticketId);


    }
}


