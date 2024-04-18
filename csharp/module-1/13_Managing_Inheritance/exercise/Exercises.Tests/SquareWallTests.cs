using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Security;

namespace Exercises.Tests
{
    [TestClass]
    public class SquareWallTests
    {
        private static readonly Type typeSquare = SafeReflection.GetType("SquareWall", "Exercises");
        private static readonly Type typeRectangle = SafeReflection.GetType("RectangleWall", "Exercises");
        private static readonly Type typeWall = SafeReflection.GetType("Wall", "Exercises");

        [TestMethod]
        public void ConstructorSetsTheProperties()
        {
            object subject = SafeReflection.CreateInstance(typeSquare, new object[] { "TEST", "TESTCOLOR", 23 });
            Assert.IsNotNull(subject);

            object subjectName = SafeReflection.GetPropertyValue(subject, "Name");
            object subjectColor = SafeReflection.GetPropertyValue(subject, "Color");
            object subjectLength = SafeReflection.GetPropertyValue(subject, "Length");
            object subjectHeight = SafeReflection.GetPropertyValue(subject, "Height");

            Assert.AreEqual("TEST", subjectName);
            Assert.AreEqual("TESTCOLOR", subjectColor);
            Assert.AreEqual(23, subjectLength);
            Assert.AreEqual(23, subjectHeight);
        }

        [TestMethod]
        public void ItIsAWall()
        {
            object subject = SafeReflection.CreateInstance(typeSquare, new object[] { "TEST", "TESTCOLOR", 1 });
            Assert.IsInstanceOfType(subject, typeWall);
        }

        [TestMethod]
        public void ItIsARectangleWall()
        {
            object subject = SafeReflection.CreateInstance(typeSquare, new object[] { "TEST", "TESTCOLOR", 1 });
            Assert.IsInstanceOfType(subject, typeRectangle);
        }

        [TestMethod]
        public void TestHasNoUnneededPropertiesOrMethods()
        {
            try
            {
                FieldInfo[] fields = typeSquare.GetFields(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic);
                if (fields.Length > 0)
                {
                    Assert.Fail("SquareWall must not contain any properties");
                }

                MethodInfo[] methods = typeSquare.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic);
                if (methods.Length > 1 || (methods.Length == 1 && methods[0].Name != "ToString"))
                {
                    Assert.Fail("SquareWall must not contain methods besides the constructor and ToString()");
                }
            }
            catch (SecurityException e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void GetAreaCalculatesCorrectArea()
        {
            object subject = SafeReflection.CreateInstance(typeSquare, new object[] { "TEST", "TESTCOLOR", 3 });
            object area = SafeReflection.InvokeMethod(subject, "GetArea", null);
            Assert.AreEqual(9, area);
        }

        [TestMethod]
        public void ToStringReturnsTheFormattedString()
        {
            object subject = SafeReflection.CreateInstance(typeSquare, new object[] { "TEST", "TESTCOLOR", 3 });
            Assert.AreEqual("TEST (3x3) square", subject.ToString());
        }
    }
}
