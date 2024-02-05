package com.techelevator;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Locale;
import java.util.Scanner;

public class WordSearch {

	// Use this scanner for all user input. Don't create additional Scanners with System.in
	private final Scanner userInput = new Scanner(System.in);

	public static void main(String[] args) {
		WordSearch wordSearch = new WordSearch();
		wordSearch.run();
	}

	public void run() {


		//keep important data in scope
		String filePath;
		File file;
		Scanner fileReader;
		boolean isCaseSensitive = false;


		while(true) {  // Will need to break in order to stop, or use System.exit. This will demand a correct input
			try {
				System.out.println("What is the name of the file you would like to search, complete with its file path?");
				filePath = userInput.nextLine();
				file = new File(filePath);

				//handle bad inputs, throw exceptions
				if (filePath.equals("x")) {
					System.out.println("Thanks for using WordSearch.");
					System.exit(1);
				} else if (!file.exists()) {
					throw new FileNotFoundException(filePath + " sadly is not real.");
				} else if (!file.isFile()) {
					throw new IllegalArgumentException(filePath + " is not a file (it may be a directory).");
				}

				//From here on, Scanner fileReader has a good file. Escape while loop with guaranteed good file input
				fileReader = new Scanner(file);
				break;
			} catch (FileNotFoundException e) {
				System.out.println(e.getMessage() + " Please try again, or enter \'x\' to close the application.");

			} catch (IllegalArgumentException e) {
				System.out.println(e.getMessage() + " Please try again, or enter \'x\' to close the application. Remember, a file" +
						" that is readable to this application will end in \'.txt\'");

			}
		}

		//get wordToSearchFor from user and guarantee it
		String wordToSearchFor = "";
		boolean isLetter = true;
		while(wordToSearchFor.length() < 1) {

			if (!isLetter) {
				System.out.println("Sorry, that is an invalid entry. Try again!");
				isLetter = false;
			}
			System.out.println("Type the word you are searching for, and then press enter.");
			wordToSearchFor = userInput.nextLine();


		}
		//determine case sensitivity
		String yesOrNo = "";
		boolean hasLoopedOnce = false;
		while (!yesOrNo.equals("Y") && !yesOrNo.equals("N")) {
			if(hasLoopedOnce) {
				System.out.println("Sorry, it seems you didn't enter either a \'Y\' for yes or a \'N\' for no. Please try again.");
			}
			System.out.println("Would you like this search to be case-sensitive? Please enter \'Y\' for yes, or \'N\' for no.");
			yesOrNo = userInput.nextLine();
			hasLoopedOnce = true;
		}
		if(yesOrNo.equals("Y")) {
			isCaseSensitive = true;
		}

		int lineNum = 1;
		while(fileReader.hasNextLine()) {
			String line = fileReader.nextLine();

			if(isCaseSensitive && line.contains(wordToSearchFor)) {
				System.out.println(lineNum + ") " + line);
			}
			else if(!isCaseSensitive && line.toUpperCase().contains(wordToSearchFor.toUpperCase())) {
				System.out.println(lineNum + ") " + line);
			}

			lineNum++;

		}

		fileReader.close();

	}

}
