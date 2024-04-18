using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static TechElevator.Testing.TestingLibrary;

namespace Exercises
{
    [TestClass]
    public class ExerciseTests
    {
        /*
         Array2List( {"Apple", "Orange", "Banana"} )  ->  ["Apple", "Orange", "Banana"]
         Array2List( {"Red", "Orange", "Yellow"} )  ->  ["Red", "Orange", "Yellow"]
         Array2List( {"Left", "Right", "Forward", "Back"} )  ->  ["Left", "Right", "Forward", "Back"]
         */
        [TestMethod]
        public void Exercise01_Array2List()
        {
            TestGroup happyPath = new TestGroup("Correctly converts an array to a List");

            happyPath.AddTest(new Test(new object[] { new string[] { "Apple", "Orange", "Banana" } }, new List<string> { "Apple", "Orange", "Banana" }));
            happyPath.AddTest(new Test(new object[] { new string[] { "Red", "Orange", "Yellow" } }, new List<string> { "Red", "Orange", "Yellow" }));
            happyPath.AddTest(new Test(new object[] { new string[] { "Left", "Right", "Forward", "Back" } }, new List<string> { "Left", "Right", "Forward", "Back" }));
            happyPath.AddTest(new Test(new object[] { new string[] { "One" } }, new List<string> { "One" }));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath };
            TestSuite test = new TestSuite(testGroups, typeof(Exercises), nameof(Exercises.Array2List), typeof(string[]));
            RunTestSuite(test);
        }

