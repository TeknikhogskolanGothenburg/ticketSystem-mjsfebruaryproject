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
    [Route("api/Venues")]
    public class ValuesController : Controller
    {
        TicketDatabase database = new TicketDatabase();

        //Get api/Venues
        [HttpGet("{query}")]
        public List<Venue> Get(string query)
        {
            return TicketDatabase.VenuesSpecific(query);
        }

        [HttpPost]
        public void Post([FromBody]Venue venue)
        {

            database.VenueAdd(venue.VenueName, venue.Address, venue.City, venue.Country);


        }


        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
