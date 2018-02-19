using System;

using TicketShopProject.Data.Interfaces;
using TicketShopProject.ViewModels;
using TicketShopProject.Data.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketShopProject.Data.Models;

namespace TicketShopProject.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ICategoryRepository _categoryRepository;
        public TicketController(ITicketRepository ticketRepository, ICategoryRepository categoryRepository)
        {
            _ticketRepository = ticketRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Ticket> tickets ;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                tickets = _ticketRepository.Tickets.OrderBy(p => p.TicketId);
                currentCategory = "All Tickets";
            }
            else
            {
                if (string.Equals("Music-Concert-Taickets", _category, StringComparison.OrdinalIgnoreCase))
                    tickets = _ticketRepository.Tickets.Where(p => p.Category.CategoryName.Equals("Music-Concert-Ticket")).OrderBy(p => p.Name);
                else
                    tickets = _ticketRepository.Tickets.Where(p => p.Category.CategoryName.Equals("Movie-Ticket")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new TicketListViewModel
            {
                Tickets = tickets,
                CurrentCategory = currentCategory
            });
        }
    }
}
