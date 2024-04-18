using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuctionApp.Models;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AuctionApp.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Net.Http.Headers;

namespace AuctionApp.Tests
{
    [TestClass]
    public class AuctionsControllerTests
    {
        protected HttpClient client;

        [TestInitialize]
        public void Setup()
        {
            var builder = new WebHostBuilder()
                .UseStartup<AuctionApp.Startup>()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build());
            var server = new TestServer(builder);
            client = server.CreateClient();
        }

        [TestMethod]
        public async Task Step4_AllMethods_ExpectUnauthorized()
        {
            Auction input = new Auction() { Title = "Dragon Plush", Description = "Not a real dragon", User = "Bernice", CurrentBid = 19.50 };

            var responseGetAuction1 = await client.GetAsync("auctions/1");
            var responsePostAuction = await client.PostAsJsonAsync("auctions", input);
            var responsePutAuction = await client.PutAsJsonAsync("auctions/1", input);
            var responseDeleteAuction = await client.DeleteAsync("auctions/1");

            Assert.IsTrue(responseGetAuction1.StatusCode == System.Net.HttpStatusCode.Unauthorized, "Get Auction should not allow unauthenticated access.");
            Assert.IsTrue(responsePostAuction.StatusCode == System.Net.HttpStatusCode.Unauthorized, "Add Auction should not allow unauthenticated access.");
            Assert.IsTrue(responsePutAuction.StatusCode == System.Net.HttpStatusCode.Unauthorized, "Update Auction should not allow unauthenticated access.");
            Assert.IsTrue(responseDeleteAuction.StatusCode == System.Net.HttpStatusCode.Unauthorized, "Delete Auction should not allow unauthenticated access.");

            var attrs = Attribute.GetCustomAttributes(typeof(AuctionsController)).ToList();
            Assert.IsTrue(attrs.Any(a => a is AuthorizeAttribute), "Authorize attribute missing from controller class.");
        }

        [TestMethod]
        public async Task Step4_GetAuctions_ExpectOk()
        {
            var responseGetAuctions = await client.GetAsync("auctions");
            var responseGetAuction1 = await client.GetAsync("auctions/1");

            Assert.IsTrue(responseGetAuctions.StatusCode == System.Net.HttpStatusCode.OK, "List Auctions should allow unauthenticated access.");
            Assert.IsTrue(responseGetAuction1.StatusCode == System.Net.HttpStatusCode.Unauthorized, "Get Auction should not allow unauthenticated access.");
        }

        [TestMethod]
        public async Task Step5_CreateMethod()
        {
            string json = "{\"Title\": \"Dragon Plush\", \"Description\": \"Not a real dragon\", \"User\": \"Bernice\", \"CurrentBid\": 19.50}";
            var inputContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            string viewerToken = await GetViewerLogin();
            string creatorToken = await GetCreatorLogin();
            string adminToken = await GetAdminLogin();

            var requestViewer = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions"), Method = HttpMethod.Post, Content = inputContent };
            requestViewer.Headers.Authorization = new AuthenticationHeaderValue("Bearer", viewerToken);
            var responseViewer = await client.SendAsync(requestViewer);

            var requestCreator = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions"), Method = HttpMethod.Post, Content = inputContent };
            requestCreator.Headers.Authorization = new AuthenticationHeaderValue("Bearer", creatorToken);
            var responseCreator = await client.SendAsync(requestCreator);

            var requestAdmin = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions"), Method = HttpMethod.Post, Content = inputContent };
            requestAdmin.Headers.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var responseAdmin = await client.SendAsync(requestAdmin);

            Assert.IsTrue(responseViewer.StatusCode == System.Net.HttpStatusCode.Forbidden, "Create Auction should not allow Viewer access.");
            Assert.IsTrue(responseCreator.IsSuccessStatusCode, "Create Auction should allow Creator access.");
            Assert.IsTrue(responseAdmin.IsSuccessStatusCode, "Create Auction should allow Admin access.");
        }

