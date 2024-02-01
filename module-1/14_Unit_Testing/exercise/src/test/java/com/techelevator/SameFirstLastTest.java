package com.techelevator;

import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class SameFirstLastTest {

    @Test
    public void isItTheSame_test_length_1_array_should_be_true() {
        SameFirstLast test = new SameFirstLast();

        boolean length1 = test.isItTheSame(new int[] {1});

        Assert.assertEquals("Any array that contains only 1 element when passed to isItTheSame should evaluate to true.", true, length1);
    }

    @Test
    public void isItTheSame_test_null_array_argument_should_be_false() {
        SameFirstLast test = new SameFirstLast();

        boolean nullp = test.isItTheSame(null);

        Assert.assertEquals("When passed a null pointer array, isItTheSame should evaluate to false.", false, nullp);
    }
    @Test
    public void isItTheSame_given_array_with_same_first_and_last_should_evaluate_true() {
        SameFirstLast test = new SameFirstLast();

        boolean three = test.isItTheSame(new int[] {1, 2, 1});
        boolean four = test.isItTheSame(new int[] {17, 84, 367, 17});
        boolean seven = test.isItTheSame(new int[] {1, 1, 1, 1, 1, 1, 1});

        Assert.assertEquals("When passed {1, 2, 1}, isItTheSame should return true.", true, three);
        Assert.assertEquals("When passed {17, 84, 367, 17}, isItTheSame should return true.", true, four);
        Assert.assertEquals("When passed {1, 1, 1, 1, 1, 1, 1}, isItTheSame should return true.", true, seven);
    }

    @Test
    public void isItTheSame_given_array_with_different_first_and_last_should_evaluate_false() {
        SameFirstLast test = new SameFirstLast();

        boolean three = test.isItTheSame(new int[] {1, 2, 2});
        boolean four = test.isItTheSame(new int[] {17, 84, 367, 18});
        boolean seven = test.isItTheSame(new int[] {1, 1, 1, 1, 1, 1, 3});

        Assert.assertEquals("When passed {1, 2, 2}, isItTheSame should return true.", false, three);
        Assert.assertEquals("When passed {17, 84, 367, 18}, isItTheSame should return true.", false, four);
        Assert.assertEquals("When passed {1, 1, 1, 1, 1, 1, 3}, isItTheSame should return true.", false, seven);
    }



}
