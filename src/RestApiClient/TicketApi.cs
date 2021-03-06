﻿using RestSharp;
using System;
using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;
using TicketEngineClassLibrary;


namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        public List<Ticket> TicketGet()
        {
            var client = new RestClient("http://localhost:54874/");
            var request = new RestRequest("ticket", Method.GET);
            var response = client.Execute<List<Ticket>>(request);
            return response.Data;
        }

        public Ticket TicketTicketIdGet(int ticketId)
        {
            var client = new RestClient("http://localhost:54874/");
            var request = new RestRequest("ticket/{id}", Method.GET);
            request.AddUrlSegment("id", ticketId);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", ticketId));
            }

            return response.Data;
        }

        public List<Venue> GetVenue(string query)
        {
            var client = new RestClient("http://localhost:54874/api/");
            var request = new RestRequest("Venues/{query}", Method.GET);
            request.AddUrlSegment("query", query);
            var response = client.Execute<List<Venue>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", query));
            }

            return response.Data;
        }

        public List<TicketEvent> GetEvent(string query)
        {
            var client = new RestClient("http://localhost:54874/api/");
            var request = new RestRequest("Event/{query}", Method.GET);
            request.AddUrlSegment("query", query);
            var response = client.Execute<List<TicketEvent>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", query));
            }

            return response.Data;
        }

        public void VenuesAdd(Venue newVenue)
        {
            var client = new RestClient("http://localhost:54874");
            var request = new RestRequest("api/Venues", Method.POST);
            request.AddJsonBody(newVenue);
            client.Execute(request);
        }

        public void EventsAdd(TicketEvent newEvent)
        {
            //var output = JsonConvert.SerializeObject(newVenue);
            var client = new RestClient("http://localhost:54874");
            var request = new RestRequest("api/Event", Method.POST);
            request.AddJsonBody(newEvent);
            //request.AddParameter("venue", output, ParameterType.RequestBody);
            client.Execute(request);
        }

        public void DateEventAdd(TicketEventDate newEventDate)
        {
            //var output = JsonConvert.SerializeObject(newVenue);
            var client = new RestClient("http://localhost:54874");
            var request = new RestRequest("api/Event", Method.POST);
            request.AddJsonBody(newEventDate);
            //request.AddParameter("venue", output, ParameterType.RequestBody);
            client.Execute(request);
        }

    }
}
