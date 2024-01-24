package com.techelevator;

import java.util.ArrayList;
import java.util.List;

public class Exercises {

	/*
	 Note, for-each is preferred, and should be used when possible.
	 */

	/*
	 Given an array of Strings, return an ArrayList containing the same Strings in the same order
	 array2List( {"Apple", "Orange", "Banana"} )  ->  ["Apple", "Orange", "Banana"]
	 array2List( {"Red", "Orange", "Yellow"} )  ->  ["Red", "Orange", "Yellow"]
	 array2List( {"Left", "Right", "Forward", "Back"} )  ->  ["Left", "Right", "Forward", "Back"]
	 */
	public List<String> array2List(String[] stringArray) {
		List<String> stringList = new ArrayList<>();
		for(String item : stringArray) {
			stringList.add(item);
		}
		return stringList;
	}

	/*
	 Given a list of Strings, return an array containing the same Strings in the same order
	 list2Array( ["Apple", "Orange", "Banana"] )  ->  {"Apple", "Orange", "Banana"}
	 list2Array( ["Red", "Orange", "Yellow"] )  ->  {"Red", "Orange", "Yellow"}
	 list2Array( ["Left", "Right", "Forward", "Back"] )  ->  {"Left", "Right", "Forward", "Back"}
	 */
	public String[] list2Array(List<String> stringList) {

		return stringList.toArray(new String[0]);
	}

	/*
	 Given an array of Strings, return an ArrayList containing the same Strings in the same order
	 except for any words that contain exactly 4 characters.
	 no4LetterWords( {"Train", "Boat", "Car"} )  ->  ["Train", "Car"]
	 no4LetterWords( {"Red", "White", "Blue"} )  ->  ["Red", "White"]
	 no4LetterWords( {"Jack", "Jill", "Jane", "John", "Jim"} )  ->  ["Jim"]
	 */
	public List<String> no4LetterWords(String[] stringArray) {
		List<String> returnList = new ArrayList<>();
		for(String item : stringArray) {
			if (item.length() != 4) {
				returnList.add(item);
			}
		}
		return returnList;
	}

	/*
	 Given an array of ints, divide each int by 2, and return an ArrayList of Doubles.
	 arrayInt2ListDouble( {5, 8, 11, 200, 97} ) -> [2.5, 4.0, 5.5, 100, 48.5]
	 arrayInt2ListDouble( {745, 23, 44, 9017, 6} ) -> [372.5, 11.5, 22, 4508.5, 3]
	 arrayInt2ListDouble( {84, 99, 3285, 13, 877} ) -> [42, 49.5, 1642.5, 6.5, 438.5]
	 */
	public List<Double> arrayInt2ListDouble(int[] intArray) {
		List<Double> returnList = new ArrayList<>();
		for(int num : intArray) {
			returnList.add(num/2.0);
		}
		return returnList;
	}

	/*
	 Given a List of Integers, return the largest value.
	 findLargest( [11, 200, 43, 84, 9917, 4321, 1, 33333, 8997] ) -> 33333
	 findLargest( [987, 1234, 9381, 731, 43718, 8932] ) -> 43718
	 findLargest( [-2, -6, -8] ) -> -2
	 */
	public Integer findLargest(List<Integer> integerList) {
		Integer largest = integerList.get(0);

		for (Integer toTest : integerList) {
			if (Integer.compare(toTest, largest) > 0) {
				largest = toTest;
			}
		}

		return largest;
	}

	/*
	 Given an array of Integers, return a List of Integers containing just the odd values.
	 oddOnly( {112, 201, 774, 92, 9, 83, 41872} ) -> [201, 9, 83]
	 oddOnly( {1143, 555, 7, 1772, 9953, 643} ) -> [1143, 555, 7, 9953, 643]
	 oddOnly( {734, 233, 782, 811, 3, 9999} ) -> [233, 811, 3, 9999]
	 */
	public List<Integer> oddOnly(Integer[] integerArray) {

		List<Integer> oddInts = new ArrayList<>();

		for( Integer toTest : integerArray) {
			if(toTest % 2 == 1 || toTest % 2 == -1) {
				oddInts.add(toTest);
			}
		}

		return oddInts;
	}

