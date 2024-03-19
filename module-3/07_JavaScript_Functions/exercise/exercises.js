/**
 * Write a function called isAdmitted. It will check entrance
 * scores and return true if the student is admitted and
 * false if rejected. It takes three parameters:
 *
 *     * gpa
 *     * satScore (optional)
 *     * recommendation (optional)
 *
 * Admit them--return true--if:
 * gpa is above 4.0 OR
 * SAT score is above 1300 OR
 * gpa is above 3.0 and they have a recommendation OR
 * SAT score is above 1200 and they have a recommendation
 * OTHERWISE reject it
 *
 * @param {number} gpa the GPA of the student, between 4.2 and 1.0
 * @param {number} [satScore=0] the student's SAT score
 * @param {boolean} [recommendation=false] does the student have a recommendation
 * @returns {boolean} true if they are admitted
 */

function isAdmitted(gpa, satScore=0, recommendation=false) {
    const hasHighGpa = gpa >= 4.0;
    const hasHighSatScore = satScore > 1300;
    const gpaAndRec = (gpa >= 3.0 && recommendation);
    const satAndRec = (satScore > 1200 && recommendation);
    if (hasHighGpa || hasHighSatScore || gpaAndRec || satAndRec) {
        return true;
    }
    return false;
}

/**
 * Write a function called useParameterToFilterArray that accepts a filter function
 * as a parameter. Use this function to filter unfilteredArray and return the result.
 *
 * @param {function} filterFunction the function to filter with
 * @returns {number[]} the filtered array
 */
let unfilteredArray = [1, 2, 3, 4, 5, 6];

function useParameterToFilterArray(filterFunction) {
    return unfilteredArray.filter(filterFunction);
}

/**
 * Write a function called makeNumber that takes two strings
 * of digits, concatenates them together, and returns
 * the value as a number.
 *
 * So if two strings are passed in "42293" and "443", then this function
 * returns the number 42293443.
 *
 * @param {string} first the first string of digits to concatenate
 * @param {string} [second=''] the second string of digits to concatenate
 * @returns {number} the resultant number
 */

function makeNumber(first, second='') {
    return parseInt(first+second);
}

/**
 * Write a function called addAll that takes an unknown number of parameters
 * and adds all of them together. Return the sum.
 *
 * @param {...number} num a series of numbers to add together
 * @returns {number} the sum of all the parameters (or arguments)
 */

function addAll(...number) {
    const numbers = Array.from(arguments);
    let sum = 0;
    for (let i = 0; i < numbers.length; i++) {
        sum += numbers[i];
    }
    return sum;

    // return arguments.reduce((prevTotal, current) => {return prevTotal+current})
}

/*
 * Write and document a function called makeHappy that takes
 * an array and prepends 'Happy ' to the beginning of all the
 * words and returns them as a new array. Use the `map` function.
 */

/**
 * Add's the string 'Happy' to the beginning of each element of a string array.
 * 
 * @param {string[]} stringArr an array of strings 
 * @returns {string[]} array of strings with 'Happy' added to the beginning of each element
 */

function makeHappy(stringArr) {
    return stringArr.map((string) => {return 'Happy ' + string})
}

/*
 * Write and document a function called getFullAddressesOfProperties
 * that takes an array of JavaScript objects. Each object contains the
 * following keys:
 *     * streetNumber
 *     * streetName
 *     * streetType
 *     * city
 *     * state
 *     * zip
 *
 * getFullAddressesOfProperties returns an array of strings. 
 * Each string is a mailing address generated from the data of a single JavaScript object. 
 * 
 * Each mailing address should have the following format:
 *    
 *  streetNumber streetName streetType city state zip
 *
 * Use `map` and an anonymous function.
 */

/**
 * Generates mailing address strings from objects containing information 
 * 
 * @param {object[]} objArr An array of objects that contain the keys "streetNumber",
 * "streetName", "streetType", "city", "state", and "zip". 
 * @return {string[]} Each element in the return array is the mailing address generated from the
 * corresponding string.
 */

function getFullAddressesOfProperties(objArr) {

    let mailingAddresses = [];

    for (let i = 0; i < objArr.length; i++) {
        const currentObj = objArr[i];
        const currentAdr = `${currentObj.streetNumber} ${currentObj.streetName} ${currentObj.streetType} ${currentObj.city} ${currentObj.state} ${currentObj.zip}`;
        // console.log(currentAdr);
        mailingAddresses.push(currentAdr);
    }

    return mailingAddresses;
}

/** 
 * Write and document a function called findLargest that uses `forEach`
 * to find the largest element in an array.
 * The function must work for strings and numbers.
 * 
 * For strings, "largest" means the word coming last in lexographical order.
 * Lexographic is similar to alphabetical order except that 
 * capital letters come before lowercase letters: 
 * 
 * "cat" < "dog" but "Dog" < "cat"
 */
  
 /**
 * Finds the largest element in an array for strings or numbers. 
 * 
 * @param {number[]|string[]} searchArray the array to search
 * @returns {number|string} the number or string that is largest
 **/

 function findLargest(searchArray) {
    let high = searchArray[0];
    searchArray.forEach((element) => 
        { if(element > high){high = element}})
    return high;
 }


/*
 * CHALLENGE
 * Write and document a function called getSumOfSubArrayValues.
 *
 * Take an array of arrays, adds up all sub values, and returns
 * the sum. For example, if you got this array as a parameter:
 * [
 *   [1, 2, 3],
 *   [2, 4, 6],
 *   [5, 10, 15]
 * ];
 *
 * The function returns 48. To do this, you will use two nested `reduce`
 * calls with two anonymous functions.
 *
 * Read the tests to verify you have the correct behavior.
 */

/**
 * Sums all the numbers in a nested array
 * 
 * @param {array[][]} nestedArrays A two dimensional array of values to sum
 * @return {number} Returns the sum of all numbers in the 2D array
 */

function getSumOfSubArrayValues(twoDArray=[[0]]) {

    // return twoDArray.reduce( ((sum, (number = innerArray.reduce((sumInner, number) => {return sumInner + number;}))) => {return sum + number;}));

    return twoDArray.reduce( (previousSum, innerArray) => {console.log(`previousSum: ${previousSum} innerArray: ${innerArray}`); return previousSum + innerArray.reduce((innerSum, currentVal) => {console.log(`innerSum: ${innerSum} currentVal: ${currentVal}`); return innerSum + currentVal;}, 0);}, 0);

}
