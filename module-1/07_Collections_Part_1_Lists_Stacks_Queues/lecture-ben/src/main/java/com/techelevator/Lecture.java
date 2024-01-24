package com.techelevator;

//import java.util.ArrayList;
//import java.util.Collections;
//import java.util.List;
import java.util.*;

public class Lecture {

	public static void main(String[] args) {

		//Integer myNumber = 4;
		//myNumber.

		System.out.println("####################");
		System.out.println("       LISTS");
		System.out.println("####################");
		List<String> names = new ArrayList<>();
		names.add("Frodo");
		names.add("Pippin");
		names.add("Gandalf");
		System.out.println("Names has " + names.size()+ " elements");
		names.add("Sam");
		names.add("Aragorn");
		System.out.println("Names has " + names.size()+ " elements");


		System.out.println("####################");
		System.out.println("Lists are ordered");
		System.out.println("####################");
		for (int i = 0; i < names.size(); i++) {
			System.out.println(names.get(i));
		}


		System.out.println("####################");
		System.out.println("Lists allow duplicates");
		System.out.println("####################");
		names.add("Sam");
		for (int i = 0; i < names.size(); i++) {
			System.out.println(names.get(i));
		}

		System.out.println("####################");
		System.out.println("Lists allow elements to be inserted in the middle");
		System.out.println("####################");
		names.add(2, "Legolas");
		for (int i = 0; i < names.size(); i++) {
			System.out.println(names.get(i));
		}

		System.out.println("####################");
		System.out.println("Lists allow elements to be removed by index");
		System.out.println("####################");

		names.remove(4);
		for (int i = 0; i < names.size(); i++) {
			System.out.println(names.get(i));
		}

		System.out.println("####################");
		System.out.println("Find out if something is already in the List");
		System.out.println("####################");

		boolean inList = names.contains("Samwise");
		System.out.println("Samwise is in the list of names: "+ inList);


		System.out.println("####################");
		System.out.println("Find index of item in List");
		System.out.println("####################");
		int indexOfGandalf = names.indexOf("Gandalf");
		names.set(indexOfGandalf, names.get(indexOfGandalf) + " the White");
		for (int i = 0; i < names.size(); i++) {
			System.out.println(names.get(i));
		}

		System.out.println("####################");
		System.out.println("Lists can be turned into an array");
		System.out.println("####################");
		//String[] stringArray = {"a", "b", "c"};
		String[] namesArray = names.toArray(new String[0]);
		for (int i = 0; i < namesArray.length; i++) {
			System.out.println(namesArray[i]);
		}

		System.out.println("####################");
		System.out.println("Lists can be sorted");
		System.out.println("####################");
		Collections.sort(names);
		for (int i = 0; i < names.size(); i++) {
			System.out.println(names.get(i));
		}

		System.out.println("####################");
		System.out.println("Lists can be reversed too");
		System.out.println("####################");
		Collections.reverse(names);
		for (int i = 0; i < names.size(); i++) {
			System.out.println(names.get(i));
		}

		System.out.println("####################");
		System.out.println("       FOREACH");
		System.out.println("####################");
		System.out.println();
		System.out.println("Regular for loop");
		for (int i = 0; i < names.size(); i++) {
			System.out.println(names.get(i));
		}
		System.out.println();
		System.out.println("For-each style of for loop");
		for (String name : names) {
			System.out.println(name);
		}

		int[] nums = {2, 4, 6, 1, 4};
		int sum = 0;
		for (int num : nums) {
			sum += num;
		}
		System.out.println("The sum is " + sum);

		System.out.println("####################");
		System.out.println("       Stacks");
		System.out.println("####################");
		System.out.println();
		Stack<String> actions = new Stack<>();
		actions.push("Climb the hill");
		actions.push("Pick up the ax");
		actions.push("Chop down the tree");
		actions.push("Burn the wood");
		System.out.println("The size of the stack is " + actions.size());

		System.out.println("The last action is " + actions.pop());
		System.out.println("The size of the stack is " + actions.size());
		System.out.println("The last action is " + actions.peek());
		System.out.println("The size of the stack is " + actions.size());

		System.out.println("####################");
		System.out.println("       Queues");
		System.out.println("####################");
		System.out.println();

		Queue<String> customers = new LinkedList<>();
		customers.offer("Ben");
		customers.offer("Lori");
		customers.offer("Tori");
		System.out.println("The size of the queue is " + customers.size());

		while (customers.size() > 0) {
			System.out.println("Serving " + customers.poll() + " next");
		}

	}
}
