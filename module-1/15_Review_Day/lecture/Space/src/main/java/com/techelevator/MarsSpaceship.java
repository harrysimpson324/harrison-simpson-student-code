package com.techelevator;

public class MarsSpaceship extends Spacecraft implements Controllable{

    private Engine engine;
    private FuelTank fuelTank;
    private Navigation navigation;

    private boolean isFlying;


    public MarsSpaceship() {
        engine = new Engine();
        fuelTank = new FuelTank();
        navigation = new Navigation();
        isFlying = false;

    }


    public void startEngine() {
        if(!engine.isRunning()) {
            engine.start();
            System.out.println("You have started the engine.");
        }
        else {
            System.out.println("The engine is already running.");
        }
    }

    public void stopEngine() {
        if(engine.isRunning()) {
            engine.stop();
            System.out.println("You have shut down the engine.");
        }
        else {
            System.out.println("The engine was already off.");
        }

    }

    public void countDown(int start) {
        if(!isFlying) {
            for(int i = 5; i > -1; i--) {
                System.out.println(i);
            }
            System.out.println("Takeoff!");
            takeOff();
        }
        else {
            System.out.println("Spacecraft is already in the air.");
        }

    }


    @Override
    public void takeOff() {



    }
    @Override
    public void land() {

    }


}
