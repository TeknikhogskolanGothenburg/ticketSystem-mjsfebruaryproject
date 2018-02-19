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
    [Route("api/Order")]
    public class OrderController : Controller
    {
    }
}