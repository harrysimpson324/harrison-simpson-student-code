package com.techelevator;

import org.junit.After; // The @After annotation is used to execute a method after every test
import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Before; // The @Before annotation is used to execute a method before every test
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;


@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class DateFashionTest {
    @Test
    public void either_you_or_date_are_very_stylish_should_be_2() {
        //Arrange
        DateFashion test = new DateFashion();
        //Act
        int meStylin = test.getATable(8, 5);
        int herStylin = test.getATable(5, 8);
        int mePerfect = test.getATable(10, 5);
        int herPerfect = test.getATable(5, 10);
        //Assert
        Assert.assertEquals("getATable(8, 5) should evaluate to 2.", 2, meStylin);
        Assert.assertEquals("getATable(5, 8) should evaluate to 2.", 2, herStylin);
        Assert.assertEquals("getATable(10, 5) should evaluate to 2.", 2, mePerfect);
        Assert.assertEquals("getATable(5, 10) should evaluate to 2.", 2, herPerfect);

    }

    @Test
    public void stylishness_out_of_0_to_10_range() {
        //Arrange
        DateFashion test = new DateFashion();
        //Act
        int meTooHigh = test.getATable(11, 5);
        int herTooHigh = test.getATable(5, 11);
        int meTooLow = test.getATable(-1, 5);
        int herTooLow = test.getATable(5, -1);
        //Assert
        Assert.assertEquals("getATable(11, 5) should evaluate to -1.", -1, meTooHigh);
        Assert.assertEquals("getATable(5, 11) should evaluate to -1.", -1, herTooHigh);
        Assert.assertEquals("getATable(-1, 5) should evaluate to -1.", -1, meTooLow);
        Assert.assertEquals("getATable(5, -1) should evaluate to -1.", -1, herTooLow);

    }

    @Test
    public void if_either_of_us_are_low_style_should_evaluate_0() {
        DateFashion test = new DateFashion();

        int meVibeKiller = test.getATable(0, 10);
        int herVibeKiller = test.getATable(10, 0);

        Assert.assertEquals("getATable(1, 10) should evaluate to 0.", 0, meVibeKiller);
        Assert.assertEquals("getATable(10, 1) should evaluate to 0.", 0, herVibeKiller);
    }

    @Test
    public void middling_style_should_evaluate_to_1() {
        DateFashion test = new DateFashion();

        int middle = test.getATable(7, 3);

        Assert.assertEquals("getTable(3,7) should evaluate to 1.", 1, middle);
    }

}
