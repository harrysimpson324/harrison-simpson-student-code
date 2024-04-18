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

    }
}