package com.techelevator.farm;

import java.math.BigDecimal;

public class Lion implements Singable, Sellable {

    public String getName() {
        return "Lion";
    }

    public String getSound() {
        return "roar!";
    }

    public BigDecimal getPrice() {
        return new BigDecimal("1500.00");
    }

}
