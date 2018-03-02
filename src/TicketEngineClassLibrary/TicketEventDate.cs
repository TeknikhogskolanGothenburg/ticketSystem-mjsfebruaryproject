using System;
using System.Collections.Generic;
using System.Text;


namespace TicketEngineClassLibrary
{
    public class TicketEventDate
    {
        public int TicketEventDateID { get; set; }
        [Required]
        public int TicketEventID { get; set; }
        [Required]
        public int VenueId { get; set; }
        [Required]
        public DateTime EventStartDateTime { get; set; }
        [Range(5, 2000)]
        public int NumberOfSeats { get; set; }
    }
}