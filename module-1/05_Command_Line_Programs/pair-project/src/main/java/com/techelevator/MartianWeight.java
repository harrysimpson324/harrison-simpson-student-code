package com.techelevator;

/*
In case you've ever pondered how much you weigh on Mars, here's the calculation:
 	Wm = We * 0.378
 	where 'Wm' is the weight on Mars, and 'We' is the weight on Earth
 
Write a command line program which accepts a series of Earth weights from the user  
and displays each Earth weight as itself, and its Martian equivalent.

Enter a series of Earth weights (space-separated): 98 235 185
 
 98 lbs. on Earth is 37 lbs. on Mars.
 235 lbs. on Earth is 88 lbs. on Mars.
 185 lbs. on Earth is 69 lbs. on Mars. 
 */


import java.util.Scanner;

public class MartianWeight {

	public static final double EARTH_TO_MARTIAN_WEIGHT = 0.378;

	public static void main(String[] args) {

		Scanner scanner = new Scanner(System.in);

		System.out.print("Hello! Welcome to Martian Weight. Enter as many weights on Earth as you'd like," +
				" separated by spaces: ");
		String inputString = scanner.nextLine();
		String[] stringArray = inputString.split(" ");

		int[] weights = new int[stringArray.length];

		for (int i = 0; i < stringArray.length; i++) {
			weights[i] = Integer.parseInt(stringArray[i]);
		}

		for (int i = 0; i < weights.length; i++) {
			weights[i] *= EARTH_TO_MARTIAN_WEIGHT;
			System.out.println("" + stringArray[i] + " lbs. on Earth is " + weights[i] + " lbs. on Mars.");
		}

	}

}
