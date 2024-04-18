using System.Collections.Generic;
using AuctionApp.Models;

namespace AuctionApp.DAO
{
    public interface IAuctionDao
    {
        List<Auction> GetAuctions();

        Auction GetAuctionById(int id);

        Auction CreateAuction(Auction auction);

        List<Auction> GetAuctionByTitle(string searchTerm);

        List<Auction> GetAuctionsByMaxBid(double maxPrice);

        List<Auction> GetAuctionsByTitleAndMaxBid(string searchTerm, double maxPrice);
    }
}
