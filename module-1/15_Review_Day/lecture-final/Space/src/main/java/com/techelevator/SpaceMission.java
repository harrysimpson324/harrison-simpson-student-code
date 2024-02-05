package com.techelevator;

import java.util.Scanner;

public class SpaceMission {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Welcome to the Mars Mission Simulator!");

        MarsSpaceship spaceship = new MarsSpaceship("Starship", "Earth", "Mars", 100);

        boolean missionInProgress = true;
        while (missionInProgress) {
            System.out.println("\n1. Start Engine\n2. Take Off\n3. Land\n4. Stop Engine\n5. Exit Simulation");
            System.out.print("Choose an action: ");
            int choice = scanner.nextInt();

            switch (choice) {
                case 1:
                    spaceship.startEngine();
                    break;
                case 2:
                    spaceship.takeOff();
                    break;
                case 3:
                    spaceship.land();
                    break;
                case 4:
                    spaceship.stopEngine();
                    break;
                case 5:
                    missionInProgress = false;
                    break;
                default:
                    System.out.println("Invalid choice. Try again.");
            }
        }

        System.out.println("Mission simulation ended.");
    }
}

