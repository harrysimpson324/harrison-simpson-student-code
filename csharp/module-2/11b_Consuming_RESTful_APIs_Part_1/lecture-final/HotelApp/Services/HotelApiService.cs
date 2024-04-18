using HotelApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HotelApp.Services
{
    public class HotelApiService
    {
        protected static RestClient client = null;

        public HotelApiService(string apiUrl)
        {
            if (client == null)
            {
                client = new RestClient(apiUrl);
            }
        }

        public List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest("hotels");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

            if (!response.IsSuccessful)
            {
                throw new HttpRequestException($"There was an error in the call to the server");
            }
            return response.Data;
        }

        public List<Review> GetReviews()
        {
            RestRequest request = new RestRequest("reviews");
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);

            if (!response.IsSuccessful)
            {
                throw new HttpRequestException($"There was an error in the call to the server");
            }
            return response.Data;
        }

        public Hotel GetHotel(int hotelId)
        {
            RestRequest request = new RestRequest($"hotels/{hotelId}");
            IRestResponse<Hotel> response = client.Get<Hotel>(request);
            CheckForError(response);
            return response.Data;
        }

        public List<Review> GetHotelReviews(int hotelId)
        {
            RestRequest request = new RestRequest($"hotels/{hotelId}/reviews");
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            CheckForError(response);
            return response.Data;
        }

        public List<Hotel> GetHotelsWithRating(int starRating)
        {
            RestRequest request = new RestRequest($"hotels?stars={starRating}");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            CheckForError(response);
            return response.Data;
        }

        public City GetPublicAPIQuery()
        {
            RestRequest request = new RestRequest("https://api.teleport.org/api/cities/geonameid:5128581/");
            IRestResponse<City> response = client.Get<City>(request);
            CheckForError(response);
            return response.Data;
        }

        private void CheckForError(IRestResponse response)
        {
            if (!response.IsSuccessful)
            {
                // TODO: Write a log message for future reference

                throw new HttpRequestException($"There was an error in the call to the server");
            }
        }
    }
}
