using RestSharp;
using RestSharp.Authenticators;
using AuctionApp.Models;
using System.Net.Http;

namespace AuctionApp.Services
{
    public class AuthenticatedApiService
    {
        public static IRestClient client = null;
        private static ApiUser user = new ApiUser();
        public bool IsLoggedIn { get { return !string.IsNullOrWhiteSpace(user.Token); } }

        public AuthenticatedApiService(string apiUrl)
        {
            if (client == null)
            {
                client = new RestClient(apiUrl);
            }
        }

        public ApiUser Login(string submittedName, string submittedPass)
        {
            // Create the "POST login" request
            IRestResponse<ApiUser> response = null;

            CheckForError(response);
            user.Token = response.Data.Token;

            // Set the authenticator on the client 

            return response.Data;
        }

        public void Logout()
        {
            user = new ApiUser();
            client.Authenticator = null;
        }

        public AuthenticatedApiService(IRestClient restClient)
        {
            client = restClient;
        }

        /// <summary>
        /// Checks RestSharp response for errors. If error, writes a log message and throws an exception 
        /// if the call was not successful. If no error, just returns to caller.
        /// </summary>
        /// <param name="response">Response returned from a RestSharp method call.</param>
        /// <param name="action">Description of the action the application was taking. Written to the log file for context.</param>
        protected void CheckForError(IRestResponse response)
        {
            string message;
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                message = $"Error occurred - unable to reach server. Response status was '{response.ResponseStatus}'.";
                throw new HttpRequestException(message, response.ErrorException);
            }
            else if (!response.IsSuccessful)
            {
                // Set an appropriate error message
                message = $"An http error occurred. Status code {(int)response.StatusCode} {response.StatusDescription}";


                // Throw an HttpRequestException with the appropriate message
            }
        }
    }
}
