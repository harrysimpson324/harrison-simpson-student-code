using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static TechElevator.Testing.TestingLibrary;

namespace Exercises.Tests
{
    [TestClass]
    public class ExerciseTests
    {
        Exercises exercises = new Exercises();
        const double DoubleAllowableDifference = 0.001;

        [TestMethod]
        public void Exercise01_AnimalGroupName()
        {
            TestGroup happyPath = new TestGroup("Returns correct group name for all expected animals");
            happyPath.AddTest(new Test(new object[] { "rhino" }, "Crash"));
            happyPath.AddTest(new Test(new object[] { "giraffe" }, "Tower"));
            happyPath.AddTest(new Test(new object[] { "elephant" }, "Herd"));
            happyPath.AddTest(new Test(new object[] { "lion" }, "Pride"));
            happyPath.AddTest(new Test(new object[] { "crow" }, "Murder"));
            happyPath.AddTest(new Test(new object[] { "pigeon" }, "Kit"));
            happyPath.AddTest(new Test(new object[] { "flamingo" }, "Pat"));
            happyPath.AddTest(new Test(new object[] { "deer" }, "Herd"));
            happyPath.AddTest(new Test(new object[] { "dog" }, "Pack"));
            happyPath.AddTest(new Test(new object[] { "crocodile" }, "Float"));

            TestGroup caseInsensitiveTests = new TestGroup("Is not case sensitive for the animal name");
            caseInsensitiveTests.AddTest(new Test(new object[] { "RHINO" }, "Crash"));
            caseInsensitiveTests.AddTest(new Test(new object[] { "giraffe" }, "Tower"));
            caseInsensitiveTests.AddTest(new Test(new object[] { "ElepHANT" }, "Herd"));
            caseInsensitiveTests.AddTest(new Test(new object[] { "LioN" }, "Pride"));
            caseInsensitiveTests.AddTest(new Test(new object[] { "cROW" }, "Murder"));

            TestGroup unknownTests = new TestGroup("Returns \"unknown\" for unexpected animals");
            unknownTests.AddTest(new Test(new object[] { "Walrus" }, "unknown"));
            unknownTests.AddTest(new Test(new object[] { "Pig" }, "unknown"));

            TestGroup nullEmptyTests = new TestGroup("Returns \"unknown\" for null or empty strings");
            string nullStr = null;
            nullEmptyTests.AddTest(new Test(new object[] { "" }, "unknown"));
            nullEmptyTests.AddTest(new Test(new object[] { nullStr }, "unknown"));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath,
                caseInsensitiveTests,
                unknownTests,
                nullEmptyTests
            };

            TestSuite test = new TestSuite(
                typeof(Exercises), nameof(Exercises.AnimalGroupName), new Type[] { typeof(string) }, testGroups);

            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise02_IsItOnSale()
        {
            TestGroup happyPath = new TestGroup("Returns correct group discount for all expected SKUs");
            happyPath.AddTest(new Test(new object[] { "KITCHEN4001" }, 0.20));
            happyPath.AddTest(new Test(new object[] { "GARAGE1070" }, 0.15));
            happyPath.AddTest(new Test(new object[] { "LIVINGROOM" }, 0.10));
            happyPath.AddTest(new Test(new object[] { "KITCHEN6073" }, 0.40));
            happyPath.AddTest(new Test(new object[] { "BEDROOM3434" }, 0.60));
            happyPath.AddTest(new Test(new object[] { "BATH0073" }, 0.15));

            TestGroup caseInsensitiveTests = new TestGroup("Is not case sensitive for the SKU");
            caseInsensitiveTests.AddTest(new Test(new object[] { "kitchen4001" }, 0.20));
            caseInsensitiveTests.AddTest(new Test(new object[] { "GaRaGe1070" }, 0.15));
            caseInsensitiveTests.AddTest(new Test(new object[] { "livingROOM" }, 0.10));
            caseInsensitiveTests.AddTest(new Test(new object[] { "Kitchen6073" }, 0.40));
            caseInsensitiveTests.AddTest(new Test(new object[] { "BedRoom3434" }, 0.60));
            caseInsensitiveTests.AddTest(new Test(new object[] { "bath0073" }, 0.15));

            TestGroup unknownTests = new TestGroup("Returns 0.00 for SKUs not on sale");
            unknownTests.AddTest(new Test(new object[] { "spaceship9999" }, (double)0));
            unknownTests.AddTest(new Test(new object[] { "KITCHEN1234" }, (double)0));
            unknownTests.AddTest(new Test(new object[] { "LivingRoom9" }, (double)0));

            TestGroup nullEmptyTests = new TestGroup("Returns 0.00 for null or empty strings");
            string nullStr = null;
            nullEmptyTests.AddTest(new Test(new object[] { "" }, (double)0));
            nullEmptyTests.AddTest(new Test(new object[] { nullStr }, (double)0));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath,
                caseInsensitiveTests,
                unknownTests,
                nullEmptyTests
            };

