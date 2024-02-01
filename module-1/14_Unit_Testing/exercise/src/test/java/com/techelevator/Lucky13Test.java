package com.techelevator;


import org.junit.After; // The @After annotation is used to execute a method after every test
import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Before; // The @Before annotation is used to execute a method before every test
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;



@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class Lucky13Test {

    @Test
    public void null_array_should_be_true() {
        Lucky13 test = new Lucky13();

        boolean nullp = test.getLucky(null);

        Assert.assertEquals("When passed a null array, getLucky should return true.", true, nullp);
    }

    @Test
    public void array_with_1_and_array_with_3_and_array_with_1_and_3_all_return_false() {
        //arrange
        Lucky13 test = new Lucky13();

        //act
        boolean has1 = test.getLucky(new int[] {0, 2, 4, 6, 8, 1});
        boolean has3 = test.getLucky(new int[] {0, 4, 2, 4, 4, 3});
        boolean has3and1 = test.getLucky(new int[] {0, 0, 0, 3, 1});

        //assert
        Assert.assertEquals("When getLucky is passed an array that contains a 1, it should return false.",false ,has1);
        Assert.assertEquals("When getLucky is passed an array that contains a 3, it should return false.",false ,has3);
        Assert.assertEquals("When getLucky is passed an array that contains a 1 and a 3, it should return false.",false ,has3and1);
    }

    @Test
    public void arrays_without_1_and_without_3_should_return_true() {
        //arrange
        Lucky13 test = new Lucky13();

        //Act
        boolean clean1 = test.getLucky(new int[] {0, 2, 4, 5, 6, 7, 8, 9, 10});
        boolean clean2 = test.getLucky(new int[] {-1, -2, -3, -4, -5, -6});

        //Arrange
        Assert.assertEquals("When getLucky is passed an array that does not contain a 1 or a 3, it should return true.",true ,clean1);
        Assert.assertEquals("When getLucky is passed an array that does not contain a 1 or a 3 but does contain negative numbers, it should return true.",true ,clean2);

    }



}
