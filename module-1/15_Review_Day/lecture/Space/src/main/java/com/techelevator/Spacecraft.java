package com.techelevator;

public abstract class Spacecraft {

    private String name;

    public abstract void takeOff();

    public abstract void land();

    public String getName() {
        return name;
    }

}
