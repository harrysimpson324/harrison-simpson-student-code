using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace FileIOWriting.Tests
{
    [TestClass]
    public class FindAndReplaceTests
    {
        private static string testSourceFile;
        private static string testDestFile;

        [ClassInitialize]
        static public void Initialize(TestContext testContext) // The ClassInitialize method must be static...and should take a single parameter of type TestContext.
        {
            testSourceFile = $"{Environment.CurrentDirectory}/DonQuixote.txt";
            testDestFile = $"{Environment.CurrentDirectory}/DonQuixote_replace.txt";
        }

        [TestMethod]
        public void ShouldReplaceNoOccurrences()
        {
            string searchWord = "selfie";
            string replaceWord = "windmills";

            RunProgram(searchWord, replaceWord);

            Assert.IsTrue(File.Exists(testDestFile));

            string srcContent = ReadFileAndNormalize(testSourceFile);
            string destContent = ReadFileAndNormalize(testDestFile);

            string expectedContent = srcContent.Replace(searchWord, replaceWord);

            Assert.AreEqual(expectedContent.Trim(), destContent.Trim(), "Expected output does not equal actual output.");

            // delete test output file
            if (File.Exists(testDestFile))
            {
                File.Delete(testDestFile);
            }
        }

        [TestMethod]
        public void ShouldReplaceOneOccurrence()
        {
            string searchWord = "great-grandfather";
            string replaceWord = "nephew";

            RunProgram(searchWord, replaceWord);

            Assert.IsTrue(File.Exists(testDestFile));

            string srcContent = ReadFileAndNormalize(testSourceFile);
            string destContent = ReadFileAndNormalize(testDestFile);

            string expectedContent = srcContent.Replace(searchWord, replaceWord);

            Assert.AreEqual(expectedContent.Trim(), destContent.Trim(), "Expected output does not equal actual output.");

            // delete test output file
            if (File.Exists(testDestFile))
            {
                File.Delete(testDestFile);
            }
        }

        [TestMethod]
        public void ShouldReplaceMultipleOccurrences()
        {
            string searchWord = "La Mancha";
            string replaceWord = "Toledo";

            RunProgram(searchWord, replaceWord);

            Assert.IsTrue(File.Exists(testDestFile));

            string srcContent = ReadFileAndNormalize(testSourceFile);
            string destContent = ReadFileAndNormalize(testDestFile);

            string expectedContent = srcContent.Replace(searchWord, replaceWord);

            Assert.AreEqual(expectedContent.Trim(), destContent.Trim(), "Expected output does not equal actual output.");

            // delete test output file
            if (File.Exists(testDestFile))
            {
                File.Delete(testDestFile);
            }
        }

        private string ReadFileAndNormalize(string filename)
        {
            return File.ReadAllText(filename).Replace("\r\n", "\n");
        }

        private void RunProgram(string searchWord, string replaceWord)
        {
            string input = searchWord + Environment.NewLine + replaceWord + Environment.NewLine + testSourceFile + Environment.NewLine + testDestFile;

            using (var reader = new StringReader(input))
            {
                Console.SetIn(reader);
                FindAndReplace.Program.Main(null);
            }
        }
    }
}
