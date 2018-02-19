﻿using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TicketSystem.DatabaseRepository;
using TicketEngineClassLibrary;

namespace TicketSystem.DatabaseRepository
{
    public class TicketDatabase : ITicketDatabase
    {
        static string ConnectionString = DatabaseConnection.ConnectionString;


        //User UserRegFind takes first name and lastname WITHOUT space sepparator.
        public List<CustomerRegistration> CustomerRegisterFind(string query)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<CustomerRegistration>("SELECT * FROM UserReg WHERE (Fname + Lname) = '%" + query + "%'").ToList();
                connection.Close();
                return values;
            }
        }

        //SiteUserFind checks if email is the same as in the SiteUser Table and IsValid =1 since it is the reprecentation of bool.
        public List<Customer> CustomerFind  (string query)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<Customer>("SELECT * FROM SiteUser WHERE Email = '%" + query + "%' AND IsValid = 1 '%").ToList();
                connection.Close();
                return values;
            }
        }
        public Customer CustomerAdd(string email, string password, int isValid)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into SiteUser([Email],[Password],[IsValid]) values(@Email,@Password, @IsValid, @Country)", new { Email = email, Password = password, IsValid = isValid });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('SiteUser') AS Current_Identity").First();
                var values = connection.Query<Customer>("SELECT * FROM SiteUser WHERE ID=@Id", new { Id = addedVenueQuery }).First();
                connection.Close();
                return values;
            }
        }
        public CustomerRegistration CustomerRegisterdAdd (string fname, string lname, string password, string city)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into SiteUser([Fname],[Lname],[Password],[City]) values(@Email,@Password, @IsValid, @Country)", new { Fname = fname, Lname = lname, Password = password, City = city });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('UserReg') AS Current_Identity").First();
                var values = connection.Query<CustomerRegistration>("SELECT * FROM UserReg WHERE ID=@Id", new { Id = addedVenueQuery }).First();
                connection.Close();
                return values;
            }
        }


        public TicketEvent EventAdd(string name, string description)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into TicketEvents(EventName, EventHtmlDescription) values(@Name, @Description)", new { Name = name, Description = description });
                var addedEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                var values = connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = addedEventQuery }).First();
                connection.Close();
                return values;
            }
        }

        public List<TicketEvent> EventFindSpecifik(string query)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE EventName like '%" + query + "%' OR EventHtmlDescription like '%" + query + "%'").ToList();
                return values;
            }
        }

        public List<object> EventDateFindEventsAndVenues(string date1, string date2)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<object>("SELECT TicketEventDates.EventStartDateTime, TicketEvents.EventName, TicketEvents.EventHtmlDescription, Venues.VenueName, Venues.Country, Venues.Address, Venues.City From TicketEventDates JOIN Venues ON Venues.VenueID = TicketEventDates.VenueID JOIN TicketEvents ON TicketEvents.TicketEventID = TicketEventDates.TicketEventID WHERE TicketEventDates.EventStartDateTime BETWEEN '%" + date1 + "%' AND '%" + date2 + "%'").ToList();
                return values;
            }
        }




        public Venue VenueAdd(string name, string address, string city, string country)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = name, Address = address, City = city, Country = country });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                var values = connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
                connection.Close();
                return values;
            }
        }

        public List<Venue> VenuesFind(string query)
        {
            string connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%" + query + "%' OR Address like '%" + query + "%' OR City like '%" + query + "%' OR Country like '%" + query + "%'").ToList();
                connection.Close();
                return values;
            }
        }

        public static List<Venue> VenuesSpecific(string query)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var values = connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%" + query + "%' OR Address like '%" + query + "%' OR City like '%" + query + "%' OR Country like '%" + query + "%'").ToList();
                return values;
            }
        }

        public List<Venue> VenuesAll()
        {
            var connectionString = ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var values = connection.Query<Venue>("SELECT * FROM Venues").ToList();
                return values;
            }
        }


    }
}