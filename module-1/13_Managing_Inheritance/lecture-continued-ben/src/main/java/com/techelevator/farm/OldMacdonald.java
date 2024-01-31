package com.techelevator.farm;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

public class OldMacdonald {
	public static void main(String[] args) {

		Cow bessie = new Cow();
		Chicken sammy = new Chicken();
		Pig buffy = new Pig();
		Tractor ruth = new Tractor();
		Lion geoffrey = new Lion();
		FarmAnimal sally = new GuernseyCow();
		Cow whichCow = (Cow) sally;
		// Singable fred = new Singable();
		Cat tasha = new Cat("Tasha");
		tasha.sleep(true);
		buffy.sleep(true);

		Singable[] singables = new Singable[] { tasha, bessie, sammy, buffy, ruth, sally };
		List<Sellable> sellables = new ArrayList<>();
		sellables.add(buffy);
		sellables.add(geoffrey);
		FarmAnimal[] farmAnimals = new FarmAnimal[] {bessie, buffy, sammy};

		bessie.sleep(true);

		for (Singable singable : singables) {
			sing(singable);
		}

		System.out.println();
		Egg[] eggs = new Egg[] {sammy.layEgg(), sammy.layEgg(), sammy.layEgg(), sammy.layEgg(), sammy.layEgg(), sammy.layEgg() };
		sellables.add(eggs[0]);
		for (Egg egg : eggs) {
			System.out.println("Egg for sale! Price " + egg.getPrice());
		}
		System.out.println();
		sing(geoffrey);

		System.out.println();
		buffy.eat();
		sammy.eat();
		bessie.eat();

		for (FarmAnimal animal : farmAnimals) {
			if (animal instanceof Pig) {
				Pig somePig = (Pig) animal;
				BigDecimal price = somePig.getPrice();
				System.out.println("You can sell the " + animal.getName() + " for " + price);
			}
		}

		System.out.println();
		for (Sellable sellable : sellables) {
			System.out.println(sellable.getName() + " for sale! Price " + sellable.getPrice());
		}

	}

	public static void sing(Singable singable) {
		String name = singable.getName();
		String sound = singable.getSound();
		System.out.println("Old MacDonald had a farm, ee, ay, ee, ay, oh!");
		if (singable instanceof Cat) {
			Cat cat = (Cat) singable;
			System.out.println("And on his farm he had " + cat.getNickname() + ", ee, ay, ee, ay, oh!");
		}
		else {
			System.out.println("And on his farm he had a " + name + ", ee, ay, ee, ay, oh!");
		}
		System.out.println("With a " + sound + " " + sound + " here");
		System.out.println("And a " + sound + " " + sound + " there");
		System.out.println("Here a " + sound + " there a " + sound + " everywhere a " + sound + " " + sound);
		System.out.println();
		if (singable instanceof Pig) {
			Pig somePig = (Pig) singable;
			BigDecimal price = somePig.getPrice();
			System.out.println("You can sell the " + somePig.getName() + " for " + price);
			System.out.println();
		}
		else if (singable instanceof Cow) {
			System.out.println("Whee, we have a cow!");
		}
	}
}