        [TestMethod]
        public async Task Step5_UpdateMethod()
        {
            string json = "{\"Id\": 2, \"Title\": \"Dragon Plush\", \"Description\": \"Not a real dragon\", \"User\": \"Bernice\", \"CurrentBid\": 19.50}";
            var inputContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            string viewerToken = await GetViewerLogin();
            string creatorToken = await GetCreatorLogin();
            string adminToken = await GetAdminLogin();

            var requestViewer = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions/2"), Method = HttpMethod.Put, Content = inputContent };
            requestViewer.Headers.Authorization = new AuthenticationHeaderValue("Bearer", viewerToken);
            var responseViewer = await client.SendAsync(requestViewer);

            var requestCreator = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions/3"), Method = HttpMethod.Put, Content = inputContent };
            requestCreator.Headers.Authorization = new AuthenticationHeaderValue("Bearer", creatorToken);
            var responseCreator = await client.SendAsync(requestCreator);

            var requestAdmin = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions/4"), Method = HttpMethod.Put, Content = inputContent };
            requestAdmin.Headers.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var responseAdmin = await client.SendAsync(requestAdmin);

            Assert.IsTrue(responseViewer.StatusCode == System.Net.HttpStatusCode.Forbidden, "Update Auction should not allow Viewer access.");
            Assert.IsTrue(responseCreator.IsSuccessStatusCode, "Update Auction should allow Creator access.");
            Assert.IsTrue(responseAdmin.IsSuccessStatusCode, "Update Auction should allow Admin access.");
        }

        [TestMethod]
        public async Task Step5_DeleteMethod()
        {
            string viewerToken = await GetViewerLogin();
            string creatorToken = await GetCreatorLogin();
            string adminToken = await GetAdminLogin();

            var requestViewer = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions/1"), Method = HttpMethod.Delete };
            requestViewer.Headers.Authorization = new AuthenticationHeaderValue("Bearer", viewerToken);
            var responseViewer = await client.SendAsync(requestViewer);

            var requestCreator = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions/1"), Method = HttpMethod.Delete };
            requestCreator.Headers.Authorization = new AuthenticationHeaderValue("Bearer", creatorToken);
            var responseCreator = await client.SendAsync(requestCreator);

            var requestAdmin = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions/1"), Method = HttpMethod.Delete };
            requestAdmin.Headers.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var responseAdmin = await client.SendAsync(requestAdmin);

            Assert.IsTrue(responseViewer.StatusCode == System.Net.HttpStatusCode.Forbidden, "Delete Auction should not allow Viewer access.");
            Assert.IsTrue(responseCreator.StatusCode == System.Net.HttpStatusCode.Forbidden, "Delete Auction should not allow Creator access.");
            Assert.IsTrue(responseAdmin.IsSuccessStatusCode, "Delete Auction should allow Admin access.");
        }

        [TestMethod]
        public async Task Step6_WhoAmI()
        {
            string viewerToken = await GetViewerLogin();
            string creatorToken = await GetCreatorLogin();
            string adminToken = await GetAdminLogin();

            var requestViewer = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions/whoami"), Method = HttpMethod.Get };
            requestViewer.Headers.Authorization = new AuthenticationHeaderValue("Bearer", viewerToken);
            var responseViewer = await client.SendAsync(requestViewer);
            string responseViewerContent = await responseViewer.Content.ReadAsStringAsync();

            var requestCreator = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions/whoami"), Method = HttpMethod.Get };
            requestCreator.Headers.Authorization = new AuthenticationHeaderValue("Bearer", creatorToken);
            var responseCreator = await client.SendAsync(requestCreator);
            string responseCreatorContent = await responseCreator.Content.ReadAsStringAsync();

            var requestAdmin = new HttpRequestMessage() { RequestUri = new Uri(client.BaseAddress + "auctions/whoami"), Method = HttpMethod.Get };
            requestAdmin.Headers.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
            var responseAdmin = await client.SendAsync(requestAdmin);
            string responseAdminContent = await responseAdmin.Content.ReadAsStringAsync();

            Assert.IsTrue(responseViewerContent == "test", "WhoAmI should return user name.");
            Assert.IsTrue(responseCreatorContent == "johnny", "WhoAmI should return user name.");
            Assert.IsTrue(responseAdminContent == "admin", "WhoAmI should return user name.");
        }


        private async Task<string> GetViewerLogin()
        {
            var viewerResponse = await client.PostAsJsonAsync("login", new { username = "test", password = "test" });
            string viewerResponseContent = await viewerResponse.Content.ReadAsStringAsync();
            User viewer = JsonConvert.DeserializeObject<User>(viewerResponseContent);
            return viewer.Token;
        }
        private async Task<string> GetCreatorLogin()
        {
            var creatorResponse = await client.PostAsJsonAsync("login", new { username = "johnny", password = "test" });
            string creatorResponseContent = await creatorResponse.Content.ReadAsStringAsync();
            User creator = JsonConvert.DeserializeObject<User>(creatorResponseContent);
            return creator.Token;
        }
        private async Task<string> GetAdminLogin()
        {
            var adminResponse = await client.PostAsJsonAsync("login", new { username = "admin", password = "admin" });
            string adminResponseContent = await adminResponse.Content.ReadAsStringAsync();
            User admin = JsonConvert.DeserializeObject<User>(adminResponseContent);
            return admin.Token;
        }
    }
}
