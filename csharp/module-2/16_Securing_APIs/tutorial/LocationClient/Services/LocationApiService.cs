using LocationClient.Models;
using RestSharp;
using System.Collections.Generic;

namespace LocationClient.Services
{
    public class LocationApiService : AuthenticatedApiService
    {
        public LocationApiService(string apiUrl) : base(apiUrl) { }

        public List<Location> GetAllLocations()
        {
            RestRequest request = new RestRequest("locations");
            IRestResponse<List<Location>> response = client.Get<List<Location>>(request);

            CheckForError(response, "Get all locations");
            // success
            return response.Data;
        }

        public Location GetDetailsForLocation(int locationId)
        {
            RestRequest requestOne = new RestRequest($"locations/{locationId}");
            IRestResponse<Location> response = client.Get<Location>(requestOne);

            CheckForError(response, $"Get details for location {locationId}");
            // success
            return response.Data;
        }

        public Location AddLocation(Location newLocation)
        {
            RestRequest request = new RestRequest("locations");
            request.AddJsonBody(newLocation);
            IRestResponse<Location> response = client.Post<Location>(request);

            CheckForError(response, "Add location");
            // success
            return response.Data;
        }

        public Location UpdateLocation(Location locationToUpdate)
        {
            RestRequest request = new RestRequest($"locations/{locationToUpdate.Id}");
            request.AddJsonBody(locationToUpdate);
            IRestResponse<Location> response = client.Put<Location>(request);

            CheckForError(response, $"Update location {locationToUpdate.Id}");
            // success
            return response.Data;
        }

        public bool DeleteLocation(int locationId)
        {
            RestRequest request = new RestRequest($"locations/{locationId}");
            IRestResponse response = client.Delete(request);

            CheckForError(response, $"Delete location {locationId}");
            // success
            return true;
        }
    }
}