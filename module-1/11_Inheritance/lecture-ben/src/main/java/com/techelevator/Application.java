package com.techelevator;

public class Application {

    public static void main(String[] args) {

        // Create a new general auction
        System.out.println("Starting a general auction");
        System.out.println("-----------------");

        Auction generalAuction = new Auction("Tech Elevator t-shirt");

        generalAuction.placeBid(new Bid("Josh", 1));
        generalAuction.placeBid(new Bid("Fonz", 23));
        generalAuction.placeBid(new Bid("Rick Astley", 13));
        //....
        //....
        // This might go on until the auction runs out of time or hits a max # of bids
        printAuctionWinner((generalAuction));
//        Bid highBid = generalAuction.getHighBid();
//        if (highBid.getBidder().equals("")) {
//            System.out.println("Nobody placed a bid for " + generalAuction.getItemForSale());
//        }
//        else {
//            //System.out.println(highBid.getBidder() + " won the auction for the " + generalAuction.getItemForSale() +
//            //                    " with a bid of $" + highBid.getBidAmount());
//            System.out.println(generalAuction.toString() + " with a winning High " + highBid);
//
//        }
//        System.out.println();
//        for (Bid bid : generalAuction.getAllBids()) {
//            System.out.println(bid);
//        }

        System.out.println();

        BuyoutAuction buyoutAuction = new BuyoutAuction("Tech Elevator engraved mug", 12);

        buyoutAuction.placeBid(new Bid("Josh", 1));
        buyoutAuction.placeBid(new Bid("Fonz", 11));
        buyoutAuction.placeBid(new Bid("Rick Astley", 13));
        buyoutAuction.placeBid(new Bid("Ben", 15));

        printAuctionWinner((buyoutAuction));
//        highBid = buyoutAuction.getHighBid();
//        if (highBid.getBidder().equals("")) {
//            System.out.println("Nobody placed a bid for " + buyoutAuction.getItemForSale());
//        }
//        else {
//            //System.out.println(highBid.getBidder() + " won the auction for the " + generalAuction.getItemForSale() +
//            //                    " with a bid of $" + highBid.getBidAmount());
//            System.out.println(buyoutAuction.toString() + " with a winning High " + highBid);
//
//        }
//        System.out.println();
//        for (Bid bid : buyoutAuction.getAllBids()) {
//            System.out.println(bid);
//        }

        System.out.println();
        ReserveAuction reserveAuction = new ReserveAuction("Tech Elevator Hat",50);

        reserveAuction.placeBid(new Bid("Ted Mosby", 35));
        reserveAuction.placeBid(new Bid("Marshall Erickson", 55));
        reserveAuction.placeBid(new Bid("Barney Stinson", 80));
        reserveAuction.placeBid(new Bid("Lily Erickson", 60));
        reserveAuction.placeBid(new Bid("Robin Sherbatsky", 85));

        printAuctionWinner(reserveAuction);

//        generalAuction = reserveAuction;
//        highBid = generalAuction.getHighBid();
//        if (highBid.getBidder().equals("")) {
//            System.out.println("Nobody placed a bid for " + generalAuction.getItemForSale());
//        }
//        else {
//            //System.out.println(highBid.getBidder() + " won the auction for the " + generalAuction.getItemForSale() +
//            //                    " with a bid of $" + highBid.getBidAmount());
//            System.out.println(generalAuction.toString() + " with a winning High " + highBid);
//
//        }
//        System.out.println();
//        for (Bid bid : generalAuction.getAllBids()) {
//            System.out.println(bid);
//        }
    }

    public static void printAuctionWinner(Auction auction) {
        Bid highBid = auction.getHighBid();
        if (highBid.getBidder().equals("")) {
            System.out.println("Nobody placed a bid for " + auction.getItemForSale());
        }
        else {
            System.out.println(auction.toString() + " with a winning High " + highBid);

        }
        System.out.println();
        for (Bid bid : auction.getAllBids()) {
            System.out.println(bid);
        }
    }

}