            TestSuite test = new TestSuite(
                typeof(Exercises), nameof(Exercises.IsItOnSale), new Type[] { typeof(string) }, testGroups);

            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise03_RobPeterToPayPaul()
        {
            TestGroup peterGivesHalf = new TestGroup("Peter gives Paul half his money");
            peterGivesHalf.AddTest(new Test(new object[] { PeterPaulDictionary(2000, 99) }, PeterPaulDictionary(1000, 1099)));
            peterGivesHalf.AddTest(new Test(new object[] { PeterPaulDictionary(2345, 500) }, PeterPaulDictionary(1173, 1672)));
            peterGivesHalf.AddTest(new Test(new object[] { PeterPaulDictionary(5000, 999) }, PeterPaulDictionary(2500, 3499)));
            peterGivesHalf.AddTest(new Test(new object[] { PeterPaulDictionary(101, 500) }, PeterPaulDictionary(51, 550)));

            TestGroup paulOver10 = new TestGroup("Peter gives no money because Paul has more than $10");
            paulOver10.AddTest(new Test(new object[] { PeterPaulDictionary(2000, 30000) }, PeterPaulDictionary(2000, 30000)));
            paulOver10.AddTest(new Test(new object[] { PeterPaulDictionary(1, 5000) }, PeterPaulDictionary(1, 5000)));
            paulOver10.AddTest(new Test(new object[] { PeterPaulDictionary(5000, 1000) }, PeterPaulDictionary(5000, 1000)));

            TestGroup peterNoMoney = new TestGroup("Peter gives no money because he has none");
            peterNoMoney.AddTest(new Test(new object[] { PeterPaulDictionary(0, 5000) }, PeterPaulDictionary(0, 5000)));
            peterNoMoney.AddTest(new Test(new object[] { PeterPaulDictionary(0, 500) }, PeterPaulDictionary(0, 500)));
            peterNoMoney.AddTest(new Test(new object[] { PeterPaulDictionary(-10, 500) }, PeterPaulDictionary(-10, 500)));
            peterNoMoney.AddTest(new Test(new object[] { PeterPaulDictionary(-100, 500) }, PeterPaulDictionary(-100, 500)));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                peterGivesHalf,
                paulOver10,
                peterNoMoney
            };

            TestSuite test = new TestSuite(
                typeof(Exercises), nameof(Exercises.RobPeterToPayPaul), new Type[] { typeof(Dictionary<string, int>) }, testGroups);

            RunTestSuite(test);
        }

        private static Dictionary<string, int> PeterPaulDictionary(int peterMoney, int paulMoney)
        {
            Dictionary<string, int> input = new Dictionary<string, int>();
            input.Add("Peter", peterMoney);
            input.Add("Paul", paulMoney);
            return input;
        }
        private static Dictionary<string, int> PeterPaulPartnershipDictionary(int peterMoney, int paulMoney, int partnership)
        {
            Dictionary<string, int> input = new Dictionary<string, int>();
            input.Add("Peter", peterMoney);
            input.Add("Paul", paulMoney);
            input.Add("PeterPaulPartnership", partnership);
            return input;
        }

        [TestMethod]
        public void Exercise04_PeterPaulPartnership()
        {
            TestGroup funded = new TestGroup("Partnership funded");
            funded.AddTest(new Test(new object[] { PeterPaulDictionary(5000, 10000) },
                    PeterPaulPartnershipDictionary(3750, 7500, 3750)));
            funded.AddTest(new Test(new object[] { PeterPaulDictionary(15000, 110000) },
                    PeterPaulPartnershipDictionary(11250, 82500, 31250)));

            TestGroup notFunded = new TestGroup("Partnership not funded");
            notFunded.AddTest(new Test(new object[] { PeterPaulDictionary(3333, 1234567890) },
                    PeterPaulDictionary(3333, 1234567890)));
            notFunded.AddTest(new Test(new object[] { PeterPaulDictionary(4999, 1234567890) },
                    PeterPaulDictionary(4999, 1234567890)));
            notFunded.AddTest(new Test(new object[] { PeterPaulDictionary(5000, 9999) },
                    PeterPaulDictionary(5000, 9999)));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                funded,
                notFunded
            };

