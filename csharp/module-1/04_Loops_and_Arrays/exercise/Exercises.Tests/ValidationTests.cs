using System.Collections.Generic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static TechElevator.Testing.TestingLibrary;

namespace Exercises.Tests
{
    [TestClass]
    public class ValidationTests
    {
        private const int SmallCheese = 10;
        private const int SmallPepperoni = 11;

        private const int MediumCheese = 20;
        private const int MediumPepperoni = 21;

        private const int LargeCheese = 30;
        private const int LargePepperoni = 31;

        private const int Calzone = 40;
        private const int SpaghettiPie = 41;
        private const int BakedZiti = 42;

        private const char SmallShirt = 'S';
        private const char MediumShirt = 'M';
        private const char LargeShirt = 'L';

        [TestMethod]
        public void Exercise01_01_CreateOrder()
        {
            TestGroup happyPath = new TestGroup("Array contains the correct item numbers in the expected order");
            happyPath.AddTest(new Test(Array.Empty<object>(), new int[] { SmallCheese, Calzone, LargePepperoni, SpaghettiPie }));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath
            };

            TestSuite testSuite = new TestSuite(testGroups, typeof(Exercise01_StoreOrders), nameof(Exercise01_StoreOrders.CreateOrder), Array.Empty<Type>());

            RunTestSuite(testSuite);
        }


        [TestMethod]
        public void Exercise01_02_GetCalzoneSales()
        {
            TestGroup happyPath = new TestGroup("Returns the count of the item number for calzones");
            happyPath.AddTest(new Test(new object[] { new int[] { Calzone, SmallCheese, LargeCheese, Calzone, SmallCheese } }, 2));
            happyPath.AddTest(new Test(new object[] { new int[] { Calzone, SmallCheese, SmallCheese } }, 1));
            happyPath.AddTest(new Test(new object[] { new int[] { SmallCheese, Calzone, SmallCheese } }, 1));
            happyPath.AddTest(new Test(new object[] { new int[] { SmallCheese, SmallCheese, Calzone } }, 1));
            happyPath.AddTest(new Test(new object[] { new int[] { BakedZiti, SmallCheese, Calzone, SpaghettiPie } }, 1));
            happyPath.AddTest(new Test(new object[] { new int[] { Calzone, Calzone, SmallCheese } }, 2));
            happyPath.AddTest(new Test(new object[] { new int[] { Calzone, Calzone, Calzone } }, 3));

            TestGroup zeroCalzone = new TestGroup("Returns 0 when calzones are not present");
            zeroCalzone.AddTest(new Test(new object[] { new int[] { SmallCheese, SmallPepperoni, SmallCheese } }, 0));
            zeroCalzone.AddTest(new Test(new object[] { new int[] { SmallPepperoni, BakedZiti } }, 0));
            zeroCalzone.AddTest(new Test(new object[] { Array.Empty<int>() }, 0));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath,
                zeroCalzone
            };

            TestSuite testSuite = new TestSuite(testGroups, typeof(Exercise01_StoreOrders), nameof(Exercise01_StoreOrders.GetCalzoneSales), typeof(int[]));

