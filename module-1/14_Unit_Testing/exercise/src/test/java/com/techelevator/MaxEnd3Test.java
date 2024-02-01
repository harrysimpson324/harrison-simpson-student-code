package com.techelevator;


import org.junit.After; // The @After annotation is used to execute a method after every test
import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Before; // The @Before annotation is used to execute a method before every test
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class MaxEnd3Test {

    @Test
    public void makeArray_returns_correct_array_when_ends_are_equal() {
        MaxEnd3 test = new MaxEnd3();

        int[] ends = new int[] {3, 11, 3};

        Assert.assertArrayEquals("When passed {3, 11, 3}, makeArray should return {3, 3, 3}.", new int[] {3, 3, 3}, test.makeArray(ends));
    }

    @Test
    public void makeArray_returns_correct_array_when_last_number_higher() {
        MaxEnd3 test = new MaxEnd3();

        int[] ends = new int[]{3, 11, 4};

        Assert.assertArrayEquals("When passed {3, 11, 4}, makeArray should return {4, 4, 4}.", new int[]{4, 4, 4}, test.makeArray(ends));
    }
    @Test
    public void makeArray_returns_correct_array_when_first_number_higher() {
        MaxEnd3 test = new MaxEnd3();

        int[] ends = new int[]{5, 11, 4};

        Assert.assertArrayEquals("When passed {5, 11, 4}, makeArray should return {5, 5, 5}.", new int[]{5, 5, 5}, test.makeArray(ends));
    }

}
