using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopProject.Data.Models;

namespace TicketShopProject.Data.Repositories
{
    public class OrderRepository : IorderRepository 
    {

        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)

        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        

        public void CreatOrder(Order order)

        {
            order.OrderPlaced = DateTime.Now;
            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems ;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()

                {
                    Amount = item.Amount,
                    TicketId = item.Ticket.TicketId,
                    OrderId = order.OrderId,
                    Price = item.Ticket.Price
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }




    }
}
