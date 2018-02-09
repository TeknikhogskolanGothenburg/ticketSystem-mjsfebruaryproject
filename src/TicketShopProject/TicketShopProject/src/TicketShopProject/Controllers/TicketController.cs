using System;

using TicketShopProject.Data.Interfaces;
using TicketShopProject.ViewModels;
using TicketShopProject.Data.Mocks; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

        public ViewResult List ()

        {
            ViewBag.Name = " Dotnet,  how ?"; 
            TicketListViewModel vm = new TicketListViewModel();
            vm.Tickets = _ticketRepository.Tickets;
            vm.CurrentCategory = "TicketCategory";   /// video 14
            return View(vm);
        }
    }
}
