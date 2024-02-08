package com.techelevator;

public class Customer {
    private String description;
    private int numberOfOrders;
    private boolean boughtInsurance;
    private int easyMark;

    public Customer(String description) {
        this.description = description;
    }

    public String getDescription() {
        return description;
    }

    public boolean isBoughtInsurance() {
        return boughtInsurance;
    }

    public int getEasyMark() {
        return easyMark;
    }

    public int getNumberOfOrders() {
        return numberOfOrders;
    }

    public String toString() {
        return "\"" + description + "\"," + numberOfOrders + "," + boughtInsurance + "," + easyMark;
    }

}
