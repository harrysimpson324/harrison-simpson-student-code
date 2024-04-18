using System;
using System.Collections.Generic;
using System.Reflection;
using Exercises.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests.Classes
{
    [TestClass]
    public class HomeworkAssignmentTests
    {
        [TestInitialize]
        public void Setup()
        {
            Type type = Type.GetType(typeof(HomeworkAssignment).AssemblyQualifiedName);
            Assert.IsFalse(type.IsAbstract, "HomeworkAssignment class must not be abstract. Remove the 'abstract' modifier on HomeworkAssignment.");
        }

        [TestMethod]
        public void Homework_HasRequiredProperties()
        {
            Type type = typeof(HomeworkAssignment);

            PropertyInfo[] properties = type.GetProperties();

            PropertyInfo prop = FindPropertyByName(properties, "EarnedMarks");
            PropertyValidator.ValidateReadWrite(prop, "EarnedMarks", typeof(int));

            prop = FindPropertyByName(properties, "PossibleMarks");
            PropertyValidator.ValidateReadWrite(prop, "PossibleMarks", typeof(int));

            prop = FindPropertyByName(properties, "SubmitterName");
            PropertyValidator.ValidateReadWrite(prop, "SubmitterName", typeof(string));


            prop = FindPropertyByName(properties, "LetterGrade");
            PropertyValidator.ValidateReadOnly(prop, "LetterGrade", typeof(string));
        }

        [TestMethod]
        public void HomeworkAssignment_Constructor()
        {
            Type type = typeof(HomeworkAssignment);
            HomeworkAssignment assignment = (HomeworkAssignment)Activator.CreateInstance(type, 100, "Default Name");

            PropertyInfo prop = FindPropertyByName(type.GetProperties(), "PossibleMarks");
            Assert.AreEqual(100, prop.GetValue(assignment), "Passed 100 into constructor and expected PossibleMarks property to return 100");
        }

        [TestMethod]
        public void HomeworkAssignment_LetterGradeTests()
        {
            Type type = typeof(HomeworkAssignment);
            const int PossibleMarks = 200;
            HomeworkAssignment assignment = (HomeworkAssignment)Activator.CreateInstance(type, PossibleMarks, "Default Name");

            PropertyInfo letterProp = FindPropertyByName(type.GetProperties(), "LetterGrade");

            PropertyInfo prop = FindPropertyByName(type.GetProperties(), "EarnedMarks");

            int[] testsForGradeA = { 100, 91, 90 };
            int[] testsForGradeB = { 89, 81, 80 };
            int[] testsForGradeC = { 79, 71, 70 };
            int[] testsForGradeD = { 69, 61, 60 };
            int[] testsForGradeF = { 59, 50, 23, 1, 0 };

            Dictionary<string, int[]> testSuite = new Dictionary<string, int[]>
            {
                { "A", testsForGradeA },
                { "B", testsForGradeB },
                { "C", testsForGradeC },
                { "D", testsForGradeD },
                { "F", testsForGradeF }
            };

            foreach (KeyValuePair<string, int[]> test in testSuite)
            {
                string letterGrade = test.Key;
                int[] testsForGrade = test.Value;
                foreach (int earnedMarks in testsForGrade)
                {
                    prop.SetValue(assignment, earnedMarks * 2);
                    Assert.AreEqual(letterGrade, letterProp.GetValue(assignment), $"Expected {letterGrade} for score of {earnedMarks * 2} out of {PossibleMarks} ({earnedMarks}%)");
                }
            }
        }

        private PropertyInfo FindPropertyByName(PropertyInfo[] properties, string name)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name == name)
                {
                    return properties[i];
                }
            }

            return null;
        }
    }
}
