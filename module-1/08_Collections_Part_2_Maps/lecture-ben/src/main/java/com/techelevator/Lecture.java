package com.techelevator;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class Lecture {

	public static void main(String[] args) {

		System.out.println("####################");
		System.out.println("        SETS");
		System.out.println("####################");
		System.out.println();

		Set<String> names = new HashSet<>();
		names.add("Harry");
		names.add("Hermione");
		names.add("Ron");
		names.add("Pokemon");
		for (String name : names) {
			System.out.println(name);
		}
		if (names.add("Ron")) {
			System.out.println("Ron added");
		}
		else {
			System.out.println("Ron could not be added");
		}
		if (names.add("Dobby")) {
			System.out.println("Dobby added");
		}
		else {
			System.out.println("Dobby could not be added");
		}



		System.out.println("####################");
		System.out.println("        MAPS");
		System.out.println("####################");
		System.out.println();

		Map<String, String> nameToZip = new HashMap<>();
		nameToZip.put("David", "44120");
		nameToZip.put("Ben", "44115");
		System.out.println("Ben lives in zipcode " + nameToZip.get("Ben"));
		nameToZip.put("David", "44122");
		//nameToZip.remove("David");
		nameToZip.put("Sally", "44115");
		nameToZip.put("Tori", "44118");

		if (nameToZip.containsKey("Sally")) {
			System.out.println("Sally lives at zipcode " + nameToZip.get("Sally"));
		}

		if (nameToZip.containsValue("44115")) {
			System.out.println("Somebody lives in zipcode 44115");
		}
		System.out.println();
		for (String name : nameToZip.keySet()) {
			System.out.println(name + " lives at zipcode " + nameToZip.get(name));
		}
		System.out.println();

		Set<String> zipcodes = new HashSet<>();
		for (Map.Entry<String, String> entry : nameToZip.entrySet()) {
			zipcodes.add(entry.getValue());
		}

		for (String zipcode : zipcodes) {
			System.out.print("All those who live in " + zipcode + ": ");
			boolean first = true;
			for (Map.Entry<String, String> entry : nameToZip.entrySet()) {
				if (entry.getValue().equals(zipcode)) {
					System.out.print((!first ? ", " : "") + entry.getKey());
					first = false;
				}
			}
			System.out.println();
		}


	}

}
