﻿namespace TicketEngineClassLibrary
{
    public class TicketEvent
    {
        public int TicketEventId { get; set; }
      
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }
        
        public int TicketEventPrice { get; set; }
    }
}
