using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuctionApp.Models;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AuctionApp.Tests
{
    [TestClass]
    public class AuctionsControllerTests
    {
        protected HttpClient client;

        [TestInitialize]
        public void Setup()
        {
            var builder = new WebHostBuilder().UseStartup<AuctionApp.Startup>();
            var server = new TestServer(builder);
            client = server.CreateClient();
        }

        [TestMethod]
        public async Task CreateAuction_ExpectCreated()
        {
            Auction input = new Auction() { Title = "Dragon Plush", Description = "Not a real dragon", User = "Bernice", CurrentBid = 19.50 };

            var response = await client.PostAsJsonAsync("auctions", input);

            string responseContent = await response.Content.ReadAsStringAsync();
            Auction content = JsonConvert.DeserializeObject<Auction>(responseContent);

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created, "Response status code should be 201 Created.");
            Assert.IsTrue(!string.IsNullOrWhiteSpace(responseContent), "Response content is empty but shouldn't be.");
            Assert.IsNotNull(content, "Response content can't be deserialized into an Auction.");
        }

        [TestMethod]
        public async Task CreateAuction_ExpectBadRequest()
        {
            Auction blankTitle = new Auction() { Title = "", Description = "Not a real dragon", User = "Bernice", CurrentBid = 19.50 };
            var responseTitle = await client.PostAsJsonAsync("auctions", blankTitle);
            Assert.IsTrue(responseTitle.StatusCode == System.Net.HttpStatusCode.BadRequest, "A blank title shouldn't be allowed for a new auction. Is data validation in place?");

            Auction blankDescr = new Auction() { Title = "Dragon Plush", Description = "", User = "Bernice", CurrentBid = 19.50 };
            var responseDescr = await client.PostAsJsonAsync("auctions", blankDescr);
            Assert.IsTrue(responseDescr.StatusCode == System.Net.HttpStatusCode.BadRequest, "A blank description shouldn't be allowed for a new auction. Is data validation in place?");

            Auction blankUser = new Auction() { Title = "Dragon Plush", Description = "Not a real dragon", User = "", CurrentBid = 19.50 };
            var responseUser = await client.PostAsJsonAsync("auctions", blankUser);
            Assert.IsTrue(responseUser.StatusCode == System.Net.HttpStatusCode.BadRequest, "A blank user shouldn't be allowed for a new auction. Is data validation in place?");

            Auction tooLowPrice = new Auction() { Title = "Dragon Plush", Description = "Not a real dragon", User = "Bernice", CurrentBid = 0.0 };
            var responsePrice = await client.PostAsJsonAsync("auctions", tooLowPrice);
            Assert.IsTrue(responsePrice.StatusCode == System.Net.HttpStatusCode.BadRequest, "A bid of 0 or less shouldn't be allowed for a new auction. Is data validation in place?");
        }

        [TestMethod]
        public async Task UpdateAuction_ExpectOk()
        {
            Auction input = new Auction() { Id = 2, Title = "Dragon Plush", Description = "Not a real dragon", User = "Bernice", CurrentBid = 19.50 };

            var response = await client.PutAsJsonAsync("auctions/2", input);

            string responseContent = await response.Content.ReadAsStringAsync();
            Auction content = JsonConvert.DeserializeObject<Auction>(responseContent);

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK, "Response status code should be 200 OK.");
            Assert.IsTrue(!string.IsNullOrWhiteSpace(responseContent), "Response content is empty but shouldn't be.");
            Assert.IsNotNull(content, "Response content can't be deserialized into an Auction.");
        }

        [TestMethod]
        public async Task UpdateAuction_ExpectBadRequest()
        {
            Auction input = new Auction() { Id = 2, Title = "", Description = "", User = "", CurrentBid = 0 };

            var response = await client.PutAsJsonAsync("auctions/2", input);

            string responseContent = await response.Content.ReadAsStringAsync();
            Auction content = JsonConvert.DeserializeObject<Auction>(responseContent);

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.BadRequest, "Updating an auction with invalid data shouldn't be allowed. Is data validation in place?");
        }

        [TestMethod]
        public async Task UpdateAuction_ExpectNotFound()
        {
            Auction input = new Auction() { Id = 23, Title = "Dragon Plush", Description = "Not a real dragon", User = "Bernice", CurrentBid = 19.50 };

            var response = await client.PutAsJsonAsync("auctions/23", input);

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound, "Response status code should be 404 NotFound.");
        }

        [TestMethod]
        public async Task DeleteAuction_ExpectNoContent()
        {
            var response = await client.DeleteAsync("auctions/7");

            string responseContent = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent, "Response status code should be 204 NoContent.");
            Assert.IsTrue(string.IsNullOrWhiteSpace(responseContent), "Response content should be empty but isn't.");
        }

        [TestMethod]
        public async Task DeleteAuction_ExpectNotFound()
        {
            var response = await client.DeleteAsync("auctions/10");

            string responseContent = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound, "Response status code should be 404 NotFound.");
        }
    }
}