	/*
	 Given a List of Integers, and an int value, return true if the int value appears two or more times in
	 the list.
	 foundIntTwice( [5, 7, 9, 5, 11], 5 ) -> true
	 foundIntTwice( [6, 8, 10, 11, 13], 8 -> false
	 foundIntTwice( [9, 9, 44, 2, 88, 9], 9) -> true
	 */
	public boolean foundIntTwice(List<Integer> integerList, int intToFind) {

		int count = 0;
		int index = 0;

		while (count < 2) {
			Integer tryGuy = intToFind;

			if (integerList.contains(tryGuy)) {
				integerList.remove(tryGuy);
				count++;
			}
			index++;

			if (index > integerList.size()) {
				return false;
			}
		}


		return true;
	}

	/*
	 Given an array of Integers, return a List that contains the same Integers (as Strings). Except any multiple of 3
	must be replaced by the String "Fizz", any multiple of 5 must be replaced by the String "Buzz",
	and any multiple of both 3 and 5 must be replaced by the String "FizzBuzz."
	** INTERVIEW QUESTION **

	fizzBuzzList( {1, 2, 3} )  ->  ["1", "2", "Fizz"]
	fizzBuzzList( {4, 5, 6} )  ->  ["4", "Buzz", "Fizz"]
	fizzBuzzList( {7, 8, 9, 10, 11, 12, 13, 14, 15} )  ->  ["7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"]

	HINT: To convert an Integer x to a String, you can use x.toString() in your code. For example, if x = 1, then x.toString() returns "1".
	 */
	public List<String> fizzBuzzList(Integer[] integerArray) {

		List<String> returnList = new ArrayList<>();

		for (Integer num : integerArray) {
			if (num % 3 == 0 && num % 5 == 0) {
				returnList.add("FizzBuzz");
			}
			else if (num % 3 == 0) {
				returnList.add("Fizz");
			}
			else if(num % 5 == 0) {
				returnList.add("Buzz");
			}
			else {
				returnList.add(num.toString());
			}
		}

		return returnList;
	}

	/*
	 Given two lists of Integers, interleave them beginning with the first element in the first list followed
	 by the first element of the second. Continue interleaving the elements until all elements have been interwoven.
	 Return the new list. If the lists are of unequal lengths, simply attach the remaining elements of the longer
	 list to the new list before returning it.
	 interleaveLists( [1, 2, 3], [4, 5, 6] )  ->  [1, 4, 2, 5, 3, 6]
     interleaveLists( [7, 1, 3], [2, 5, 7, 9] )  ->  [7, 2, 1, 5, 3, 7, 9]
     interleaveLists( [1, 2, 5, 8, 10], [4, 5, 6] )  ->  [1, 4, 2, 5, 5, 6, 8, 10]
	 */
	public List<Integer> interleaveLists(List<Integer> listOne, List<Integer> listTwo) {
		boolean isListOneBigger = listOne.size() > listTwo.size();

		List<Integer> combinedList = new ArrayList<>();

		//using indexed for loop, i will go up to
		for (int i = 0; i < (isListOneBigger ? listOne.size() : listTwo.size()); i++) {
			//address condition: we are off the end of smaller list two
			if (isListOneBigger && i >= listTwo.size()) {
				combinedList.add(listOne.get(i));
			}
			//address condition: we are off the end of smaller list one
			else if (!isListOneBigger && i >= listOne.size()) {
				combinedList.add(listTwo.get(i));
			}
			//all other conditions: add list one then add list two
			else {
				combinedList.add(listOne.get(i));
				combinedList.add(listTwo.get(i));
			}
		}
		return combinedList;
	}

}
