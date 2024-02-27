package com.techelevator.hotels.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class Currency {
    @JsonProperty("base")
    private String currencyAbbreviation;

    ExchangeRates rates;

    public String getCurrencyAbbreviation() {
        return currencyAbbreviation;
    }

    public void setCurrencyAbbreviation(String currencyAbbreviation) {
        this.currencyAbbreviation = currencyAbbreviation;
    }

    public ExchangeRates getRates() {
        return rates;
    }

    public void setRates(ExchangeRates rates) {
        this.rates = rates;
    }
}
