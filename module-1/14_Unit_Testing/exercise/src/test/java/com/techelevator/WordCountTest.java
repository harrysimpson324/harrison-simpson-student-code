package com.techelevator;


import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;
import java.util.HashMap;
import java.util.Map;


@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class WordCountTest {

    @Test
    public void getCount_returns_empty_Map_when_passed_null_and_empty_arrays() {
        WordCount test = new WordCount();

        Map<String, Integer> emptyNull = test.getCount(null);
        Map<String, Integer> emptyEmpty = test.getCount(new String[0]);

        Assert.assertEquals("When getCount is passed null, it does not return an empty Map.", new HashMap<String, Integer>(), emptyNull);
        Assert.assertEquals("When getCount is passed an empty String array, it does not return an empty Map.", new HashMap<String, Integer>(), emptyEmpty);
    }

    @Test
    public void getCount_returns_correct_Map_when_passed_array_with_null_pointers_in_it() {
        //Arrange
        WordCount test = new WordCount();

        //Act
            //use method to get actual value when last value is null, set up expected Map accordingly
        Map<String, Integer> lastValNull = test.getCount(new String[] {"silver", "silver", "dog", "cat", null});
        Map<String, Integer> lastValNullExpected = new HashMap<>();
        lastValNullExpected.put("silver",2);
        lastValNullExpected.put("dog", 1);
        lastValNullExpected.put("cat", 1);

            //set up a multiple null pointer array of strings
        String[]fourNullsArray = new String[6];
        fourNullsArray[1] = "gold";
        fourNullsArray[5] = "gold";

            //use method on multiple null string array and set up return map accordingly
        Map<String, Integer> fourNulls = test.getCount(fourNullsArray);
        Map<String, Integer> fourNullsExpected = new HashMap<>();
        fourNullsExpected.put("gold", 2);

        //Assert
        Assert.assertEquals("When getCount is passed a String array with the last value being null, it does not return the correct Map.", lastValNullExpected, lastValNull );
        Assert.assertEquals("When getCount is passed a String array with multiple null values and multiple real values, it does not return the correct Map.", fourNullsExpected, fourNulls);
    }


}
