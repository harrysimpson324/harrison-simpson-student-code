package com.techelevator;


import org.junit.Assert; // The Assert class has static assertion methods for validating test results
import org.junit.Test; // The @Test annotation is used to label methods that should be run as tests
import org.junit.FixMethodOrder;
import org.junit.runners.MethodSorters;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
public class StringBitsTest {
    @Test
    public void getBits_returns_empty_String_when_passed_null() {
        StringBits test = new StringBits();

        String nullp = test.getBits(null);

        Assert.assertEquals("When getBits is passed a null pointer, it should return an empty String.", "", nullp);
    }

    @Test
    public void getBits_returns_empty_String_when_passed_empty_String() {
        StringBits test = new StringBits();

        String empty = test.getBits("");

        Assert.assertEquals("When getBits is passed an empty String, it should return an empty String.", "", empty);
    }


    @Test
    public void getBits_returns_correct_output_when_given_String_values() {
        StringBits test = new StringBits();

//        	 * getBits("Hello") → "Hlo"
//           * getBits("Hi") → "H"
//           * getBits("Heeololeo") → "Hello"

        String testHello = test.getBits("Hello");
        String testHi = test.getBits("Hi");
        String testHeeololeo = test.getBits("Heeololeo");

        Assert.assertEquals("When getBits is passed \"Hello\", it should return \"Hlo\".", "Hlo", testHello);
        Assert.assertEquals("When getBits is passed \"Hi\", it should return \"H\".", "H", testHi);
        Assert.assertEquals("When getBits is passed \"Heeololeo\", it should return \"Hello\".", "Hello", testHeeololeo);
    }




}
