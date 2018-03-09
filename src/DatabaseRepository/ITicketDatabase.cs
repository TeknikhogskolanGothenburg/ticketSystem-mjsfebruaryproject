﻿using System.Collections.Generic;
using TicketEngineClassLibrary;

namespace TicketSystem.DatabaseRepository
{
    public interface ITicketDatabase
    {
        /// <summary>
        /// Add a new Event to the database
        /// </summary>
        /// <param name="name">Name of the event</param>
        /// <param name="description">A desription of the event, html markup of the event is allowed</param>
        /// <returns>An object representing the newly created TicketEvent</returns>
        TicketEvent EventAdd(string name, string description, int ticketeventprice);

        /// <summary>
        /// Add a new venue to the database
        /// </summary>
        /// <param name="name">Name of the venue</param>
        /// <param name="address">Physical address of the venue</param>
        /// <param name="city">City part of the adress</param>
        /// <param name="country">Country part of the adress</param>
        /// <returns>An object representing the newly created Venue</returns>
        //Venue VenueAdd(string name, string address, string city, string country);


        /// <summary>
        /// Find all venues matching the query
        /// </summary>
        /// <param name="query">A text which is user i looking for in the venues</param>
        /// <returns>A list of venues matching the query</returns>
        IEnumerable<Venue> VenuesFind(string query);
    }
}
