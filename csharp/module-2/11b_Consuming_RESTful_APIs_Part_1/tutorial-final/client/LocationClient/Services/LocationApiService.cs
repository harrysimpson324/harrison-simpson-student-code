using LocationClient.Models;
using RestSharp;
using System.Collections.Generic;

namespace LocationClient.Services
{
    public class LocationApiService
    {
        private readonly string apiUrl;
        public LocationApiService(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }

        public List<Location> GetAllLocations()
        {
            RestClient client = new RestClient(apiUrl);
            RestRequest request = new RestRequest("locations");
            IRestResponse<List<Location>> response = client.Get<List<Location>>(request);
            return response.Data;
        }

        public Location GetDetailsForLocation(int locationId)
        {
            RestClient client = new RestClient(apiUrl);
            RestRequest requestOne = new RestRequest($"locations/{locationId}");
            IRestResponse<Location> response = client.Get<Location>(requestOne);
            return response.Data;
        }
    }
}