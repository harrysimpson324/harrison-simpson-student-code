package com.techelevator;

import org.junit.After; // The @After annotation is used to execute a method after every test
import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Before; // The @Before annotation is used to execute a method before every test
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class AnimalGroupNameTest {

    @Test
    public void getHerd_is_case_insensitive() {
        //Arrange
        AnimalGroupName test = new AnimalGroupName();

        //Act
        String everyOther = "ElEpHaNt";
        String lower = "elephant";
        String upper = "ELEPHANT";

        String everyOtherValue = test.getHerd(everyOther);
        String lowerValue = test.getHerd(lower);
        String upperValue = test.getHerd(upper);
        String[] strArray = {everyOtherValue, lowerValue, upperValue};

        //Assert
        Assert.assertArrayEquals("When passed the string \"elephant\" in various cases (upper, lower, random), " +
                "getHerd() did not obtain the correct key.", strArray, new String[] {"Herd", "Herd", "Herd"} );
    }

    @Test
    public void getHerd_returns_unknown_when_passed_null() {
        //Arrange
        AnimalGroupName test = new AnimalGroupName();
        //Act
        String herd = test.getHerd(null);
        //Assert
        Assert.assertEquals("When passed a null pointer, getHerd did not return \"unknown\".", "unknown" , herd);
    }

    @Test
    public void getHerd_returns_unknown_when_passed_empty_String() {
        //Arrange
        AnimalGroupName test = new AnimalGroupName();
        //Act
        String group = test.getHerd("");
        //Assert
        Assert.assertEquals("When passed an empty String, getHerd did not return \"unknown\".", "unknown" , group);
    }

}
