package com.techelevator.farm;

public class OldMacdonald {
	public static void main(String[] args) {

		Cow bessie = new Cow();
		Chicken sammy = new Chicken();
		Pig buffy = new Pig();
		Tractor ruth = new Tractor();
		Lion geoffrey = new Lion();
		// Singable fred = new Singable();

		Singable[] singables = new Singable[] { bessie, sammy, buffy, ruth };

		for (Singable singable : singables) {
			sing(singable);
		}

		System.out.println();
		Egg[] eggs = new Egg[] {sammy.layEgg(), sammy.layEgg(), sammy.layEgg(), sammy.layEgg(), sammy.layEgg(), sammy.layEgg() };
		for (Egg egg : eggs) {
			System.out.println("Egg for sale! Price " + egg.getPrice());
		}
		System.out.println();
		sing(geoffrey);
	}

	public static void sing(Singable singable) {
		String name = singable.getName();
		String sound = singable.getSound();
		System.out.println("Old MacDonald had a farm, ee, ay, ee, ay, oh!");
		System.out.println("And on his farm he had a " + name + ", ee, ay, ee, ay, oh!");
		System.out.println("With a " + sound + " " + sound + " here");
		System.out.println("And a " + sound + " " + sound + " there");
		System.out.println("Here a " + sound + " there a " + sound + " everywhere a " + sound + " " + sound);
		System.out.println();
	}
}