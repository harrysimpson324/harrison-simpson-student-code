package com.techelevator.auctions.controller;

import com.techelevator.auctions.dao.AuctionDao;
import com.techelevator.auctions.dao.MemoryAuctionDao;
import com.techelevator.auctions.model.Auction;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/auctions")
public class AuctionController {

    private AuctionDao auctionDao;

    public AuctionController() {
        this.auctionDao = new MemoryAuctionDao();
    }

    @RequestMapping(path = "", method = RequestMethod.GET)
    public List<Auction> list(@RequestParam(required = false, defaultValue = "") String title_like,
                              @RequestParam(required = false, defaultValue = "0") String currentBid_lte) {

        double bidLte = Double.parseDouble(currentBid_lte);

        if (title_like != null && !title_like.equals("") && bidLte > 0) {
            return auctionDao.getAuctionsByTitleAndMaxBid(title_like, bidLte);
        } if (title_like != null && !title_like.equals("")) {
            return auctionDao.getAuctionsByTitle(title_like);
        } if (bidLte > 0) {
            return auctionDao.getAuctionsByMaxBid(bidLte);
        }
        return auctionDao.getAuctions();
    }

    @RequestMapping(path = "/{id}" , method = RequestMethod.GET)
    public Auction get(@PathVariable int id) {
        return auctionDao.getAuctionById(id);
    }

    @RequestMapping(path = "", method = RequestMethod.POST)
    public Auction create(@RequestBody Auction auction) {
        return auctionDao.createAuction(auction);
    }

}
