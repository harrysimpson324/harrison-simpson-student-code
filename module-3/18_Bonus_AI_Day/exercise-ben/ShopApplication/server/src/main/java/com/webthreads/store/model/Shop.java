package com.webthreads.store.model;

import javax.validation.constraints.NotBlank;

public class Shop {

    private int shopId;
    @NotBlank(message = "Name must not be blank.")
    private String name;
    @NotBlank(message = "Street address must not be blank.")
    private String streetAddress;
    @NotBlank(message = "City must not be blank.")
    private String city;
    @NotBlank(message = "State must not be blank.")
    private String state;
    @NotBlank(message = "Zip code must not be blank.")
    private String zipCode;

    public int getShopId() {
        return shopId;
    }

    public void setShopId(int shopId) {
        this.shopId = shopId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getStreetAddress() {
        return streetAddress;
    }

    public void setStreetAddress(String streetAddress) {
        this.streetAddress = streetAddress;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public String getState() {
        return state;
    }

    public void setState(String state) {
        this.state = state;
    }

    public String getZipCode() {
        return zipCode;
    }

    public void setZipCode(String zipCode) {
        this.zipCode = zipCode;
    }
}
