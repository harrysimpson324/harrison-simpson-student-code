package com.techelevator.hotels.services;

import com.techelevator.hotels.model.Currency;
import com.techelevator.hotels.model.Hotel;
import com.techelevator.hotels.model.Review;

import java.util.Scanner;

public class ConsoleService {

    private final Scanner scanner = new Scanner(System.in);

    public int promptForMenuSelection() {
        int menuSelection;
        System.out.print("Please choose an option: ");
        try {
            menuSelection = Integer.parseInt(scanner.nextLine());
        } catch (NumberFormatException e) {
            menuSelection = -1;
        }
        return menuSelection;
    }

    public void printMainMenu() {
        System.out.println();
        System.out.println("----Hotels Main Menu----");
        System.out.println("1: List Hotels");
        System.out.println("2: List Reviews");
        System.out.println("3: Show Details for Hotel ID 1");
        System.out.println("4: List Reviews for Hotel ID 1");
        System.out.println("5: List Hotels with star rating 3");
        System.out.println("6: Public API Query - Currency rates against Canadian dollar");
        System.out.println("0: Exit");
        System.out.println();
    }

    public void printHotels(Hotel[] hotels) {
        System.out.println("--------------------------------------------");
        System.out.println("Hotels");
        System.out.println("--------------------------------------------");
        for (Hotel hotel : hotels) {
            System.out.println(hotel.getId() + ": " + hotel.getName() + " has " + hotel.getRoomsAvailable() + " rooms available");
        }
    }

    public void printHotel(Hotel hotel) {
        System.out.println(hotel.toString());
    }

    public void printReviews(Review[] reviews) {
        for (Review review : reviews) {
            System.out.println(review.toString());
        }
    }

    public void printCurrency(Currency currency) {
        System.out.println("--------------------------------------------");
        System.out.println("Currency rates for " + currency.getCurrencyAbbreviation());
        System.out.println("--------------------------------------------");
        System.out.println("Exchange rate with U.S. dollars: " + currency.getRates().getUsd());
        System.out.println("Exchange rate with euros: " + currency.getRates().getEur());
        System.out.println("Exchange rate with Japanese yen: " + currency.getRates().getYen());

    }

    public void pause() {
        System.out.println("\nPress Enter to continue...");
        scanner.nextLine();
    }

}
