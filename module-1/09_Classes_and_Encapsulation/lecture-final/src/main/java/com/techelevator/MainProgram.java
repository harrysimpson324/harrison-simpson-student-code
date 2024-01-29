package com.techelevator;

import com.techelevator.cardexample.Game;
import com.techelevator.draw.tool.WoodenPencil;

public class MainProgram {

	public static void main(String[] args) {

		// ** Pencil Demo **
		WoodenPencil pencil = new WoodenPencil();
		System.out.println("Pencil length: " + pencil.getLength() + " inches");
		System.out.println("Pencil sharpness: " + pencil.getSharpness());
		System.out.println();

		pencil.sharpen();
		System.out.println("Sharpening...");
		System.out.println("Pencil length: " + pencil.getLength() + " inches");
		System.out.println("Pencil sharpness: " + pencil.getSharpness());
		System.out.println();

		pencil.write();
		System.out.println("Writing...");
		System.out.println("Pencil sharpness: " + pencil.getSharpness());
		System.out.println();

		pencil.sharpen();
		System.out.println("Sharpening...");
		System.out.println("Pencil length: " + pencil.getLength() + " inches");
		System.out.println("Pencil sharpness: " + pencil.getSharpness());
		System.out.println();

		// ** Card Demo **

		// Create a new Game, which sets up the appropriate deck
		Game game = new Game();
		
		// Display the unshuffled deck
		System.out.println("Unshuffled deck:");
		System.out.println(game.getDeck().deckString());
		
		// Shuffle the deck and redisplay
		game.getDeck().shuffle();
		System.out.println("Shuffled deck:");
		System.out.println(game.getDeck().deckString());
		
	}

}
