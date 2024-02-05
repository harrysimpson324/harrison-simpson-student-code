package com.techelevator;

public class FuelTank {

    private int fuelLevel;

    public void consumeFuel(int fuelBurned) {
        fuelLevel -= fuelBurned;
    }

    public int getFuelLevel() {
        return fuelLevel;
    }

}
