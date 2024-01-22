package com.techelevator;

import java.util.Scanner;

class DiscountCalculator {

    /**
     * The main method is the start and end of our program
     */
    public static void main(String[] args) {

        Scanner userInput = new Scanner(System.in);

        System.out.println("Welcome to the Discount Calculator");
        System.out.println();

        // Prompt the user for a discount amount
        // The answer needs to be saved as a double
        double discount;
        do {
            System.out.print("Enter the discount amount (w/out percent sign, between 0 and 100): ");
            String discountString = userInput.nextLine();
            discount = Double.parseDouble(discountString);
            //System.out.println("The internal discount amount is " + discount);
        } while (discount < 0.0 || discount > 100.0);
        discount /= 100.00;
        // "21"
        // "2.1"
        // "       21"
        // "2 1"
        // "-21"
        // "2.0"
        //-.20
        // "2"

        // Prompt the user for a series of prices
        System.out.print("Please provide a series of prices (space separated): ");
        String priceString = userInput.nextLine();
        String[] pricesStringArray = priceString.split(" ");

        int newLength = 0;
        for (int i = 0; i < pricesStringArray.length; i++) {
            if (pricesStringArray[i].length() > 0) {
                newLength++;
            }
        }


        double[] prices = new double[newLength];
        int m = 0;
        for (int i = 0; i < pricesStringArray.length; i++) {
            if (pricesStringArray[i].length() > 0) {
                prices[m++] = Double.parseDouble(pricesStringArray[i]);
            }
        }

        for (int i = 0; i < prices.length; i++) {
            System.out.println("Original price: $" + prices[i] + ", Discounted price: $" + (prices[i] - (prices[i] * discount)));
        }







    }

}