package com.techelevator;

import java.util.Scanner;

public class SpaceMission {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Welcome to the Space (Mars) Mission Simulator!");

        // TODO: Create a MarsSpaceship object called "Starship", heading to "Mars" with an initial fuel level of 100


        boolean missionInProgress = true;
        while (missionInProgress) {
            System.out.println("\n1. Start Engine\n2. Take Off\n3. Land\n4. Stop Engine\n5. Exit Simulation");
            System.out.print("Choose an action: ");
            int choice = scanner.nextInt();

            // TODO: Complete steps 1 - 6
            // Step 1 - Handle choice = 1: start spaceship engine

            // Step 2 - Handle choice = 2: spaceship take off

            // Step 3 - Handle choice = 3: land spaceship

            // Step 4 - Handle choice = 4: stop spaceship engine

            // Step 5 - Handle choice = 5: exit simulation

            // Step 6 - Handle invalid choice - display "Invalid choice. Try again."


        }

        System.out.println("Mission simulation ended.");
    }
}

