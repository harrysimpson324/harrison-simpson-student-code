package com.techelevator;

public class Engine {
    private boolean isRunning;

    public Engine() {
        this.isRunning = false;
    }

    public void start() {
        isRunning = true;
        System.out.println("Engine started.");
    }

    public void stop() {
        isRunning = false;
        System.out.println("Engine stopped.");
    }

    // Encapsulation - Getter
    public boolean isRunning() {
        return isRunning;
    }
}

