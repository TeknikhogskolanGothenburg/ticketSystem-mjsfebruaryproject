using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopProject.Data.Interfaces;
using TicketShopProject.Data.Models;

namespace TicketShopProject.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository // maybe small spelling will cause a problem
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                     {
                         new Category { CategoryName = "Music-Concert-Ticket", Description = "All Music COncert Tickets" },
                         new Category { CategoryName = "Movie-Ticket", Description = "All Film Tickets" }
                     };
            }
        }


    }
}
