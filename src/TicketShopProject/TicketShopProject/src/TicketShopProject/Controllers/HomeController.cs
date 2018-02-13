using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketShopProject.Data.Interfaces;
using TicketShopProject.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketShopProject.Controllers
{
    public class HomeController : Controller
    {


        private readonly ITicketRepository _ticketRepository;
        public HomeController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository ;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredTickets  = _ticketRepository.PreferredTickets
            };
            return View(homeViewModel);
        }
    }
}
