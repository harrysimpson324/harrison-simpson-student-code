using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VariableNaming.Tests
{
    [TestClass]
    public class VariableTests
    {
        static List<Exercise> exercises = new List<Exercise>();

        private enum DataType { WholeNumber, Floating, String }
        private readonly string[] WholeNumberTypes = new string[] { "byte", "int", "long", "short" };
        private readonly string[] FloatingTypes = new string[] { "decimal", "double", "float" };
        private readonly string[] StringTypes = new string[] { "string" };

        [ClassInitialize]
        static public void InitializeExercises(TestContext testContext) // The ClassInitialize method must be static...and should take a single parameter of type TestContext.
        {
            SyntaxAnalysis sa = new SyntaxAnalysis();
            exercises = sa.ParseExercises();
        }

        [TestMethod]
        public void Exercise_01()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 1);
            TestSuite(exercise, DataType.WholeNumber, 3);
        }

        [TestMethod]
        public void Exercise_02()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 2);
            TestSuite(exercise, DataType.WholeNumber, 3);
        }

        [TestMethod]
        public void Exercise_03()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 3);
            TestSuite(exercise, DataType.WholeNumber, 1);
        }

        [TestMethod]
        public void Exercise_04()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 4);
            TestSuite(exercise, DataType.WholeNumber, 2);
        }

        [TestMethod]
        public void Exercise_05()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 5);
            TestSuite(exercise, DataType.WholeNumber, 2);
        }

        [TestMethod]
        public void Exercise_06()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 6);
            TestSuite(exercise, DataType.WholeNumber, 5);
        }

        [TestMethod]
        public void Exercise_07()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 7);
            TestSuite(exercise, DataType.WholeNumber, 1);
        }

        [TestMethod]
        public void Exercise_08()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 8);
            TestSuite(exercise, DataType.WholeNumber, 3);
        }

        [TestMethod]
        public void Exercise_09()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 9);
            TestSuite(exercise, DataType.WholeNumber, 2);
        }

        [TestMethod]
        public void Exercise_10()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 10);
            TestSuite(exercise, DataType.Floating, 0.45, 0.01);
        }

        [TestMethod]
        public void Exercise_11()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 11);
            TestSuite(exercise, DataType.WholeNumber, 55);
        }

        [TestMethod]
        public void Exercise_12()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 12);
            TestSuite(exercise, DataType.Floating, 0.38, 0.01);
        }

        [TestMethod]
        public void Exercise_13()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 13);
            TestSuite(exercise, DataType.WholeNumber, 18);
        }

        [TestMethod]
        public void Exercise_14()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 14);
            TestSuite(exercise, DataType.WholeNumber, 12);
        }

        [TestMethod]
        public void Exercise_15()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 15);
            TestSuite(exercise, DataType.Floating, 4.5, 0.01);
        }

        [TestMethod]
        public void Exercise_16()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 16);
            TestSuite(exercise, DataType.WholeNumber, 9);
        }

        [TestMethod]
        public void Exercise_17()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 17);
            TestSuite(exercise, DataType.WholeNumber, 6);
        }

        [TestMethod]
        public void Exercise_18()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 18);
            TestSuite(exercise, DataType.WholeNumber, 9);
        }

        [TestMethod]
        public void Exercise_19()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 19);
            TestSuite(exercise, DataType.WholeNumber, 48);
        }

        [TestMethod]
        public void Exercise_20()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 20);
            TestSuite(exercise, DataType.WholeNumber, 48);
        }

        [TestMethod]
        public void Exercise_21()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 21);
            TestSuite(exercise, DataType.Floating, 1.98, 0.01);
        }

        [TestMethod]
        public void Exercise_22()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 22);
            TestSuite(exercise, DataType.WholeNumber, 61);
        }

        [TestMethod]
        public void Exercise_23()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 23);
            TestSuite(exercise, DataType.WholeNumber, 23);
        }

        [TestMethod]
        public void Exercise_24()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 24);
            TestSuite(exercise, DataType.WholeNumber, 46);
        }

        [TestMethod]
        public void Exercise_25()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 25);
            TestSuite(exercise, DataType.WholeNumber, 135);
        }

        [TestMethod]
        public void Exercise_26()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 26);
            TestSuite(exercise, DataType.Floating, 3.00, 0.01);
        }

        [TestMethod]
        public void Exercise_27()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 27);
            TestSuite(exercise, DataType.WholeNumber, 7);
        }

        [TestMethod]
        public void Exercise_28()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 28);
            TestSuite(exercise, DataType.WholeNumber, 13);
        }

        [TestMethod]
        public void Exercise_29()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 29);
            TestSuite(exercise, DataType.Floating, 0.46, 0.01);
        }

        [TestMethod]
        public void Exercise_30()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 30);
            TestSuite(exercise, DataType.WholeNumber, 25);
        }

        [TestMethod]
        public void Exercise_31()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 31);
            TestSuite(exercise, DataType.WholeNumber, 48);
        }

        [TestMethod]
        public void Exercise_32()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 32);
            TestSuite(exercise, DataType.WholeNumber, 20);
        }

        [TestMethod]
        public void Exercise_33()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 33);
            TestSuite(exercise, DataType.Floating, 2.00, 0.01);
        }

        [TestMethod]
        public void Exercise_34()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 34);
            TestSuite(exercise, DataType.WholeNumber, 15);
        }

        [TestMethod]
        public void Exercise_35()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 35);
            TestSuite(exercise, DataType.WholeNumber, 323);
        }

        [TestMethod]
        public void Exercise_36()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 36);
            TestSuite(exercise, DataType.WholeNumber, 48);
        }

        [TestMethod]
        public void Exercise_37()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 37);
            TestSuite(exercise, DataType.WholeNumber, 1110);
        }

        [TestMethod]
        public void Exercise_38()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 38);
            TestSuite(exercise, DataType.WholeNumber, 220);
        }

        [TestMethod]
        public void Exercise_39()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 39);
            TestSuite(exercise, DataType.Floating, 12.5, 0.01);
        }

        [TestMethod]
        public void Exercise_40()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 40);
            TestSuite(exercise, DataType.WholeNumber, 5);
        }

        [TestMethod]
        public void Exercise_41()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 41);
            TestSuite(exercise, DataType.WholeNumber, 3);
        }

        [TestMethod]
        public void Exercise_42()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 42);
            TestSuite(exercise, DataType.WholeNumber, 23);
        }

        [TestMethod]
        public void Exercise_43()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 43);
            TestSuite(exercise, DataType.WholeNumber, 40);
        }

        [TestMethod]
        public void Exercise_44()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 44);
            TestSuite(exercise, DataType.WholeNumber, 17);
        }

        [TestMethod]
        public void Exercise_45()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 45);
            TestSuite(exercise, DataType.WholeNumber, 2);
        }

        [TestMethod]
        public void Exercise_46()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 46);
            TestSuite(exercise, DataType.WholeNumber, 14);
        }

        [TestMethod]
        public void Exercise_47()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 47);
            TestSuite(exercise, DataType.WholeNumber, 24);
        }

        [TestMethod]
        public void Exercise_48()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 48);
            TestSuite(exercise, DataType.WholeNumber, 6);
        }

        [TestMethod]
        public void Exercise_49()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 49);
            TestSuite(exercise, DataType.WholeNumber, 1_300_000_000_000);
        }

        [TestMethod]
        public void Exercise_50()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 50);
            TestSuite(exercise, DataType.Floating, 2.4285714285714284, 0.1);
        }

        [TestMethod]
        public void Exercise_51()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 51);
            TestSuite(exercise, DataType.Floating, 5.0432098765432105, 0.01);
        }

        [TestMethod]
        public void Exercise_52()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 52);
            TestSuite(exercise, DataType.String, "Hopper, Grace B.");
        }

        [TestMethod]
        public void Exercise_53()
        {
            Exercise exercise = exercises.FirstOrDefault(x => x.ExerciseId == 53);
            TestSuite(exercise, DataType.WholeNumber, 67);
        }


        // called by all exercises
        private void TestSuite(Exercise exercise, DataType dataType, object expectedValue)
        {
            TestSuite(exercise, dataType, expectedValue, null);
        }

        private void TestSuite(Exercise exercise, DataType dataType, object expectedValue, object delta)
        {
            AssertVariableNaming(exercise.VariableDeclarations);
            AssertConstantNaming(exercise.VariableDeclarations);

            Assert.IsTrue(exercise.VariableDeclarations.Count + exercise.ExpressionStatements.Count > 0, "You should use at least one variable to arrive at the answer. Try using variables to store values described in the problem.");
            AssertLastVarCorrectType(exercise, dataType);

            // The validation logic needs to be different based on the different data types
            if (dataType == DataType.Floating)
            {
                AssertCorrectDecimalResult(exercise, expectedValue, delta);
            }
            else
            {
                AssertCorrectResult(exercise, expectedValue);
            }
        }

        private void AssertVariableNaming(IList<VariableDeclaration> varDecs)
        {
            foreach (VariableDeclaration varDecl in varDecs)
            {
                if (!varDecl.IsConstant)
                {
                    string varName = varDecl.VariableName;
                    Regex regex = new Regex(@"^[a-z]");
                    if (!regex.IsMatch(varName))
                    {
                        Assert.Fail($"Variable name '{varName}' must start with a lowercase character.");
                    }
                    regex = new Regex(@"_+");
                    if (regex.IsMatch(varName))
                    {
                        Assert.Fail($"Variable name '{varName}' must not contain underscore characters.");
                    }
                    Assert.IsTrue(varName.Length >= 2, $"Variable name '{varName}' must be 2 or more characters long.");
                }

            }
        }

        private void AssertConstantNaming(IList<VariableDeclaration> varDecs)
        {
            foreach (VariableDeclaration varDecl in varDecs)
            {
                if (varDecl.IsConstant)
                {
                    string constantName = varDecl.VariableName;
                    Regex regex = new Regex(@"^[A-Z]");
                    if (!regex.IsMatch(constantName))
                    {
                        Assert.Fail($"Constant name '{constantName}' must start with a uppercase character.");
                    }
                    regex = new Regex(@"_+");
                    if (regex.IsMatch(constantName))
                    {
                        Assert.Fail($"Constant name '{constantName}' must not contain underscore characters.");
                    }
                    Assert.IsTrue(constantName.Length >= 2, $"Constant name '{constantName}' must be 2 or more characters long.");
                }
            }
        }

        private void AssertLastVarCorrectType(Exercise exercise, DataType acceptableType)
        {
            string lastVar = GetLastVarName(exercise);
            if (string.IsNullOrWhiteSpace(lastVar))
            {
                Assert.Fail("Exercise does not appear to have a variable defined");
            }

            VariableDeclaration lastVarDec = exercise.VariableDeclarations.First(vd => vd.VariableName == lastVar);
            switch (acceptableType)
            {
                case DataType.WholeNumber:
                    if (!WholeNumberTypes.Any(type => lastVarDec.DataType == type))
                    {
                        Assert.Fail("Your last variable is not the correct type for this problem. You need to store a whole number.");
                    }
                    break;
                case DataType.Floating:
                    if (!FloatingTypes.Any(type => lastVarDec.DataType == type))
                    {
                        Assert.Fail("Your last variable is not the correct type for this problem. You need to store a number with a decimal point.");
                    }
                    break;
                case DataType.String:
                    if (!StringTypes.Any(type => lastVarDec.DataType == type))
                    {
                        Assert.Fail("Your last variable is not the correct type for this problem. You need to store some text.");
                    }
                    break;
            }
        }

        private void AssertCorrectResult(Exercise exercise, object expectedValue)
        {
            //execute student code block
            object codeResult = RunStudentCode(exercise);

            // call ToString() for simple comparison. With ints we shouldn't need more than this
            Assert.AreEqual(expectedValue.ToString(), codeResult.ToString());
        }

        private void AssertCorrectDecimalResult(Exercise exercise, object expectedValue, object delta)
        {
            //execute student code block
            object codeResult = RunStudentCode(exercise);

            if (GetLastVarType(exercise) == "double")
            {
                double dblActualValue = (double)codeResult;
                double dblExpectedValue = (double)expectedValue;
                double dblDelta = (double)delta;
                Assert.AreEqual(dblActualValue, dblExpectedValue, dblDelta);
            }
            else if (GetLastVarType(exercise) == "float")
            {
                // Can't directly cast from System.Single (float) to System.Double (double) so trick it with ToString and Parse
                double dblActualValue = double.Parse(codeResult.ToString());
                double dblExpectedValue = (double)expectedValue;
                double dblDelta = (double)delta;
                Assert.AreEqual(dblActualValue, dblExpectedValue, dblDelta);
            }
            else if (GetLastVarType(exercise) == "decimal")
            {
                decimal decActualValue = decimal.Parse(codeResult.ToString());
                decimal decExpectedValue = decimal.Parse(expectedValue.ToString());
                decimal decDelta = decimal.Parse(delta.ToString());
                if (!(Math.Abs(decActualValue - decExpectedValue) <= Math.Abs(decDelta)))
                {
                    Assert.Fail($"Expected a difference no greater than <{decDelta}> between expected value <{decExpectedValue}> and actual <{decActualValue}>.");
                }
            }
            else
            {
                // The student's last variable could not be parsed to a decimal value. Show them the type instead
                Assert.Fail($"Expected the last variable to be numeric, but it was a {codeResult.GetType().Name}");
            }
        }

        private object RunStudentCode(Exercise exercise)
        {
            string lastVar = GetLastVarName(exercise);

            return Task.Run(async () =>
            {
                var s = await CSharpScript.RunAsync(exercise.OriginalCodeBlock + lastVar); //appending lastVar will return the value of the variable
                return s.ReturnValue;
            }).Result;
        }

        private string GetLastVarName(Exercise exercise)
        {
            //get last variable used
            int maxSpanVar = exercise.VariableDeclarations.Count > 0 ? exercise.VariableDeclarations.Max(v => v.SpanStart) : -1;
            int maxSpanExp = exercise.ExpressionStatements.Count > 0 ? exercise.ExpressionStatements.Max(v => v.SpanStart) : -1;

            string lastVar = string.Empty;
            if (maxSpanVar > maxSpanExp)
            {
                VariableDeclaration declaration = exercise.VariableDeclarations.FirstOrDefault(v => v.SpanStart == maxSpanVar);
                lastVar = declaration.VariableName;
            }
            if (maxSpanExp > maxSpanVar)
            {
                ExpressionStatement statement = exercise.ExpressionStatements.FirstOrDefault(v => v.SpanStart == maxSpanExp);
                lastVar = statement.AssignTo;
            }

            if (string.IsNullOrWhiteSpace(lastVar))
            {
                Assert.Fail("Exercise does not appear to have a variable defined");
            }

            return lastVar;
        }

        private string GetLastVarType(Exercise exercise)
        {
            string lastVar = GetLastVarName(exercise);
            if (string.IsNullOrWhiteSpace(lastVar))
            {
                Assert.Fail("Exercise does not appear to have a variable defined");
            }

            VariableDeclaration lastVarDec = exercise.VariableDeclarations.First(vd => vd.VariableName == lastVar);
            return lastVarDec.DataType;
        }
    }
}
