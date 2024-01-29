package com.techelevator;

public class BuyoutAuction extends Auction {

    private int buyoutPrice;

    public BuyoutAuction(String itemForSale, int buyoutPrice) {
        super(itemForSale);
        this.buyoutPrice = buyoutPrice;
    }

    public int getBuyoutPrice() {
        return buyoutPrice;
    }

    @Override
    public boolean placeBid(Bid offeredBid) {
        boolean isCurrentWinningBid = false;
        if (getHighBid().getBidAmount() < buyoutPrice) {
            if (offeredBid.getBidAmount() > buyoutPrice) {
                Bid newBid = new Bid(offeredBid.getBidder(), buyoutPrice);
                isCurrentWinningBid = super.placeBid(newBid);
            } else {
                isCurrentWinningBid = super.placeBid((offeredBid));
            }
        }

        return isCurrentWinningBid;
    }

    @Override
    public String toString() {
        return "Buyout " + super.toString();
    }


}
