using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTellerExerciseTests.Classes
{
    [TestClass]
    public class CheckingAccountTests
    {
        private const string ClassName = "CheckingAccount";
        private const string BaseName = "BankAccount";
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

            // Assert withdraw decreases balance
            MethodInfo withdraw = SafeReflection.GetMethod(classType, "Withdraw");
            decimal withdrawParamValue = 23;
            decimal withdrawExpectedReturnValue = testBalance - withdrawParamValue;
            object withdrawActualReturnValue = withdraw.Invoke(threeArgInstance, new object[] { withdrawParamValue });
            Assert.AreEqual(withdrawExpectedReturnValue, withdrawActualReturnValue, $"{ClassName} Withdraw method fails to decrease balance by correct amount. Starting balance: {testBalance}, withdraw: {withdrawParamValue}, new balance should be {withdrawExpectedReturnValue}.");
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

            // Assert 1 dollar under 0 balance allows overdraft and assesses fee
            object account = SafeReflection.CreateInstance(classType, new object[] { "", "", 100M });
            withdraw.Invoke(account, new object[] { 101M });
            object balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(-11M, balance, $"{ClassName} Withdraw method fails to decrease balance by correct amount. Starting balance: 100, withdraw: 101, new balance should be -11 (-1 is greater than -100, 10 fee incurred).");

            // Assert 10 dollar above -100 balance allows overdraft and assesses fee
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 100M });
            withdraw.Invoke(account, new object[] { 190M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(-100M, balance, $"{ClassName} Withdraw method fails to decrease balance by correct amount. Starting balance: 100, withdraw: 190, new balance should be -100 (-90 is greater than -100, 10 fee incurred).");

            // Assert 1 dollar above -100 balance allows overdraft and assesses fee
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 100M });
            withdraw.Invoke(account, new object[] { 199M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(-109M, balance, $"{ClassName} Withdraw method fails to decrease balance by correct amount. Starting balance: 100, withdraw: 199, new balance should be -109 (-99 is greater than -100, 10 fee incurred).");

            // Assert withdraw that would make -100 balance denies overdraft and doesn't assess fee
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 100M });
            withdraw.Invoke(account, new object[] { 200M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(100M, balance, $"{ClassName} Withdraw method fails to decrease balance by correct amount. Starting balance: 100, withdraw: 200, overdraft should be denied (100 - 200 >= -100) and balance remains at 100.");

            // Assert withdraw that would make 0 balance does not incur fee
            account = SafeReflection.CreateInstance(classType, new object[] { "", "", 100M });
            withdraw.Invoke(account, new object[] { 100M });
            balance = SafeReflection.GetPropertyValue(account, "Balance");
            Assert.AreEqual(0M, balance, $"{ClassName} Withdraw method fails to decrease balance by correct amount. Starting balance: 100, withdraw: 100, new balance should be 0. No fee incurred because balance is not less than 0.");

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

            // Assert CheckingAccount extends BankAccount
            if (BaseName != classType.BaseType.Name) { return $"{ClassName} must inherit from {BaseName}."; }

            // Assert constructors exist
            ConstructorInfo twoArgConstructor = SafeReflection.GetConstructor(classType, new Type[] { typeof(string), typeof(string) });
            if (twoArgConstructor == null) { return $"{ClassName} does not have the required two argument constructor {ClassName}(string, string). Make sure access for the constructor is public."; }

            ConstructorInfo threeArgConstructor = SafeReflection.GetConstructor(classType, new Type[] { typeof(string), typeof(string), typeof(decimal) });
            if (threeArgConstructor == null) { return $"{ClassName} does not have the required three argument constructor {ClassName}(string, string, decimal). Make sure access for the constructor is public."; }

            // Assert override methods are present -- whether they work is confirmed in other test methods
            string methodName = "Withdraw";
            MethodInfo withdraw = SafeReflection.GetMethod(classType, methodName);
            if (ClassName != withdraw.DeclaringType.Name) { return $"{ClassName} must declare {methodName} method and override the {BaseName} {methodName} method."; }
            if (BaseName != withdraw.GetBaseDefinition().DeclaringType.Name) { return $"{ClassName} must override {BaseName} {methodName} method."; }

            // Assert BankAccount properties are NOT redefined in CheckingAccount
            string propertyName = "AccountHolderName";
            PropertyInfo accountHolderName = SafeReflection.GetProperty(classType, propertyName);
            if (BaseName != accountHolderName.DeclaringType.Name) { return $"{ClassName} must NOT declare {propertyName} property, it should inherit from the {BaseName} class."; }

            propertyName = "AccountNumber";
            PropertyInfo accountNumber = SafeReflection.GetProperty(classType, propertyName);
            if (BaseName != accountNumber.DeclaringType.Name) { return $"{ClassName} must NOT declare {propertyName} property, it should inherit from the {BaseName} class."; }

            propertyName = "Balance";
            PropertyInfo balance = SafeReflection.GetProperty(classType, propertyName);
            if (BaseName != balance.DeclaringType.Name) { return $"{ClassName} must NOT declare {propertyName} property, it should inherit from the {BaseName} class."; }

            // Assert BankAccount methods are NOT redefined in CheckingAccount
            methodName = "Deposit";
            MethodInfo deposit = SafeReflection.GetMethod(classType, methodName);
            if (BaseName != deposit.DeclaringType.Name) { return $"{ClassName} must NOT declare {methodName} method, it should inherit from the {BaseName} class."; }

            return "";
        }
    }
}
