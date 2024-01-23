package com.techelevator;

import java.math.BigDecimal;

public class Lecture {

	public static void main(String[] args) {

		//BankAccount bensSavings;
		//bensSavings = new BankAccount("226615423", 200.00, "Ben Langhinrichs");
		//int[] intArray = new int[]{1, 2, 3, 4};
		//int[] intArray2 = {1, 2, 3, 4};

		//String myString = "Fred";
		//String[] arrayOfStrings = { myString };

		//myString = null;
		//System.out.println(arrayOfStrings[0]);
		//System.out.println("The array length is "+ myString.length());




		System.out.println("************************************");
		System.out.println("****** MAKING A STRING OBJECT ******");
		System.out.println("************************************");

		/* The String class gets special treatment in the Java language.  One
		 * example of this is that there is a literal representation of a
		 * String (i.e. characters appearing between two double quotes.  This
		 * is not the case for most classes */

		/* create an new instance of String using a literal */
		String greeting = "Hello, World!";
		System.out.println("greeting is " + greeting);

		
		System.out.println();
		System.out.println("******************************");
		System.out.println("****** MEMBER METHODS ******");
		System.out.println("******************************");
		System.out.println();


		/* Other commonly used methods:
		 *
		 * endsWith
		 * startsWith
		 * indexOf
		 * lastIndexOf
		 * length
		 * substring
		 * toLowerCase
		 * toUpperCase
		 * trim
		 */

		String name = "Obama";
		if (name.startsWith("Ob")) {
			System.out.println("Yay, it started with \"Ob\"");
		}
		if (name.startsWith("OB")) {
			System.out.println("Yay, it started with \"OB\"");
		}
		System.out.println("The 'm' in the name is at " + name.indexOf('m'));
		char first = name.charAt(0);
		char last = name.charAt(name.length()-1);
		System.out.println(name.toLowerCase());
		System.out.println(reverseString(name));
		System.out.println(reverseString(name).toUpperCase());
		String name1 = "Ben Langhinrichs";
		String name2 = "ben LANGHINRICHS";
		if (name1.equals(name2)) {
			System.out.println("Equivalent");
		}

		if (name1 == name2) {
			System.out.println("1) name1 and name 2 do point to the same place");
		} else {
			System.out.println("1) name1 and name2 do not point to the same place");
		}

		name2 = "Ben Langhinrichs";
		if (name1 == name2) {
			System.out.println("2) name1 and name 2 do point to the same place");
		} else {
			System.out.println("2) name1 and name2 do not point to the same place");
		}

		name2 = new String("Ben Langhinrichs");
		if (name1 == name2) {
			System.out.println("3) name1 and name 2 do point to the same place");
		} else {
			System.out.println("3) name1 and name2 do not point to the same place");
		}



		System.out.println();
		System.out.println("**********************");
		System.out.println("****** EQUALITY ******");
		System.out.println("**********************");
		System.out.println();

        char[] helloArray = new char[] { 'H', 'e', 'l', 'l', 'o' };
        String hello1 = new String(helloArray);
        String hello2 = new String(helloArray);

		/* Double equals will compare to see if the two variables, hello1 and
		 * hello2 point to the same object in memory. Are they the same object? */
		if (hello1 == hello2) {
			System.out.println("They are equal!");
		} else {
			System.out.println(hello1 + " is not equal to " + hello2);
		}

		String hello3 = hello1;
		if (hello1 == hello3) {
			System.out.println("hello1 is the same reference as hello3");
		}

		/* So, to compare the values of two objects, we need to use the equals method.
		 * Every object type has an equals method */
		if (hello1.equals(hello2)) {
			System.out.println("They are equal!");
		} else {
			System.out.println(hello1 + " is not equal to " + hello2);
		}

		BigDecimal number1 = new BigDecimal("3.33333333333333333333333333333333");
		double number2 = 3.33333333333333333333333333333333;
		System.out.println(number1.multiply(new BigDecimal("3")));
		System.out.println(number2*3);


	}

	public static String reverseString(String name) {
		char[] reversedName = new char[name.length()];
		int m = 0;
		for (int i = name.length() - 1; i >= 0; i--) {
			reversedName[m++] = name.charAt(i);
		}

		return new String(reversedName);
	}

//	public static String myNewMethod(String name) {
//		if (name == null) {
//			return "Null string";
//		}
//		return name.toUpperCase() + " Esquire";
//	}
}