            TestSuite test = new TestSuite(typeof(Exercises), nameof(Exercises.PeterPaulPartnership), new Type[] { typeof(Dictionary<string, int>) }, testGroups);
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise05_BeginningAndEnding()
        {
            TestGroup basicTests = new TestGroup("Returns Dictionary of beginnings and last ending");
            Dictionary<string, string> expected = new Dictionary<string, string>
            {
                { "b", "g" },
                { "c", "e" }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "code", "bug" } }, expected));

            expected = new Dictionary<string, string>
            {
                { "b", "g" },
                { "c", "t" }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "code", "bug", "cat" } }, expected));

            expected = new Dictionary<string, string>
            {
                { "m", "n" }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "man", "moon", "main" } }, expected));

            expected = new Dictionary<string, string>
            {
                { "m", "t" },
                { "g", "d" },
                { "n", "t" }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "muddy", "good", "moat", "good", "night" } }, expected));

            TestGroup nullTests = new TestGroup("Returns empty Dictionary for empty array");
            nullTests.AddTest(new Test(new object[] { Array.Empty<string>() }, new Dictionary<string, string>()));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                basicTests,
                nullTests
            };

            TestSuite test = new TestSuite(typeof(Exercises), nameof(Exercises.BeginningAndEnding), new Type[] { typeof(string[]) }, testGroups);
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise06_WordCount()
        {
            TestGroup basicTests = new TestGroup("Returns Dictionary of string counts");

            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                { "a", 2 },
                { "b", 2 },
                { "c", 1 }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "a", "b", "a", "c", "b" } }, expected));

            expected = new Dictionary<string, int>
            {
                { "a", 1 },
                { "b", 1 },
                { "c", 1 }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "c", "b", "a" } }, expected));

            expected = new Dictionary<string, int>
            {
                { "ba", 2 },
                { "black", 1 },
                { "sheep", 1 }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "ba", "ba", "black", "sheep" } }, expected));

            expected = new Dictionary<string, int>
            {
                { "ba", 4 },
                { "black", 2 },
                { "sheep", 2 }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "ba", "ba", "black", "sheep", "ba", "ba", "black", "sheep" } }, expected));

            expected = new Dictionary<string, int>
            {
                { "apple", 4 },
                { "banana", 3 },
                { "carrot", 1 },
                { "dill", 2 }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "apple", "apple", "banana", "apple", "carrot", "banana", "dill", "dill", "banana", "apple" } }, expected));

            expected = new Dictionary<string, int>
            {
                { "apple", 6 }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "apple", "apple", "apple", "apple", "apple", "apple" } }, expected));

            TestGroup nullTests = new TestGroup("Returns empty Dictionary for empty array");
            nullTests.AddTest(new Test(new object[] { Array.Empty<string>() }, new Dictionary<string, int>()));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                basicTests,
                nullTests
            };

            TestSuite test = new TestSuite(typeof(Exercises), nameof(Exercises.WordCount), new Type[] { typeof(string[]) }, testGroups);
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise07_IntCount()
        {
            TestGroup basicTests = new TestGroup("Returns Dictionary of int counts");

            Dictionary<int, int> expected = new Dictionary<int, int>
            {
                { 1, 2 },
                { 44, 1 },
                { 55, 1 },
                { 63, 3 },
                { 77, 1 },
                { 99, 2 }
            };
            basicTests.AddTest(new Test(new object[] { new int[] { 1, 99, 63, 1, 55, 77, 63, 99, 63, 44 } }, expected));

            expected = new Dictionary<int, int>
            {
                { 33, 4 },
                { 106, 1 },
                { 107, 3 }
            };
            basicTests.AddTest(new Test(new object[] { new int[] { 107, 33, 107, 33, 33, 33, 106, 107 } }, expected));

            TestGroup nullTests = new TestGroup("Returns empty Dictionary for empty array");
            nullTests.AddTest(new Test(new object[] { Array.Empty<int>() }, new Dictionary<int, int>()));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                basicTests,
                nullTests
            };

            TestSuite test = new TestSuite(typeof(Exercises), nameof(Exercises.IntCount), new Type[] { typeof(int[]) }, testGroups);
            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise08_WordMultiple()
        {
            TestGroup basicTests = new TestGroup("Returns a Dictionary indicating if the strings occur 2 or more times");

            Dictionary<string, bool> expected = new Dictionary<string, bool>
            {
                { "apple", true },
                { "banana", true },
                { "carrot", false }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "apple", "banana", "apple", "carrot", "banana" } }, expected));

            expected = new Dictionary<string, bool>
            {
                { "a", false },
                { "b", false },
                { "c", false }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "c", "b", "a" } }, expected));

            expected = new Dictionary<string, bool>
            {
                { "c", true }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "c", "c", "c", "c" } }, expected));

            expected = new Dictionary<string, bool>
            {
                { "cat", true },
                { "dog", true }
            };
            basicTests.AddTest(new Test(new object[] { new string[] { "cat", "dog", "dog", "cat" } }, expected));

            TestGroup nullTests = new TestGroup("Returns empty Dictionary for empty array");
            nullTests.AddTest(new Test(new object[] { new string[] { } }, new Dictionary<string, bool>()));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                basicTests,
                nullTests
            };

            TestSuite test = new TestSuite(typeof(Exercises), nameof(Exercises.WordMultiple), new Type[] { typeof(string[]) }, testGroups);
            RunTestSuite(test);

        }

        [TestMethod]
        public void Exercise09_ConsolidateInventory()
        {
            TestGroup basicTests = new TestGroup("Returns consolidated inventory Dictionary");

            Dictionary<string, int> inventory1 = new Dictionary<string, int>
            {
                { "SKU1", 100 },
                { "SKU2", 53 },
                { "SKU3", 44 }
            };

            Dictionary<string, int> inventory2 = new Dictionary<string, int>
            {
                { "SKU2", 11 },
                { "SKU4", 5 }
            };

            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                { "SKU1", 100 },
                { "SKU2", 64 },
                { "SKU3", 44 },
                { "SKU4", 5 }
            };

            basicTests.AddTest(new Test(new object[] { inventory1, inventory2 }, expected));

            inventory1 = new Dictionary<string, int>
            {
                { "SKU_4", 0 },
                { "SKU_23", 53 },
                { "SKU_39", 66 },
                { "SKU_X", 8 }
            };

            inventory2 = new Dictionary<string, int>
            {
                { "SKU_4", 68 },
                { "SKU_23", 33 },
                { "SKU_50", 444 },
                { "SKU_X", 1 }
            };

            expected = new Dictionary<string, int>
            {
                { "SKU_4", 68 },
                { "SKU_23", 86 },
                { "SKU_39", 66 },
                { "SKU_50", 444 },
                { "SKU_X", 9 }
            };

            basicTests.AddTest(new Test(new object[] { inventory1, inventory2 }, expected));

            TestGroup nullTests = new TestGroup("Handles empty inventories");
            inventory1 = new Dictionary<string, int>
            {
                { "Lorem", 11 },
                { "Ipsum", 22 },
                { "Dolor", 33 },
                { "Sit", 44 },
                { "Amet", 55 }
            };

            nullTests.AddTest(new Test(new object[] { inventory1, new Dictionary<string, int>() }, inventory1));
            nullTests.AddTest(new Test(new object[] { new Dictionary<string, int>(), inventory1 }, inventory1));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                basicTests,
                nullTests
            };

            TestSuite test = new TestSuite(
                typeof(Exercises), nameof(Exercises.ConsolidateInventory), new Type[] { typeof(Dictionary<string, int>), typeof(Dictionary<string, int>) }, testGroups);

            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise10_Last2Revisited()
        {
            TestGroup basicTests = new TestGroup("Returns Dictionary of last2 counts");

            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                { "hixxhi", 1 },
                { "xaxxaxaxx", 1 },
                { "axxxaaxx", 2 }
            };

            basicTests.AddTest(new Test(new object[] { new string[] { "hixxhi", "xaxxaxaxx", "axxxaaxx" } }, expected));

            expected = new Dictionary<string, int>
            {
                { "banana", 1 },
                { "kiwi", 0 },
                { "Hahahahaha", 3 }
            };

            basicTests.AddTest(new Test(new object[] { new string[] { "banana", "kiwi", "Hahahahaha" } }, expected));

            TestGroup nullTests = new TestGroup("Returns empty Dictionary for empty array");
            nullTests.AddTest(new Test(new object[] { new string[] { } }, new Dictionary<string, int>()));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                basicTests,
                nullTests
            };

            TestSuite test = new TestSuite(
                typeof(Exercises), nameof(Exercises.Last2Revisited), new Type[] { typeof(string[]) }, testGroups);

            RunTestSuite(test);

        }
    }
}
