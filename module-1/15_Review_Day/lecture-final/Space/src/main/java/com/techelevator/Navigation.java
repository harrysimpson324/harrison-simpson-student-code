package com.techelevator;

public class Navigation {
    private String currentLocation;
    private String destination;



    public Navigation(String currentLocation, String destination) {
        this.currentLocation = currentLocation;
        this.destination = destination;
    }



    // Encapsulation - Getters and Setters
    public String getCurrentLocation() {
        return currentLocation;
    }

    public void setCurrentLocation(String currentLocation) {
        this.currentLocation = currentLocation;
    }

    public String getDestination() {
        return destination;
    }

    public void setDestination(String destination) {
        this.destination = destination;
    }

    // Other Methods
    public void updateDestination(String newDestination) {
        destination = newDestination;
        System.out.println("Navigation updated. New destination: " + destination);
    }
}

