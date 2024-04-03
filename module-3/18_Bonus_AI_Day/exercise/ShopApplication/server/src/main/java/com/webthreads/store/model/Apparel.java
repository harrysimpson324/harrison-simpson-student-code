package com.webthreads.store.model;

import java.math.BigDecimal;

public class Apparel {
    private int apparelId;
    private String title;
    private String description;
    private String size;
    private BigDecimal price;
    private ShopApparel shopInventory;

    public int getApparelId() {
        return apparelId;
    }

    public void setApparelId(int apparelId) {
        this.apparelId = apparelId;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getSize() {
        return size;
    }

    public void setSize(String size) {
        this.size = size;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    public ShopApparel getShopInventory() {
        return shopInventory;
    }

    public void setShopInventory(ShopApparel shopInventory) {
        this.shopInventory = shopInventory;
    }
}
