package com.techelevator;

import org.junit.After; // The @After annotation is used to execute a method after every test
import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Before; // The @Before annotation is used to execute a method before every test
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class NonStartTest {

    @Test
    public void getPartialString_test_null_and_length_of_one_arguments() {
        NonStart test = new NonStart();

        String null1 = test.getPartialString(null, "a");
        String null2 = test.getPartialString("a", null);
        String nullBoth = test.getPartialString(null, null);
        String oneBoth = test.getPartialString("a", "a");

        Assert.assertEquals("When passed one null argument as 'a' and a length one String as 'b', getPartialString does not return an empty String", "", null1);
        Assert.assertEquals("When passed one null argument as 'b' and a length one String as 'a', getPartialString does not return an empty String", "", null2);
        Assert.assertEquals("When passed two null arguments, getPartialString does not return an empty String", "", nullBoth);
        Assert.assertEquals("When passed two length-one arguments, getPartialString does not return an empty String", "", oneBoth);
    }

    @Test
    public void getPartialString_input_cha_and_cha_should_return_haha() {
        NonStart test = new NonStart();

        String haha = test.getPartialString("cha", "cha");

        Assert.assertEquals("When passed \"cha\" and \"cha\", getPartialString does not return \"haha\".", "haha", haha);

    }

    public void getPartialString_input_four_and_twenty_should_return_ourwenty() {
        NonStart test = new NonStart();

        String blazeThaChronic = test.getPartialString("four", "twenty");

        Assert.assertEquals("When passed \"four\" and \"twenty\", getPartialString does not return \"ourwenty\".", "ourwenty", blazeThaChronic);
    }




//    public void getPartialString_returns_argument_Strings_of_length_one_correctly() {
//        NonStart test = new NonStart();
//
//        String oneOne = test.getPartialString("a", "");
//        String oneTwo = test.getPartialString("", "a");
//        String oneBoth = test.getPartialString("a", "a");
//
//        Assert.assertEquals("When passed one null argument as 'a' and an empty String as 'b', getPartialString does not return an empty String", "a", oneOne);
//        Assert.assertEquals("When passed one null argument as 'b' and an empty String as 'a', getPartialString does not return an empty String", "a", oneTwo);
//        Assert.assertEquals("When passed two null arguments, getPartialString does not return an empty String", "aa", oneBoth);
//
//    }


}
