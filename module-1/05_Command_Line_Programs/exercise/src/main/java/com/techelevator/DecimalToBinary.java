package com.techelevator;

import java.sql.SQLOutput;
import java.util.Scanner;

public class DecimalToBinary {

	public static void main(String[] args) {

		Scanner user = new Scanner(System.in);
		System.out.println("*******************************************************************************");
		System.out.println("**** Welcome to the world of binary featuring me, your host, Command Line! ****");
		System.out.println("*******************************************************************************");

		String integerString;
		String[] integerStringArray;

		int count = 0;
		int points = 0;

		//Summary: this loop playfully guarantees the user inputted something.

		do {
			if (count++ > 0) {
				System.out.println("Uh oh! Looks like there was an error. If you would like to try again, here are the instructions " +
						(count > 1 ? "however many" : "once") +  " more" + (count > 1 ? "times you need I guess.": "") + ".");
				System.out.println("Additionally, you may enter \"x\" if you wish to stop." );
			}
			else {
				System.out.println("In the world of binary, you must follow the instructions precisely. Our goal is to take our cool" +
						" and normal base-10 numbers that we use every day, and convert them into evil, nasty, binary that us gross COMPUTERS use!");
			}
			System.out.print("Submit as many base-10 integer values as you like, but make sure they are each separated by a space and I, Command Line," +
					" will do your dirty work: ");
			integerString = user.nextLine();
			if (integerString.equals("x")) {
				System.out.println("Thanks for not playing I guess. Command Line, out.");
				return;
			}

			if (count > 9) {
				System.out.println("Congratulations on staying in this interface for so long! That's some commitment to the bit. You get 1 point!");
				points++;
			}
			integerStringArray = integerString.split(" ");

		} while(integerStringArray.length == 0);

		String trick = "";
		int numOfInts = 0;

		// This section of code ensures that blank entries are eliminated and sets up our integer array to be initialized.
		for (int i = 0; i < integerStringArray.length; i++) {
			if (integerStringArray[i].length() > 0 ) {
				numOfInts++;
			}
			else {
				trick = trick.format("You didn't follow the incredibly simple instructions!!! I, Command Line, am very angry >:(" +
						"\nDespite my anger: \n");
			}
		}

		//integer array holding values from the users input is initialized
		int[] intArray = new int[numOfInts];
		int intCounter = 0;

		for(int i = 0; i < integerStringArray.length; i++) {
			if (integerStringArray[i].length() > 0) {
				intArray[intCounter++] = Integer.parseInt(integerStringArray[i]);
			}
		}
		//we have intArray, we just need to write the convert to binary code inside a for loop and iterate through the integer array.
		// we use an array of strings because we're just printing after this and with the binary strategy in the ReadMe prepending strings
		// seems like the easiest way to do this.
		String[] binaries = new String[intArray.length];

		for (int i = 0; i < intArray.length; i++) {
			String binaryVal = "";
			int valueAtIndex = intArray[i];
			do {
				 binaryVal = (valueAtIndex % 2) + binaryVal;
				 valueAtIndex /= 2;
			} while (valueAtIndex/2 != 0);
			// there is an off by one error unless you add what is leftover from valueAtIndex here. If its a zero, we shouldn't see it though.
			if (valueAtIndex != 0) {
				binaries[i] = valueAtIndex + binaryVal;
			}
		}

		//display answers
		System.out.printf("" + (trick.length() > 0 ? trick: "") + "Here are the results of your binary inquiry.\n");
		for(int i = 0; i < intArray.length; i++) {
			System.out.println("Integer you entered: " + intArray[i] + " its binary equivalent: " + binaries[i]);
		}

		if(points > 0) {
			System.out.println("Points don't matter, you silly goose. Get outa here!");
		}


	}

}