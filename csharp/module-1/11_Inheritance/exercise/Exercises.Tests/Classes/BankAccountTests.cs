using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Exercise.Tests.ReflectionTestHelper;

namespace BankTellerExerciseTests.Classes
{
    [TestClass]
    public class BankAccountTests
    {
        private const string ClassName = "BankAccount";
        private const string NamespaceName = "BankTellerExercise.Classes";
        private static Type classType;

        [TestMethod]
        public void Test01_ClassWellFormed()
        {
            string wellFormedCheck = ClassWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail(wellFormedCheck);
            }
        }

        [TestMethod]
        public void Test02_HappyPathTests()
        {
            string wellFormedCheck = ClassWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail($"{ClassName} is not well formed. The Test01_ClassWellFormed tests must pass first.\r\n\t{wellFormedCheck}");
            }

            // Assert constructors set properties
            string testAccountHolderName = "Tester Testerson";
            string testAccountNumber = "CHK:1234";
            decimal testBalance = 100M;

            // Two arg constructor
            object twoArgInstance = SafeReflection.CreateInstance(classType, new object[] { testAccountHolderName, testAccountNumber });
            object twoArgAccountHolderName = SafeReflection.GetPropertyValue(twoArgInstance, "AccountHolderName");
            object twoArgAccountNumber = SafeReflection.GetPropertyValue(twoArgInstance, "AccountNumber");
            Assert.AreEqual(testAccountHolderName, twoArgAccountHolderName, $"{ClassName} two argument constructor {ClassName}(string, string) does not correctly set the property AccountHolderName.");
            Assert.AreEqual(testAccountNumber, twoArgAccountNumber, $"{ClassName} two argument constructor {ClassName}(string, string) does not correctly set the property AccountNumber.");

            // Three arg constructor
            object threeArgInstance = SafeReflection.CreateInstance(classType, new object[] { testAccountHolderName, testAccountNumber, testBalance });
            object threeArgAccountHolderName = SafeReflection.GetPropertyValue(threeArgInstance, "AccountHolderName");
            object threeArgAccountNumber = SafeReflection.GetPropertyValue(threeArgInstance, "AccountNumber");
            object threeArgBalance = SafeReflection.GetPropertyValue(threeArgInstance, "Balance");
            Assert.AreEqual(testAccountHolderName, threeArgAccountHolderName, $"{ClassName} three argument constructor {ClassName}(string, string, decimal) does not correctly set the property AccountHolderName.");
            Assert.AreEqual(testAccountNumber, threeArgAccountNumber, $"{ClassName} three argument constructor {ClassName}(string, string, decimal) does not correctly set the property AccountNumber.");
            Assert.AreEqual(testBalance, threeArgBalance, $"{ClassName} three argument constructor {ClassName}(string, string, decimal) does not correctly set the property Balance.");

            // Assert deposit increases balance
            MethodInfo deposit = SafeReflection.GetMethod(classType, "Deposit");
            decimal depositParamValue = 23;
            decimal depositExpectedReturnValue = testBalance + depositParamValue;
            object depositActualReturnValue = deposit.Invoke(threeArgInstance, new object[] { depositParamValue });
            Assert.AreEqual(depositExpectedReturnValue, depositActualReturnValue, $"{ClassName} Deposit method fails to increase balance by correct amount. Starting balance: {testBalance}, deposit: {depositParamValue}, new balance should be {depositExpectedReturnValue}.");

