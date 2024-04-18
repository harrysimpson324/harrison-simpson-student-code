using HotelReservationsClient.Models;
using RestSharp;
using System.Collections.Generic;

namespace HotelReservationsClient.Services
{
    public class HotelApiService : ApiService
    {
        public HotelApiService(string apiUrl) : base(apiUrl) { }

        public List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest("hotels");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

            CheckForError(response, "Get hotels");
            return response.Data;
        }

        public List<Reservation> GetReservations(int hotelId = 0)
        {
            string url;
            if (hotelId != 0)
            {
                url = $"hotels/{hotelId}/reservations";
            }
            else
            { 
                url = "reservations";
            }

            RestRequest request = new RestRequest(url);
            IRestResponse<List<Reservation>> response = client.Get<List<Reservation>>(request);

            CheckForError(response, $"Get reservations for hotel {hotelId}");
            return response.Data;
        }

        public Reservation GetReservation(int reservationId)
        {
            RestRequest request = new RestRequest($"reservations/{reservationId}");
            IRestResponse<Reservation> response = client.Get<Reservation>(request);

            CheckForError(response, $"Get reservation {reservationId}");
            return response.Data;
        }

        public Reservation AddReservation(Reservation newReservation)
        {
            RestRequest request = new RestRequest("reservations");
            request.AddJsonBody(newReservation);
            IRestResponse<Reservation> response = client.Post<Reservation>(request);

            CheckForError(response, "Add reservation");
            return response.Data;
        }

        public Reservation UpdateReservation(Reservation reservationToUpdate)
        {
            RestRequest request = new RestRequest($"reservations/{reservationToUpdate.Id}");
            request.AddJsonBody(reservationToUpdate);
            IRestResponse<Reservation> response = client.Put<Reservation>(request);

            CheckForError(response, $"Update reservation {reservationToUpdate.Id}");
            return response.Data;
        }

        public bool DeleteReservation(int reservationId)
        {
            RestRequest request = new RestRequest($"reservations/{reservationId}");
            IRestResponse response = client.Delete(request);

            CheckForError(response, $"Delete reservation {reservationId}");
            return true;
        }
    }
}
