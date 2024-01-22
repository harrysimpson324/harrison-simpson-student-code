package com.techelevator;
import java.util.Scanner;
public class LinearConvert {

	public static final double METERS_TO_FEET = 3.2808399;
	public static final double FEET_TO_METERS = 0.3048;

	public static void main(String[] args) {

		Scanner user = new Scanner(System.in);

		System.out.println("Welcome to the handy-dandy feet-to-meters or meters-to-feet calculator. ");
		System.out.print("Please enter the length that you wish to convert: ");
		String inputLengthString = user.nextLine();
		System.out.print("Is this measurement in (m)eters, or (f)eet?");
		String inputTypeString = user.nextLine();

		double lengthOG = Double.parseDouble(inputLengthString);

		if (inputTypeString.equals("f")) {
			System.out.printf("" + ((int)lengthOG) + " feet is " + ((int) (lengthOG*FEET_TO_METERS)) + " meters" );
		}
		else {
			System.out.printf("" + (int)lengthOG + " meters is " + ((int) (lengthOG*METERS_TO_FEET)) + " feet");
		}


	}

}
