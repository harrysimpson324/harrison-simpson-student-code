using RestSharp;
using System.Collections.Generic;
using AuctionApp.Models;

namespace AuctionApp.Services
{
    public class AuctionApiService
    {
        private IRestClient client;

        public AuctionApiService(string apiUrl)
        {
            client = new RestClient(apiUrl);
        }

        public List<Auction> GetAllAuctions()
        {
            throw new System.NotImplementedException();
        }

        public Auction GetDetailsForAuction(int auctionId)
        {
            throw new System.NotImplementedException();
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTerm)
        {
            throw new System.NotImplementedException();
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            throw new System.NotImplementedException();
        }
    }
}
