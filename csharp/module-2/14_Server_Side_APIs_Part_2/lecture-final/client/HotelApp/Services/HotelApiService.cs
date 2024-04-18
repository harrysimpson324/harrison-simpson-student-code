using HotelReservationsClient.Models;
using HotelReservationsClient.Utility;
using RestSharp;
using System.Collections.Generic;
using System.Net.Http;

namespace HotelReservationsClient.Services
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

        /// <summary>
        /// Checks RestSharp response for errors. If error, writes a log message and throws an exception 
        /// if the call was not successful. If no error, just returns to caller.
        /// </summary>
        /// <param name="response">Response returned from a RestSharp method call.</param>
        /// <param name="action">Description of the action the application was taking. Written to the log file for context.</param>
        private void CheckForError(IRestResponse response, string action)
        {
            string message = "";
            string messageDetails = "";
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                message = $"Error occurred in '{action}' - unable to reach server.";
                messageDetails = $"Action: {action}\n" +
                    $"\tResponse status was '{response.ResponseStatus}'.";
                if (response.ErrorException != null)
                {
                    messageDetails += $"\n\t{response.ErrorException.Message}";
                }
            }
            else if (!response.IsSuccessful)
            {
                message = $"An http error occurred.";
                messageDetails = $"Action: {action}\n" +
                    $"\tResponse: {(int)response.StatusCode} {response.StatusDescription}";
            }
            if (message.Length > 0)
            {
                BasicLogger.Log($"{message}\n\t{messageDetails}\n");
                throw new HttpRequestException(message, response.ErrorException);
            }
        }
    }
}
