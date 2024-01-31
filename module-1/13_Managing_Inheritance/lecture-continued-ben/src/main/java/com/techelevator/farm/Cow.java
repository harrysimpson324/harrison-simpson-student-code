package com.techelevator.farm;

public final class Cow extends FarmAnimal {

	public Cow() {
		super("Cow", "moo!");
	}

	@Override
	public void eat() {
		System.out.println("Cow chews cud...");
	}

}