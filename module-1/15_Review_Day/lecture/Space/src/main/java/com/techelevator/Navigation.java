package com.techelevator;

public class Navigation {

    private String currentLocation;
    private String destination;

    public void updateDestination(String newDest) {
        destination = newDest;
    }

    public String getCurrentLocation(){
        return currentLocation;
    }

    public String getDestination() {
        return destination;
    }
}
