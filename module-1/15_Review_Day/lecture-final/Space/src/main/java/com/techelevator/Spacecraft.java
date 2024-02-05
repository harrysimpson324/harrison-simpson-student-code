package com.techelevator;

public abstract class Spacecraft {
    protected String name;

    public Spacecraft(String name) {
        this.name = name;
    }

    // Abstract methods
    public abstract void takeOff();
    public abstract void land();

    // Encapsulation - Getter
    public String getName() {
        return name;
    }
}

