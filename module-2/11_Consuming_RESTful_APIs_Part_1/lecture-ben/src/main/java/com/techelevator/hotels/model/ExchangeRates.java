package com.techelevator.hotels.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class ExchangeRates {
    @JsonProperty("USD")
    private double usd;
    @JsonProperty("EUR")
    private double eur;
    @JsonProperty("JPY")
    private double yen;

    public double getUsd() {
        return usd;
    }

    public void setUsd(double usd) {
        this.usd = usd;
    }

    public double getEur() {
        return eur;
    }

    public void setEur(double eur) {
        this.eur = eur;
    }

    public double getYen() {
        return yen;
    }

    public void setYen(double yen) {
        this.yen = yen;
    }
}
