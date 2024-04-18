using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using RestSharp;
using System.Net;
using AuctionApp.Models;
using System.Net.Http;
using AuctionApp.Services;

namespace AuctionApp.Tests
{
    [TestClass]
    public class AuctionApiServiceTests
    {
        private const string baseApiUrl = "http://localhost";
        private AuctionApiService apiService;

        [TestInitialize]
        public void Setup()
        {
            // Create a new api service
            apiService = new AuctionApiService(baseApiUrl);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Make sure no mock client is left from the test
            AuthenticatedApiService.client = null;
        }

        private static bool CompareUrl(string clientBase, string resource, string fullResource)
        {
            return
                fullResource == clientBase + resource ||
                fullResource == resource ||
                fullResource == clientBase + resource.Substring(1); // In case there's a starting slash
        }

        [TestMethod]
        public void Step2_LoginMethod()
        {
            // Arrange
            string fullResource = $"{baseApiUrl}/login";
            string clientBase = AuthenticatedApiService.client.BaseUrl.ToString();

            ApiUser expected = new ApiUser { Username = "test", Token = "abcdefgh123456789", Message = null };
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute<ApiUser>(It.Is<IRestRequest>(r => CompareUrl(clientBase, r.Resource, fullResource)), Method.POST))
                .Returns(new RestResponse<ApiUser>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = expected,
                    ResponseStatus = ResponseStatus.Completed
                });
            AuthenticatedApiService.client = restClient.Object;

            // Act
            ApiUser actual = apiService.Login("test", "test");

            // Assert
            expected.Should().BeEquivalentTo(actual); // Uses FluentAssertions
        }

        [TestMethod]
        public void Step3_UnauthorizedResponse()
        {
            // Arrange
            string fullResource = $"{baseApiUrl}/auctions/1";
            string clientBase = AuthenticatedApiService.client.BaseUrl.ToString();

            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute<Auction>(It.Is<IRestRequest>(r => CompareUrl(clientBase, r.Resource, fullResource)), Method.GET))
                .Returns(new RestResponse<Auction>
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ResponseStatus = ResponseStatus.Completed
                });
            AuthenticatedApiService.client = restClient.Object;

            // Act
            try
            {
                Auction actual = apiService.GetDetailsForAuction(1);
            }
            catch (HttpRequestException ex)
            {
                Assert.IsTrue(ex.Message.ToLower().Contains("authoriz"),
                    "Exception message should contain the word 'authorization' or 'authorize'");
                return;
            }

            // Assert
            Assert.Fail("Exception should be thrown.");
        }

        [TestMethod]
        public void Step3_ForbiddenResponse()
        {
            // Arrange
            string fullResource = $"{baseApiUrl}/auctions/1";
            string clientBase = AuthenticatedApiService.client.BaseUrl.ToString();

            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute<Auction>(It.Is<IRestRequest>(r => CompareUrl(clientBase, r.Resource, fullResource)), Method.GET))
                .Returns(new RestResponse<Auction>
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    ResponseStatus = ResponseStatus.Completed
                });
            AuthenticatedApiService.client = restClient.Object;

            // Act
            try
            {
                Auction actual = apiService.GetDetailsForAuction(1);
            }
            catch (HttpRequestException ex)
            {
                Assert.IsTrue(ex.Message.ToLower().Contains("forbid") || ex.Message.ToLower().Contains("permission"),
                    "Exception message should contain the word 'forbid' or 'permission'");
                return;
            }

            // Assert
            Assert.Fail("Exception should be thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public void Step3_Other4xxResponse()
        {
            // Arrange
            string fullResource = $"{baseApiUrl}/auctions/1";
            string clientBase = AuthenticatedApiService.client.BaseUrl.ToString();

            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute<Auction>(It.Is<IRestRequest>(r => CompareUrl(clientBase, r.Resource, fullResource)), Method.GET))
                .Returns(new RestResponse<Auction>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ResponseStatus = ResponseStatus.Completed
                });
            AuthenticatedApiService.client = restClient.Object;

            // Act
            Auction actual = apiService.GetDetailsForAuction(1);

            // Assert
            Assert.Fail("Exception should be thrown.");
        }
    }
}