            // Assert withdraw decreases balance
            MethodInfo withdraw = SafeReflection.GetMethod(classType, "Withdraw");
            decimal withdrawParamValue = 22;
            decimal withdrawExpectedReturnValue = depositExpectedReturnValue - withdrawParamValue;
            object withdrawActualReturnValue = withdraw.Invoke(threeArgInstance, new object[] { withdrawParamValue });
            Assert.AreEqual(withdrawExpectedReturnValue, withdrawActualReturnValue, $"{ClassName} Withdraw method fails to decrease balance by correct amount. Starting balance: {depositExpectedReturnValue}, withdraw: {withdrawParamValue}, new balance should be {withdrawExpectedReturnValue}.");
        }

        [TestMethod]
        public void Test03_EdgeCaseTests()
        {
            string wellFormedCheck = ClassWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail($"{ClassName} is not well formed. The Test01_ClassWellFormed tests must pass first.\r\n\t{wellFormedCheck}");
            }

            MethodInfo deposit = SafeReflection.GetMethod(classType, "Deposit");
            MethodInfo withdraw = SafeReflection.GetMethod(classType, "Withdraw");

            // Assert two argument constructor defaults balance to 0
            object account = SafeReflection.CreateInstance(classType, new object[] { "", "" });
            object balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(0M, balance, $"{ClassName} two argument constructor {ClassName}(string, string) does not correctly default Balance to 0.");

            // Assert withdraw method can handle 0 balance
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 1M });
            withdraw.Invoke(account, new object[] { 1M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(0M, balance, $"{ClassName} Withdraw method fails to decrease balance by correct amount. Starting balance: 1, withdraw: 1, new balance should be 0.");

            // Assert deposit method can handle 0 balance
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 0M });
            deposit.Invoke(account, new object[] { 1M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(1M, balance, $"{ClassName} Deposit method fails to increase balance by correct amount. Starting balance: 0, deposit: 1, new balance should be 1.");

            // Assert can't deposit a negative amount
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 100M });
            deposit.Invoke(account, new object[] { -10M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(100M, balance, $"{ClassName} Deposit method fails to prevent negative deposit amount. Starting balance: 100, deposit: -10, balance should remain at 100.");

            // Assert can't withdraw a negative amount
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 100M });
            withdraw.Invoke(account, new object[] { -10M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(100M, balance, $"{ClassName} Withdraw method fails to prevent negative withdraw amount. Starting balance: 100, withdraw: -10, balance should remain at 100.");
        }

        private string ClassWellFormedCheck()
        {
            // Assert class exists
            classType = SafeReflection.GetType(ClassName, NamespaceName);

            if (classType == null) { return $"{ClassName} class not found. Have you declared it yet? Make sure the class name is '{ClassName}' and the namespace is '{NamespaceName}'."; }

            if (classType.IsAbstract) { return $"{ClassName} class must not be abstract. Remove the 'abstract' modifier on {ClassName}."; }

            // Assert constructors exist
            ConstructorInfo twoArgConstructor = SafeReflection.GetConstructor(classType, new Type[] { typeof(string), typeof(string) });
            if (twoArgConstructor == null) { return $"{ClassName} does not have the required two argument constructor {ClassName}(string, string). Make sure access for the constructor is public."; }

            ConstructorInfo threeArgConstructor = SafeReflection.GetConstructor(classType, new Type[] { typeof(string), typeof(string), typeof(decimal) });
            if (threeArgConstructor == null) { return $"{ClassName} does not have the required three argument constructor {ClassName}(string, string, decimal). Make sure access for the constructor is public."; }

            // Assert properties exist, are of correct type and access
            string propertyCheck = CheckProperty(classType, "AccountHolderName", typeof(string), AccessModifier.Public, AccessModifier.Private);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            propertyCheck = CheckProperty(classType, "AccountNumber", typeof(string), AccessModifier.Public, AccessModifier.None);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            propertyCheck = CheckProperty(classType, "Balance", typeof(decimal), AccessModifier.Public, AccessModifier.Private);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            // Assert methods are present -- whether they work is confirmed in other test methods
            string methodCheck = CheckMethod(classType, "Deposit", typeof(decimal), true, false, new Type[] { typeof(decimal) });
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }
            methodCheck = CheckMethod(classType, "Withdraw", typeof(decimal), true, true, new Type[] { typeof(decimal) });
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }

            return "";
        }
    }
}
