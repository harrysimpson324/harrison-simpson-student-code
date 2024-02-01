package com.techelevator;

import org.junit.After; // The @After annotation is used to execute a method after every test
import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Before; // The @Before annotation is used to execute a method before every test
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class CigarPartyTest {

    @Test
    public void below_40_cigars_returns_false() {
        //Arrange
        CigarParty test = new CigarParty();
        //Act
        boolean tooFewWeekend = test.haveParty(39, true);
        boolean tooFewWeekday = test.haveParty(39, false);
        //Assert
        Assert.assertEquals("haveParty(39, true) should evaluate to false", false, tooFewWeekend);
        Assert.assertEquals("haveParty(39, false) should evaluate to false", false, tooFewWeekend);
    }

    @Test
    public void above_60_cigars_when_isWeekend_is_true_returns_true() {
        //Arrange
        CigarParty test = new CigarParty();
        //Act
        boolean tooManyWeekend = test.haveParty(61, true);
        //Assert
        Assert.assertEquals("haveParty(61, true) should evaluate to true", true, tooManyWeekend);
    }

    @Test
    public void above_60_cigars_when_isWeekend_is_false_returns_false() {
        //Arrange
        CigarParty test = new CigarParty();
        //Act
        boolean tooManyWeekday = test.haveParty(61, false);
        //Assert
        Assert.assertEquals("haveParty(61, false) should evaluate to false",false, tooManyWeekday);
    }


}
