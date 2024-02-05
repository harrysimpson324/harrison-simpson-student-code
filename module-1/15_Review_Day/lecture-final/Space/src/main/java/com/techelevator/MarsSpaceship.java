package com.techelevator;

public class MarsSpaceship extends Spacecraft implements Controllable {
    private final int COUNT_DOWN_TIME = 5;
    private Engine engine;  // composition
    private FuelTank fuelTank; // composition
    private Navigation navigation; // composition

    public MarsSpaceship(String name, String currentLocation, String destination, int initialFuel) {
        super(name);
        this.engine = new Engine();
        this.fuelTank = new FuelTank(initialFuel);
        this.navigation = new Navigation(currentLocation, destination);
    }


    public void countDown(int seconds) {
        System.out.println("Countdown to takeoff:");
        try {
            for (int i = seconds; i > 0; i--) {
                System.out.println(i + "...");
                Thread.sleep(1000); // Wait for 1 second
            }
            System.out.println("Takeoff!");
        } catch (InterruptedException e) {
            System.out.println("Countdown was interrupted");
        }
    }

    @Override
    public void startEngine() {
        if (fuelTank.getFuelLevel() > 0) {
            engine.start();
        } else {
            System.out.println("Cannot start engine. No fuel.");
        }
    }

    @Override
    public void stopEngine() {
        engine.stop();
    }

    @Override
//    public void takeOff() {
//        if (engine.isRunning()) {
//            System.out.println(name + " is taking off towards " + navigation.getDestination() + "!");
//            fuelTank.consumeFuel(50); // Example fuel consumption
//        } else {
//            System.out.println("Cannot take off. Engine is not running.");
//        }
//    }

    public void takeOff() {
        if (!engine.isRunning()) {
            System.out.println("Cannot take off. Engine is not running.");
            return;
        }
        if (fuelTank.getFuelLevel() <= 0) {
            System.out.println("Cannot take off. No fuel.");
            return;
        }
        countDown(COUNT_DOWN_TIME); // Start a 5-second countdown
        // Takeoff logic
        System.out.println(name + " is taking off towards " + navigation.getDestination() + "!");
        fuelTank.consumeFuel(50); // Example fuel consumption
    }

    @Override
    public void land() {
        if (engine.isRunning()) {
            System.out.println(name + " is landing on " + navigation.getDestination() + "!");
            fuelTank.consumeFuel(30); // Example fuel consumption
        } else {
            System.out.println("Cannot land. Engine is not running.");
        }
    }
}
