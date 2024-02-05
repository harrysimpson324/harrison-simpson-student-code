package com.techelevator;

public class Engine {

    private boolean isRunning;

    public void start() {
        isRunning = true;
    }

    public void stop() {
        isRunning = false;
    }

    public boolean isRunning() {
        return isRunning;
    }




}
