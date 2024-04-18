using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class StringExercisesTests
    {
        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()

        [TestMethod]
        public void MakeAbbaTest()
        {
         //makeAbba("Hi", "Bye") → "HiByeByeHi"
         //makeAbba("Yo", "Alice") → "YoAliceAliceYo"
         //makeAbba("What", "Up") → "WhatUpUpWhat"

            StringExercises stringExercises = new StringExercises();

            string result = stringExercises.MakeAbba("Hi", "Bye");
            Assert.AreEqual("HiByeByeHi", result);

             result = stringExercises.MakeAbba("Yo", "Alice");
            Assert.AreEqual("YoAliceAliceYo", result);

            Assert.AreEqual("WhatUpUpWhat", stringExercises.MakeAbba("What", "Up"),"Please try agin, cutie!");
        }

        [TestMethod]
        public void FirstTwoTest()
        {
        //firstTwo("Hello") → "He"
        //firstTwo("abcdefg") → "ab"
        //firstTwo("ab") → "ab"

            //Arrange
            StringExercises stringExercises = new StringExercises();

            //Assert
            Assert.AreEqual("He", stringExercises.FirstTwo("Hello"));
            Assert.AreEqual("ab", stringExercises.FirstTwo("abcdefg"));
            Assert.AreEqual("ab", stringExercises.FirstTwo("ab"));

        }



    }
}