
using TicketShopProject.Data.Models; 
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace TicketShopProject.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context =
                applicationBuilder.ApplicationServices.GetRequiredService< AppDbContext >();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Tickets.Any())
            {
                context.AddRange
                (
                    new Ticket
                    {
                        Name = "Bad World Tour",
                        Price = 300.95M,
                        ShortDescription = "Michael Jackson is The king of Pop  and one the greatest pop singers of the latter half of the Twentieth Century.",
                        LongDescription = "  Michael Joseph Jackson—the King of Pop, The Gloved One,Jacko—was one the greatest pop singers of the latter half of the Twentieth Century, and, according to the Guinness Book of World Records, one of the most successful entertainers of all time. The chart-crossing Jackson 5—Michael and his brothers Jackie, Tito, Jermaine, Marlon, and, as The Jacksons, Randy—made up the one of the few groups in recording history to have their first four major-label singles reach the top of Billboard’s Hot 100. Their songs appeared on both the Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body dominated the group. As Michael’s vision outpaced the brother act, he moved into a media-breaking solo career. Like all Motown singers, the five Jacksons—a late addition to the Motown  stable of artists—performed tightly choreographed, often unison dancing. Even before Motown, the boys culled “moves” from their environment— television, and from the streets and social dancing in their Gary, Indiana, community.",
                        Category = Categories["Music-Concert-Ticket"],
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        InStock = true,
                        IsPreferredTicket = true,
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "Svensson, Svensson",
                        Price = 12.95M,
                        ShortDescription = " Svensson, Svensson is a Swedish sitcom. It has also been made into a feature film and a play.",
                        LongDescription = "Two seasons consisting of 12 episodes each were broadcast in the autumn of 1994 and the autumn of 1996.They have since been repeated numerous times.The series was revived for a third season in 2007, and a fourth in 2008.Michael Joseph Jackson—the King of Pop, The Gloved One, Jacko—was one the greatest pop singers of the latter half of the Twentieth Century, and, according to the Guinness Book of World Records, one of the most successful entertainers of all time.The chart - crossing Jackson 5—Michael and his brothers Jackie, Tito, Jermaine, Marlon, and, as The Jacksons, Randy—made up the one of the few groups in recording history to have their first four major - label singles reach the top of Billboard’s Hot 100.Their songs appeared on both the Top 5 Pop Hits and at number one on the R & B singles chart.From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body dominated the group.As Michael’s vision outpaced the brother act, he moved into a media - breaking solo career.",

                      Category = Categories["Movie-Ticket"],
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg",
                        InStock = true,
                      IsPreferredTicket = false
                      
                    },
                    new Ticket 
                    {
                        Name = "The Virgin Tour",
                        Price = 250.95M,
                        ShortDescription = "Madonna Louise Ciccone  is an American singer, songwriter, actress, and businesswoman",
                        LongDescription = "Madonna Louise Ciccone according to the Guinness Book of World Records, one of the most successful entertainers of all time. The chart-crossing Jackson 5—Michael and his brothers Jackie, Tito, Jermaine, Marlon, and, as The Jacksons, Randy—made up the one of the few groups in recording history to have their first four major-label singles reach the top of Billboard’s Hot 100. Their songs appeared on both the Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body dominated the group. As Michael’s vision outpaced the brother act, he moved into a media-breaking solo career. Like all Motown singers, the five Jacksons—a late addition to the Motown  stable of artists—performed tightly choreographed, often unison dancing. Even before Motown, the boys culled “moves” from their environment— television, and from the streets and social dancing in their Gary, Indiana, community.Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body .",
                        Category = Categories["Music-Concert-Ticket"],
                         
                        InStock = true,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "Tribute to Eazy-E Tour ",
                        Price = 160.75M,
                        ShortDescription = " Tribute to Eazy-E Tour is 2 pacs Tour ",
                     
                        LongDescription = "2 pac  according to the Guinness Book of World Records, one of the most successful entertainers of all time. The chart-crossing Jackson 5—Michael and his brothers Jackie, Tito, Jermaine, Marlon, and, as The Jacksons, Randy—made up the one of the few groups in recording history to have their first four major-label singles reach the top of Billboard’s Hot 100. Their songs appeared on both the Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body dominated the group. As Michael’s vision outpaced the brother act, he moved into a media-breaking solo career. Like all Motown singers, the five Jacksons—a late addition to the Motown  stable of artists—performed tightly choreographed, often unison dancing. Even before Motown, the boys culled “moves” from their environment— television, and from the streets and social dancing in their Gary, Indiana, community.Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body ",
                        Category = Categories["Music-Concert-Ticket"],
                         
                        InStock = true,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "WelCame To Sweden ",
                        Price = 50.95M,
                        ShortDescription = "WelCame to Sweden is a Swedish Tv Serie",
                        Category = Categories["Movie-Ticket"],
                        LongDescription = " Welcame to Sweden is Two seasons consisting of 12 episodes each were broadcast in the autumn of 1994 and the autumn of 1996. They have since been repeated numerous times. The series was revived for a third season in 2007, and a fourth in 2008.Michael Joseph Jackson—the King of Pop, The Gloved One,Jacko—was one the greatest pop singers of the latter half of the Twentieth Century, and, according to the Guinness Book of World Records, one of the most successful entertainers of all time. The chart-crossing Jackson 5—Michael and his brothers Jackie, Tito, Jermaine, Marlon, and, as The Jacksons, Randy—made up the one of the few groups in recording history to have their first four major-label singles reach the top of Billboard’s Hot 100. Their songs appeared on both the Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body dominated the group. As Michael’s vision outpaced the brother act, he moved into a media-breaking solo career.",
                        
                        InStock = true,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "Good Girl Gone Bad Tour",
                        Price = 155.95M,
                        ShortDescription = "Good Girl Gone Bad Tour was the second overall and first world concert tour by Barbadian singer Rihanna",
                        LongDescription = " Rihanna according to the Guinness Book of World Records, one of the most successful entertainers of all time. The chart-crossing Jackson 5—Michael and his brothers Jackie, Tito, Jermaine, Marlon, and, as The Jacksons, Randy—made up the one of the few groups in recording history to have their first four major-label singles reach the top of Billboard’s Hot 100. Their songs appeared on both the Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body dominated the group. As Michael’s vision outpaced the brother act, he moved into a media-breaking solo career. Like all Motown singers, the five Jacksons—a late addition to the Motown  stable of artists—performed tightly choreographed, often unison dancing. Even before Motown, the boys culled “moves” from their environment— television, and from the streets and social dancing in their Gary, Indiana, community.Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body.",
                        Category = Categories["Music-Concert-Ticket"],
                        
                        InStock = false,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "All I Want For Christmas Is You Tour ",
                        Price = 15.95M,
                        ShortDescription = " All I Want For Christmas Is You is a Maria Carry Tour",
                        LongDescription = " Mariah Carey is an American singer and songwriter. After signing to Columbia Records, she released her debut album, Mariah Carey,Marlon, and, as The Jacksons, Randy—made up the one of the few groups in recording history to have their first four major-label singles reach the top of Billboard’s Hot 100. Their songs appeared on both the Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body dominated the group. As Michael’s vision outpaced the brother act, he moved into a media-breaking solo career. Like all Motown singers, the five Jacksons—a late addition to the Motown  stable of artists—performed tightly choreographed, often unison dancing. Even before Motown, the boys culled “moves” from their environment— television, and from the streets and social dancing in their Gary, Indiana, community.Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage. ",
                        Category = Categories["Music-Concert-Ticket"],
                       
                        InStock = false,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    }, 
                    new Ticket
                    {
                        Name = "The Secret Life of the American Teenager",
                        Price = 15.95M,
                        ShortDescription = "The Secret Life of the American Teenager  is an American teen drama television series created by Brenda Hampton.",
                        LongDescription = " The Secret Life of the American Teenager  and songwriter. After signing to Columbia Records, she released her debut album, Mariah Carey,Marlon, and, as The Jacksons, Randy—made up the one of the few groups in recording history to have their first four major-label singles reach the top of Billboard’s Hot 100. Their songs appeared on both the Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body dominated the group. As Michael’s vision outpaced the brother act, he moved into a media-breaking solo career. Like all Motown singers, the five Jacksons—a late addition to the Motown  stable of artists—performed tightly choreographed, often unison dancing. Even before Motown, the boys culled “moves” from their environment— television, and from the streets and social dancing in their Gary, Indiana, community.Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage",
                        Category = Categories["Movie-Ticket"],
                        
                        InStock = false,
                        IsPreferredTicket  = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "ABBA: The Tour",
                        Price = 156.95M,
                        ShortDescription = "ABBA: The Tour,[1] later also labelled ABBA in Concert and ABBA: ",
                        LongDescription = " ABBA: The Tour North American and European Tour 1979, was the third and final concert tour by the Swedish pop group, ABBA. Primarily visiting North America, Europe and Asia during 1979–1980, the tour supported the group's sixth studio album, Voulez-Vous. The tour opened in Edmonton, Alberta  the few groups in recording history to have their first four major-label singles reach the top of Billboard’s Hot 100. Their songs appeared on both the Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage, Michael’s powerful voice and diminutive dervish of a body dominated the group. As Michael’s vision outpaced the brother act, he moved into a media-breaking solo career. Like all Motown singers, the five Jacksons—a late addition to the Motown  stable of artists—performed tightly choreographed, often unison dancing. Even before Motown, the boys culled “moves” from their environment— television, and from the streets and social dancing in their Gary, Indiana, community.Top 5 Pop Hits and at number one on the R&B singles chart. From the moment he joined his brothers on stage.",
                        Category = Categories["Music-Concert-Ticket"],
                         
                        InStock = false,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket 
                    {
                        Name = " Prison Break",
                        Price = 15.95M,
                        ShortDescription = "Prison break is a hollywood Movie ",
                        LongDescription = " Prison Break is Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = Categories["Movie-Ticket"],
                        
                        InStock = false,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket 
                    {
                        Name = "History Tour ",
                        Price = 15.95M,
                        ShortDescription = "History Tour is a Michael Jacksons Tour ",
                        LongDescription = " Michael jackson and othere performencers and profetional giatarists Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = Categories["Music-Concert-Ticket"],
                        
                        InStock = false,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "Da Clube Concert ",
                        Price = 154.95M,
                        ShortDescription = "Da Club Concert is a 50 cent tour to different Contries ",
                        LongDescription = " 50 Cent is an american rapper Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = Categories["Music-Concert-Ticket"],
                        
                        InStock = false,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "All Eyez On Me Tour ",
                        Price = 188.95M,
                        ShortDescription = "All Eyz On Me is 2 pacs Tour ",
                        LongDescription = " 2 pac is an american raper Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = Categories["Music-Concert-Ticket"],
                        
                        InStock = false,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "Triller Tour ",
                        Price = 335.95M,
                        ShortDescription = "Triller is a Michael Jacksons Tour .",
                        LongDescription = " Michael Jackson is an merican singer Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = Categories["Music-Concert-Ticket"],
                         
                        InStock = false,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "Dear Mamma Tour  ",
                        Price = 124.95M,
                        ShortDescription = " Dear Mamma Tour is a 2 pacs MUSIC Concert",
                        LongDescription = " 2 pac is an american rapper Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = Categories["Music-Concert-Ticket"],
                        
                        InStock = true,
                        IsPreferredTicket = true,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "Bad Boy ",
                        Price = 124.95M,
                        ShortDescription = " Bad Boys is an american Movie  ",
                        LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = Categories["Movie-Ticket"],
                        
                        InStock = true,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "Music Tour ",
                        Price = 82.95M,
                        ShortDescription = " Music Tour is a Madona Tour ",
                        LongDescription = " Madona is an american singer, actress and bussnesswoman Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = Categories["Music-Concert-Ticket"],
                        
                        InStock = true,
                        IsPreferredTicket = true,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = " History 2 ",
                        Price = 312.95M,
                        ShortDescription = " History 2 Tour is a Michael Jacsons music concert",
                        LongDescription = "  Michael jackson is an american music star Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = Categories["Music-Concert-Ticket"],
                          
                        InStock = true,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    },
                    new Ticket
                    {
                        Name = "Bad 2  ",
                        Price = 212.95M,
                        ShortDescription = "Bad Tour is a Michael jackson music concert.",
                        LongDescription = " Michael Jackson is an american pop star Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = Categories["Music-Concert-Ticket"],
                        
                        InStock = true,
                        IsPreferredTicket = false,
                        ImageUrl = " http://www.telegraph.co.uk/content/dam/technology/Spark/how-phones-changed-the-world/mobile-phones-held-up-at-gig_trans_NvBQzQNjv4BqqVzuuqpFlyLIwiB6NTmJwfSVWeZ_vEN7c6bHu2jJnT8.jpg?imwidth=450",
                        //ImageThumbnailUrl = "http://s3.india.com/travel/wp-content/uploads/2015/06/Michael-Jackson.jpg"
                    }
                );
        }

        context.SaveChanges();
        }

    private static Dictionary<string, Category> categories;
    public static Dictionary<string, Category> Categories
    {
        get
        {
            if (categories == null)
            {
                var genresList = new Category[]
                {
                        new Category { CategoryName = "Music-Concert-Ticket", Description="All Music Concert Tickets" },
                        new Category { CategoryName = "Movie-Ticket", Description="All Movie Tickets" }
                };

                categories = new Dictionary<string, Category>();

                foreach (Category genre in genresList)
                {
                    categories.Add(genre.CategoryName, genre);
                }
            }

            return categories;
        }
    }
}
}
