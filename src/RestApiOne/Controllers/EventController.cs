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
    [Route("api/Event")]
    public class EventController : Controller
    {

        TicketDatabase tbd = new TicketDatabase();

        [HttpGet("{query}")]
        public List<TicketEvent> Get(string query)
        {
            return tbd.EventFindSpecifik(query);
        }

        [HttpPost]
        public void Post([FromBody]TicketEvent newEvent)
        {
            tbd.EventAdd(newEvent.EventName, newEvent.EventHtmlDescription);
        }
    }
}