package com.techelevator;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.Scanner;

public class FileSplitter {

	// Use this scanner for all user input. Don't create additional Scanners with System.in
	private final Scanner userInput = new Scanner(System.in);

	public static void main(String[] args) {
		FileSplitter fileSplitter = new FileSplitter();
		fileSplitter.run();
	}

	public void run() {

		System.out.println("Please enter the file path of the file-to-be-split: ");
		String filePath = userInput.nextLine();

		System.out.println("What should be the maximum number of lines in the split files? Please enter a number here: ");
		int numLines = Integer.parseInt(userInput.nextLine());

		File toBeSplit = new File(filePath);

		try ( Scanner counter = new Scanner(toBeSplit);
			  Scanner reader = new Scanner(toBeSplit);
			) {

			//find out info about our problem.
			int lineCount = 0;

//			System.out.println(toBeSplit.exists());
//			System.out.println(toBeSplit.isFile());

			while (counter.hasNextLine() && lineCount < 100) {
//				System.out.println(lineCount++);
				lineCount++;
				counter.nextLine();
			}
			counter.close();

			System.out.println("The input file has " + lineCount + " lines of text.");
			System.out.println();
			int numFiles = lineCount / numLines;
			if (lineCount % numLines != 0) {
				numFiles++;
			}
			System.out.println("Since our max number of lines is " + numLines + ", we will need " + numFiles + " files.");

			for (int i = 1; i <= numFiles; i++) {
				try (PrintWriter printer = new PrintWriter(new File(filePath + "-" + i))) {
					for (int j = 1; j <= numLines; j++) {
						if (!reader.hasNextLine()) {
							break;
						}
						String line = reader.nextLine();
						printer.println(line);
					}

				} catch (FileNotFoundException e) {
					System.out.println("Debug ya printwriter in ya for loop, foo.");
				}

			}


		} catch (FileNotFoundException e) {
			System.out.println("Looks like the file path of the file-to-be-split is not valid. Program has been terminated.");
			System.exit(1);
		}






	}

}
