using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketShopProject.Data.Models
{
    public class Ticket
    {

        public int TicketId  { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPreferredTicket  { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


       
    }
}
