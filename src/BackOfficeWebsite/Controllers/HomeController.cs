using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackOfficeWebsite.Models;
using TicketEngineClassLibrary;
using TicketSystem.RestApiClient;


namespace BackOfficeWebsite.Controllers
{
    public class HomeController : Controller
    {


        VenueApi venueApi = new VenueApi();
        EventApi eventApi = new EventApi();
        
        public IActionResult Index()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Venues");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Venues()
        {
            List<Venue> venueList = new List<Venue> { };
            venueList = venueApi.VenueGet();
            if (User.Identity.IsAuthenticated)
            {
                return View(venueList);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Events()
        {
            List<TicketEvent> eventList = new List<TicketEvent> { };
            eventList = eventApi.GetAllEvents();

            if (User.Identity.IsAuthenticated)
            {
                return View(eventList);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Order(string query)
        {
            return View();
        }

        public IActionResult CreatVenue()
        {
            Venue venue = new Venue();
            if (User.Identity.IsAuthenticated)
            {
                return View(venue);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }


        
        public IActionResult CreatEvent ()
        {
            TicketEvent ticketevent = new TicketEvent();

            if (User.Identity.IsAuthenticated)
            {
                return View(ticketevent);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult DateAdd()
        {
            VenueEventModel hybrid = new VenueEventModel();
            hybrid.venues = venueApi.VenueGet();
            hybrid.events = eventApi.GetAllEvents();
            if (User.Identity.IsAuthenticated)
            {
                return View(hybrid);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

       
       

        public IActionResult About()
        {

            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

