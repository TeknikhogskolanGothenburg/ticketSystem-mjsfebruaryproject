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
    [Route("api/CustomerRegistration")]
    public class CustomerRegistrationController : Controller
    {

        TicketDatabase database = new TicketDatabase();

        [HttpGet("{query}")]
        public List<CustomerRegistration> GetCustomerRegister(string query)
        {
            return database.CustomerRegisterFind(query);
        }

        // POST: api/SiteUser
        [HttpPost]
        public void Post([FromBody]CustomerRegistration customer)
        {
            database.CustomerRegisterdAdd(customer.FName, customer.LName, customer.Password, customer.City);
        }

    }
}