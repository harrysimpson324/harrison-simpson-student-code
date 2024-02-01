package com.techelevator;


import org.junit.After; // The @After annotation is used to execute a method after every test
import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Before; // The @Before annotation is used to execute a method before every test
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class Less20Test {

    @Test
    public void isLessThanMultipleOf20_returns_true_when_passed_279_and_278() {
        Less20 test = new Less20();

        boolean two79 = test.isLessThanMultipleOf20(279);
        boolean two78 = test.isLessThanMultipleOf20(278);

        Assert.assertEquals("isLessThanMultipleOf20 should return true when passed 278",true, two78);
        Assert.assertEquals("isLessThanMultipleOf20 should return true when passed 279",true, two79);
    }

    @Test
    public void isLessThanMultipleOf20_returns_false_when_passed_167_and_170() {
        Less20 test = new Less20();

        boolean one67 = test.isLessThanMultipleOf20(167);
        boolean one70 = test.isLessThanMultipleOf20(170);

        Assert.assertEquals("isLessThanMultipleOf20 should return false when passed 167",false, one67);
        Assert.assertEquals("isLessThanMultipleOf20 should return false when passed 170",false, one70);
    }

    @Test
    public void isLessThanMultipleOf20_returns_false_when_passed_zero() {
        Less20 test = new Less20();

        boolean zero = test.isLessThanMultipleOf20(0);

        Assert.assertEquals("isLessThanMultipleOf20 should return false when passed 0.", false, zero);
    }

}
