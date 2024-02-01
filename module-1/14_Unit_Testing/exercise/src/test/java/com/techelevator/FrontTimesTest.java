package com.techelevator;

import org.junit.After; // The @After annotation is used to execute a method after every test
import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Before; // The @Before annotation is used to execute a method before every test
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;
@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class FrontTimesTest {

    @Test
    public void test_empty_String_and_null_String_and_0_for_n_edge_cases() {
        //Arrange
        FrontTimes test = new FrontTimes();
        //Act
        String empty = test.generateString("", 3);
        String nullP = test.generateString(null, 1);
        String zeroN = test.generateString("tst", 0);

        //Assert
        Assert.assertEquals("When passed an empty String, generateString should return an empty String.","", empty);
        Assert.assertEquals("When passed a null pointer, generateString should return an empty String.","", nullP);
        Assert.assertEquals("When passed a 0 for n, generateString should return an empty String.","", zeroN);
    }

    @Test
    public void returns_ChaChaCha_when_passed_Change_and_3() {
        FrontTimes test = new FrontTimes();

        String cha = test.generateString("Change", 3);

        Assert.assertEquals("When passed (\"Change\", 3) generateString should return \"ChaChaCha\".","ChaChaCha", cha);
    }


}
