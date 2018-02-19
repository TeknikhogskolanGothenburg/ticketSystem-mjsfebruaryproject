using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketShopProject.Data.Interfaces;
using TicketShopProject.Data.Models;
using TicketShopProject.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketShopProject.Controllers
{
    public class ShoppingCartController : Controller
    {


        private readonly ITicketRepository _ticketRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ITicketRepository ticketRepository, ShoppingCart shoppingCart)
        {
            _ticketRepository = ticketRepository;
            _shoppingCart = shoppingCart;
        }
        // GET: /<controller>/
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int ticketId )
        {
            var selectedTicket = _ticketRepository.Tickets.FirstOrDefault(p => p.TicketId == ticketId);
            if (selectedTicket != null)
            {
                _shoppingCart.AddToCart(selectedTicket, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int ticketId )
        {
            var selectedTicket = _ticketRepository.Tickets.FirstOrDefault(p => p.TicketId == ticketId);
            if (selectedTicket != null)
            {
                _shoppingCart.RemoveFromCart(selectedTicket);
            }
            return RedirectToAction("Index");
        }
    }
}
