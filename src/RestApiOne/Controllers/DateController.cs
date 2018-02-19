using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketEngineClassLibrary;
using TicketSystem.DatabaseRepository;

namespace RestApiOne.Controllers
{
    [Produces("application/json")]
    [Route("api/Date")]
    public class DateController : Controller
    {

        TicketDatabase tbd = new TicketDatabase();

        [HttpGet("{query}")]
        public List<object> Get(string date1, string date2)
        {
            return tbd.EventDateFindEventsAndVenues(date1, date2);
        }
    }
}