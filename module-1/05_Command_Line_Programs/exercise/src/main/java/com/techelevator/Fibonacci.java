package com.techelevator;
import java.util.Scanner;
public class Fibonacci {

	public static void main(String[] args) {

		System.out.println("So you want to see the Fibonacci sequence, huh.");
		System.out.println("Well, alright then. Enter a number and I will display the Fibonacci sequence up to that number: ");

		Scanner user = new Scanner(System.in);

		String inputString = user.nextLine();

		int inputNumber = Integer.parseInt(inputString);

		if(inputNumber <= 0) {
			System.out.println("0, 1");
			return;
		}

//		these ints will hold the newest and 2nd newest fibonacci values, and a temp variable because i think i need one and
//		thats what im trying right this very second

		int lastFib = 1;
		int secondLastFib = 0;
		int temp;
		System.out.print("0, ");

		while(inputNumber >= lastFib) {
			System.out.print(lastFib);
			temp = lastFib;
			lastFib += secondLastFib;
			secondLastFib = temp;
			System.out.print((inputNumber >= lastFib ? ", ": ""));
		}

		//hey alright yeah lets go we did it wooooo

	}

}
