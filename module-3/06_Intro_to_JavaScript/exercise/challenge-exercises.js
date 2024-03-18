/*
1. **iqTest** Bob is preparing to pass an IQ test. The most frequent task in this test 
    is to find out which one of the given numbers differs from the others. Bob observed
    that one number usually differs from the others in evenness. Help Bob — to check his 
    answers, he needs a program that among the given numbers finds one that is different in 
    evenness, and return the position of this number. _Keep in mind that your task is to help 
    Bob solve a real IQ test, which means indexes of the elements start from 1 (not 0)_

		iqTest("2 4 7 8 10") → 3 //third number is odd, while the rest are even
		iqTest("1 2 1 1") → 2 // second number is even, while the rest are odd
		iqTest("") → 0 // there are no numbers in the given set
        iqTest("2 2 4 6") → 0 // all numbers are even, therefore there is no position of an odd number
*/

function iqTest(str) {
    if (str.length === 0) {
        return 0;
    }
    const numArray = str.split(' ');
    let numEven = 0;
    let numOdd = 0;
    for (let i = 0; i < numArray.length; i++) {
        if (numArray[i]%2 == 1) {
            numOdd++
        }
        else {
            numEven++
        }
    }

    const isOnlyOneEven = (numEven===1);
    const isOnlyOneOdd = (numOdd ===1);

    for (element of numArray) {
        if ((isOnlyOneEven && (element%2===0) || (isOnlyOneOdd && (element%2 === 1)))) {
            return numArray.indexOf(element) + 1;
        }
    }
    return 0;
}

/*
2. **titleCase** Write a function that will convert a string into title case, given an optional 
    list of exceptions (minor words). The list of minor words will be given as a string with each 
    word separated by a space. Your function should ignore the case of the minor words string -- 
    it should behave in the same way even if the case of the minor word string is changed.


* First argument (required): the original string to be converted.
* Second argument (optional): space-delimited list of minor words that must always be lowercase
except for the first word in the string. The JavaScript tests will pass undefined when this 
argument is unused.

		titleCase('a clash of KINGS', 'a an the of') // should return: 'A Clash of Kings'
		titleCase('THE WIND IN THE WILLOWS', 'The In') // should return: 'The Wind in the Willows'
        titleCase('the quick brown fox') // should return: 'The Quick Brown Fox'
*/

function titleCase(title, exceptions) {

    let exceptionsArray = [];
    if (exceptions !== undefined) {
        // console.log('splitting exceptions string')
        exceptionsArray = exceptions.split(' ');
    }

    // for(element of exceptionsArray) {
    //     console.log(element + ' ')
    // }


    const titleArray = title.split(' ');

    const returnArray = [capitalize(titleArray[0])];

    for (let i = 1; i < titleArray.length; i++) {

        if (!isInArray(titleArray[i], exceptionsArray)) {
            // console.log(`in if statement for when word is not in exceptions array. adding${capitalize(titleArray[i])} to the returnArray`);
            returnArray.push(capitalize(titleArray[i]));
        }
        else {
            // console.log(`in else statement, word is in exceptions array. adding ${titleArray[i].toLowerCase()} to the returnArray`);
            returnArray.push(titleArray[i].toLowerCase());
        }
    }

    let returnString = '';

    // for (element of returnArray) {
    //     returnString += element + " "
    // }

    for (let i = 0; i < returnArray.length; i++) {
        returnString += returnArray[i];
        if (i != returnArray.length-1) {
            returnString+=' ';
        }
    }
    
    return returnString;

}

function isInArray(word, exceptions) {
    // console.log("in isInArray method")
    if (exceptions.length == 0) {
        // console.log('returning false because no exceptions')
        return false;
    }

    for (let i = 0; i < exceptions.length; i++) {
        if (exceptions[i].toUpperCase() == word.toUpperCase()) {
            // console.log(`word:${word}exceptions[i]:${exceptions[i]}`)
            return true;
        }
    }
    // console.log('returning false')
    return false;
}

function capitalize(word) {
    word = word.toLowerCase();
    const firstLetter = word.charAt(0).toUpperCase();
    if (word.length < 2) { 
        return firstLetter.toUpperCase();
    }
    const restOfWord = word.substring(1, word.length).toLowerCase();
    return firstLetter.toUpperCase() + restOfWord
}