            RunTestSuite(testSuite);
        }


        [TestMethod]
        public void Exercise01_03_GetCheesePizzaRevenue()
        {
            TestGroup oneCheese = new TestGroup("Returns the correct amount for one cheese pizza");
            oneCheese.AddTest(new Test(new object[] { new int[] { SmallCheese } }, 8));
            oneCheese.AddTest(new Test(new object[] { new int[] { MediumCheese } }, 11));
            oneCheese.AddTest(new Test(new object[] { new int[] { LargeCheese } }, 14));

            TestGroup multiCheese = new TestGroup("Returns the correct amount for multiple cheese pizzas");
            multiCheese.AddTest(new Test(new object[] { new int[] { SmallCheese, MediumCheese } }, 19));
            multiCheese.AddTest(new Test(new object[] { new int[] { MediumCheese, LargeCheese } }, 25));
            multiCheese.AddTest(new Test(new object[] { new int[] { SmallCheese, MediumCheese, LargeCheese } }, 33));
            multiCheese.AddTest(new Test(new object[] { new int[] { SmallCheese, SmallCheese } }, 16));
            multiCheese.AddTest(new Test(new object[] { new int[] { MediumCheese, MediumCheese } }, 22));
            multiCheese.AddTest(new Test(new object[] { new int[] { LargeCheese, LargeCheese } }, 28));

            TestGroup cheeseAndOthers = new TestGroup("Returns the correct amount for cheese pizzas with other items");
            cheeseAndOthers.AddTest(new Test(new object[] { new int[] { SmallCheese, Calzone } }, 8));
            cheeseAndOthers.AddTest(new Test(new object[] { new int[] { MediumCheese, BakedZiti } }, 11));
            cheeseAndOthers.AddTest(new Test(new object[] { new int[] { LargeCheese, SpaghettiPie } }, 14));
            cheeseAndOthers.AddTest(new Test(new object[] { new int[] { SmallCheese, SmallPepperoni } }, 8));
            cheeseAndOthers.AddTest(new Test(new object[] { new int[] { MediumCheese, MediumPepperoni } }, 11));
            cheeseAndOthers.AddTest(new Test(new object[] { new int[] { LargeCheese, LargePepperoni } }, 14));
            cheeseAndOthers.AddTest(new Test(new object[] { new int[] { SmallCheese, SmallPepperoni, MediumCheese } }, 19));
            cheeseAndOthers.AddTest(new Test(new object[] { new int[] { SmallCheese, SmallPepperoni, MediumCheese, SmallPepperoni, LargeCheese } }, 33));
            cheeseAndOthers.AddTest(new Test(new object[] { new int[] { MediumCheese, SmallPepperoni, LargeCheese } }, 25));

            TestGroup noCheese = new TestGroup("Returns 0 when there are no cheese pizzas");
            noCheese.AddTest(new Test(new object[] { new int[] { SmallPepperoni, MediumPepperoni, LargePepperoni } }, 0));
            noCheese.AddTest(new Test(new object[] { new int[] { BakedZiti, SpaghettiPie, Calzone } }, 0));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                oneCheese,
                multiCheese,
                cheeseAndOthers,
                noCheese
            };

            TestSuite testSuite = new TestSuite(testGroups, typeof(Exercise01_StoreOrders), nameof(Exercise01_StoreOrders.GetCheesePizzaRevenue), typeof(int[]));

            RunTestSuite(testSuite);
        }


        [TestMethod]
        public void Exercise02_01_GenerateSeatingChart()
        {
            TestGroup allElementsTrue = new TestGroup("Returns an array of the correct values and length");
            allElementsTrue.AddTest(new Test(new object[] { 1 }, new bool[] { true }));
            allElementsTrue.AddTest(new Test(new object[] { 2 }, new bool[] { true, true }));
            allElementsTrue.AddTest(new Test(new object[] { 3 }, new bool[] { true, true, true }));
            allElementsTrue.AddTest(new Test(new object[] { 4 }, new bool[] { true, true, true, true }));
            allElementsTrue.AddTest(new Test(new object[] { 5 }, new bool[] { true, true, true, true, true }));

            TestGroup zeroLength = new TestGroup("Returns an array of zero length for 0");
            zeroLength.AddTest(new Test(new object[] { 0 }, Array.Empty<bool>()));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                allElementsTrue,
                zeroLength
            };

            TestSuite testSuite = new TestSuite(testGroups, typeof(Exercise02_BoardingGate), nameof(Exercise02_BoardingGate.GenerateSeatingChart), typeof(int));

            RunTestSuite(testSuite);
        }


        [TestMethod]
        public void Exercise02_02_GetAvailableSeatCount()
        {
            TestGroup available = new TestGroup("Returns the correct number of available seats");
            available.AddTest(new Test(new object[] { new bool[] { true } }, 1));
            available.AddTest(new Test(new object[] { new bool[] { true, false, false, false } }, 1));
            available.AddTest(new Test(new object[] { new bool[] { true, false, true, false } }, 2));
            available.AddTest(new Test(new object[] { new bool[] { false, true, true, false } }, 2));
            available.AddTest(new Test(new object[] { new bool[] { false, false, true, true } }, 2));
            available.AddTest(new Test(new object[] { new bool[] { true, true, true, false } }, 3));
            available.AddTest(new Test(new object[] { new bool[] { true, true, false, true } }, 3));
            available.AddTest(new Test(new object[] { new bool[] { true, false, true, true } }, 3));
            available.AddTest(new Test(new object[] { new bool[] { false, true, true, true } }, 3));

            TestGroup notAvailable = new TestGroup("Returns 0 for no available seats");
            notAvailable.AddTest(new Test(new object[] { new bool[] { false } }, 0));
            notAvailable.AddTest(new Test(new object[] { new bool[] { false, false, false } }, 0));
            notAvailable.AddTest(new Test(new object[] { new bool[] { false, false, false, false, false, false } }, 0));

            TestGroup noSeatsGiven = new TestGroup("Returns 0 for no seats given");
            noSeatsGiven.AddTest(new Test(new object[] { Array.Empty<bool>() }, 0));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                available,
                notAvailable,
                noSeatsGiven
            };

            TestSuite testSuite = new TestSuite(testGroups, typeof(Exercise02_BoardingGate), nameof(Exercise02_BoardingGate.GetAvailableSeatCount), typeof(bool[]));

            RunTestSuite(testSuite);
        }


        [TestMethod]
        public void Exercise02_03_GetNumberOfFullRows()
        {
            TestGroup fullRows = new TestGroup("Returns the correct number of full rows");
            fullRows.AddTest(new Test(new object[] { new bool[] { false, false, false } }, 1));
            fullRows.AddTest(new Test(new object[] { new bool[] { false, false, false, false, false, false } }, 2));
            fullRows.AddTest(new Test(new object[] { new bool[] { false, false, false, true, true, true } }, 1));
            fullRows.AddTest(new Test(new object[] { new bool[] { true, true, true, false, false, false } }, 1));
            fullRows.AddTest(new Test(new object[] { new bool[] { true, true, true, false, false, false } }, 1));

            TestGroup noFullRows = new TestGroup("Returns 0 for no full rows");
            noFullRows.AddTest(new Test(new object[] { new bool[] { true, true, true } }, 0));
            noFullRows.AddTest(new Test(new object[] { new bool[] { true, true, true, true, true, true } }, 0));
            noFullRows.AddTest(new Test(new object[] { new bool[] { true, true, true, true, true, true, true, true, true } }, 0));
            noFullRows.AddTest(new Test(new object[] { new bool[] { false, true, true, false, true, true } }, 0));
            noFullRows.AddTest(new Test(new object[] { new bool[] { true, false, true, true, false, true } }, 0));
            noFullRows.AddTest(new Test(new object[] { new bool[] { true, true, false, true, true, false } }, 0));
            noFullRows.AddTest(new Test(new object[] { new bool[] { true, false, true, false, true, false } }, 0));

            TestGroup noRowsGiven = new TestGroup("Returns 0 for no rows given");
            noRowsGiven.AddTest(new Test(new object[] { Array.Empty<bool>() }, 0));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                fullRows,
                noFullRows,
                noRowsGiven
            };

            TestSuite testSuite = new TestSuite(testGroups, typeof(Exercise02_BoardingGate), nameof(Exercise02_BoardingGate.GetNumberOfFullRows), typeof(bool[]));

            RunTestSuite(testSuite);
        }


        [TestMethod]
        public void Exercise03_01_BuildOrder()
        {
            TestGroup happyPath = new TestGroup("Array contains the correct shirt sizes in the expected order");
            happyPath.AddTest(new Test(Array.Empty<object>(), new char[] { SmallShirt, SmallShirt, SmallShirt, MediumShirt, MediumShirt, LargeShirt }));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath
            };

            TestSuite testSuite = new TestSuite(testGroups, typeof(Exercise03_Shirts), nameof(Exercise03_Shirts.BuildOrder), Array.Empty<Type>());

            RunTestSuite(testSuite);
        }


        [TestMethod]
        public void Exercise03_02_BuildBulkOrder()
        {
            TestGroup happyPath = new TestGroup("Returns the correct array of shirt sizes");
            happyPath.AddTest(new Test(new object[] { 1 }, new char[] { SmallShirt }));
            happyPath.AddTest(new Test(new object[] { 2 }, new char[] { SmallShirt, MediumShirt }));
            happyPath.AddTest(new Test(new object[] { 3 }, new char[] { SmallShirt, MediumShirt, LargeShirt }));
            happyPath.AddTest(new Test(new object[] { 4 }, new char[] { SmallShirt, MediumShirt, LargeShirt, SmallShirt }));
            happyPath.AddTest(new Test(new object[] { 5 }, new char[] { SmallShirt, MediumShirt, LargeShirt, SmallShirt, MediumShirt }));
            happyPath.AddTest(new Test(new object[] { 6 }, new char[] { SmallShirt, MediumShirt, LargeShirt, SmallShirt, MediumShirt, LargeShirt }));

            TestGroup zeroLength = new TestGroup("Returns an array of zero length for 0");
            zeroLength.AddTest(new Test(new object[] { 0 }, new char[] { }));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath,
                zeroLength
            };

            TestSuite testSuite = new TestSuite(testGroups, typeof(Exercise03_Shirts), nameof(Exercise03_Shirts.BuildBulkOrder), typeof(int));

            RunTestSuite(testSuite);
        }


        [TestMethod]
        public void Exercise03_03_PlaceRequest()
        {
            TestGroup smallIn = new TestGroup("Returns true if a small t-shirt is in the order");
            smallIn.AddTest(new Test(new object[] { new char[] { SmallShirt } }, true));
            smallIn.AddTest(new Test(new object[] { new char[] { SmallShirt, MediumShirt, LargeShirt } }, true));
            smallIn.AddTest(new Test(new object[] { new char[] { MediumShirt, SmallShirt, LargeShirt } }, true));
            smallIn.AddTest(new Test(new object[] { new char[] { MediumShirt, LargeShirt, SmallShirt } }, true));
            smallIn.AddTest(new Test(new object[] { new char[] { SmallShirt, SmallShirt } }, true));

            TestGroup noSmall = new TestGroup("Returns false if no small t-shirts are in the order");
            noSmall.AddTest(new Test(new object[] { new char[] { } }, false));
            noSmall.AddTest(new Test(new object[] { new char[] { MediumShirt } }, false));
            noSmall.AddTest(new Test(new object[] { new char[] { LargeShirt } }, false));
            noSmall.AddTest(new Test(new object[] { new char[] { MediumShirt, LargeShirt } }, false));
            noSmall.AddTest(new Test(new object[] { new char[] { MediumShirt, MediumShirt, LargeShirt } }, false));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                smallIn,
                noSmall
            };

            TestSuite testSuite = new TestSuite(testGroups, typeof(Exercise03_Shirts), nameof(Exercise03_Shirts.PlaceRequest), typeof(char[]));

            RunTestSuite(testSuite);
        }


        [TestMethod]
        public void Exercise04_01_FirstCard()
        {
            TestGroup happyPath = new TestGroup("Returns the first card of the hand");
            happyPath.AddTest(new Test(new object[] { new string[] { "3-H", "7-H", "5-H", "8-H", "6-H" } }, "3-H"));
            happyPath.AddTest(new Test(new object[] { new string[] { "1-C", "1-D", "1-H", "1-S", "2-C" } }, "1-C"));
            happyPath.AddTest(new Test(new object[] { new string[] { "K-C", "Q-D", "J-H", "10-S", "Q-C" } }, "K-C"));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath
            };

            TestSuite test = new TestSuite(testGroups, typeof(Exercise04_Cards), nameof(Exercise04_Cards.GetFirstCard), typeof(string[]));

            RunTestSuite(test);
        }


        [TestMethod]
        public void Exercise04_02_DiscardFirstCard()
        {
            TestGroup happyPath = new TestGroup("Returns the array without the first card");
            happyPath.AddTest(new Test(new object[] { new string[] { "3-H", "7-H", "5-H", "8-H", "6-H" } },
                                                            new string[] { "7-H", "5-H", "8-H", "6-H" }));
            happyPath.AddTest(new Test(new object[] { new string[] { "1-C", "1-D", "1-H", "1-S", "2-C" } },
                                                            new string[] { "1-D", "1-H", "1-S", "2-C" }));
            happyPath.AddTest(new Test(new object[] { new string[] { "K-C", "Q-D", "J-H", "10-S", "Q-C" } },
                                                            new string[] { "Q-D", "J-H", "10-S", "Q-C" }));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath
            };

            TestSuite test = new TestSuite(testGroups, typeof(Exercise04_Cards), nameof(Exercise04_Cards.DiscardFirstCard), typeof(string[]));

            RunTestSuite(test);
        }

        [TestMethod]
        public void Exercise04_03_DiscardTopCard()
        {
            TestGroup happyPath = new TestGroup("Returns the deck without the first card");
            happyPath.AddTest(new Test(new object[] { new string[] { "8-C", "10-H", "J-C", "8-D", "6-S", "Q-C", "2-D" } },
                                                            new string[] { "10-H", "J-C", "8-D", "6-S", "Q-C", "2-D" }));
            happyPath.AddTest(new Test(new object[] { new string[] { "2-C", "A-S", "K-S", "Q-S", "J-S", "10-S" } },
                                                            new string[] { "A-S", "K-S", "Q-S", "J-S", "10-S" }));
            happyPath.AddTest(new Test(new object[] { new string[] { "4-D", "6-S", "K-D" } },
                                                            new string[] { "6-S", "K-D" }));

            TestGroup emptyDeck = new TestGroup("Returns an empty deck when no cards left");
            emptyDeck.AddTest(new Test(new object[] { new string[] { "9-H" } }, Array.Empty<string>()));
            emptyDeck.AddTest(new Test(new object[] { Array.Empty<string>() }, Array.Empty<string>()));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath,
                emptyDeck
            };

            TestSuite test = new TestSuite(testGroups, typeof(Exercise04_Cards), nameof(Exercise04_Cards.DiscardTopCard), typeof(string[]));

            RunTestSuite(test);
        }


        [TestMethod]
        public void Exercise05_01_BelowFreezing()
        {
            TestGroup happyPath = new TestGroup("Returns the number of days where temperature is 32 or less");
            happyPath.AddTest(new Test(new object[] { new int[] { 32, 31, 30, 29, 30, 31, 32 } }, 7));
            happyPath.AddTest(new Test(new object[] { new int[] { 33, 30, 37, 32, 38, 31, 36 } }, 3));
            happyPath.AddTest(new Test(new object[] { new int[] { -7, -3, 19, 35, 30 } }, 4));
            happyPath.AddTest(new Test(new object[] { new int[] { 33, -7, 31, -3, 34, 32 } }, 4));
            happyPath.AddTest(new Test(new object[] { new int[] { 33, -11 } }, 1));
            happyPath.AddTest(new Test(new object[] { new int[] { 32, 33 } }, 1));

            TestGroup zeroOrEmpty = new TestGroup("Returns 0 for no freezing days or no days given");
            zeroOrEmpty.AddTest(new Test(new object[] { new int[] { 33, 43, 55, 37, 44, 52, 34 } }, 0));
            zeroOrEmpty.AddTest(new Test(new object[] { Array.Empty<int>() }, 0));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath,
                zeroOrEmpty
            };

            TestSuite test = new TestSuite(testGroups, typeof(Exercise05_Weather), nameof(Exercise05_Weather.BelowFreezing), typeof(int[]));

            RunTestSuite(test);
        }


        [TestMethod]
        public void Exercise05_02_HottestDay()
        {
            TestGroup happyPath = new TestGroup("Returns the temperature of the hottest day");
            happyPath.AddTest(new Test(new object[] { new int[] { 81, 93, 94, 105, 99, 95, 101, 90, 89, 92 } }, 105));
            happyPath.AddTest(new Test(new object[] { new int[] { 23, 24 } }, 24));
            happyPath.AddTest(new Test(new object[] { new int[] { 34, 33 } }, 34));
            happyPath.AddTest(new Test(new object[] { new int[] { 55 } }, 55));

            TestGroup atOrBelowZero = new TestGroup("Returns the correct value when values are all at zero or less");
            happyPath.AddTest(new Test(new object[] { new int[] { -9, -12, 0, -2, -7 } }, 0));
            happyPath.AddTest(new Test(new object[] { new int[] { 0 } }, 0));
            happyPath.AddTest(new Test(new object[] { new int[] { -7, -2, -11, -9, -4 } }, -2));
            happyPath.AddTest(new Test(new object[] { new int[] { -22 } }, -22));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath,
                atOrBelowZero
            };

            TestSuite test = new TestSuite(testGroups, typeof(Exercise05_Weather), nameof(Exercise05_Weather.HottestDay), typeof(int[]));

            RunTestSuite(test);
        }


        [TestMethod]
        public void Exercise05_03_FixTemperatures()
        {
            TestGroup happyPath = new TestGroup("Returns an array of the corrected temperatures");
            happyPath.AddTest(new Test(new object[] { new int[] { 33, 30, 32, 37, 44, 31, 41 } }, new int[] { 35, 30, 34, 37, 46, 31, 43 }));
            happyPath.AddTest(new Test(new object[] { new int[] { -7, -33, 19, 35 } }, new int[] { -5, -33, 21, 35 }));
            happyPath.AddTest(new Test(new object[] { new int[] { -1, 0, 1 } }, new int[] { 1, 0, 3 }));
            happyPath.AddTest(new Test(new object[] { new int[] { -1 } }, new int[] { 1 }));

            TestGroup emptyArray = new TestGroup("Returns an empty array when there are no temperatures given");
            emptyArray.AddTest(new Test(new object[] { Array.Empty<int>() }, Array.Empty<int>()));

            List<TestGroup> testGroups = new List<TestGroup>
            {
                happyPath,
                emptyArray
            };

            TestSuite test = new TestSuite(testGroups, typeof(Exercise05_Weather), nameof(Exercise05_Weather.FixTemperatures), typeof(int[]));

            RunTestSuite(test);
        }
    }
}
