using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using TechElevator.Testing;
using static TechElevator.Testing.TestingLibrary;

namespace Exercises.Tests
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void Exercise01_HelloName()
        {
            TestGroup happyPath = new TestGroup("Generates correct hello message");

            happyPath.AddTest(new Test(new object[] { "Bob" }, "Hello Bob!"));
            happyPath.AddTest(new Test(new object[] { "Alice" }, "Hello Alice!"));
            happyPath.AddTest(new Test(new object[] { "" }, "Hello !"));
            happyPath.AddTest(new Test(new object[] { "Hello" }, "Hello Hello!"));
            happyPath.AddTest(new Test(new object[] { "xyz" }, "Hello xyz!"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.HelloName), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise02_MakeAbba()
        {
            TestGroup happyPath = new TestGroup("Generates correct ABBA (first, second, second, first) message");

            happyPath.AddTest(new Test(new object[] { "Hi", "Bye" }, "HiByeByeHi"));
            happyPath.AddTest(new Test(new object[] { "Yo", "Alice" }, "YoAliceAliceYo"));
            happyPath.AddTest(new Test(new object[] { "What", "Up" }, "WhatUpUpWhat"));

            TestGroup emptyStrings = new TestGroup("Handles empty string inputs correctly");
            emptyStrings.AddTest(new Test(new object[] { "A", "" }, "AA"));
            emptyStrings.AddTest(new Test(new object[] { "", "B" }, "BB"));
            emptyStrings.AddTest(new Test(new object[] { "", "" }, ""));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, emptyStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.MakeAbba), typeof(string), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise03_MakeTags()
        {
            TestGroup happyPath = new TestGroup("Generates correct tag and contents");

            happyPath.AddTest(new Test(new object[] { "i", "Yay" }, "<i>Yay</i>"));
            happyPath.AddTest(new Test(new object[] { "i", "Hello" }, "<i>Hello</i>"));
            happyPath.AddTest(new Test(new object[] { "cite", "Yay" }, "<cite>Yay</cite>"));

            TestGroup emptyStrings = new TestGroup("Correctly handles empty string inputs");
            emptyStrings.AddTest(new Test(new object[] { "i", "" }, "<i></i>"));
            emptyStrings.AddTest(new Test(new object[] { "", "B" }, "<>B</>"));
            emptyStrings.AddTest(new Test(new object[] { "", "" }, "<></>"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, emptyStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.MakeTags), typeof(string), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise04_MakeOutWord()
        {
            TestGroup happyPath = new TestGroup("Generates correct string");

            happyPath.AddTest(new Test(new object[] { "<<>>", "Yay" }, "<<Yay>>"));
            happyPath.AddTest(new Test(new object[] { "<<>>", "WooHoo" }, "<<WooHoo>>"));
            happyPath.AddTest(new Test(new object[] { "[[]]", "word" }, "[[word]]"));
            happyPath.AddTest(new Test(new object[] { "ABYZ", "word" }, "ABwordYZ"));

            TestGroup emptyStrings = new TestGroup("Correctly handles empty string inputs");
            emptyStrings.AddTest(new Test(new object[] { "ABCD", "" }, "ABCD"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, emptyStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.MakeOutWord), typeof(string), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise05_ExtraEnd()
        {
            TestGroup happyPath = new TestGroup("Generates correct string");

            happyPath.AddTest(new Test(new object[] { "Hello" }, "lololo"));
            happyPath.AddTest(new Test(new object[] { "ab" }, "ababab"));
            happyPath.AddTest(new Test(new object[] { "Hi" }, "HiHiHi"));
            happyPath.AddTest(new Test(new object[] { "  " }, "      "));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.ExtraEnd), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise06_FirstTwo()
        {
            TestGroup happyPath = new TestGroup("Generates correct string for inputs two or more characters long");

            happyPath.AddTest(new Test(new object[] { "Hello" }, "He"));
            happyPath.AddTest(new Test(new object[] { "abcdefg" }, "ab"));
            happyPath.AddTest(new Test(new object[] { "ab" }, "ab"));
            happyPath.AddTest(new Test(new object[] { "    " }, "  "));

            TestGroup shortStrings = new TestGroup("Generates correct string for inputs less than two characters");

            shortStrings.AddTest(new Test(new object[] { "" }, ""));
            shortStrings.AddTest(new Test(new object[] { "a" }, "a"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.FirstTwo), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise07_FirstHalf()
        {
            TestGroup happyPath = new TestGroup("Generates correct string");

            happyPath.AddTest(new Test(new object[] { "WooHoo" }, "Woo"));
            happyPath.AddTest(new Test(new object[] { "HelloThere" }, "Hello"));
            happyPath.AddTest(new Test(new object[] { "abcdef" }, "abc"));
            happyPath.AddTest(new Test(new object[] { "ab" }, "a"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.FirstHalf), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise08_WithoutEnd()
        {
            TestGroup happyPath = new TestGroup("Generates correct string");

            happyPath.AddTest(new Test(new object[] { "Hello" }, "ell"));
            happyPath.AddTest(new Test(new object[] { "CSharp" }, "Shar"));
            happyPath.AddTest(new Test(new object[] { "coding" }, "odin"));
            happyPath.AddTest(new Test(new object[] { "ab" }, ""));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.WithoutEnd), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise09_ComboString()
        {
            TestGroup happyPath = new TestGroup("Generates correct string");

            happyPath.AddTest(new Test(new object[] { "Hello", "hi" }, "hiHellohi"));
            happyPath.AddTest(new Test(new object[] { "hi", "Hello" }, "hiHellohi"));
            happyPath.AddTest(new Test(new object[] { "aaa", "b" }, "baaab"));

            TestGroup emptyStrings = new TestGroup("Generates correct string with empty inputs");

            emptyStrings.AddTest(new Test(new object[] { "", "hi" }, "hi"));
            emptyStrings.AddTest(new Test(new object[] { "hi", "" }, "hi"));
            emptyStrings.AddTest(new Test(new object[] { "", "a" }, "a"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, emptyStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.ComboString), typeof(string), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise10_NonStart()
        {
            TestGroup happyPath = new TestGroup("Generates correct string");

            happyPath.AddTest(new Test(new object[] { "Hello", "There" }, "ellohere"));
            happyPath.AddTest(new Test(new object[] { "CSharp", "code" }, "Sharpode"));
            happyPath.AddTest(new Test(new object[] { "CSharp", "hasatack" }, "Sharpasatack"));

            TestGroup shortStrings = new TestGroup("Generates correct string using inputs with length of 1");

            shortStrings.AddTest(new Test(new object[] { "a", "bc" }, "c"));
            shortStrings.AddTest(new Test(new object[] { "bc", "a" }, "c"));
            shortStrings.AddTest(new Test(new object[] { "a", "a" }, ""));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.NonStart), typeof(string), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise11_Left2()
        {
            TestGroup happyPath = new TestGroup("Generates correct string");

            happyPath.AddTest(new Test(new object[] { "Hello" }, "lloHe"));
            happyPath.AddTest(new Test(new object[] { "CSharp" }, "harpCS"));
            happyPath.AddTest(new Test(new object[] { "12345678" }, "34567812"));

            TestGroup shortStrings = new TestGroup("Generates correct string using inputs with length of 2");

            shortStrings.AddTest(new Test(new object[] { "ab" }, "ab"));
            shortStrings.AddTest(new Test(new object[] { "XY" }, "XY"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.Left2), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise12_Right2()
        {
            TestGroup happyPath = new TestGroup("Generates correct string");

            happyPath.AddTest(new Test(new object[] { "Hello" }, "loHel"));
            happyPath.AddTest(new Test(new object[] { "CSharp" }, "rpCSha"));
            happyPath.AddTest(new Test(new object[] { "12345678" }, "78123456"));

            TestGroup shortStrings = new TestGroup("Generates correct string using inputs with length of 2");

            shortStrings.AddTest(new Test(new object[] { "ab" }, "ab"));
            shortStrings.AddTest(new Test(new object[] { "XY" }, "XY"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.Right2), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise13_TheEnd()
        {
            TestGroup happyPath = new TestGroup("Generates correct string");

            happyPath.AddTest(new Test(new object[] { "Hello", true }, "H"));
            happyPath.AddTest(new Test(new object[] { "Hello", false }, "o"));
            happyPath.AddTest(new Test(new object[] { "12345678", true }, "1"));
            happyPath.AddTest(new Test(new object[] { "12345678", false }, "8"));

            TestGroup shortStrings = new TestGroup("Generates correct string using inputs with length of 1");

            shortStrings.AddTest(new Test(new object[] { "X", true }, "X"));
            shortStrings.AddTest(new Test(new object[] { "X", false }, "X"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.TheEnd), typeof(string), typeof(bool));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise14_WithoutEnd2()
        {
            TestGroup happyPath = new TestGroup("Generates correct string for inputs 3 characters or longer");

            happyPath.AddTest(new Test(new object[] { "Hello" }, "ell"));
            happyPath.AddTest(new Test(new object[] { "abc" }, "b"));
            happyPath.AddTest(new Test(new object[] { "12345678" }, "234567"));

            TestGroup shortStrings = new TestGroup("Generates correct string for short inputs");

            shortStrings.AddTest(new Test(new object[] { "XY" }, ""));
            shortStrings.AddTest(new Test(new object[] { "X" }, ""));
            shortStrings.AddTest(new Test(new object[] { "" }, ""));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.WithoutEnd2), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise15_MiddleTwo()
        {
            TestGroup happyPath = new TestGroup("Generates correct string for inputs 4 characters or longer");

            happyPath.AddTest(new Test(new object[] { "string" }, "ri"));
            happyPath.AddTest(new Test(new object[] { "code" }, "od"));
            happyPath.AddTest(new Test(new object[] { "12345678" }, "45"));

            TestGroup shortStrings = new TestGroup("Generates correct string for short inputs");

            shortStrings.AddTest(new Test(new object[] { "XY" }, "XY"));
            shortStrings.AddTest(new Test(new object[] { "ab" }, "ab"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.MiddleTwo), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise16_EndsLy()
        {
            TestGroup lyStrings = new TestGroup("Returns true for strings that end in \"ly\"");

            lyStrings.AddTest(new Test(new object[] { "oddly" }, true));
            lyStrings.AddTest(new Test(new object[] { "barely" }, true));
            lyStrings.AddTest(new Test(new object[] { "ly" }, true));

            TestGroup nonLyStrings = new TestGroup("Returns false for strings that don't end in \"ly\"");

            nonLyStrings.AddTest(new Test(new object[] { "oddl" }, false));
            nonLyStrings.AddTest(new Test(new object[] { "bare" }, false));
            nonLyStrings.AddTest(new Test(new object[] { "X" }, false));
            nonLyStrings.AddTest(new Test(new object[] { "" }, false));

            List<TestGroup> testGroups = new List<TestGroup> { lyStrings, nonLyStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.EndsLy), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise17_NTwice()
        {
            TestGroup nonOverlapping = new TestGroup("Returns correct string for non-overlapping substrings");

            nonOverlapping.AddTest(new Test(new object[] { "Hello", 2 }, "Helo"));
            nonOverlapping.AddTest(new Test(new object[] { "Chocolate", 3 }, "Choate"));
            nonOverlapping.AddTest(new Test(new object[] { "Chocolate", 1 }, "Ce"));
            nonOverlapping.AddTest(new Test(new object[] { "Code", 2 }, "Code"));

            TestGroup overlapping = new TestGroup("Returns correct string for overlapping and zero length substrings");

            overlapping.AddTest(new Test(new object[] { "Hello", 4 }, "Hellello"));
            overlapping.AddTest(new Test(new object[] { "Code", 4 }, "CodeCode"));
            overlapping.AddTest(new Test(new object[] { "Anything", 0 }, ""));
            overlapping.AddTest(new Test(new object[] { "", 0 }, ""));

            List<TestGroup> testGroups = new List<TestGroup> { nonOverlapping, overlapping };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.NTwice), typeof(string), typeof(int));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise18_TwoChar()
        {
            TestGroup happyPath = new TestGroup("Returns correct string for n in range");

            happyPath.AddTest(new Test(new object[] { "CSharp", 0 }, "CS"));
            happyPath.AddTest(new Test(new object[] { "CSharp", 4 }, "rp"));
            happyPath.AddTest(new Test(new object[] { "ab", 0 }, "ab"));
            happyPath.AddTest(new Test(new object[] { "1234567890", 8 }, "90"));

            TestGroup outOfRange = new TestingLibrary.TestGroup("Returns first two characters for n not in range");

            outOfRange.AddTest(new Test(new Object[] { "Hello", 5 }, "He"));
            outOfRange.AddTest(new Test(new Object[] { "AB", 1 }, "AB"));
            outOfRange.AddTest(new Test(new Object[] { "ABCDE", -1 }, "AB"));
            outOfRange.AddTest(new Test(new Object[] { "ABCDE", 6 }, "AB"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, outOfRange };
            TestingLibrary.TestSuite test = new TestingLibrary.TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.TwoChar), typeof(String), typeof(int));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise19_MiddleThree()
        {
            TestGroup happyPath = new TestGroup("Extracts correct substring");

            happyPath.AddTest(new Test(new object[] { "Candy" }, "and"));
            happyPath.AddTest(new Test(new object[] { "abc" }, "abc"));
            happyPath.AddTest(new Test(new object[] { "123456789" }, "456"));
            happyPath.AddTest(new Test(new object[] { "abc   123" }, "   "));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.MiddleThree), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise20_HasBad()
        {
            TestGroup hasBad = new TestGroup("Returns true when bad appears at index 0 or 1");

            hasBad.AddTest(new Test(new object[] { "badxx" }, true));
            hasBad.AddTest(new Test(new object[] { "xbadxx" }, true));
            hasBad.AddTest(new Test(new object[] { "bad" }, true));
            hasBad.AddTest(new Test(new object[] { "xbad" }, true));

            TestGroup doesntHaveBad = new TestGroup("Returns false when bad doesn't appear at index 0 or 1");

            doesntHaveBad.AddTest(new Test(new object[] { "Hello" }, false));
            doesntHaveBad.AddTest(new Test(new object[] { "baxd" }, false));
            doesntHaveBad.AddTest(new Test(new object[] { "ba" }, false));
            doesntHaveBad.AddTest(new Test(new object[] { "b" }, false));
            doesntHaveBad.AddTest(new Test(new object[] { "" }, false));

            List<TestGroup> testGroups = new List<TestGroup> { hasBad, doesntHaveBad };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.HasBad), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise21_StringTimes()
        {
            TestGroup happyPath = new TestGroup("Returns correct string for non-empty strings and positive n's");

            happyPath.AddTest(new Test(new object[] { "Hi", 2 }, "HiHi"));
            happyPath.AddTest(new Test(new object[] { "Hi", 3 }, "HiHiHi"));
            happyPath.AddTest(new Test(new object[] { "Hi", 1 }, "Hi"));
            happyPath.AddTest(new Test(new object[] { "X", 10 }, "XXXXXXXXXX"));

            TestGroup doesntHaveBad = new TestGroup("Returns correct string for empty strings and zero n's");

            doesntHaveBad.AddTest(new Test(new object[] { "Hello", 0 }, ""));
            doesntHaveBad.AddTest(new Test(new object[] { "", 0 }, ""));
            doesntHaveBad.AddTest(new Test(new object[] { "", 100 }, ""));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, doesntHaveBad };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.StringTimes), typeof(string), typeof(int));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise22_FrontTimes()
        {
            TestGroup happyPath = new TestGroup("Returns correct string for long inputs and positive n's");

            happyPath.AddTest(new Test(new object[] { "Chocolate", 1 }, "Cho"));
            happyPath.AddTest(new Test(new object[] { "Chocolate", 2 }, "ChoCho"));
            happyPath.AddTest(new Test(new object[] { "1234", 3 }, "123123123"));

            TestGroup shortStrings = new TestGroup("Returns correct string for short inputs and zero n's");

            shortStrings.AddTest(new Test(new object[] { "Ab", 2 }, "AbAb"));
            shortStrings.AddTest(new Test(new object[] { "A", 2 }, "AA"));
            shortStrings.AddTest(new Test(new object[] { "", 100 }, ""));
            shortStrings.AddTest(new Test(new object[] { "Abcd", 0 }, ""));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.FrontTimes), typeof(string), typeof(int));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise23_CountXX()
        {
            TestGroup happyPath = new TestGroup("Returns correct count of xx's");

            happyPath.AddTest(new Test(new object[] { "xx" }, 1));
            happyPath.AddTest(new Test(new object[] { "xxx" }, 2));
            happyPath.AddTest(new Test(new object[] { "xxaxx" }, 2));
            happyPath.AddTest(new Test(new object[] { "aaaxx" }, 1));
            happyPath.AddTest(new Test(new object[] { "xxxxxxxx" }, 7));

            TestGroup noXxs = new TestGroup("Returns zero when no xx's");

            noXxs.AddTest(new Test(new object[] { "xXxXxX" }, 0));
            noXxs.AddTest(new Test(new object[] { "x" }, 0));
            noXxs.AddTest(new Test(new object[] { "" }, 0));
            noXxs.AddTest(new Test(new object[] { "12345" }, 0));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, noXxs };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.CountXX), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise24_DoubleX()
        {
            TestGroup happyPath = new TestGroup("Returns true when first x followed by another x");

            happyPath.AddTest(new Test(new object[] { "xx" }, true));
            happyPath.AddTest(new Test(new object[] { "xxx" }, true));
            happyPath.AddTest(new Test(new object[] { "xxax" }, true));
            happyPath.AddTest(new Test(new object[] { "aaaxx" }, true));
            happyPath.AddTest(new Test(new object[] { "xxxxxxxx" }, true));

            TestGroup noXxs = new TestGroup("Returns false when no x's or first x not followed by an x");

            noXxs.AddTest(new Test(new object[] { "xXxxXxxX" }, false));
            noXxs.AddTest(new Test(new object[] { "x" }, false));
            noXxs.AddTest(new Test(new object[] { "" }, false));
            noXxs.AddTest(new Test(new object[] { "12345" }, false));
            noXxs.AddTest(new Test(new object[] { "12345x" }, false));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, noXxs };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.DoubleX), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise25_StringBits()
        {
            TestGroup happyPath = new TestGroup("Returns correct string from long string inputs");

            happyPath.AddTest(new Test(new object[] { "Hello" }, "Hlo"));
            happyPath.AddTest(new Test(new object[] { "Hi" }, "H"));
            happyPath.AddTest(new Test(new object[] { "Heeololeo" }, "Hello"));
            happyPath.AddTest(new Test(new object[] { "123456" }, "135"));

            TestGroup shortStrings = new TestGroup("Returns correct string from short string inputs");

            shortStrings.AddTest(new Test(new object[] { "H" }, "H"));
            shortStrings.AddTest(new Test(new object[] { "" }, ""));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.StringBits), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise26_StringSplosion()
        {
            TestGroup happyPath = new TestGroup("Returns correct string");

            happyPath.AddTest(new Test(new object[] { "Code" }, "CCoCodCode"));
            happyPath.AddTest(new Test(new object[] { "abc" }, "aababc"));
            happyPath.AddTest(new Test(new object[] { "a" }, "a"));
            happyPath.AddTest(new Test(new object[] { "x" }, "x"));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.StringSplosion), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise27_Last2()
        {
            TestGroup happyPath = new TestGroup("Returns correct string from long string inputs");

            happyPath.AddTest(new Test(new object[] { "hixxhi" }, 1));
            happyPath.AddTest(new Test(new object[] { "xaxxaxaxx" }, 1));
            happyPath.AddTest(new Test(new object[] { "axxxaaxx" }, 2));
            happyPath.AddTest(new Test(new object[] { "xxxx" }, 2));
            happyPath.AddTest(new Test(new object[] { "13121311" }, 0));
            happyPath.AddTest(new Test(new object[] { "1717171" }, 2));

            TestGroup shortStrings = new TestGroup("Returns correct string from short string inputs");

            shortStrings.AddTest(new Test(new object[] { "xx" }, 0));
            shortStrings.AddTest(new Test(new object[] { "x" }, 0));
            shortStrings.AddTest(new Test(new object[] { "" }, 0));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.Last2), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise28_StringX()
        {
            TestGroup happyPath = new TestGroup("Returns correct string from long string inputs");

            happyPath.AddTest(new Test(new object[] { "xxHxix" }, "xHix"));
            happyPath.AddTest(new Test(new object[] { "abxxxcd" }, "abcd"));
            happyPath.AddTest(new Test(new object[] { "xabxxxcdx" }, "xabcdx"));
            happyPath.AddTest(new Test(new object[] { "xxxx" }, "xx"));
            happyPath.AddTest(new Test(new object[] { "abcd" }, "abcd"));

            TestGroup shortStrings = new TestGroup("Returns correct string from short string inputs");

            shortStrings.AddTest(new Test(new object[] { "xx" }, "xx"));
            shortStrings.AddTest(new Test(new object[] { "x" }, "x"));
            shortStrings.AddTest(new Test(new object[] { "ab" }, "ab"));
            shortStrings.AddTest(new Test(new object[] { "a" }, "a"));
            shortStrings.AddTest(new Test(new object[] { "" }, ""));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.StringX), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise29_AltPairs()
        {
            TestGroup happyPath = new TestGroup("Returns correct string from string inputs four and longer");

            happyPath.AddTest(new Test(new object[] { "kitten" }, "kien"));
            happyPath.AddTest(new Test(new object[] { "Chocolate" }, "Chole"));
            happyPath.AddTest(new Test(new object[] { "CodingHorror" }, "Congrr"));
            happyPath.AddTest(new Test(new object[] { "1234" }, "12"));
            happyPath.AddTest(new Test(new object[] { "1234567" }, "1256"));

            TestGroup shortStrings = new TestGroup("Returns correct string from string inputs less than four");

            shortStrings.AddTest(new Test(new object[] { "abc" }, "ab"));
            shortStrings.AddTest(new Test(new object[] { "ab" }, "ab"));
            shortStrings.AddTest(new Test(new object[] { "a" }, "a"));
            shortStrings.AddTest(new Test(new object[] { "" }, ""));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, shortStrings };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.AltPairs), typeof(string));
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise30_StringYak()
        {
            TestGroup happyPath = new TestGroup("Returns correct string from string inputs with one or more yaks");

            happyPath.AddTest(new Test(new object[] { "yakpak" }, "pak"));
            happyPath.AddTest(new Test(new object[] { "pakyak" }, "pak"));
            happyPath.AddTest(new Test(new object[] { "yak123ya" }, "123ya"));
            happyPath.AddTest(new Test(new object[] { "xxyakzz" }, "xxzz"));
            happyPath.AddTest(new Test(new object[] { "yakyakyakyakyak" }, ""));
            happyPath.AddTest(new Test(new object[] { "1234yak5678yak90" }, "1234567890"));

            TestGroup noYaks = new TestGroup("Returns correct string from string inputs with no yaks");

            noYaks.AddTest(new Test(new object[] { "12345678" }, "12345678"));
            noYaks.AddTest(new Test(new object[] { "12" }, "12"));
            noYaks.AddTest(new Test(new object[] { "1" }, "1"));
            noYaks.AddTest(new Test(new object[] { "" }, ""));

            List<TestGroup> testGroups = new List<TestGroup> { happyPath, noYaks };
            TestSuite test = new TestSuite(testGroups, typeof(StringExercises), nameof(StringExercises.StringYak), typeof(string));
            RunTestSuite(test);
        }

    }
}

