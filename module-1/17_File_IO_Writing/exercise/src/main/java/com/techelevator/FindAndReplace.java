package com.techelevator;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;

public class FindAndReplace {

    // Use this scanner for all user input. Don't create additional Scanners with System.in
    private final Scanner userInput = new Scanner(System.in);

    public static void main(String[] args) {
        FindAndReplace findAndReplace = new FindAndReplace();
        findAndReplace.run();
    }

    public void run() {

        System.out.println("Please type the word you are searching for and then press enter: ");
        String wordToSearch = userInput.nextLine();

        System.out.println("Please type the replacement word and then press enter: ");
        String wordToReplace = userInput.nextLine();

        System.out.println("Please enter the complete file path for the file you want to do find-and-replace on: ");
        String sourceFilePath = userInput.nextLine();

        System.out.println("Please enter the complete file path for where you want the result to go: ");
        String destFilePath = userInput.nextLine();

        File sourceFile = new File(sourceFilePath);
        File destFile = new File(destFilePath);

        try     (
                Scanner sourceReader = new Scanner(sourceFile);
                PrintWriter destPrinter = new PrintWriter(destFile);
                ) {

            //get destination file working (actually printwriter does all that.
//            try {
//                if (!destFile.exists()) {
//                    destFile.createNewFile();
//                } else if (!destFile.isFile()) {
//                    System.out.println("Sorry, the destination file path you entered is not valid. Program has been terminated.");
//                    System.exit(1);
//                }
//
//
//            } catch (IOException e) {
//
//            } catch (SecurityException e) {
//
//            }

            while(sourceReader.hasNextLine()) {
                String lineBeingRead = sourceReader.nextLine();
                lineBeingRead = lineBeingRead.replace(wordToSearch, wordToReplace);
                destPrinter.println(lineBeingRead);
            }





        } catch (FileNotFoundException e) {
            System.out.println("Something went wrong with the entry of the input file path. Program has been terminated.");
            System.exit(1);
        }






    }

}
