package com.techelevator;

public class Elevator {

    //properties

    private int currentFloor;
    private int numberOfFloors;
    private boolean doorOpen;

    //constructors

    public Elevator(int numberOfLevels) {
        numberOfFloors = numberOfLevels;
        currentFloor = 1;
    }

    //getters

    public int getCurrentFloor() {
        return currentFloor;
    }

    public int getNumberOfFloors() {
        return numberOfFloors;
    }

    public boolean isDoorOpen() {
        return doorOpen;
    }

    //other

    public void openDoor() {
        doorOpen = true;
    }

    public void closeDoor() {
        doorOpen = false;
    }

    public void goUp(int desiredFloor) {
        if(!doorOpen && desiredFloor <= numberOfFloors && desiredFloor > currentFloor) {
            currentFloor = desiredFloor;
        }
    }

    public void goDown(int desiredFloor) {
        if (!doorOpen && desiredFloor >= 1  && desiredFloor < currentFloor) {
            currentFloor = desiredFloor;
        }

    }

}
