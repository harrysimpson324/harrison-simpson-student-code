using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using AuctionApp.Models;
using AuctionApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AuctionApp.Tests
{
    [TestClass]
    public class ApiServiceTests
    {
        private const string baseApiUrl = "http://localhost:3001";
        private const string baseApiUrlInvalid = "http://localhost:3002";
        private static AuctionApiService apiService;
        private static AuctionApiService apiServiceInvalidUrl;
        private static Process serverProcess;

        [ClassInitialize]
        public static void Setup(TestContext unused) // The ClassInitialize method must be static, public, void, and take a single parameter of type TestContext.
        {
            // Windows: node server\\node_modules\\json-server\\lib\\cli\\bin.js server\\data-test.js --host=127.0.0.1 --port=3001
            // Linux:   node server/node_modules/json-server/lib/cli/bin.js server/data-test.js --host=127.0.0.1 --port=3001
            string command = "node";
            string cli = Path.Combine("server", "node_modules", "json-server", "lib", "cli", "bin.js");
            string data = Path.Combine("server", "data-test.js");
            string host = "--host=127.0.0.1";
            string port = "--port=3001";
            string mid = "--middlewares " + Path.Combine("server", "middleware.js");

            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo(command, $"{cli} {data} {mid} {host} {port}");
                processInfo.UseShellExecute = false;
                processInfo.RedirectStandardOutput = true;
                processInfo.RedirectStandardError = true;
                processInfo.WorkingDirectory = TryGetServerDirectory();

                serverProcess = Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                throw new Exception("Server process could not be started.", ex);
            }

            if (!PingServer(baseApiUrl, 10, 500)) // time-out after ~5 seconds
            {
                throw new Exception("Unable to connect to server: " + baseApiUrl + Environment.NewLine + "Make sure you've run `npm install` in the `server` folder and can run json-server.");
            }

            // Create new api services
            apiService = new AuctionApiService(baseApiUrl);
            apiServiceInvalidUrl = new AuctionApiService(baseApiUrlInvalid);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            if (serverProcess != null && !serverProcess.HasExited)
            {
                serverProcess.Kill();
                serverProcess.Dispose();
            }
        }

        [TestMethod]
        public void AddAuction_ExpectSuccess()
        {
            // Arrange
            Auction newAuction = new Auction()
            {
                Title = "a",
                Description = "b",
                User = "c",
                CurrentBid = 99.99
            };
            
            // Act
            Auction actualAuction = apiService.AddAuction(newAuction);

            // Assert
            Assert.IsNotNull(actualAuction, "New auction returned is null.");
            Assert.IsTrue(actualAuction.Id > 0, "New auction ID is still 0.");

            newAuction.Id = actualAuction.Id; // ID > 0 so it should be valid, assign it so we can pass it to AssertAuctionsMatch()
            AssertAuctionsMatch(newAuction, actualAuction, "The auction returned is not the same as expected.");
        }

        [TestMethod]
        [ExpectedException(typeof(HttpRequestException), "An exception should be thrown when the server can't be reached or doesn't respond.")]
        public void AddAuction_ExpectExceptionForInvalidUrl()
        {
            // Arrange
            Auction auction = new Auction() { Title = "Dragon Plush Toy", Description = "Not a real dragon", User = "Bernice", CurrentBid = 19.99 };
            
            // Act
            apiServiceInvalidUrl.AddAuction(auction);
            
            // Assert
            // no assertions, because exception is expected - see [ExpectedException] attribute on this test method
        }

        [TestMethod]
        public void UpdateAuction_ExpectSuccess()
        {
            // Arrange
            Auction auctionToUpdate = new Auction()
            {
                Id = 1,
                Title = "q",
                Description = "w",
                User = "e",
                CurrentBid = 11.11
            };

            // Act
            Auction returnedAuction = apiService.UpdateAuction(auctionToUpdate);

            // Assert
            Assert.IsNotNull(returnedAuction, "Returned auction is null.");
            AssertAuctionsMatch(auctionToUpdate, returnedAuction, "The auction returned is not the same as expected.");
        }

        [TestMethod]
        [ExpectedException(typeof(HttpRequestException), "An exception should be thrown when if the server responds with an error.")]
        public void UpdateAuction_ExpectExceptionForInvalidData()
        {   
            // Arrange
            Auction auctionToUpdate = new Auction()
            {
                Id = 9, // ID doesn't exist in test data
                Title = "q",
                Description = "w",
                User = "e",
                CurrentBid = 11.11
            };

            // Act
            apiService.UpdateAuction(auctionToUpdate);

            // Assert
            // no assertions, because exception is expected - see [ExpectedException] attribute on this test method
        }

        [TestMethod]
        [ExpectedException(typeof(HttpRequestException), "An exception should be thrown when the server can't be reached or doesn't respond.")]
        public void UpdateAuction_ExpectExceptionForInvalidUrl()
        {
            // Arrange
            Auction auctionToUpdate = new Auction()
            {
                Id = 1,
                Title = "q",
                Description = "w",
                User = "e",
                CurrentBid = 11.11
            };

            // Act
            apiServiceInvalidUrl.UpdateAuction(auctionToUpdate);

            // Assert
            // no assertions, because exception is expected - see [ExpectedException] attribute on this test method
        }

        [TestMethod]
        public void DeleteAuction_ExpectSuccess()
        {
            // Act
            bool deleteSuccess = apiService.DeleteAuction(2);

            // Assert
            Assert.IsTrue(deleteSuccess, "DeleteAuction() did not return true for a successful operation.");
        }

        [TestMethod]
        [ExpectedException(typeof(HttpRequestException), "An exception should be thrown when if the server responds with an error.")]
        public void DeleteAuction_ExpectExceptionForInvalidData()
        {
            // Act
            apiService.DeleteAuction(99);
            
            // Assert
            // no assertions, because exception is expected - see [ExpectedException] attribute on this test method
        }

        [TestMethod]
        [ExpectedException(typeof(HttpRequestException), "An exception should be thrown when the server can't be reached or doesn't respond.")]
        public void DeleteAuction_ExpectExceptionForInvalidUrl()
        {
            // Act
            apiServiceInvalidUrl.DeleteAuction(2);

            // Assert
            // no assertions, because exception is expected - see [ExpectedException] attribute on this test method
        }

        private void AssertAuctionsMatch(Auction expected, Auction actual, string message)
        {
            Assert.AreEqual(expected.Id, actual.Id, message);
            Assert.AreEqual(expected.Title, actual.Title, message);
            Assert.AreEqual(expected.Description, actual.Description, message);
            Assert.AreEqual(expected.User, actual.User, message);
            Assert.AreEqual(expected.CurrentBid, actual.CurrentBid, 0.01, message);
        }

        private static string TryGetServerDirectory(string currentPath = null)
        {
            DirectoryInfo directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetDirectories("server").Any())
            {
                directory = directory.Parent;
            }
            return directory.FullName;
        }

        private static bool PingServer(string url, int maxTries, int waitInterval)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(url);

            int tryCount = 0;
            while (tryCount < maxTries)
            {
                tryCount++;
                try
                {
                    IRestResponse response = client.Head(request);
                    if (response.IsSuccessful)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    // Just eat the exception and try the request again.
                }
                Thread.Sleep(waitInterval);
            }
            return false;
        }
    }
}
