using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShopProject.Data.Interfaces;
using TicketShopProject.Data.Models;

namespace TicketShopProject.Data.Mocks
{
    public class MockTicketRepository : ITicketRepository
    {
        //maybe the tickets problem

        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Ticket> Tickets 
        {
            get
            {
                return new List<Ticket>
                {
                    new Ticket {
                        Name = "Michael Jackson Concert",
                        Price = 200.95M, ShortDescription = "Michael Joseph Jackson (August 29, 1958 – June 25, 2009)",
                        LongDescription = " The eighth child of the Jackson family, Michael made his professional debut in 1964 with his elder brothers Jackie, Tito, Jermaine, and Marlon as a member of the Jackson 5. He began his solo career in 1971 while at Motown Records. In the early 1980s, Jackson became a dominant figure in popular music. His music videos, including those of from his 1982 album Thriller, are credited with breaking racial barriers and transforming the medium into an art form and promotional tool. The popularity of these videos helped bring the television channel MTV to fame. Jackson's 1987 album Bad spawned the U.S. Billboard Hot 100 number-one singles I Just Can't Stop Loving You, Ba dThe Way You Make Me Feel Man in the Mirror , and Dirty Diana, becoming the first album to have five number-one singles in the nation. He continued to innovate with videos such as and throughout the 1990s, and forged a reputation as a touring solo artist.",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "http://imgh.us/beerL_2.jpg",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "http://imgh.us/beerS_1.jpeg"
                    },
                    new Ticket {
                        Name = "Madona Concert",
                        Price = 12.95M, ShortDescription = " Madona is an american singer.",
                        LongDescription = " The eighth child of the Jackson family, Michael made his professional debut in 1964 with his elder brothers Jackie, Tito, Jermaine, and Marlon as a member of the Jackson 5. He began his solo career in 1971 while at Motown Records. In the early 1980s, Jackson became a dominant figure in popular music. His music videos, including those of from his 1982 album Thriller, are credited with breaking racial barriers and transforming the medium into an art form and promotional tool. The popularity of these videos helped bring the television channel MTV to fame. Jackson's 1987 album Bad spawned the U.S. Billboard Hot 100 number-one singles I Just Can't Stop Loving You, Ba dThe Way You Make Me Feel Man in the Mirror , and Dirty Diana, becoming the first album to have five number-one singles in the nation. He continued to innovate with videos such as and throughout the 1990s, and forged a reputation as a touring solo artist.",
                        Category =  _categoryRepository.Categories.First(),
                        ImageUrl = "http://imgh.us/rumCokeL.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "http://imgh.us/rumAndCokeS.jpg"
                    },
                    new Ticket {
                        Name = "2 Pac  Concert  ",
                        Price = 12.95M, ShortDescription = " 2 pac is an american rapper ",
                        LongDescription = " The eighth child of the Jackson family, Michael made his professional debut in 1964 with his elder brothers Jackie, Tito, Jermaine, and Marlon as a member of the Jackson 5. He began his solo career in 1971 while at Motown Records. In the early 1980s, Jackson became a dominant figure in popular music. His music videos, including those of from his 1982 album Thriller, are credited with breaking racial barriers and transforming the medium into an art form and promotional tool. The popularity of these videos helped bring the television channel MTV to fame. Jackson's 1987 album Bad spawned the U.S. Billboard Hot 100 number-one singles I Just Can't Stop Loving You, Ba dThe Way You Make Me Feel Man in the Mirror , and Dirty Diana, becoming the first album to have five number-one singles in the nation. He continued to innovate with videos such as and throughout the 1990s, and forged a reputation as a touring solo artist.",
                        Category =  _categoryRepository.Categories.First(),
                        ImageUrl = "http://imgh.us/tequilaL.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "http://imgh.us/tequilaS.jpg"
                    },
                    new Ticket
                    {
                        Name = "50 Cent  Concert",
                        Price = 12.95M,
                        ShortDescription = " 50 Cent is an american rapper",
                        LongDescription = "  The eighth child of the Jackson family, Michael made his professional debut in 1964 with his elder brothers Jackie, Tito, Jermaine, and Marlon as a member of the Jackson 5. He began his solo career in 1971 while at Motown Records. In the early 1980s, Jackson became a dominant figure in popular music. His music videos, including those of from his 1982 album Thriller, are credited with breaking racial barriers and transforming the medium into an art form and promotional tool. The popularity of these videos helped bring the television channel MTV to fame. Jackson's 1987 album Bad spawned the U.S. Billboard Hot 100 number-one singles I Just Can't Stop Loving You, Ba dThe Way You Make Me Feel Man in the Mirror , and Dirty Diana, becoming the first album to have five number-one singles in the nation. He continued to innovate with videos such as and throughout the 1990s, and forged a reputation as a touring solo artist.",
                        Category = _categoryRepository.Categories.Last(),
                        ImageUrl = "http://imgh.us/juiceL.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "http://imgh.us/juiceS.jpg"
                    }
                };
            }
        }
        public IEnumerable<Ticket> PreferredTickets { get; }
        public Ticket GetDrinkById(int drinkId)
        {
            throw new NotImplementedException();
        }
    }
}
