using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TicketSystem.DatabaseRepository;
using TicketEngineClassLibrary;
using System;

namespace TicketSystem.DatabaseRepository
{
    public class TicketDatabase : ITicketDatabase
    {
        private readonly DateTime SQL_MIN_DATETIME = DateTime.Parse("1753-01-01 12:00:00");
        private readonly DateTime SQL_MAX_DATETIME = DateTime.Parse("9999-12-31 11:59:59");
        private const string CONNECTION_STRING = "Server=(local)\\SqlExpress; Database=TicketSystem; Trusted_connection=true";

         
        public Venue VenueAdd(string name, string address, string city, string country)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var result = connection.ExecuteScalar<int>("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country); SELECT SCOPE_IDENTITY();", new { Name = name, Address = address, City = city, Country = country });
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = result }).First();
            }
        }

       
        public IEnumerable<Venue> VenuesFind(string query)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                int id = -1;
                int.TryParse(query, out id);
                return connection.Query<Venue>("SELECT * FROM [Venues] WHERE VenueID LIKE @ID OR VenueName LIKE @Query OR Address LIKE @Query OR City LIKE @Query OR Country LIKE @Query", new { ID = id, Query = $"%{query}%" });
                //return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%" + query + "%' OR Address like '%" + query + "%' OR City like '%" + query + "%' OR Country like '%" + query + "%'").ToList();
            }
        }

       
        public List<Venue> AllVenues()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<Venue>("SELECT * FROM Venues").ToList();
            }
        }

        
        public void UpdateVenue(int id, string name, string address, string city, string country)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                if (name != null)
                {
                    connection.Query("UPDATE Venues SET [VenueName] = @VenueName WHERE [VenueID] = @VenueID; ", new { VenueName = name, VenueID = id });
                }
                if (address != null)
                {
                    connection.Query("UPDATE Venues SET [Address] = @Address WHERE [VenueID] = @VenueID; ", new { Address = address, VenueID = id });
                }
                if (city != null)
                {
                    connection.Query("UPDATE Venues SET [City] = @City WHERE [VenueID] = @VenueID; ", new { City = city, VenueID = id });
                }
                if (country != null)
                {
                    connection.Query("UPDATE Venues SET [Country] = @Country WHERE [VenueID] = @VenueID; ", new { Country = country, VenueID = id });
                }
            }
        }
 
        public void DeleteVenue(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                connection.Query<Venue>("DELETE FROM [Venues] WHERE VenueID = @ID", new { ID = id }).FirstOrDefault();
            }
        }

        
        public Venue FindVenueByID(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<Venue>("SELECT * FROM [Venues] WHERE VenueID = @ID", new { ID = id }).FirstOrDefault();
            }
        }

       
        public TicketEvent EventAdd(string eventName, string htmlDescription, int ticketEventprice)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var result = connection.Query<int>("insert into TicketEvents([EventName],[EventHtmlDescription],[TicketEventPrice]) values(@EventName, @EventHtmlDescription, @TicketEventPrice); SELECT SCOPE_IDENTITY();", new { EventName = eventName, EventHtmlDescription = htmlDescription, TicketEventPrice = ticketEventprice });
                var createdEventQuery = result.First();
                //var createdEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = createdEventQuery }).First();
            }
        }
 
        public void UpdateEvent(int id, string eventName, string htmlDescription, int ticketeventPrice)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                if (eventName != null)
                {
                    //connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = name, Address = address, City = city, Country = country })
                    connection.Query("UPDATE TicketEvents SET [EventName] = @EventName WHERE [TicketEventID] = @TicketEventID; ", new { EventName = eventName, TicketEventID = id });
                }
                if (htmlDescription != null)
                {
                    connection.Query("UPDATE TicketEvents SET [EventHtmlDescription] = @EventHtmlDescription WHERE [TicketEventID] = @TicketEventID; ", new { EventHtmlDescription = htmlDescription, TicketEventID = id });
                }
                if (ticketeventPrice != 0 && ticketeventPrice >= 150)
                {
                    connection.Query("UPDATE TicketEvents SET [TicketEventPrice] = @TicketEventPrice WHERE [TicketEventID] = @TicketEventID; ", new { TicketEventPrice = ticketeventPrice, TicketEventID = id });
                }
            }
        }

 
        public void DeleteEvent(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                connection.Query<TicketEvent>("DELETE FROM [TicketEvents] WHERE TicketEventID = @ID", new { ID = id }).FirstOrDefault();
            }
        }

        
        public List<TicketEvent> FindAllEvents()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents").ToList();
            }
        }

       
        public IEnumerable<TicketEvent> FindEvents(string query)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                int id = -1;
                int.TryParse(query, out id);
                return connection.Query<TicketEvent>("SELECT * FROM [TicketEvents] WHERE TicketEventID = @ID OR EventName like @Query", new { ID = id, Query = $"%{query}%" });
            }
        }

        public int GetTicketEventID(string query)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Execute("SELECT TicketEvents.TicketEventID From TicketEvents WHERE EventName like @Query ", new { Query = $"%{query}" });
            }
        }

       
        public TicketEvent FindEventByID(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<TicketEvent>("SELECT * FROM [TicketEvents] WHERE TicketEventID = @ID", new { ID = id }).FirstOrDefault();
            }
        }

       
        public IEnumerable<Order> FindCustomerOrders(string query)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                int id = -1;
                int.TryParse(query, out id);
                return FindOrdersSuchThat("TicketTransactions.BuyerFirstName LIKE @Query OR TicketTransactions.BuyerLastName Like @Query OR TicketTransactions.BuyerEmailAddress LIKE @Query", new { ID = id, Query = $"%{query}%" });
            }
        }

             

        public List<Order> FindAllCustomerOrder()
        {
            return FindOrdersSuchThat("1 = 1", new { }).ToList();
        }


       
        private IEnumerable<Order> FindOrdersSuchThat(string wherePart, object parameters)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var temp = connection.Query<Order>("SELECT *  FROM TicketTransactions WHERE " + wherePart, parameters);
                foreach (Order order in temp)
                {
                    bool first = true;
                    string ids = "";
                    foreach (int id in FindTicketsByTransactionID(order.TransactionID))
                    {
                        if (!first)
                        {
                            ids += ",";
                        }
                        ids += id.ToString();
                        first = false;
                    }
                    order.TicketIDs = ids;
                }
                return temp;
            }
        }

        
        public Order FindCustomerOrderByID(int id)
        {
            return FindOrdersSuchThat("TicketTransactions.TransactionID = @ID", new { ID = id }).FirstOrDefault();
        }

        
        public void UpdateCustomerOrder(int transactionID, string buyerLastName,
            string buyerFirstName, string buyerAddress, string buyerCity)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                if (buyerLastName != null)
                {
                    connection.Query("UPDATE TicketTransactions SET [BuyerLastName] = @BuyerLastName WHERE [TransactionID] = @TransactionID; ", new { BuyerLastName = buyerLastName, TransactionID = transactionID });
                }
                if (buyerAddress != null)
                {
                    connection.Query("UPDATE TicketTransactions SET[BuyerAddress] = @BuyerAddress WHERE[TransactionID] = @TransactionID; ", new { BuyerAddress = buyerAddress, TransactionID = transactionID });
                }
                if (buyerFirstName != null)
                {
                    connection.Query("UPDATE TicketTransactions SET [BuyerFirstName] = @BuyerFirstName WHERE [TransactionID] = @TransactionID; ", new { BuyerFirstName = buyerFirstName, TransactionID = transactionID });
                }
                if (buyerCity != null)
                {
                    connection.Query("UPDATE TicketTransactions SET [BuyerCity] = @BuyerCity WHERE [TransactionID] = @TransactionID; ", new { BuyerCity = buyerCity, TransactionID = transactionID });
                }
            }
        }

       
        public void DeleteCustomerOrder(int transactionID)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var tickets = connection.Query<int>("SELECT TicketsToTransactions.TicketID FROM TicketsToTransactions WHERE TicketsToTransactions.TransactionID = @ID", new { ID = transactionID });
                connection.Execute("DELETE FROM TicketsToTransactions WHERE TicketsToTransactions.TransactionID = @ID", new { ID = transactionID });
                connection.Execute("DELETE FROM TicketTransactions WHERE TransactionID = @ID ", new { ID = transactionID });
                foreach (var ticket in tickets)
                {
                    connection.Execute("DELETE FROM Tickets WHERE TicketID = @TicketID", new { TicketID = ticket });
                }
            }
        }
 
       

       
        public TicketEventDate AddTicketEventDate(int ticketEventID, int venueID, DateTime eventDateTime, int numberOfSeats)
        {

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                if (!DateTimeIsValid(eventDateTime))
                {
                    throw new ArgumentException("Datetime out of range.");
                }
                var createdEventID = connection.ExecuteScalar<int>("INSERT INTO TicketEventDates([TicketEventID],[VenueID],[EventStartDateTime]) VALUES(@TicketEventID, @VenueID, @EventStartDateTime); SELECT SCOPE_IDENTITY();", new { TicketEventID = ticketEventID, VenueID = venueID, EventStartDateTime = eventDateTime });

                var seatQuery = "INSERT INTO SeatsAtEventDate([TicketEventDateID]) VALUES(@ID)";
                var parameters = new { ID = createdEventID };
                for (int i = 0; i < numberOfSeats; i++)
                {
                    connection.Query(seatQuery, parameters);
                }
                return connection.Query<TicketEventDate>("SELECT * FROM TicketEventDates WHERE TicketEventDateID=@Id", parameters).First();
            }
        }

       
        public void UpdateTicketEventDate(int ticketEventDateID, int ticketEventID, int venueID, DateTime eventDateTime)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                if (ticketEventID != 0)
                {
                    connection.Query("UPDATE TicketEventDates SET [TicketEventID] = @TicketEventID WHERE [TicketEventDateID] = @TicketEventDateID; ", new { TicketEventID = ticketEventID, TicketEventDateID = ticketEventDateID });
                }
                if (venueID != 0)
                {
                    connection.Query("UPDATE TicketEventDates SET [VenueID] = @VenueID WHERE [TicketEventDateID] = @TicketEventDateID; ", new { VenueID = venueID, TicketEventDateID = ticketEventDateID });
                }
                if (DateTimeIsValid(eventDateTime))
                {
                    connection.Query("UPDATE TicketEventDates SET [EventStartDateTime] = @EventStartDateTime WHERE [TicketEventDateID] = @TicketEventDateID; ", new { EventStartDateTime = eventDateTime, TicketEventDateID = ticketEventDateID });
                }
            }
        }

        
        private bool DateTimeIsValid(DateTime t)
        {
            return t != null && t >= SQL_MIN_DATETIME && t <= SQL_MAX_DATETIME;
        }

 
        public Ticket FindTicketByTicketID(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<Ticket>("SELECT Tickets.*, Venues.VenueName AS VenueName, TicketEventDates.EventStartDateTime AS EventStartDateTime, " +
                    "TicketEvents.TicketEventPrice AS TicketEventPrice, TicketEvents.EventName AS EventName " +
                    "FROM Tickets " +
                    "INNER JOIN SeatsAtEventDate ON SeatsAtEventDate.SeatID = Tickets.SeatID " +
                    "INNER JOIN TicketEventDates ON TicketEventDates.TicketEventDateID = SeatsAtEventDate.TicketEventDateID " +
                    "INNER JOIN TicketEvents ON TicketEvents.TicketEventID = TicketEventDates.TicketEventID " +
                    "INNER JOIN Venues on Venues.VenueID = TicketEventDates.VenueID " +
                    "WHERE Tickets.TicketID = @ID", new { ID = id }).FirstOrDefault();
            }
        }

        
        public Ticket CreateTicket(int ticketEventDateID)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var availableSeat = FindOneAvailableSeatAtTicketEventDate(ticketEventDateID);

                var ticketID = connection.ExecuteScalar<int>("INSERT INTO Tickets (Tickets.SeatID) VALUES (@AvSeat); SELECT SCOPE_IDENTITY() ", new { AvSeat = availableSeat });
                return FindTicketByTicketID(ticketID);
            }
        }

        private bool AreThereAnyFreeSeatsAtEventDate(int ticketEventDateID)
        {
            IEnumerable<int> seats = GetAvailableSeatsAtTicketEventDate(ticketEventDateID);
            if (seats.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<Ticket>("SELECT Tickets.*, Venues.VenueName AS VenueName, TicketEventDates.EventStartDateTime AS EventStartDateTime, " +
                    "TicketEvents.TicketEventPrice AS TicketEventPrice, TicketEvents.EventName AS EventName " +
                    "FROM Tickets " +
                    "INNER JOIN SeatsAtEventDate ON SeatsAtEventDate.SeatID = Tickets.SeatID " +
                    "INNER JOIN TicketEventDates ON TicketEventDates.TicketEventDateID = SeatsAtEventDate.TicketEventDateID " +
                    "INNER JOIN TicketEvents ON TicketEvents.TicketEventID = TicketEventDates.TicketEventID " +
                    "INNER JOIN Venues on Venues.VenueID = TicketEventDates.VenueID ");
            }
        }
      
        private IEnumerable<int> FindTicketsByTransactionID(int transactionID)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<int>($"SELECT TicketsToTransactions.TicketID From TicketsToTransactions WHERE TicketsToTransactions.TransactionID = {transactionID}");
            }
        }

        
        public IEnumerable<int> GetSeatsAtTicketEventDate(int ticketEventDateID)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<int>("SELECT SeatsAtEventDate.SeatID From SeatsAtEventDate INNER JOIN TicketEventDates ON TicketEventDates.TicketEventDateID = " +
                    "SeatsAtEventDate.TicketEventDateID " +
                    "WHERE(TicketEventDates.TicketEventDateID) = @TicketEventDID; ", new { TicketEventDID = ticketEventDateID });
            }
        }

        
        public int GetNumberOfSeatsAtTicketEventDate(int ticketEventDateID)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<int>("SELECT COUNT(SeatsAtEventDate.SeatID) AS NumberOfSeats From SeatsAtEventDate " +
                    "INNER JOIN TicketEventDates ON TicketEventDates.TicketEventDateID = " +
                    "SeatsAtEventDate.TicketEventDateID " +
                    "WHERE(TicketEventDates.TicketEventDateID) = @TicketEventDID; ", new { TicketEventDID = ticketEventDateID }).FirstOrDefault();
            }
        }

       
        public IEnumerable<int> GetAvailableSeatsAtTicketEventDate(int ticketEventDateID)
        {
            // TODO: skriv klart detta
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<int>("SELECT SeatsatEventDate.SeatID  From SeatsAtEventDate " +
                    "INNER JOIN TicketEventDates ON TicketEventDates.TicketEventDateID = SeatsAtEventDate.TicketEventDateID " +
                    "WHERE(TicketEventDates.TicketEventDateID) = @TicketEventDID " +
                    "AND SeatsAtEventDate.SeatID NOT IN(SELECT Tickets.SeatID From Tickets); ", new { TicketEventDID = ticketEventDateID });
            }
        }

        
        private int FindOneAvailableSeatAtTicketEventDate(int ticketEventDateID)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<int>("SELECT TOP 1 SeatsatEventDate.SeatID  From SeatsAtEventDate " +
                    "INNER JOIN TicketEventDates ON TicketEventDates.TicketEventDateID = SeatsAtEventDate.TicketEventDateID " +
                    "WHERE(TicketEventDates.TicketEventDateID) = @TicketEventDID " +
                    "AND SeatsAtEventDate.SeatID NOT IN(SELECT Tickets.SeatID From Tickets); ", new { TicketEventDID = ticketEventDateID }).FirstOrDefault();
            }
        }
       
        public int GetNROfAvailableSeatsAtTicketEventDate(int ticketEventDateID)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<int>("SELECT COUNT(SeatsatEventDate.SeatID) AS NumberOfAvailableSeats From SeatsAtEventDate " +
                    "INNER JOIN TicketEventDates ON TicketEventDates.TicketEventDateID = SeatsAtEventDate.TicketEventDateID " +
                    "WHERE(TicketEventDates.TicketEventDateID) = @TicketEventDID " +
                    "AND SeatsAtEventDate.SeatID NOT IN(SELECT Tickets.SeatID From Tickets); ", new { TicketEventDID = ticketEventDateID }).FirstOrDefault();
            }
        }

        
         
        public void UpdateTicket(int ticketID, int seatID)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var seatExists = connection.Query("SELECT SeatsAtEventDate.SeatID FROM SeatsAtEventDate WHERE SeatsAtEventDate.SeatID = @SeatID", new { SeatID = seatID });

                connection.Query("UPDATE TicketEvents SET [SeatID] = @SeatID WHERE [TicketID] = @TicketID; ", new { SeatID = seatID, TicketID = ticketID });
            }
        }

        
        /// <param name="ticketID"></param>
        public void DeleteTicket(int ticketID)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                connection.Query("DELETE FROM [Tickets] WHERE TicketID = @ID", new { ID = ticketID });
            }
        }

       
        public TicketEventDate FindTicketEventDateByID(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<TicketEventDate>("SELECT TicketEventDates.*, Venues.VenueName, TicketEvents.EventName, innerTable.seats AS NumberOfSeats " +
                    "FROM TicketEventDates " +
                    "INNER JOIN " +
                        "(SELECT SeatsAtEventDate.TicketEventDateID AS id, COUNT(*) AS seats FROM SeatsAtEventDate GROUP BY SeatsAtEventDate.TicketEventDateID) innerTable " +
                    "ON TicketEventDates.TicketEventDateID = innerTable.id " +
                    "INNER JOIN [Venues] ON TicketEventDates.VenueID = Venues.VenueID " +
                    "INNER JOIN [TicketEvents] ON TicketEventDates.TicketEventID = TicketEvents.TicketEventID " +
                    "WHERE TicketEventDates.TicketEventDateID = @ID", new { ID = id }).FirstOrDefault();
            }
        }

       
        public IEnumerable<TicketEventDate> FindTicketEventDates(string query)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                int id = -1;
                int.TryParse(query, out id);
                return connection.Query<TicketEventDate>(
                    "SELECT TicketEventDates.*, Venues.VenueName, TicketEvents.EventName, innerTable.seats AS NumberOfSeats " +
                    "FROM TicketEventDates " +
                    "INNER JOIN " +
                        "(SELECT SeatsAtEventDate.TicketEventDateID AS id, COUNT(*) AS seats FROM SeatsAtEventDate GROUP BY SeatsAtEventDate.TicketEventDateID) innerTable " +
                    "ON TicketEventDates.TicketEventDateID = innerTable.id " +
                    "INNER JOIN [Venues] ON TicketEventDates.VenueID = Venues.VenueID " +
                    "INNER JOIN [TicketEvents] ON TicketEventDates.TicketEventID = TicketEvents.TicketEventID " +
                    "WHERE TicketEventDates.TicketEventDateID = @ID OR TicketEvents.TicketEventID = @ID OR Venues.VenueID = @ID OR Venues.VenueName LIKE @Query OR TicketEvents.EventName LIKE @Query;",
                    new { ID = id, Query = $"%{query}%" }
                );
            }
        }

        
        public List<TicketEventDate> GetAllTicketEventDates()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<TicketEventDate>("SELECT TicketEventDates.*,innerTable.seats AS NumberOfSeats FROM TicketEventDates " +
                  "INNER JOIN (SELECT SeatsAtEventDate.TicketEventDateID AS id, COUNT(*) AS seats FROM SeatsAtEventDate GROUP BY " +
                    "SeatsAtEventDate.TicketEventDateID) innerTable ON TicketEventDates.TicketEventDateID = innerTable.id ").ToList();
                //return connection.Query<TicketEventDate>("SELECT * FROM TicketEventDates").ToList();

            }
        }

        
        public void DeleteTicketEventDate(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                connection.Query("DELETE FROM SeatsAtEventDate WHERE TicketEventDateID = @ID", new { ID = id }).FirstOrDefault();
                connection.Query<TicketEventDate>("DELETE FROM [TicketEventDates] WHERE TicketEventDateID = @ID", new { ID = id }).FirstOrDefault();
            }
        }
    }
}