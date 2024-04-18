using RestSharp;
using System.Collections.Generic;
using AuctionApp.Models;

namespace AuctionApp.Services
{
    public class AuctionApiService : AuthenticatedApiService
    {
        public readonly string ApiUrl;

        public AuctionApiService(string apiUrl) : base(apiUrl) { }

        public List<Auction> GetAllAuctions()
        {
            RestRequest request = new RestRequest("auctions");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            CheckForError(response);
            return response.Data;
        }

        public Auction GetDetailsForAuction(int auctionId)
        {
            RestRequest requestOne = new RestRequest($"auctions/{auctionId}");
            IRestResponse<Auction> response = client.Get<Auction>(requestOne);
            CheckForError(response);
            return response.Data;
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTerm)
        {
            RestRequest request = new RestRequest($"auctions?title_like={searchTerm}");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            CheckForError(response);
            return response.Data;
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            RestRequest request = new RestRequest($"auctions?currentBid_lte={searchPrice}");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            CheckForError(response);
            return response.Data;
        }

        public Auction AddAuction(Auction newAuction)
        {
            RestRequest request = new RestRequest("auctions");
            request.AddJsonBody(newAuction);
            IRestResponse<Auction> response = client.Post<Auction>(request);
            CheckForError(response);
            return response.Data;
        }

        public Auction UpdateAuction(Auction auctionToUpdate)
        {
            RestRequest request = new RestRequest($"auctions/{auctionToUpdate.Id}");
            request.AddJsonBody(auctionToUpdate);
            IRestResponse<Auction> response = client.Put<Auction>(request);
            CheckForError(response);
            return response.Data;
        }

        public bool DeleteAuction(int auctionId)
        {
            RestRequest request = new RestRequest($"auctions/{auctionId}");
            IRestResponse response = client.Delete(request);
            CheckForError(response);
            return true;
        }
    }
}
