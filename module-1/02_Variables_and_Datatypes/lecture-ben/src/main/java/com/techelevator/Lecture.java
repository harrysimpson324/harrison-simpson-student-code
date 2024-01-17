package com.techelevator;

public class Lecture {

	public static void main(String[] args) {
		
		/*
		1. Create a variable to hold an int and call it numberOfExercises.
			Then set it to 26.
		*/

		// byte
		//     00000000    number 0
		//     00000001    number 1
		//     00000010    number 2
		//     01111111    number 127
		//     10000001    number -1

		// int
		//     00000000000000000000000000000001    number 1
		//     10000000000000000000000000000001    number -1


		// char is represented using single quotes
		// the letter 'a';
		char myFirstCharVariable = 'a';
		// can't do this --> char char = 'b';

		// camelCase - first letter lowercase, each word afterwards starts with upper (Java variables)
		// PascalCase - first letter uppercase, each word afterwards starts with upper
		// snake_case - words separated by underscore
		// kebab-case - words separated by dashes



		int numberOfExercises;
		numberOfExercises = 26;

		System.out.println(numberOfExercises);

		System.out.println(150);
		System.out.println(150.0);
		numberOfExercises = 20;

		/*
		2. Create a variable to hold a double and call it half.
			Set it to 0.5.
		*/
		double half;
		half = 0.5;
		System.out.println(half);

		/*
		3. Create a variable to hold a String and call it name.
			Set it to "TechElevator".
		*/
		String ourFineCodingBootcamp = "Tech Elevator";

		System.out.println(ourFineCodingBootcamp);


		/*
		4. Create a variable called seasonsOfFirefly and set it to 1.
		*/
		int seasonsOfFirefly = 1;

		System.out.println(seasonsOfFirefly);

		/*
		5. Create a variable called myFavoriteLanguage and set it to "Java".
		*/
		String myFavoriteLanguage = "Java";
		System.out.println(myFavoriteLanguage);

		/*
		6. Create a variable called pi and set it to 3.1416.
		*/
		double pi = 3.1416;

		System.out.println(pi);

		/*
		7. Create and set a variable that holds your name.
		*/
		String myName = "Ben";

		/*
		8. Create and set a variable that holds the number of buttons on your mouse.
		*/
		int numberOfButtons = 2;
		System.out.println(myName + " has a mouse with " + numberOfButtons + " buttons");

		/*
		9. Create and set a variable that holds the percentage of battery left on
		your phone.
		*/
		double percentBattery = 0.25;
		int percentDisplayed = (int) (percentBattery * 100);
		percentBattery = percentDisplayed;


		System.out.println("Battery remaining: " + percentDisplayed + "%");

		double halfOfFive = 5 / 2.0;
		System.out.println(halfOfFive);

		int myResult = (2 + 4) * 5;
		System.out.println("My result is " + myResult);


		/*
		10. Create an int variable that holds the difference between 121 and 27.
		*/
		int differenceBetweenNumbers = 121 - 27;

		/*
		11. Create a double that holds the addition of 12.3 and 32.1.
		*/
		double additionOf = 12.3 + 32.1;

		/*
		12. Create a String that holds your full name.
		*/
		String myFullName = "Ben Langhinrichs";

		/*
		13. Create a String that holds the word "Hello, " concatenated onto your
		name from above.
		*/
		String myGreeting = ("Hello, " + myFullName);
		System.out.println(myGreeting);

		/*
		14. Add " Esquire" onto the end of your full name and save it back to
		the same variable.
		*/
		myFullName = myFullName + " Esquire";

		/*
		15. Now do the same as exercise 14, but use the += operator.
		*/
		// += -= *= /=   shortcut assignment operators
		// a = a + 2   --->   a += 2

		myFullName += " Esquire";
		numberOfButtons += 1;
		numberOfButtons -= 1;
		System.out.println(numberOfButtons);

		//numberOfButtons++;
		System.out.println(++numberOfButtons);
		System.out.println(numberOfButtons);




		/*
		16. Create a variable to hold "Saw" and add a 2 onto the end of it.
		*/
		String movieTitle = "Saw" + 2;

		/*
		17. Add a 0 onto the end of the variable from exercise 16.
		*/
		movieTitle += 0;
		System.out.println(movieTitle);

		/*
		18. What is 4.4 divided by 2.2?
		*/
		System.out.println(4.4 / 2.2);

		/*
		19. What is 5.4 divided by 2?
		*/
		System.out.println(5.4 / 2);

		/*
		20. What is 5 divided by 2?
		*/
		System.out.println(5 / 2);

		/*
		21. What is 5.0 divided by 2?
		*/
		System.out.println(5.0 / 2);

		/*
		22. What is 66.6 divided by 100? Is the answer you get right or wrong?
		*/
		System.out.println(66.6 / 100);

		/*
		23. If I divide 5 by 2, what's my remainder?
		*/
		System.out.println(5 % 2);

		/*
		24. What is 1,000,000,000 * 3?
		*/
		System.out.println(1000000000 * 3L);

		/*
		25. Create a variable that holds a boolean called isDoneWithExercises and
		set it to false.
		*/
		boolean isDoneWithExercises = false;

		/*
		26. Now set isDoneWithExercise to true.
		*/
		isDoneWithExercises = true;
		System.out.println("I am done with exercises. " + isDoneWithExercises);
	}

}
