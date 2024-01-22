package com.techelevator;

import java.util.Scanner;

/*
 Write a command line program which prompts the user for the total bill, and the amount tendered. It should then
 display the change required.

 Please enter the amount of the bill: 23.65
 Please enter the amount tendered: 100.00
 The change required is 76.35
 */
public class MakeChange {

	public static void main(String[] args) {

		System.out.println("Welcome to Make-A-Change");

		Scanner userInput = new Scanner(System.in);

		System.out.print("Please enter the amount of the bill: ");
		String billString = userInput.nextLine();
		double bill = Double.parseDouble(billString);

		System.out.print("Please enter the amount tendered: ");
		String totalString = userInput.nextLine();
		double total = Double.parseDouble(totalString);

		double changeRequired = ((total*100)-(bill*100))/100;
		System.out.printf("The change required is $%4.2f", changeRequired);

		double[] changeAmounts = {20.0, 10.0, 5.0, 1.00, 0.25, 0.10, 0.05, 0.01};
		int[] amountCount = new int[changeAmounts.length];

		for (int i = 0; i < changeAmounts.length; i++) {
			while (changeRequired >= changeAmounts[i]) {
				changeRequired -= changeAmounts[i];
				amountCount[i]++;
			}
		}

		System.out.println();
		for (int i = 0; i < changeAmounts.length; i++) {
			if (amountCount[i] > 0) {
				if (changeAmounts[i] >= 1.00) {
					System.out.println(amountCount[i] + " $" + (int) changeAmounts[i] + " bill" + (amountCount[i] > 1 ? "s" : ""));
				}
				else {
					System.out.println(amountCount[i] + " $" + changeAmounts[i]);
				}
			}
		}

	}

}
