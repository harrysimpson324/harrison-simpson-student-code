package com.techelevator.farm;

public class Chicken extends FarmAnimal {

	public Chicken() {
		super("Chicken", "cluck!");
	}

	public Egg layEgg() {
		System.out.println("Chicken laid an egg!");
		return new Egg();
	}

}