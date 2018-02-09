using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopProject.Data.Interfaces;
using TicketShopProject.Data.Models;

namespace TicketShopProject.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                     {
                         new Category { CategoryName = "Music-Concert-Ticket", Description = "All alcoholic drinks" },
                         new Category { CategoryName = "Teater-Concert-Ticket", Description = "All non-alcoholic drinks" }
                     };
            }
        }


    }
}