        /*
         Given a list of Strings, return an array containing the same Strings in the same order
         List2Array( ["Apple", "Orange", "Banana"] )  ->  {"Apple", "Orange", "Banana"}
         List2Array( ["Red", "Orange", "Yellow"] )  ->  {"Red", "Orange", "Yellow"}
         List2Array( ["Left", "Right", "Forward", "Back"] )  ->  {"Left", "Right", "Forward", "Back"}
         */
        [TestMethod]
        public void Exercise02_List2Array()
        {
            TestGroup happyPath = new TestGroup("Correctly converts a List to an array");

            happyPath.AddTest(new Test(new object[] { new List<string> { "Apple", "Orange", "Banana" } }, new string[] { "Apple", "Orange", "Banana" }));
            happyPath.AddTest(new Test(new object[] { new List<string> { "Red", "Orange", "Yellow" } }, new string[] { "Red", "Orange", "Yellow" }));
            happyPath.AddTest(new Test(new object[] { new List<string> { "Left", "Right", "Forward", "Back" } }, new string[] { "Left", "Right", "Forward", "Back" }));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath };
            TestSuite test = new TestSuite(testGroups, typeof(Exercises), nameof(Exercises.List2Array), typeof(List<string>));
            RunTestSuite(test);
        }

        /*
         Given an array of Strings, return a List containing the same Strings in the same order
         except for any words that contain exactly 4 characters.
         No4LetterWords( {"Train", "Boat", "Car"} )  ->  ["Train", "Car"]
         No4LetterWords( {"Red", "White", "Blue"} )  ->  ["Red", "White"]
         No4LetterWords( {"Jack", "Jill", "Jane", "John", "Jim"} )  ->  ["Jim"]
         */
        [TestMethod]
        public void Exercise03_No4LetterWords()
        {
            TestGroup happyPath = new TestGroup("Returns List with 4 letter words removed");

            happyPath.AddTest(new Test(new object[] { new string[] { "Train", "Boat", "Car" } }, new List<string> { "Train", "Car" }));
            happyPath.AddTest(new Test(new object[] { new string[] { "Red", "White", "Blue" } }, new List<string> { "Red", "White" }));
            happyPath.AddTest(new Test(new object[] { new string[] { "Jack", "Jill", "Jane", "John", "Jim" } }, new List<string> { "Jim" }));

            TestGroup no4LetterWords = new TestGroup("Handles arrays with no 4 letter words");

            no4LetterWords.AddTest(new Test(new object[] { new string[] { "January", "February", "March" } }, new List<string> { "January", "February", "March" }));
            no4LetterWords.AddTest(new Test(new object[] { new string[] { "April" } }, new List<string> { "April" }));

            TestGroup all4LetterWords = new TestGroup("Handles arrays with all 4 letter words");

            all4LetterWords.AddTest(new Test(new object[] { new string[] { "Left", "Down" } }, new List<string>()));
            all4LetterWords.AddTest(new Test(new object[] { new string[] { "Mars" } }, new List<string>()));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, no4LetterWords, all4LetterWords };
            TestSuite test = new TestSuite(testGroups, typeof(Exercises), nameof(Exercises.No4LetterWords), typeof(string[]));
            RunTestSuite(test);
        }

        /*
         Given an array of ints, divide each int by 2, and return an List of Doubles.
         ArrayInt2ListDouble( {5, 8, 11, 200, 97} ) -> [2.5, 4.0, 5.5, 100, 48.5]
         ArrayInt2ListDouble( {745, 23, 44, 9017, 6} ) -> [372.5, 11.5, 22, 4508.5, 3]
         ArrayInt2ListDouble( {84, 99, 3285, 13, 877} ) -> [42, 49.5, 1642.5, 6.5, 438.5]
         */
        [TestMethod]
        public void Exercise04_ArrayInt2ListDouble()
        {
            TestGroup happyPath = new TestGroup("Correctly converts an int array to a List of Doubles");

            happyPath.AddTest(new Test(new object[] { new int[] { 2, 4, 6, 8 } }, new List<double> { 1.0, 2.0, 3.0, 4.0 }));
            happyPath.AddTest(new Test(new object[] { new int[] { 1, 3, 5, 7 } }, new List<double> { 0.5, 1.5, 2.5, 3.5 }));

            TestGroup zeroAndNegativeNums = new TestGroup("Handles zeroes and negative numbers");

            zeroAndNegativeNums.AddTest(new Test(new object[] { new int[] { -2, 0, 2 } }, new List<double> { -1.0, 0.0, 1.0 }));
            zeroAndNegativeNums.AddTest(new Test(new object[] { new int[] { -11 } }, new List<double> { -5.5 }));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, zeroAndNegativeNums };
            TestSuite test = new TestSuite(testGroups, typeof(Exercises), nameof(Exercises.ArrayInt2ListDouble), typeof(int[]));
            RunTestSuite(test);
        }

        /*
         Given a List of Integers, return the largest value.
         FindLargest( [11, 200, 43, 84, 9917, 4321, 1, 33333, 8997] ) -> 33333
         FindLargest( [987, 1234, 9381, 731, 43718, 8932] ) -> 43718
         FindLargest( [34070, 1380, 81238, 7782, 234, 64362, 627] ) -> 81238
         */
        [TestMethod]
        public void Exercise05_FindLargest()
        {
            TestGroup happyPath = new TestGroup("Correctly finds largest number");

            happyPath.AddTest(new Test(new object[] { new List<int> { 11, 200, 43, 84, 9917, 4321, 1, 33333, 8997 } }, 33333));
            happyPath.AddTest(new Test(new object[] { new List<int> { 3, 2, 1 } }, 3));
            happyPath.AddTest(new Test(new object[] { new List<int> { 1, 2, 3 } }, 3));

            TestGroup allNegativeNums = new TestGroup("Correctly finds largest number when all values are negative");

            allNegativeNums.AddTest(new Test(new object[] { new List<int> { -2, -6, -3 } }, -2));
            allNegativeNums.AddTest(new Test(new object[] { new List<int> { -1 } }, -1));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, allNegativeNums };
            TestSuite test = new TestSuite(testGroups, typeof(Exercises), nameof(Exercises.FindLargest), typeof(List<int>));
            RunTestSuite(test);
        }

        /*
         Given an array of Integers, return a List of Integers containing just the odd values.
         OddOnly( {112, 201, 774, 92, 9, 83, 41872} ) -> [201, 9, 83]
         OddOnly( {1143, 555, 7, 1772, 9953, 643} ) -> [1143, 555, 7, 9953, 643]
         OddOnly( {734, 233, 782, 811, 3, 9999} ) -> [233, 811, 3, 9999]
         */
        [TestMethod]
        public void Exercise06_OddOnly()
        {
            TestGroup happyPath = new TestGroup("Returns correct List with even numbers removed");

            happyPath.AddTest(new Test(new object[] { new int[] { 112, 201, 774, 92, 9, 83, 41872 } }, new int[] { 201, 9, 83 }));
            happyPath.AddTest(new Test(new object[] { new int[] { 1143, 555, 7, 1772, 9953, 643 } }, new int[] { 1143, 555, 7, 9953, 643 }));
            happyPath.AddTest(new Test(new object[] { new int[] { 734, 233, 782, 811, 3, 9999 } }, new int[] { 233, 811, 3, 9999 }));

            TestGroup allOddNums = new TestGroup("Correctly handles input of all odd numbers");

            allOddNums.AddTest(new Test(new object[] { new int[] { 1, 3, 5 } }, new int[] { 1, 3, 5 }));
            allOddNums.AddTest(new Test(new object[] { new int[] { -1, 1 } }, new int[] { -1, 1 }));

            TestGroup allEvenNums = new TestGroup("Correctly handles input of all even numbers");

            allEvenNums.AddTest(new Test(new object[] { new int[] { 2, 4, 6 } }, new int[] { }));
            allEvenNums.AddTest(new Test(new object[] { new int[] { -2, 2 } }, new int[] { }));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, allOddNums };
            TestSuite test = new TestSuite(testGroups, typeof(Exercises), nameof(Exercises.OddOnly), typeof(int[]));
            RunTestSuite(test);
        }

        /*
         Given a List of Integers, and an int value, return true if the int value appears two or more times in
         the list.
	     FoundIntTwice( [5, 7, 9, 5, 11], 5 ) -> true
	     FoundIntTwice( [6, 8, 10, 11, 13], 8 -> false
	     FoundIntTwice( [9, 9, 44, 2, 88, 9], 9) -> true
         */
        [TestMethod]
        public void Exercise07_FoundIntTwice()
        {
            TestGroup happyPath = new TestGroup("Correctly determines if number occurs twice or more");

            happyPath.AddTest(new Test(new object[] { new List<int> { 55, 17, 3, 6, 12 }, 4 }, false));
            happyPath.AddTest(new Test(new object[] { new List<int> { 5, 7, 9, 5, 11 }, 5 }, true));
            happyPath.AddTest(new Test(new object[] { new List<int> { 6, 8, 10, 11, 13 }, 8 }, false));
            happyPath.AddTest(new Test(new object[] { new List<int> { 9, 9, 44, 2, 88, 9 }, 9 }, true));
            happyPath.AddTest(new Test(new object[] { new List<int> { 1 }, 1 }, false));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath };
            TestSuite test = new TestSuite(testGroups, typeof(Exercises), nameof(Exercises.FoundIntTwice), typeof(List<int>), typeof(int));
            RunTestSuite(test);
        }

        /*
         Given an array of Integers, return a List that contains strings.  except any multiple of 3
         should be replaced by the String "Fizz", any multiple of 5 should be replaced by the String "Buzz",
         and any multiple of both 3 and 5 should be replaced by the String "FizzBuzz"
         FizzBuzzList( {1, 2, 3} )  ->  ["1", "2", "Fizz"]
         FizzBuzzList( {4, 5, 6} )  ->  ["4", "Buzz", "Fizz"]
         FizzBuzzList( {7, 8, 9, 10, 11, 12, 13, 14, 15} )  ->  ["7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"]
         */
        [TestMethod]
        public void Exercise08_FizzBuzzList()
        {
            TestGroup happyPath = new TestGroup("Correctly fizzes and buzzes the array");

            happyPath.AddTest(new Test(new object[] { new int[] { 1, 2, 3 } }, new List<string> { "1", "2", "Fizz" }));
            happyPath.AddTest(new Test(new object[] { new int[] { 4, 5, 6 } }, new List<string> { "4", "Buzz", "Fizz" }));
            happyPath.AddTest(new Test(new object[] { new int[] { 7, 8, 9, 10, 11, 12, 13, 14, 15 } }, new List<string> { "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" }));

            TestGroup shortArrays = new TestGroup("Correctly handles short arrays");

            shortArrays.AddTest(new Test(new object[] { new int[] { 1 } }, new List<string> { "1" }));
            shortArrays.AddTest(new Test(new object[] { new int[] { 3 } }, new List<string> { "Fizz" }));
            shortArrays.AddTest(new Test(new object[] { new int[] { 5 } }, new List<string> { "Buzz" }));
            shortArrays.AddTest(new Test(new object[] { new int[] { 15 } }, new List<string> { "FizzBuzz" }));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortArrays };
            TestSuite test = new TestSuite(testGroups, typeof(Exercises), nameof(Exercises.FizzBuzzList), typeof(int[]));
            RunTestSuite(test);
        }

        /*
        Given two lists of Integers, interleave them beginning with the first element in the first list followed
        by the first element of the second. Continue interleaving the elements until all elements have been interwoven.
        Return the new list. If the lists are of unequal lengths, simply attach the remaining elements of the longer
        list to the new list before returning it.
        InterleaveLists( [1, 2, 3], [4, 5, 6] )  ->  [1, 4, 2, 5, 3, 6]
        InterleaveLists( [7, 1, 3], [2, 5, 7, 9] )  ->  [7, 2, 1, 5, 3, 7, 9]
        InterleaveLists( [1, 2, 5, 8, 10], [4, 5, 6] )  ->  [1, 4, 2, 5, 5, 6, 8, 10]
        */
        [TestMethod]
        public void Exercise09_InterleaveLists()
        {
            TestGroup happyPath = new TestGroup("Correctly interleaves same length Lists");

            happyPath.AddTest(new Test(new object[] { new List<int> { 1, 2, 3 }, new List<int> { 4, 5, 6 } }, new List<int> { 1, 4, 2, 5, 3, 6 }));
            happyPath.AddTest(new Test(new object[] { new List<int> { 1 }, new List<int> { 2 } }, new List<int> { 1, 2 }));

            TestGroup firstLonger = new TestGroup("Correctly interleaves Lists when first is longer");

            firstLonger.AddTest(new Test(new object[] { new List<int> { 1, 2, 3, 99 }, new List<int> { 4, 5, 6 } }, new List<int> { 1, 4, 2, 5, 3, 6, 99 }));
            firstLonger.AddTest(new Test(new object[] { new List<int> { 1, 2, 3, 99, 100 }, new List<int> { 4, 5, 6 } }, new List<int> { 1, 4, 2, 5, 3, 6, 99, 100 }));

            TestGroup secondLonger = new TestGroup("Correctly interleaves Lists when second is longer");

            secondLonger.AddTest(new Test(new object[] { new List<int> { 1, 2, 3 }, new List<int> { 4, 5, 6, 99 } }, new List<int> { 1, 4, 2, 5, 3, 6, 99 }));
            secondLonger.AddTest(new Test(new object[] { new List<int> { 1, 2, 3 }, new List<int> { 4, 5, 6, 99, 100 } }, new List<int> { 1, 4, 2, 5, 3, 6, 99, 100 }));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, firstLonger, secondLonger };

            TestSuite test = new TestSuite(testGroups, typeof(Exercises), nameof(Exercises.InterleaveLists), typeof(List<int>), typeof(List<int>));
            RunTestSuite(test);
        }
    }
}
