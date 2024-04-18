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
            CheckForError(response);
            // success
            return response.Data;
        }

        public Location GetDetailsForLocation(int locationId)
        {
            RestRequest requestOne = new RestRequest($"locations/{locationId}");
            IRestResponse<Location> response = client.Get<Location>(requestOne);
            CheckForError(response);
            // success
            return response.Data;
        }

        public Location AddLocation(Location newLocation)
        {
            RestRequest request = new RestRequest("locations");
            request.AddJsonBody(newLocation);
            IRestResponse<Location> response = client.Post<Location>(request);
            CheckForError(response);
            // success
            return response.Data;
        }

        public Location UpdateLocation(Location locationToUpdate)
        {
            RestRequest request = new RestRequest($"locations/{locationToUpdate.Id}");
            request.AddJsonBody(locationToUpdate);
            IRestResponse<Location> response = client.Put<Location>(request);
            CheckForError(response);
            // success
            return response.Data;
        }

        public bool DeleteLocation(int locationId)
        {
            RestRequest request = new RestRequest($"locations/{locationId}");
            IRestResponse response = client.Delete(request);
            CheckForError(response);
            // success
            return true;
        }

        private void CheckForError(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                //response not received
                throw new Exception("An error occurred - unable to reach the server.", response.ErrorException);
            }
            else if (!response.IsSuccessful)
            {
                //response indicating an error
                throw new Exception("An error response was received from the server. The status code is " + (int)response.StatusCode);
            }
            return;
        }
    }
}