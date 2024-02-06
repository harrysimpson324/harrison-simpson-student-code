package com.techelevator;

import java.io.*;
import java.util.Scanner;

public class Lecture {

	public static void main(String[] args) throws IOException {

		Scanner userInput = new Scanner(System.in);

		/*
		 * The java.io.File class is a representation of file and directory path names.  It provides methods to inspect and
		 * modify file system objects.
		 *
		 * One benefit is that it compensates for differences in Windows and Unix use of '/' and '\' as directory delimiters.
		 *
		 * A new instance of File can be created from a String that contains a file system path
		 */

		System.out.println("Enter the path of a file or directory: ");
		String path = userInput.nextLine();
		File f = new File(path);

		System.out.println();

		if (f.exists()) {
			System.out.println("name: " + f.getName());
			if (f.isDirectory()) {
				System.out.println("type: directory");
			}
			else if (f.isFile()) {
				System.out.println("type: file");
			}
			System.out.println("size: " + f.length());
		}
		else {
			System.out.println(f.getAbsolutePath() + " does not exist!");
		}

		System.out.println();
		System.out.println("Let's create a new directory.");
		System.out.println("Entr the path of the new directory: ");
		path = userInput.nextLine();
		File newDirectory = new File(path);

		if (newDirectory.exists()) {
			//System.out.println("Sorry, " + newDirectory.getAbsolutePath() + " already exists.");
			if (newDirectory.isFile()) {
				System.out.println("Sorry, '" + path + "' is a file, so it cannot be a directory");
			}
		}
		else {
			if (newDirectory.mkdir()) {
				System.out.println("New directory created at " + newDirectory.getAbsolutePath());
			}
			else {
				System.out.println("Could not create '" + path + "' directory");
				System.exit(1);
			}
		}

		System.out.println();
		System.out.println("Let's create a file");
		System.out.print("Enter the name of the file to go in the " + newDirectory.getName() + " directory: ");
		String fileName = userInput.nextLine();
		File newFile = new File(newDirectory, fileName);
		if (!newFile.exists()) {
			newFile.createNewFile();
		}

		System.out.println("name: " + newFile.getName());
		System.out.println("absolutePath: " + newFile.getAbsolutePath());
		System.out.println("size: " + newFile.length());

		System.out.println();
		System.out.print("Enter a message to put in the file: ");
		String message = userInput.nextLine();

		// Output version 1 - Overwrites the file by writing a single version of the message
		try (PrintWriter writer = new PrintWriter(newFile)) {
			writer.println(message);
		}

		// Output version 2a - Overwrites the file by writing the message, a line of asterisks,
		//                     and the contents of the file specified uppercased
		try (Scanner input = new Scanner(f); PrintWriter output = new PrintWriter(newFile)) {
			output.println(message);
			output.println("*********************************************");
			while (input.hasNextLine()) {
				String inputLine = input.nextLine();
				output.println(inputLine.toUpperCase());
			}
		}

		// Output version 2b - Appends to the file another line of asterisks and a closing message
		try (PrintWriter output = new PrintWriter(new FileOutputStream(newFile, true))) {
			output.println("*********************************************");
			output.println("I hope you enjoyed the adventure");
		}




		// when we exit the try block, it will close the file and automatically flush

		System.out.println("name: " + newFile.getName());
		System.out.println("absolutePath: " + newFile.getAbsolutePath());
		System.out.println("size: " + newFile.length());







	}

}
