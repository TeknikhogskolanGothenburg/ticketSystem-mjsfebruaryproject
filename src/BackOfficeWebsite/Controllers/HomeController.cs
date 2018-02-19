using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BackOfficeWebsite.Models;
using TicketEngineClassLibrary;
using TicketSystem.RestApiClient;
using System.Collections.Generic;

namespace BackOfficeWebsite.Controllers
{
    public class HomeController : Controller
    {

        VenueApi venueApi = new VenueApi();
         
        Ordermanagment ordermanagmentApi = new Ordermanagment();
        public IActionResult Index()
        {
            return View();
        }
        

        public IActionResult Venues(string VenueName, string address, string city, string country)
        {
            if (!string.IsNullOrEmpty(VenueName))
            {
                TicketApi ticketApi = new TicketApi();
                ticketApi.VenuesAdd(new Venue()
                {
                    VenueName = VenueName,
                    Address = address,
                    City = city,
                    Country = country
                });
            }
            return View();
           
             //else
            //{
            //    return RedirectToAction("Login", "Account");
            //}


        }

        public IActionResult Events(string name, string description)
        {
            if (!string.IsNullOrEmpty(name))
            {
                TicketApi ticketApi = new TicketApi();
                ticketApi.EventsAdd(new TicketEvent()
                {
                    EventName = name,
                    EventHtmlDescription = description
                });
            }
            return View();

            //else
            //{
            //    return RedirectToAction("Login", "Account");
            //}


        }



        public IActionResult Order()
        {
            List<Order> orderList = new List<Order> { };
            //orderList = ordermanagmentApi.GetAllOrders();

            if (User.Identity.IsAuthenticated)
            {
                return View(orderList);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}