using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        private static AuctionApiService apiService;
        private static Process serverProcess;

        private static readonly List<Auction> expectedAuctions = new List<Auction>() {
            new Auction() { Id = 1, Title = "Zero", Description = "Zero Auction", User = "User0", CurrentBid = 0.0 },
            new Auction() { Id = 2, Title = "One", Description = "One Auction", User = "User1", CurrentBid = 1.1}
        };
        private static readonly Auction expectedAuction = expectedAuctions[0];

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
            
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo(command, $"{cli} {data} {host} {port}");
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

            // Create a new api service
            apiService = new AuctionApiService(baseApiUrl);
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
        public void GetAllAuctions_ExpectList()
        {
            // Act
            List<Auction> actualAuctions = apiService.GetAllAuctions();

            // Assert
            Assert.AreEqual(expectedAuctions.Count, actualAuctions.Count, "The number of auctions returned is not the expected value.");
            for (int i = 0; i < actualAuctions.Count; i++)
            {
                AssertAuctionsMatch(expectedAuctions[i], actualAuctions[i], "The auction returned is not the same as expected.");
            }
        }

        [TestMethod]
        public void GetDetailsForAuction_ExpectSpecificItem()
        {
            // Act
            Auction actualAuction = apiService.GetDetailsForAuction(1);

            // Assert
            AssertAuctionsMatch(expectedAuction, actualAuction, "The auction returned is not the same as expected.");
        }

        [TestMethod]
        public void GetAuctionsSearchTitle_ExpectList()
        {
            // Act
            List<Auction> actualAuctions = apiService.GetAuctionsSearchTitle("Zero");

            // Assert
            Assert.AreEqual(1, actualAuctions.Count, "The number of auctions returned is not the expected value.");
            AssertAuctionsMatch(expectedAuctions[0], actualAuctions[0], "The auction returned is not the same as expected.");
        }

        [TestMethod]
        public void GetAuctionsSearchPrice_ExpectList()
        {
            // Act
            List<Auction> actualAuctions = apiService.GetAuctionsSearchPrice(1.00);

            // Assert
            Assert.AreEqual(1, actualAuctions.Count, "The number of auctions returned is not the expected value.");
            AssertAuctionsMatch(expectedAuctions[0], actualAuctions[0], "The auction returned is not the same as expected.");
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
