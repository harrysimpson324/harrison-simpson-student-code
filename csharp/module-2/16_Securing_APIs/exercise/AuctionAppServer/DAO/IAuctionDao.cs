using System.Collections.Generic;
using AuctionApp.Models;

namespace AuctionApp.DAO
{
    public interface IAuctionDao
    {
        List<Auction> GetAuctions();

        Auction GetAuctionById(int id);

        Auction CreateAuction(Auction auction);

        Auction UpdateAuction(Auction auction);

        int DeleteAuctionById(int id);

        List<Auction> GetAuctionsByTitle(string searchTerm);

        List<Auction> GetAuctionsByMaxBid(double maxPrice);
    }
}
