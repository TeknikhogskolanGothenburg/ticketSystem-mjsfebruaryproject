﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

using TicketEngineClassLibrary;

namespace TicketSystem.RestApiClient
{
  public   class VenueApi
    {

        
        public List<Venue> VenueGet()
        {
            var client = new RestClient("http://localhost:54874/");
            var request = new RestRequest("Venue", Method.GET);
            var response = client.Execute<List<Venue>>(request);
            return response.Data;
        }

        public Venue VenueGetByID(int VenueId)
        {
            var client = new RestClient("http://localhost:54874/");
            var request = new RestRequest("Venue/{id}", Method.GET);
            request.AddUrlSegment("id", VenueId);
            var response = client.Execute<Venue>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Venue with ID: {0} is not found", VenueId));
            }

            return response.Data;
        }

        public void AddNewVenue()
        {
            var client = new RestClient("http://localhost:54874/");
            var request = new RestRequest("Venue", Method.POST);
            var response = client.Execute(request);
        }

        public void UpdateVenue()
        {
            var client = new RestClient("http://localhost:54874/");
            var request = new RestRequest("Venue", Method.PUT);
            var response = client.Execute(request);
        }

        public void DeleteVenueAtId()
        {
            var client = new RestClient("http://localhost:54874/");
            var request = new RestRequest("Venue", Method.DELETE);
            var response = client.Execute(request);
        }
    }
}
