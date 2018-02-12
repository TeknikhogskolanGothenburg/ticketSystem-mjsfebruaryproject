using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TicketShopProject.Data.Interfaces;
using TicketShopProject.Data.Models;

namespace TicketShopProject.Data.Repositories
{
  
    public class CategoryRepository  : ICategoryRepository 
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext )
        {
            _appDbContext = appDbContext;
        }

       public  IEnumerable<Category> Categories => _appDbContext.Categories; 
    }
}
