using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class LoopsAndArrayExercisesTests
    {
        //CollectionAssert
        //.AllItemsAreNotNull() - Looks at each item in actual collection for not null
        //.AllItemsAreUnique() - Checks for uniqueness among actual collection
        //.AreEqual() - Checks to see if two collections are equal (same order and quantity)
        //.AreEquivalent() - Checks to see if two collections have same element in same quantity, any order
        //.AreNotEqual() - Opposite of AreEqual
        //.AreNotEquivalent() - Opposite or AreEqualivent
        //.Contains() - Checks to see if collection contains a value/object

        [TestMethod]
        public void MiddleWayTest()
        {
            //middleWay([1, 2, 3], [4, 5, 6]) → [2, 5]
            //middleWay([7, 7, 7], [3, 8, 0]) → [7, 8]
            //middleWay([5, 2, 9], [1, 4, 5]) → [2, 4]

            LoopsAndArrayExercises loopsAndArrayExercises = new LoopsAndArrayExercises();
            int[] a = { 1, 2, 3 };
            int[] b = { 4, 5, 6 };

            int[] result = loopsAndArrayExercises.MiddleWay(a, b);

            CollectionAssert.AreEqual(new int[] { 2, 5 }, result);

            int[] c = { 7, 7, 7 };
            int[] d = { 3, 8, 0 };

            result = loopsAndArrayExercises.MiddleWay(c, d);

            CollectionAssert.AreEqual(new int[] { 7, 8 }, result);
        }
    }
}