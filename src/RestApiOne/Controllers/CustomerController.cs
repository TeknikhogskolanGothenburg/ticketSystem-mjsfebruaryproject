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
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        TicketDatabase database = new TicketDatabase();
        // GET: api/SiteUser
        [HttpGet]
        public List<Customer> GetSiteUser(string query)
        {
            return database.CustomerFind(query);
        }

        // POST: api/SiteUser
        [HttpPost]
        public void Post([FromBody]Customer  customer)
        {
            database.CustomerAdd(customer.Email, customer.Password, customer.IsVaild);

        }



    }
}