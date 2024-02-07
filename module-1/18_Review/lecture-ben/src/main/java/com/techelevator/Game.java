package com.techelevator;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Game {

	private Map<String, Customer> customers = new HashMap<>();
	private Scanner userInput = new Scanner(System.in);

	/**
	 * Construct an app and set it up.
	 */
	public Game() {

		// Initial setup
		customers.put("T1A", new Customer("greasy motercycle dude with fresh blood on arm"));
		customers.put("T1B", new Customer("mousy blonde with bad skin"));
		customers.put("B3A", new Customer("severe looking professor with hair in bun"));
		customers.put("B4B", new Customer("giggly bachelorette with tiara"));
		customers.put("B4A", new Customer("sad bachelorette friend with limp"));
		customers.put("B4C", new Customer("drunk bachelorette friend with dazed look"));
		customers.put("B4D", new Customer("bachelorette friend with low cut top and roving eye"));
		customers.put("HTC", new Customer("ordinary looking guy, too ordinary, with black polished wingtips"));
	}

	public void run() {
		// TODO Command processor
		String verb = "";
		String inputLine;


		do {
			System.out.print("What would you like to do next? ");
			inputLine = userInput.nextLine();
			if (inputLine.length() == 0) {
				continue;
			}
			String[] words = inputLine.split(" ");
			verb = words[0];
			String location = "";

			if (verb.equalsIgnoreCase("look")) {
				look();
			}
			else if (verb.equalsIgnoreCase("help")) {
				help();
			}
			else if (verb.equalsIgnoreCase("save")) {
				save();
			}
			else {
				if (words.length < 2 || words[1].length() == 0) {
					System.out.println("You must specify a location");
					continue;
				}
				location = words[1];

				Customer customer = customers.get(words[1].toUpperCase());

				if (customer == null) {
					System.out.println("You must specify a valid location. If you want a list, use 'look'.");
					continue;
				}

				if (verb.equalsIgnoreCase("pitch")) {
					if (pitch(customer)) {
						System.out.println("Congratulations, you sold insurance to the " + customer.getDescription());
					}
				}

			}
		} while (!verb.equalsIgnoreCase("quit"));

	}

	public boolean look() {
		System.out.println("** Looking around the room **");
		for (Map.Entry<String, Customer> entry : customers.entrySet()) {
			System.out.println(entry.getKey() + " " + entry.getValue().getDescription());
		}
		System.out.println("*************************************");
		return true;
	}

	public boolean help() {
		System.out.println("** Valid commands **");
		System.out.println("look - look around the room");
		System.out.println("pitch loc - picth insurance to the person at location loc");
		System.out.println("*************************************");
		return true;
	}

	public boolean save() {
		File output = new File("room.log");
		try (PrintWriter writer = new PrintWriter(output)) {
			for (Map.Entry<String, Customer> entry : customers.entrySet()) {
				writer.println(entry.getKey() + "," + entry.getValue());
			}
		}
		catch (FileNotFoundException e) {
			System.out.println("Could not open the room.log file");
		}
		return true;
	}

	public boolean pitch(Customer customer) {
		// TODO use some randomization to see if they bought insurance
		return true;
	}
}
