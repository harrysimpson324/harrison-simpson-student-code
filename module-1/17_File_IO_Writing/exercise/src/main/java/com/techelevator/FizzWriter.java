package com.techelevator;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.Scanner;

public class FizzWriter {

	// Use this scanner for all user input. Don't create additional Scanners with System.in
	private final Scanner userInput = new Scanner(System.in);

	public static void main(String[] args) {
		FizzWriter fizzWriter = new FizzWriter();
		fizzWriter.run();
	}

	public void run() {

		System.out.println("Please enter the file path that you would like FizzWriter to write to: ");
		String destFilePath = userInput.nextLine();

		try 	(
				PrintWriter printer = new PrintWriter(new File(destFilePath));
				) {

			for (int i = 1; i <=300; i++ ) {
				if (i%3 == 0 && i%5 == 0) {
					printer.println("FizzBuzz");
				}
				else if(i%5 == 0) {
					printer.println("Buzz");
				}
				else if(i%3 == 0) {
					printer.println("Fizz");
				}
				else {
					printer.println(i);
				}
			}



		} catch (FileNotFoundException e) {
			System.out.println("Sorry, it seems that is an invalid file destination. Program has been terminated.");
			System.exit(1);
		}


	}

}
