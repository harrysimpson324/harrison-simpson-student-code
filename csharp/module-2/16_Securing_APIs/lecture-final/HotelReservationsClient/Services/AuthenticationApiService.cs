using HotelReservationsClient.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace HotelReservationsClient.Services
{
    public class AuthenticationApiService : ApiService
    {
        private static ApiUser user = new ApiUser();
        public bool LoggedIn { get { return !string.IsNullOrWhiteSpace(user.Token); } }
        public AuthenticationApiService(string apiUrl) : base(apiUrl) { }

        public bool Login(string submittedName, string submittedPass)
        {
            LoginUser loginUser = new LoginUser { Username = submittedName, Password = submittedPass };
            RestRequest request = new RestRequest("login");
            request.AddJsonBody(loginUser);
            IRestResponse<ApiUser> response = client.Post<ApiUser>(request);

            CheckForError(response, "Login");
            user.Token = response.Data.Token;
            client.Authenticator = new JwtAuthenticator(user.Token);
            return true;
        }

        public void Logout()
        {
            user = new ApiUser();
            client.Authenticator = null;
        }
    }
}
