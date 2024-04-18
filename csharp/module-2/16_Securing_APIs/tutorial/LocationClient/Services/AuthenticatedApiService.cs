using LocationClient.Models;
using LocationClient.Utility;
using RestSharp;
using RestSharp.Authenticators;
using System.Net.Http;

namespace LocationClient.Services
{
    public class AuthenticatedApiService
    {
        protected static RestClient client = null;
        protected ApiUser user = new ApiUser();
        public bool LoggedIn { get { return !string.IsNullOrWhiteSpace(user.Token); } }

        public AuthenticatedApiService(string apiUrl)
        {
            if (client == null)
            {
                client = new RestClient(apiUrl);
            }
        }

        public bool Login(string submittedName, string submittedPass)
        {
            LoginUser loginUser = new LoginUser { Username = submittedName, Password = submittedPass };
            RestRequest request = new RestRequest("login");
            request.AddJsonBody(loginUser);
            IRestResponse<ApiUser> response = client.Post<ApiUser>(request);

            CheckForError(response, "Login");
            user.Token = response.Data.Token;
            return true;
        }

        public void Logout()
        {
            user = new ApiUser();
        }

        /// <summary>
        /// Checks RestSharp response for errors. If error, writes a log message and throws an exception 
        /// if the call was not successful. If no error, just returns to caller.
        /// </summary>
        /// <param name="response">Response returned from a RestSharp method call.</param>
        /// <param name="action">Description of the action the application was taking. Written to the log file for context.</param>
        protected void CheckForError(IRestResponse response, string action)
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
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    message = $"Authorization is required and the user has not logged in.";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    message = $"The user does not have permission.";
                }
                else
                {
                    message = $"An http error occurred.";
                }
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