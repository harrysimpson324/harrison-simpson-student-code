package com.webthreads.store.model;

import javax.validation.constraints.PositiveOrZero;

public class ShopApparelDto {
    private int shopId;
    private int apparelId;
    @PositiveOrZero()
    private int quantity;

    public ShopApparelDto() {
    }

    public int getShopId() {
        return shopId;
    }

    public void setShopId(int shopId) {
        this.shopId = shopId;
    }

    public int getApparelId() {
        return apparelId;
    }

    public void setApparelId(int apparelId) {
        this.apparelId = apparelId;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

}