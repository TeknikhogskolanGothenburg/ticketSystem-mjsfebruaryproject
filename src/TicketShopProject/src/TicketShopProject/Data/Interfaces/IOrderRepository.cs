using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopProject.Data.Models;

namespace TicketShopProject.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
