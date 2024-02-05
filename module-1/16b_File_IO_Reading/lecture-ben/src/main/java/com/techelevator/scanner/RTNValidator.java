package com.techelevator.scanner;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Scanner;

public class RTNValidator {
	
	private static final int[] CHECKSUM_WEIGHTS = new int[] { 3, 7, 1, 3, 7, 1, 3, 7, 1 };

	public static void main(String[] args) throws FileNotFoundException {

		printApplicationBanner();
		
		File inputFile = getInputFileFromUser();
		try(Scanner fileScanner = new Scanner(inputFile)){
			while (fileScanner.hasNextLine()) {
				String line = fileScanner.nextLine();
				String rtn = line.substring(0, 9);

				if (checksumIsValid(rtn) == false) {
					System.out.println(line);
				}
			}
		}
		catch (FileNotFoundException e) {
			System.out.println(inputFile.getPath() + " + could not be opened or does not exist.");
		}
		catch (IOException e) {
			System.out.println(inputFile.getPath() + " + failed with error " + e.getMessage());
		}






//		Scanner fileScanner;
//		try {
//			fileScanner = new Scanner(inputFile);
//			while (fileScanner.hasNextLine()) {
//				String line = fileScanner.nextLine();
//				String rtn = line.substring(0, 9);
//
//				if (checksumIsValid(rtn) == false) {
//					System.out.println(line);
//				}
//			}
//		}
//		catch (FileNotFoundException e) {
//			System.out.println(inputFile.getPath() + " + could not be opened or does not exist.");
//		}
//		catch (IOException e) {
//			System.out.println(inputFile.getPath() + " + failed with error " + e.getMessage());
//		}
//		finally {
//			if (fileScanner != null) {
//				fileScanner.close();
//			}
//		}
	}

	private static void printApplicationBanner() {
		System.out.println("******************");
		System.out.println("RTN Validator 9000");
		System.out.println("******************");
		System.out.println();
	}

	@SuppressWarnings("resource")
	private static File getInputFileFromUser() {
		Scanner userInput = new Scanner(System.in);
		System.out.print("Please enter path to input file >>> ");
		String path = userInput.nextLine();
		
		File inputFile = new File(path);
		if (!inputFile.exists()) { // checks for the existence of a file
			System.out.println(path+" does not exist");
			System.exit(1); // Ends the program
		} else if (!inputFile.isFile()) {
			System.out.println(path+" is not a file");
			System.exit(1); // Ends the program
		}
		return inputFile;
	}

	private static boolean checksumIsValid(String routingNumber) {
		int checksum = 0;
		for (int i = 0; i < 9; i++) {
			int digit = Integer.parseInt(routingNumber.substring(i, i+1));
			checksum += digit * CHECKSUM_WEIGHTS[i];
		}
		return checksum % 10 == 0;
	}
}
