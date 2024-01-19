package com.techelevator;

public class Tutorial {

    public static void main(String[] args) {

        // write your code here

       String[] names = {"its", "johnny"};
       String[] otherNames = names;
       otherNames[0] = "steve";
        System.out.println(names[0]);
    }
}
