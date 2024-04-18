using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static TechElevator.Testing.TestingLibrary;

namespace TechElevator.Exercises.LogicalBranching.Tests
{
    [TestClass]
    public class ExerciseTests
    {
        [TestMethod]
        public void Exercise00_01_isRainExpected()
        {
            // precipitationExpected, highTemperatureF GT 32
            TestGroup rainExpected = new TestGroup("Returns true when precipitation is expected and the high is greater than 32");
            rainExpected.AddTest(new Test(new object[] { true, 90 }, true));
            rainExpected.AddTest(new Test(new object[] { true, 33 }, true));

            // precipitationExpected, highTemperatureF LTE 32
            TestGroup rainNotExpected = new TestGroup("Returns false when precipitation is expected and the high is 32 or less");
            rainNotExpected.AddTest(new Test(new object[] { true, 32 }, false));
            rainNotExpected.AddTest(new Test(new object[] { true, 0 }, false));

            // precipitationExpected false, highTemperatureF irrelevant
            TestGroup noPrecipitationExpected = new TestGroup("Returns false when precipitation isn't expected");
            noPrecipitationExpected.AddTest(new Test(new object[] { false, 90 }, false));
            noPrecipitationExpected.AddTest(new Test(new object[] { false, 32 }, false));
            noPrecipitationExpected.AddTest(new Test(new object[] { false, 0 }, false));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(rainExpected);
            testGroups.Add(rainNotExpected);
            testGroups.Add(noPrecipitationExpected);

            TestSuite testSuite = new TestSuite(testGroups, typeof(GettingStarted), nameof(GettingStarted.IsRainExpected), typeof(bool), typeof(int));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise01_01_GradeTestPassFail()
        {
            // score GTE 70
            TestGroup testPass = new TestGroup("Returns true when score is 70 or greater");
            testPass.AddTest(new Test(new object[] { 105 }, true));
            testPass.AddTest(new Test(new object[] { 100 }, true));
            testPass.AddTest(new Test(new object[] { 70 }, true));

            // score LT 70
            TestGroup testFail = new TestGroup("Returns false when score is less than 70");
            testFail.AddTest(new Test(new object[] { 69 }, false));
            testFail.AddTest(new Test(new object[] { 0 }, false));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(testPass);
            testGroups.Add(testFail);

            TestSuite testSuite = new TestSuite(testGroups, typeof(TestGrading), nameof(TestGrading.GradeTestPassFail), typeof(int));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise01_02_GradeTestNumeric()
        {
            // score GTE 90
            TestGroup testGrade3 = new TestGroup("Returns 3 when score is 90 or greater");
            testGrade3.AddTest(new Test(new object[] { 105 }, 3));
            testGrade3.AddTest(new Test(new object[] { 100 }, 3));
            testGrade3.AddTest(new Test(new object[] { 95 }, 3));
            testGrade3.AddTest(new Test(new object[] { 90 }, 3));

            // score GTE 50 and LTE 89
            TestGroup testGrade2 = new TestGroup("Returns 2 when score is between 50 and 89");
            testGrade2.AddTest(new Test(new object[] { 89 }, 2));
            testGrade2.AddTest(new Test(new object[] { 70 }, 2));
            testGrade2.AddTest(new Test(new object[] { 50 }, 2));

            // score GTE 25 and LTE 49
            TestGroup testGrade1 = new TestGroup("Returns 1 when score is between 25 and 49");
            testGrade1.AddTest(new Test(new object[] { 49 }, 1));
            testGrade1.AddTest(new Test(new object[] { 25 }, 1));

            // score LT 25
            TestGroup testGrade0 = new TestGroup("Returns 0 when score is less than 25");
            testGrade0.AddTest(new Test(new object[] { 24 }, 0));
            testGrade0.AddTest(new Test(new object[] { 0 }, 0));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(testGrade3);
            testGroups.Add(testGrade2);
            testGroups.Add(testGrade1);
            testGroups.Add(testGrade0);

            TestSuite testSuite = new TestSuite(testGroups, typeof(TestGrading), nameof(TestGrading.GradeTestNumeric), typeof(int));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise01_03_GradeTestLetter()
        {
            // score GTE 90
            TestGroup testGradeA = new TestGroup("Returns 'A' when score is 90 or greater");
            testGradeA.AddTest(new Test(new object[] { 105 }, 'A'));
            testGradeA.AddTest(new Test(new object[] { 91 }, 'A'));
            testGradeA.AddTest(new Test(new object[] { 90 }, 'A'));

            // score GTE 80 and LTE 89
            TestGroup testGradeB = new TestGroup("Returns 'B' when score is between 80 and 89");
            testGradeB.AddTest(new Test(new object[] { 89 }, 'B'));
            testGradeB.AddTest(new Test(new object[] { 88 }, 'B'));
            testGradeB.AddTest(new Test(new object[] { 81 }, 'B'));
            testGradeB.AddTest(new Test(new object[] { 80 }, 'B'));

            // score GTE 70 and LTE 79
            TestGroup testGradeC = new TestGroup("Returns 'C' when score is between 70 and 79");
            testGradeC.AddTest(new Test(new object[] { 79 }, 'C'));
            testGradeC.AddTest(new Test(new object[] { 78 }, 'C'));
            testGradeC.AddTest(new Test(new object[] { 71 }, 'C'));
            testGradeC.AddTest(new Test(new object[] { 70 }, 'C'));

            // score GTE 60 and LTE 69
            TestGroup testGradeD = new TestGroup("Returns 'D' when score is between 60 and 69");
            testGradeD.AddTest(new Test(new object[] { 69 }, 'D'));
            testGradeD.AddTest(new Test(new object[] { 68 }, 'D'));
            testGradeD.AddTest(new Test(new object[] { 61 }, 'D'));
            testGradeD.AddTest(new Test(new object[] { 60 }, 'D'));

            // score LT 60
            TestGroup testGradeF = new TestGroup("Returns 'F' when score is less than 60");
            testGradeF.AddTest(new Test(new object[] { 59 }, 'F'));
            testGradeF.AddTest(new Test(new object[] { 0 }, 'F'));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(testGradeA);
            testGroups.Add(testGradeB);
            testGroups.Add(testGradeC);
            testGroups.Add(testGradeD);
            testGroups.Add(testGradeF);

            TestSuite testSuite = new TestSuite(testGroups, typeof(TestGrading), nameof(TestGrading.GradeTestLetter), typeof(int));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise02_01_CanDrive()
        {
            // hasPermit is true, withLicensedPassenger is true
            TestGroup canDrive = new TestGroup("Returns true when driver has permit and licensed passenger");
            canDrive.AddTest(new Test(new object[] { true, true }, true));

            // either hasPermit is true or withLicensedPassenger is true, but not both are true
            TestGroup canDriveNoPermitOrLicensedPassenger = new TestGroup("Returns false when driver has no permit or licensed passenger");
            canDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { true, false }, false));      // has permit, but no licensed passenger
            canDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, true }, false));      // has licensed passenger, but no permit
            canDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, false }, false));     // has neither permit nor licensed passenger (tested for completeness-sake)

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(canDrive);
            testGroups.Add(canDriveNoPermitOrLicensedPassenger);

            TestSuite testSuite = new TestSuite(testGroups, typeof(AllowDriving), nameof(AllowDriving.CanDrive), typeof(bool), typeof(bool));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise02_02_CanDriveAgeLimit()
        {
            // hasPermit is true, withLicensedPassenger is true, passengerAge GTE 21
            TestGroup canDriveAgeLimit = new TestGroup("Returns true when driver has permit and licensed passenger 21 or over");
            canDriveAgeLimit.AddTest(new Test(new object[] { true, true, 80 }, true));
            canDriveAgeLimit.AddTest(new Test(new object[] { true, true, 22 }, true));
            canDriveAgeLimit.AddTest(new Test(new object[] { true, true, 21 }, true));

            // hasPermit is true, withLicensedPassenger is true, passengerAge LT 21
            TestGroup cannotDriveAgeLimitUnderage = new TestGroup("Returns false when driver has permit and licensed passenger under 21");
            cannotDriveAgeLimitUnderage.AddTest(new Test(new object[] { true, true, 20 }, false));
            cannotDriveAgeLimitUnderage.AddTest(new Test(new object[] { true, true, 16 }, false));

            // either hasPermit is true or withLicensedPassenger is true, but not both are true, passengerAge irrelevant
            TestGroup cannotDriveNoPermitOrLicensedPassenger = new TestGroup("Returns false when driver has no permit or licensed passenger");
            cannotDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { true, false, 80 }, false));  // has permit, by no licensed passenger, passenger's age irrelevant
            cannotDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { true, false, 21 }, false));  //
            cannotDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { true, false, 16 }, false));  //
            cannotDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, true, 80 }, false));  // has licensed passenger, but no permit, passenger's age irrelevant
            cannotDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, true, 21 }, false));  //
            cannotDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, true, 16 }, false));  //
            cannotDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, false, 80 }, false)); // has neither permit nor licensed passenger, passenger's age irrelevant (for the sake of completeness)
            cannotDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, false, 21 }, false)); //   tested for completeness-sake
            cannotDriveNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, false, 16 }, false)); //

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(canDriveAgeLimit);
            testGroups.Add(cannotDriveAgeLimitUnderage);
            testGroups.Add(cannotDriveNoPermitOrLicensedPassenger);

            TestSuite testSuite = new TestSuite(testGroups, typeof(AllowDriving), nameof(AllowDriving.CanDrive), typeof(bool), typeof(bool), typeof(int));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise02_03_CanDriveGuardian()
        {
            // hasPermit is true, withLicensedPassenger is true, passengerAge GTE 21
            TestGroup canDriveAge21 = new TestGroup("Returns true when driver has permit and licensed passenger who is 21 or older");
            canDriveAge21.AddTest(new Test(new object[] { true, true, 80, true }, true));
            canDriveAge21.AddTest(new Test(new object[] { true, true, 21, true }, true));
            canDriveAge21.AddTest(new Test(new object[] { true, true, 80, false }, true));
            canDriveAge21.AddTest(new Test(new object[] { true, true, 21, false }, true));

            // hasPermit is true, withLicensedPassenger is true, passengerAge GTE 18 and LTE 20, isPassengerOurGuardian is true
            TestGroup canDriveAge18Guardian = new TestGroup("Returns true when driver has permit and licensed passenger between 18 and 20 who is their guardian");
            canDriveAge18Guardian.AddTest(new Test(new object[] { true, true, 20, true }, true));
            canDriveAge18Guardian.AddTest(new Test(new object[] { true, true, 18, true }, true));

            // hasPermit is true, withLicensedPassenger is true, passengerAge GTE 18 and LTE 20, isPassengerOurGuardian is false
            TestGroup canDriveAge18NotGuardian = new TestGroup("Returns false when driver has permit and licensed passenger between 18 and 20 who isn't their guardian");
            canDriveAge18NotGuardian.AddTest(new Test(new object[] { true, true, 20, false }, false));
            canDriveAge18NotGuardian.AddTest(new Test(new object[] { true, true, 18, false }, false));

            // hasPermit is true, withLicensedPassenger is true, passengerAge LT 18, isPassengerOurGuardian irrelevant
            TestGroup canDriveGuardianUnderage = new TestGroup("Returns false when driver has permit and licensed passenger under 18");
            canDriveGuardianUnderage.AddTest(new Test(new object[] { true, true, 17, false }, false));
            canDriveGuardianUnderage.AddTest(new Test(new object[] { true, true, 17, true }, false));

            // either hasPermit is true or withLicensedPassenger is true, but not both are true, passengerAge and isPassengerOUrGuardian irrelevant
            TestGroup canDriveGuardianNoPermitOrLicensedPassenger = new TestGroup("Returns false when diver has no permit or licensed passenger");
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { true, false, 80, true }, false));    // has permit, by no licensed passenger, any passenger's age and guardian status irrelevant
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { true, false, 21, true }, false));    //
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { true, false, 16, true }, false));    //
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { true, false, 80, false }, false));   // has permit, by no licensed passenger, any passenger's age and guardian status irrelevant
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { true, false, 21, false }, false));   //
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { true, false, 16, false }, false));   //
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, true, 80, true }, false));    // has licensed passenger, but no permit, any passenger's age and guardian status irrelevant
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, true, 21, true }, false));    //
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, true, 16, true }, false));    //
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, true, 80, false }, false));   // has licensed passenger, but not permit, any passenger's age and guardian status irrelevant
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, true, 21, false }, false));   //
            canDriveGuardianNoPermitOrLicensedPassenger.AddTest(new Test(new object[] { false, true, 16, false }, false));   //

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(canDriveAge21);
            testGroups.Add(canDriveAge18Guardian);
            testGroups.Add(canDriveAge18NotGuardian);
            testGroups.Add(canDriveGuardianUnderage);
            testGroups.Add(canDriveGuardianNoPermitOrLicensedPassenger);

            TestSuite testSuite = new TestSuite(testGroups, typeof(AllowDriving), nameof(AllowDriving.CanDrive), typeof(bool), typeof(bool), typeof(int), typeof(bool));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise03_01_CalculateShippingRate()
        {
            // weight GT 40
            TestGroup shippingRateWeightOver40 = new TestGroup("Returns 0.75 when weight is greater than 40 lbs.");
            shippingRateWeightOver40.AddTest(new Test(new object[] { 50 }, 0.75));
            shippingRateWeightOver40.AddTest(new Test(new object[] { 41 }, 0.75));

            // weight LTE 40
            TestGroup shippingRateWeightUpTo40 = new TestGroup("Returns 0.5 when weight is 40 lbs. or less");
            shippingRateWeightUpTo40.AddTest(new Test(new object[] { 40 }, 0.5));
            shippingRateWeightUpTo40.AddTest(new Test(new object[] { 35 }, 0.5));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(shippingRateWeightOver40);
            testGroups.Add(shippingRateWeightUpTo40);

            TestSuite testSuite = new TestSuite(testGroups, typeof(ShippingTotal), nameof(ShippingTotal.CalculateShippingRate), typeof(int));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise03_02_CalculateShippingTotal()
        {
            // weight GT 40
            TestGroup shippingTotalWeightOver40 = new TestGroup("Returns correct total when weight is greater than 40 lbs.");
            shippingTotalWeightOver40.AddTest(new Test(new object[] { 50 }, 37.5));
            shippingTotalWeightOver40.AddTest(new Test(new object[] { 41 }, 30.75));

            // weight LTE 40
            TestGroup shippingTotalWeightUpTo40 = new TestGroup("Returns correct total when weight is 40 lbs. or less");
            shippingTotalWeightUpTo40.AddTest(new Test(new object[] { 40 }, 20.0));
            shippingTotalWeightUpTo40.AddTest(new Test(new object[] { 35 }, 17.5));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(shippingTotalWeightOver40);
            testGroups.Add(shippingTotalWeightUpTo40);

            TestSuite testSuite = new TestSuite(testGroups, typeof(ShippingTotal), nameof(ShippingTotal.CalculateShippingTotal), typeof(int));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise03_03_CalculateShippingTotalDiscounted()
        {
            // weight GT 40, hasDiscount is true
            TestGroup shippingTotalWeightOver40Discounted = new TestGroup("Returns correct total when weight is greater than 40 lbs. and there's a discount");
            shippingTotalWeightOver40Discounted.AddTest(new Test(new object[] { 50, true }, 33.75));
            shippingTotalWeightOver40Discounted.AddTest(new Test(new object[] { 41, true }, 27.675));

            // weight GT 40, hasDiscount is false
            TestGroup shippingTotalWeightOver40NoDiscount = new TestGroup("Returns correct total when weight is greater than 40 lbs. and no discount");
            shippingTotalWeightOver40NoDiscount.AddTest(new Test(new object[] { 50, false }, 37.5));
            shippingTotalWeightOver40NoDiscount.AddTest(new Test(new object[] { 41, false }, 30.75));

            // weight LTE 40, hasDiscount is true
            TestGroup shippingTotalWeightUpTo40Discounted = new TestGroup("Returns correct total when weight is 40 lbs. or less and there's a discount");
            shippingTotalWeightUpTo40Discounted.AddTest(new Test(new object[] { 40, true }, 18.0));
            shippingTotalWeightUpTo40Discounted.AddTest(new Test(new object[] { 35, true }, 15.75));

            // weight LTE 40, hasDiscount is false
            TestGroup shippingTotalWeightUpTo40NoDiscount = new TestGroup("Returns correct total when weight is 40 lbs. or less and no discount");
            shippingTotalWeightUpTo40NoDiscount.AddTest(new Test(new object[] { 40, false }, 20.0));
            shippingTotalWeightUpTo40NoDiscount.AddTest(new Test(new object[] { 35, false }, 17.5));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(shippingTotalWeightOver40Discounted);
            testGroups.Add(shippingTotalWeightOver40NoDiscount);
            testGroups.Add(shippingTotalWeightUpTo40Discounted);
            testGroups.Add(shippingTotalWeightUpTo40NoDiscount);

            TestSuite testSuite = new TestSuite(testGroups, typeof(ShippingTotal), nameof(ShippingTotal.CalculateShippingTotal), typeof(int), typeof(bool));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise04_01_CalculateStayTotal()
        {
            // numberOfNights GTE 3
            TestGroup stayTotalDiscountRate = new TestGroup("Returns correct amount when stay is 3 nights or more");
            stayTotalDiscountRate.AddTest(new Test(new object[] { 5 }, 449.95));
            stayTotalDiscountRate.AddTest(new Test(new object[] { 3 }, 269.97));

            // numberOfNights LT 3
            TestGroup stayTotalDailyRate = new TestGroup("Returns correct amount when stay is less than 3 nights");
            stayTotalDailyRate.AddTest(new Test(new object[] { 2 }, 199.98));
            stayTotalDailyRate.AddTest(new Test(new object[] { 1 }, 99.99));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(stayTotalDiscountRate);
            testGroups.Add(stayTotalDailyRate);

            TestSuite testSuite = new TestSuite(testGroups, typeof(HotelReservation), nameof(HotelReservation.CalculateStayTotal), typeof(int));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise04_02_CalculateStayTotalParking()
        {
            // numberOfNights GTE 3, includesParking is true
            TestGroup stayTotalDiscountRateWithParking = new TestGroup("Returns correct amount when stay is 3 nights or more and parking is included");
            stayTotalDiscountRateWithParking.AddTest(new Test(new object[] { 5, true }, 574.95));
            stayTotalDiscountRateWithParking.AddTest(new Test(new object[] { 3, true }, 344.97));

            // numberOfNights GTE 3, includesParking is false
            TestGroup stayTotalDiscountRateNoParking = new TestGroup("Returns correct amount when stay is 3 nights or more and no parking");
            stayTotalDiscountRateNoParking.AddTest(new Test(new object[] { 5, false }, 449.95));
            stayTotalDiscountRateNoParking.AddTest(new Test(new object[] { 3, false }, 269.97));

            // numberOfNights LT 3, includesParking is true
            TestGroup stayTotalDailyRateWithParking = new TestGroup("Returns correct amount when stay is less than 3 nights and parking is included");
            stayTotalDailyRateWithParking.AddTest(new Test(new object[] { 2, true }, 249.98));
            stayTotalDailyRateWithParking.AddTest(new Test(new object[] { 1, true }, 124.99));

            // numberOfNights LT 3, includesParking is false
            TestGroup stayTotalDailyRateNoParking = new TestGroup("Returns correct amount when stay is less than 3 nights and no parking");
            stayTotalDailyRateNoParking.AddTest(new Test(new object[] { 2, false }, 199.98));
            stayTotalDailyRateNoParking.AddTest(new Test(new object[] { 1, false }, 99.99));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(stayTotalDiscountRateWithParking);
            testGroups.Add(stayTotalDiscountRateNoParking);
            testGroups.Add(stayTotalDailyRateWithParking);
            testGroups.Add(stayTotalDailyRateNoParking);

            TestSuite testSuite = new TestSuite(testGroups, typeof(HotelReservation), nameof(HotelReservation.CalculateStayTotal), typeof(int), typeof(bool));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise04_03_CalculateStayTotalLateCheckout()
        {
            // numberOfNights GTE 3, includesParking is true, includesLateCheckout is true
            TestGroup stayTotalDiscountRateWithParkingLateCheckout = new TestGroup("Returns correct amount when stay is 3 nights or more with parking included and late checkout");
            stayTotalDiscountRateWithParkingLateCheckout.AddTest(new Test(new object[] { 5, true, true }, 594.95));
            stayTotalDiscountRateWithParkingLateCheckout.AddTest(new Test(new object[] { 3, true, true }, 364.97));

            // numberOfNights GTE 3, includesParking is true, includesLateCheckout is false
            TestGroup stayTotalDiscountRateWithParkingLateNoLateCheckout = new TestGroup("Returns correct amount when stay is 3 nights or more with parking included but no late checkout");
            stayTotalDiscountRateWithParkingLateNoLateCheckout.AddTest(new Test(new object[] { 5, true, false }, 574.95));
            stayTotalDiscountRateWithParkingLateNoLateCheckout.AddTest(new Test(new object[] { 3, true, false }, 344.97));

            // numberOfNights GTE 3, includesParking is false, includesLateCheckout is true
            TestGroup stayTotalDiscountRateWithNoParkingLateCheckout = new TestGroup("Returns correct amount when stay is 3 nights or more with no parking included but late checkout");
            stayTotalDiscountRateWithNoParkingLateCheckout.AddTest(new Test(new object[] { 5, false, true }, 469.95));
            stayTotalDiscountRateWithNoParkingLateCheckout.AddTest(new Test(new object[] { 3, false, true }, 289.97));

            // numberOfNights GTE 3, includesParking is false, includesLateCheckout is false
            TestGroup stayTotalDiscountRateWithNoParkingNoLateCheckout = new TestGroup("Returns correct amount when stay is 3 nights or more with no parking included or late checkout");
            stayTotalDiscountRateWithNoParkingNoLateCheckout.AddTest(new Test(new object[] { 5, false, false }, 449.95));
            stayTotalDiscountRateWithNoParkingNoLateCheckout.AddTest(new Test(new object[] { 3, false, false }, 269.97));

            // numberOfNights LT 3, includesParking is true, includesLateCheckout is true
            TestGroup stayTotalDailyRateWithParkingLateCheckout = new TestGroup("Returns correct amount when stay is less than 3 nights with parking included and late checkout");
            stayTotalDailyRateWithParkingLateCheckout.AddTest(new Test(new object[] { 2, true, true }, 269.98));
            stayTotalDailyRateWithParkingLateCheckout.AddTest(new Test(new object[] { 1, true, true }, 144.99));

            // numberOfNights LT 3, includesParking is true, includesLateCheckout is false
            TestGroup stayTotalDailyRateWithParkingNoLateCheckout = new TestGroup("Returns correct amount when stay is less than 3 nights with parking included but no late checkout");
            stayTotalDailyRateWithParkingNoLateCheckout.AddTest(new Test(new object[] { 2, true, false }, 249.98));
            stayTotalDailyRateWithParkingNoLateCheckout.AddTest(new Test(new object[] { 1, true, false }, 124.99));

            // numberOfNights LT 3, includesParking is false, includesLateCheckout is true
            TestGroup stayTotalDailyRateWithNoParkingLateCheckout = new TestGroup("Returns correct amount when stay is less than 3 nights with no parking included but late checkout");
            stayTotalDailyRateWithNoParkingLateCheckout.AddTest(new Test(new object[] { 2, false, true }, 219.98));
            stayTotalDailyRateWithNoParkingLateCheckout.AddTest(new Test(new object[] { 1, false, true }, 119.99));

            // numberOfNights LT 3, includesParking is false, includesLateCheckout is false
            TestGroup stayTotalDailyRateWithNoParkingNoLateCheckout = new TestGroup("Returns correct amount when stay is less than 3 nights with no parking included or late checkout");
            stayTotalDailyRateWithNoParkingNoLateCheckout.AddTest(new Test(new object[] { 2, false, false }, 199.98));
            stayTotalDailyRateWithNoParkingNoLateCheckout.AddTest(new Test(new object[] { 1, false, false }, 99.99));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(stayTotalDiscountRateWithParkingLateCheckout);
            testGroups.Add(stayTotalDiscountRateWithParkingLateNoLateCheckout);
            testGroups.Add(stayTotalDiscountRateWithNoParkingLateCheckout);
            testGroups.Add(stayTotalDiscountRateWithNoParkingNoLateCheckout);
            testGroups.Add(stayTotalDailyRateWithParkingLateCheckout);
            testGroups.Add(stayTotalDailyRateWithParkingNoLateCheckout);
            testGroups.Add(stayTotalDailyRateWithNoParkingLateCheckout);
            testGroups.Add(stayTotalDailyRateWithNoParkingNoLateCheckout);

            TestSuite testSuite = new TestSuite(testGroups, typeof(HotelReservation), nameof(HotelReservation.CalculateStayTotal), typeof(int), typeof(bool), typeof(bool));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise05_01_AcceptPackageWeight()
        {
            // weightPounds LTE 40
            TestGroup acceptPackageWeightUpTo40 = new TestGroup("Returns true when weight is acceptable");
            acceptPackageWeightUpTo40.AddTest(new Test(new object[] { 40 }, true));
            acceptPackageWeightUpTo40.AddTest(new Test(new object[] { 30 }, true));

            // weightPounds GT 40
            TestGroup acceptPackageWeightOver40 = new TestGroup("Returns false when weight is over");
            acceptPackageWeightOver40.AddTest(new Test(new object[] { 41 }, false));
            acceptPackageWeightOver40.AddTest(new Test(new object[] { 50 }, false));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(acceptPackageWeightUpTo40);
            testGroups.Add(acceptPackageWeightOver40);

            TestSuite testSuite = new TestSuite(testGroups, typeof(PackageAcceptance), nameof(PackageAcceptance.AcceptPackage), typeof(int));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise05_02_AcceptPackageWeightVolume()
        {
            // weightPounds LTE 40, volume LTE 10,368
            TestGroup acceptPackageWeightUpTo40VolumeUpTo10368 = new TestGroup("Returns true when weight and volume are acceptable");
            acceptPackageWeightUpTo40VolumeUpTo10368.AddTest(new Test(new object[] { 40, 36, 24, 12 }, true));   // weight 40, permute dimensions
            acceptPackageWeightUpTo40VolumeUpTo10368.AddTest(new Test(new object[] { 40, 36, 12, 24 }, true));   //
            acceptPackageWeightUpTo40VolumeUpTo10368.AddTest(new Test(new object[] { 40, 24, 36, 12 }, true));   //
            acceptPackageWeightUpTo40VolumeUpTo10368.AddTest(new Test(new object[] { 40, 24, 12, 36 }, true));   //
            acceptPackageWeightUpTo40VolumeUpTo10368.AddTest(new Test(new object[] { 40, 36, 24, 12 }, true));   //
            acceptPackageWeightUpTo40VolumeUpTo10368.AddTest(new Test(new object[] { 40, 12, 24, 36 }, true));   //
            acceptPackageWeightUpTo40VolumeUpTo10368.AddTest(new Test(new object[] { 30, 36, 24, 12 }, true));   // weight 30, no need to further permute dimensions

            // weightPounds LTE 40, volume GT 10,368
            TestGroup rejectPackageWeightUpTo40VolumeOver10368 = new TestGroup("Returns false when weight is acceptable but volume is over");
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 37, 24, 12 }, false));  // weight 40, permute dimensions
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 37, 12, 24 }, false));  //
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 24, 37, 12 }, false));  //
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 24, 12, 37 }, false));  //
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 37, 24, 12 }, false));  //
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 12, 24, 37 }, false));  //
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 30, 37, 24, 12 }, false));  // weight 30, no need to further permute dimensions

            // weightPounds GT 40, volume LTE 10,368
            TestGroup rejectPackageWeightOver40VolumeUpTo10368 = new TestGroup("Returns false when volume is acceptable but weight is over");
            rejectPackageWeightOver40VolumeUpTo10368.AddTest(new Test(new object[] { 41, 36, 24, 12 }, false));
            rejectPackageWeightOver40VolumeUpTo10368.AddTest(new Test(new object[] { 50, 36, 24, 12 }, false));

            // Since the package is rejected if either the weightPounds or volume tests fail, it's not necessary to test if they fail together.

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(acceptPackageWeightUpTo40VolumeUpTo10368);
            testGroups.Add(rejectPackageWeightUpTo40VolumeOver10368);
            testGroups.Add(rejectPackageWeightOver40VolumeUpTo10368);

            TestSuite testSuite = new TestSuite(testGroups, typeof(PackageAcceptance), nameof(PackageAcceptance.AcceptPackage), typeof(int), typeof(int), typeof(int), typeof(int));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise05_03_AcceptPackageWeightVolumeDimensions()
        {
            // weightPounds LTE 40, volume LTE 10,368, dimension LTE 66, isSurchargePaid irrelevant
            TestGroup acceptPackageWeightUpTo40VolumeUpTo10368DimensionUpTo66 = new TestGroup("Returns true when weight, volume, and dimensions are acceptable");
            acceptPackageWeightUpTo40VolumeUpTo10368DimensionUpTo66.AddTest(new Test(new object[] { 40, 36, 24, 12, true }, true));  // weight 40, permute dimensions
            acceptPackageWeightUpTo40VolumeUpTo10368DimensionUpTo66.AddTest(new Test(new object[] { 40, 36, 12, 24, true }, true));  //
            acceptPackageWeightUpTo40VolumeUpTo10368DimensionUpTo66.AddTest(new Test(new object[] { 40, 24, 36, 12, true }, true));  //
            acceptPackageWeightUpTo40VolumeUpTo10368DimensionUpTo66.AddTest(new Test(new object[] { 40, 24, 12, 36, false }, true)); //
            acceptPackageWeightUpTo40VolumeUpTo10368DimensionUpTo66.AddTest(new Test(new object[] { 40, 36, 24, 12, false }, true)); //
            acceptPackageWeightUpTo40VolumeUpTo10368DimensionUpTo66.AddTest(new Test(new object[] { 40, 12, 24, 36, false }, true)); //
            acceptPackageWeightUpTo40VolumeUpTo10368DimensionUpTo66.AddTest(new Test(new object[] { 30, 36, 24, 12, true }, true));  // weight 30, no need to further permute dimensions
            acceptPackageWeightUpTo40VolumeUpTo10368DimensionUpTo66.AddTest(new Test(new object[] { 30, 36, 24, 12, true }, true));  // weight 30, no need to further permute dimensions

            // weightPounds LTE 40, volume LTE 10,368, dimension GT 66, isSurchargePaid is true
            TestGroup rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66IsSurchargePaid = new TestGroup("Returns true when weight and volume are acceptable, but package is over-sized with surcharge paid");
            rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66IsSurchargePaid.AddTest(new Test(new object[] { 40, 67, 12, 12, true }, true));   // weight 40, rotate too large dimension
            rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66IsSurchargePaid.AddTest(new Test(new object[] { 40, 12, 67, 12, true }, true));   //
            rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66IsSurchargePaid.AddTest(new Test(new object[] { 40, 12, 12, 67, true }, true));   //
            rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66IsSurchargePaid.AddTest(new Test(new object[] { 30, 67, 12, 12, true }, true));   // weight 30, no need to further permute dimensions

            // weightPounds LTE 40, volume LTE 10,368, at least one dimension GT 66, isSurchargePaid is false
            TestGroup rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66SurchargeNotPaid = new TestGroup("Returns false when weight and volume are acceptable, but package is over-sized with no surcharge paid");
            rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66SurchargeNotPaid.AddTest(new Test(new object[] { 40, 67, 12, 12, false }, false));    // weight 40, rotate too large dimension
            rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66SurchargeNotPaid.AddTest(new Test(new object[] { 40, 12, 67, 12, false }, false));    //
            rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66SurchargeNotPaid.AddTest(new Test(new object[] { 40, 12, 12, 67, false }, false));    //
            rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66SurchargeNotPaid.AddTest(new Test(new object[] { 30, 67, 12, 12, false }, false));    // weight 30, no need to further permute dimensions

            // weightPounds LTE 40, volume GT 10,368, dimension and isSurcharge irrelevant
            TestGroup rejectPackageWeightUpTo40VolumeOver10368 = new TestGroup("Returns false when weight is acceptable but volume is over");
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 37, 24, 12, true }, false));    // weight 40, permute dimensions
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 37, 12, 24, true }, false));    //
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 24, 37, 12, true }, false));    //
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 24, 12, 37, false }, false));   //
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 37, 24, 12, false }, false));   //
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 40, 12, 24, 37, false }, false));   //
            rejectPackageWeightUpTo40VolumeOver10368.AddTest(new Test(new object[] { 30, 37, 24, 12, false }, false));   // weight 30, no need to further permute dimensions

            // weightPounds GT 40, volume LTE 10,368, dimension and isSurcharge irrelevant
            TestGroup rejectPackageWeightOver40VolumeUpTo10368 = new TestGroup("Returns false when volume is acceptable but weight is over");
            rejectPackageWeightOver40VolumeUpTo10368.AddTest(new Test(new object[] { 41, 36, 24, 12, false }, false));
            rejectPackageWeightOver40VolumeUpTo10368.AddTest(new Test(new object[] { 50, 36, 24, 12, false }, false));

            // Since the package is rejected if weightPounds, volume, or dimension with surcharge tests fail, it's not necessary to test if they fail together.

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(acceptPackageWeightUpTo40VolumeUpTo10368DimensionUpTo66);
            testGroups.Add(rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66IsSurchargePaid);
            testGroups.Add(rejectPackageWeightUpTo40VolumeUpTo10368DimensionOver66SurchargeNotPaid);

            testGroups.Add(rejectPackageWeightUpTo40VolumeOver10368);
            testGroups.Add(rejectPackageWeightOver40VolumeUpTo10368);

            TestSuite testSuite = new TestSuite(testGroups, typeof(PackageAcceptance), nameof(PackageAcceptance.AcceptPackage), typeof(int), typeof(int), typeof(int), typeof(int), typeof(bool));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise06_01_DetermineRaceBlock()
        {
            // age LT 18, isEarlyRegistration irrelevant
            TestGroup determineRaceBlockLess18 = new TestGroup("Returns 3 when runner is under 18");
            determineRaceBlockLess18.AddTest(new Test(new object[] { 17, true }, 3));
            determineRaceBlockLess18.AddTest(new Test(new object[] { 12, true }, 3));
            determineRaceBlockLess18.AddTest(new Test(new object[] { 17, false }, 3));
            determineRaceBlockLess18.AddTest(new Test(new object[] { 12, false }, 3));

            // age GTE 18, isEarlyRegistration is true
            TestGroup determineRaceBlock18EarlyRegistration = new TestGroup("Returns 1 when runner is 18 or over and an early registration");
            determineRaceBlock18EarlyRegistration.AddTest(new Test(new object[] { 18, true }, 1));
            determineRaceBlock18EarlyRegistration.AddTest(new Test(new object[] { 80, true }, 1));

            // age GTE 18, isEarlyRegistration is false
            TestGroup determineRaceBlock18NotEarlyRegistration = new TestGroup("Returns 2 when runner is 18 or over and not an early registration");
            determineRaceBlock18NotEarlyRegistration.AddTest(new Test(new object[] { 18, false }, 2));
            determineRaceBlock18NotEarlyRegistration.AddTest(new Test(new object[] { 80, false }, 2));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(determineRaceBlockLess18);
            testGroups.Add(determineRaceBlock18EarlyRegistration);
            testGroups.Add(determineRaceBlock18NotEarlyRegistration);

            TestSuite testSuite = new TestSuite(testGroups, typeof(RaceDay), nameof(RaceDay.DetermineRaceBlock), typeof(int), typeof(bool));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise06_02_GetBibNumber()
        {
            // age LT 18, isEarlyRegistration irrelevant
            TestGroup getBibNumberLess18 = new TestGroup("Returns correct bib number when runner is under 18");
            getBibNumberLess18.AddTest(new Test(new object[] { 17, 1, true }, 1));
            getBibNumberLess18.AddTest(new Test(new object[] { 12, 2, true }, 2));
            getBibNumberLess18.AddTest(new Test(new object[] { 17, 3, false }, 3));
            getBibNumberLess18.AddTest(new Test(new object[] { 12, 4, false }, 4));

            // age GTE 18, isEarlyRegistration is true
            TestGroup getBibNumber18EarlyRegistration = new TestGroup("Returns correct bib number when runner is over 18 and an early registration");
            getBibNumber18EarlyRegistration.AddTest(new Test(new object[] { 80, 1, true }, 1001));
            getBibNumber18EarlyRegistration.AddTest(new Test(new object[] { 18, 2, true }, 1002));

            // age GTE 18, isEarlyRegistration is false
            TestGroup getBibNumber18NotEarlyRegistration = new TestGroup("Returns correct bib number when runner is 18 or over and not an early registration");
            getBibNumber18NotEarlyRegistration.AddTest(new Test(new object[] { 80, 1, false }, 1));
            getBibNumber18NotEarlyRegistration.AddTest(new Test(new object[] { 18, 2, false }, 2));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(getBibNumberLess18);
            testGroups.Add(getBibNumber18EarlyRegistration);
            testGroups.Add(getBibNumber18NotEarlyRegistration);

            TestSuite testSuite = new TestSuite(testGroups, typeof(RaceDay), nameof(RaceDay.GetBibNumber), typeof(int), typeof(int), typeof(bool));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise06_03_GetConfirmedBibNumber()
        {
            // age LT 18, isEarlyRegistration irrelevant
            TestGroup getConfirmedBibNumberLess18 = new TestGroup("Returns correct bib number when runner is under 18");
            getConfirmedBibNumberLess18.AddTest(new Test(new object[] { 17, 1, true }, 1));
            getConfirmedBibNumberLess18.AddTest(new Test(new object[] { 12, 2, true }, 2));
            getConfirmedBibNumberLess18.AddTest(new Test(new object[] { 17, 3, false }, 3));
            getConfirmedBibNumberLess18.AddTest(new Test(new object[] { 12, 4, false }, 4));

            // age GTE 18, isEarlyRegistration is true
            TestGroup getConfirmedBibNumber18EarlyRegistration = new TestGroup("Returns correct bib number when runner is 18 or over and an early registration");
            getConfirmedBibNumber18EarlyRegistration.AddTest(new Test(new object[] { 80, 1, true }, 1001));
            getConfirmedBibNumber18EarlyRegistration.AddTest(new Test(new object[] { 18, 2, true }, 1002));

            // age GTE 18, isEarlyRegistration is false, registrationNumber LTE 1000
            TestGroup getConfirmedBibNumber18NotEarlyRegistrationless1000 = new TestGroup("Returns correct bib number when runner is 18 or over, not an early registration, but a spot remains");
            getConfirmedBibNumber18NotEarlyRegistrationless1000.AddTest(new Test(new object[] { 80, 999, false }, 999));
            getConfirmedBibNumber18NotEarlyRegistrationless1000.AddTest(new Test(new object[] { 18, 1000, false }, 1000));

            // age GTE 18, isEarlyRegistration is false, registrationNumber GT 1000
            TestGroup getConfirmedBibNumber18NotEarlyRegistration1001 = new TestGroup("Returns -1 when runner is 18 or over, not an early registration, and no spots remain");
            getConfirmedBibNumber18NotEarlyRegistration1001.AddTest(new Test(new object[] { 80, 1001, false }, -1));
            getConfirmedBibNumber18NotEarlyRegistration1001.AddTest(new Test(new object[] { 18, 1111, false }, -1));

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(getConfirmedBibNumberLess18);
            testGroups.Add(getConfirmedBibNumber18EarlyRegistration);
            testGroups.Add(getConfirmedBibNumber18NotEarlyRegistrationless1000);
            testGroups.Add(getConfirmedBibNumber18NotEarlyRegistration1001);

            TestSuite testSuite = new TestSuite(testGroups, typeof(RaceDay), nameof(RaceDay.GetConfirmedBibNumber), typeof(int), typeof(int), typeof(bool));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise07_01_IsStoreOpen()
        {
            TestGroup storeOpen = new TestGroup("Returns true when within open hours");
            storeOpen.AddTest(new Test(new object[] { 8 }, true));       // opening
            storeOpen.AddTest(new Test(new object[] { 9 }, true));
            storeOpen.AddTest(new Test(new object[] { 15 }, true));
            storeOpen.AddTest(new Test(new object[] { 16 }, true));      // last full hour before closing

            TestGroup storeClosed = new TestGroup("Returns false when not within open hours");
            storeClosed.AddTest(new Test(new object[] { 0 }, false));        // midnight
            storeClosed.AddTest(new Test(new object[] { 7 }, false));        // one hour before opening
            storeClosed.AddTest(new Test(new object[] { 17 }, false));       // closing hour
            storeClosed.AddTest(new Test(new object[] { 24 }, false));       // midnight

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(storeOpen);
            testGroups.Add(storeClosed);

            TestSuite testSuite = new TestSuite(testGroups, typeof(StoreHours), nameof(StoreHours.IsStoreOpen), typeof(int));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise07_02_IsStoreOpenCurrentDay()
        {
            TestGroup storeOpen = new TestGroup("Returns true when within open hours on Monday, Wednesday, or Friday");
            storeOpen.AddTest(new Test(new object[] { 8, 'M' }, true));      // opening Monday
            storeOpen.AddTest(new Test(new object[] { 8, 'W' }, true));      // opening Wednesday
            storeOpen.AddTest(new Test(new object[] { 8, 'F' }, true));      // opening Friday
            storeOpen.AddTest(new Test(new object[] { 16, 'M' }, true));     // last full hour Monday
            storeOpen.AddTest(new Test(new object[] { 16, 'W' }, true));     // last full hour Wednesday
            storeOpen.AddTest(new Test(new object[] { 16, 'F' }, true));     // last full hour Friday

            TestGroup storeClosedHours = new TestGroup("Returns false when not within open hours on Monday, Wednesday, or Friday");
            storeClosedHours.AddTest(new Test(new object[] { 7, 'M' }, false));   // too early Monday
            storeClosedHours.AddTest(new Test(new object[] { 7, 'W' }, false));   // too early Wednesday
            storeClosedHours.AddTest(new Test(new object[] { 7, 'F' }, false));   // too early Friday
            storeClosedHours.AddTest(new Test(new object[] { 17, 'M' }, false));  // too late Monday
            storeClosedHours.AddTest(new Test(new object[] { 17, 'W' }, false));  // too late Wednesday
            storeClosedHours.AddTest(new Test(new object[] { 17, 'F' }, false));  // too late Friday

            TestGroup storeClosedDay = new TestGroup("Returns false when not open at all on that day");
            storeClosedDay.AddTest(new Test(new object[] { 8, 'S' }, false));   // not open Saturday, current hour is meaningless
            storeClosedDay.AddTest(new Test(new object[] { 16, 'U' }, false));  // not open Sunday, current hour is meaningless
            storeClosedDay.AddTest(new Test(new object[] { 14, 'H' }, false));  // not open Thursday, current hour is meaningless
            storeClosedDay.AddTest(new Test(new object[] { 10, 'T' }, false));  // not open Tuesday, current hour is meaningless

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(storeOpen);
            testGroups.Add(storeClosedHours);
            testGroups.Add(storeClosedDay);

            TestSuite testSuite = new TestSuite(testGroups, typeof(StoreHours), nameof(StoreHours.IsStoreOpen), typeof(int), typeof(char));

            RunTestSuite(testSuite);
        }

        [TestMethod]
        public void Exercise07_03_IsStoreOpenSummer()
        {
            TestGroup mondayFriday = new TestGroup("Returns correct open status when Monday or Friday");
            mondayFriday.AddTest(new Test(new object[] { 8, 'M', true }, true));       // opening Monday (summer)
            mondayFriday.AddTest(new Test(new object[] { 8, 'F', true }, true));       // opening Friday (summer)
            mondayFriday.AddTest(new Test(new object[] { 16, 'M', true }, true));      // last full hour Monday (summer)
            mondayFriday.AddTest(new Test(new object[] { 16, 'F', true }, true));      // last full hour Friday (summer)
            mondayFriday.AddTest(new Test(new object[] { 8, 'M', false }, true));      // opening Monday
            mondayFriday.AddTest(new Test(new object[] { 8, 'F', false }, true));      // opening Friday
            mondayFriday.AddTest(new Test(new object[] { 16, 'M', false }, true));     // last full hour Monday
            mondayFriday.AddTest(new Test(new object[] { 16, 'F', false }, true));     // last full hour Friday
            mondayFriday.AddTest(new Test(new object[] { 7, 'M', true }, false));      // too early Monday (summer)
            mondayFriday.AddTest(new Test(new object[] { 7, 'F', true }, false));      // too early Friday (summer)
            mondayFriday.AddTest(new Test(new object[] { 17, 'M', false }, false));    // too late Monday
            mondayFriday.AddTest(new Test(new object[] { 17, 'F', false }, false));    // too late Friday

            TestGroup wedSatNotSummer = new TestGroup("Returns correct open status when Wednesday or Saturday and not summer hours");
            wedSatNotSummer.AddTest(new Test(new object[] { 8, 'W', false }, true));    // opening Wednesday
            wedSatNotSummer.AddTest(new Test(new object[] { 16, 'W', false }, true));   // last full hour Wednesday
            wedSatNotSummer.AddTest(new Test(new object[] { 7, 'W', false }, false));   // too early Wednesday
            wedSatNotSummer.AddTest(new Test(new object[] { 17, 'W', false }, false));  // too late Wednesday
            wedSatNotSummer.AddTest(new Test(new object[] { 8, 'S', false }, false));    // closed Saturday
            wedSatNotSummer.AddTest(new Test(new object[] { 15, 'S', false }, false));   // closed Saturday

            TestGroup wedSatSummer = new TestGroup("Returns correct open status when Wednesday or Saturday and is summer hours");
            wedSatSummer.AddTest(new Test(new object[] { 8, 'W', true }, true));     // opening Wednesday
            wedSatSummer.AddTest(new Test(new object[] { 17, 'W', true }, true));    // previous close Wednesday
            wedSatSummer.AddTest(new Test(new object[] { 19, 'W', true }, true));    // last full hour Wednesday
            wedSatSummer.AddTest(new Test(new object[] { 7, 'W', true }, false));    // too early Wednesday
            wedSatSummer.AddTest(new Test(new object[] { 20, 'W', true }, false));   // too late Wednesday
            wedSatSummer.AddTest(new Test(new object[] { 9, 'S', true }, true));      // opening Saturday
            wedSatSummer.AddTest(new Test(new object[] { 14, 'S', true }, true));     // last full hour Saturday

            TestGroup storeClosedDay = new TestGroup("Returns false when not open at all on that day");
            storeClosedDay.AddTest(new Test(new object[] { 16, 'U', true }, false));  // not open Sunday, current hour is meaningless
            storeClosedDay.AddTest(new Test(new object[] { 16, 'U', false }, false));  // not open Sunday, current hour is meaningless
            storeClosedDay.AddTest(new Test(new object[] { 8, 'H', true }, false));   // not open Thursday, current hour is meaningless
            storeClosedDay.AddTest(new Test(new object[] { 16, 'T', false }, false));  // not open Tuesday, current hour is meaningless

            List<TestGroup> testGroups = new List<TestGroup>();
            testGroups.Add(mondayFriday);
            testGroups.Add(wedSatNotSummer);
            testGroups.Add(wedSatSummer);
            testGroups.Add(storeClosedDay);

            TestSuite testSuite = new TestSuite(testGroups, typeof(StoreHours), nameof(StoreHours.IsStoreOpen), typeof(int), typeof(char), typeof(bool));

            RunTestSuite(testSuite);
        }
    }
}
