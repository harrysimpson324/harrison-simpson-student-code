package com.techelevator;
import org.junit.After; // The @After annotation is used to execute a method after every test
import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Before; // The @Before annotation is used to execute a method before every test
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class TelevisionTest {

    @Test
    public void changeChannel_plus_two_should_be_three() {
        //arrange
        Television tv = new Television();

        //act
        int actual = tv.changeChannel(2);

        //assert
        Assert.assertEquals(3, actual);
    }

    @Test
    public void changeChannel_plus_four_should_be_one() {
        //arrange
        Television tv = new Television();

        //act
        int actual = tv.changeChannel(4);

        //assert
        Assert.assertEquals(1, actual);
    }


}
