using LocationClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace LocationClient.Services
{
    public class LocationApiService
    {
        private RestClient client = null;
        public LocationApiService(string apiUrl)
        {
            client = new RestClient(apiUrl);
        }

        public List<Location> GetAllLocations()
        {
            RestRequest request = new RestRequest("locations");
            IRestResponse<List<Location>> response = client.Get<List<Location>>(request);
            return response.Data;
        }

        public Location GetDetailsForLocation(int locationId)
        {
            RestRequest requestOne = new RestRequest($"locations/{locationId}");
            IRestResponse<Location> response = client.Get<Location>(requestOne);
            return response.Data;
        }

        public Location AddLocation(Location newLocation)
        {
            throw new NotImplementedException("The api method has not yet been implemented.");
        }

        public Location UpdateLocation(Location locationToUpdate)
        {
            throw new NotImplementedException("The api method has not yet been implemented.");
        }

        public bool DeleteLocation(int locationId)
        {
            throw new NotImplementedException("The api method has not yet been implemented.");
        }
    }
}