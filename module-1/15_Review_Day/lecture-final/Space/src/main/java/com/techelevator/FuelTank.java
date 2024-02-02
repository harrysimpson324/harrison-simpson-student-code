package com.techelevator;

public class FuelTank {
    private int fuelLevel;

    public FuelTank(int initialFuel) {
        this.fuelLevel = initialFuel;
    }

    public void consumeFuel(int amount) {
        fuelLevel = Math.max(fuelLevel - amount, 0);
        System.out.println("Fuel consumed. Remaining fuel: " + fuelLevel);
    }

    // Encapsulation - Getter
    public int getFuelLevel() {
        return fuelLevel;
    }
}

