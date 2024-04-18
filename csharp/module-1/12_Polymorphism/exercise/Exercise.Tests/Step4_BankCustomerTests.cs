using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Exercise.Tests.ReflectionTestHelper;

namespace Exercise.Tests
{
    [TestClass]
    public class Step4_BankCustomerTests
    {
        private const string NamespaceName = "Exercise";
        private const string BankCustomerClassName = "BankCustomer";
        private const string BankAccountClassName = "BankAccount";
        private const string CheckingAccountClassName = "CheckingAccount";
        private const string SavingsAccountClassName = "SavingsAccount";
        private const string CreditCardAccountClassName = "CreditCardAccount";
        private const string AccountableInterfaceName = "IAccountable";

        private static Type bankCustomerClassType;
        private static Type accountableInterfaceType;
        private static Type creditCardAccountClassType;

        [TestInitialize]
        public void Intialize()
        {
            bankCustomerClassType = SafeReflection.GetType(BankCustomerClassName, NamespaceName);
            accountableInterfaceType = SafeReflection.GetType(AccountableInterfaceName, NamespaceName);
            creditCardAccountClassType = SafeReflection.GetType(CreditCardAccountClassName, NamespaceName);
        }

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
                Assert.Fail($"{BankCustomerClassName} is not well formed. The Test01_ClassWellFormed tests must pass first.\r\n\t{wellFormedCheck}");
            }

            // Assert getters and setters work correctly
            string testName = "Tester Testerson";
            string testAddress = "123 Main Street";
            string testPhoneNumber = "555-555-1234";

            object instance = SafeReflection.CreateInstance(bankCustomerClassType, Array.Empty<object>());

            SafeReflection.SetPropertyValue(instance, "Name", testName);
            object instanceName = SafeReflection.GetPropertyValue(instance, "Name");
            Assert.AreEqual(testName, instanceName, $"{BankCustomerClassName} does not correctly set the property Name.");

            SafeReflection.SetPropertyValue(instance, "Address", testAddress);
            object instanceAddress = SafeReflection.GetPropertyValue(instance, "Address");
            Assert.AreEqual(testAddress, instanceAddress, $"{BankCustomerClassName} does not correctly set the property Address.");

            SafeReflection.SetPropertyValue(instance, "PhoneNumber", testPhoneNumber);
            object instancePhoneNumber = SafeReflection.GetPropertyValue(instance, "PhoneNumber");
            Assert.AreEqual(testPhoneNumber, instancePhoneNumber, $"{BankCustomerClassName} does not correctly set the property PhoneNumber.");


            // populate the `accounts` field with a list of accounts to test with
            object listOfAccountables = CreateListOfAccountables(false);
            SafeReflection.SetFieldValue(instance, "accounts", listOfAccountables);

            // Assert GetAccounts() retrieves accounts
            string methodName = "GetAccounts";
            MethodInfo getAccounts = SafeReflection.GetMethod(bankCustomerClassType, methodName);
            object getAccountsReturnValue = getAccounts.Invoke(instance, Array.Empty<object>());
            // compare to another call of CreateListOfAccountables() so it's not the same reference
            Assert.IsTrue(AreListsEqual(CreateListOfAccountables(false), getAccountsReturnValue), $"{BankCustomerClassName} GetAccounts method fails to return the expected list.");

            // Assert AddAccount() adds an account
            methodName = "AddAccount";
            MethodInfo addAccount = SafeReflection.GetMethod(bankCustomerClassType, methodName);
            addAccount.Invoke(instance, new object[] { AdditionalAccountForTest() });
            // compare to another call of CreateListOfAccountables() so it's not the same reference
            object accountsFieldValue = SafeReflection.GetFieldValue(instance, "accounts");
            Assert.IsTrue(AreListsEqual(CreateListOfAccountables(true), accountsFieldValue), $"{BankCustomerClassName} AddAccount method fails to add the expected account to the list.");
        }

        private string ClassWellFormedCheck()
        {
            // Assert class exists
            if (bankCustomerClassType == null) { return $"{BankCustomerClassName} class not found. Have you declared it yet? Make sure the class name is '{BankCustomerClassName}' and the namespace is '{NamespaceName}'."; }

            if (bankCustomerClassType.IsAbstract) { return $"{BankCustomerClassName} class must not be abstract. Remove the 'abstract' modifier on {BankCustomerClassName}."; }
            if (bankCustomerClassType.GetTypeInfo().ImplementedInterfaces.Count() != 0) { return $"{BankCustomerClassName} must not implement any interfaces."; }

            // Assert properties exist, are of correct type and access
            string propertyCheck = CheckProperty(bankCustomerClassType, "Name", typeof(string), AccessModifier.Public, AccessModifier.Public);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            propertyCheck = CheckProperty(bankCustomerClassType, "Address", typeof(string), AccessModifier.Public, AccessModifier.Public);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            propertyCheck = CheckProperty(bankCustomerClassType, "PhoneNumber", typeof(string), AccessModifier.Public, AccessModifier.Public);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            string fieldCheck = CheckField(bankCustomerClassType, "accounts", CreateTypeIListOfAccountables(), AccessModifier.Private);
            if (!string.IsNullOrEmpty(fieldCheck)) { return fieldCheck; }

            // Assert methods are present -- whether they work is confirmed in other test methods
            string methodCheck = CheckMethod(bankCustomerClassType, "GetAccounts", Array.CreateInstance(accountableInterfaceType, 0).GetType(), true, false, Array.Empty<Type>());
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }

            methodCheck = CheckMethod(bankCustomerClassType, "AddAccount", typeof(void), true, false, new Type[] { accountableInterfaceType });
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }

            return "";
        }

        /// <summary>
        /// Create a List<IAccountable> with reflection because IAccountable type might not exist, and populate it with sample data to be used for tests.
        /// </summary>
        /// <param name="additionalAccountForAddTest">Adds an additional BankAccount to be used with AddAccount() tests.</param>
        /// <returns>A `List<IAccountable>` populated with various IAccountable types.</returns>
        private static object CreateListOfAccountables(bool additionalAccountForAddTest)
        {
            // test data
            List<object> bankAccounts = new List<object>
            {
                // should be safe to assume BankAccount, CheckingAccount, and SavingsAccount exist and can instantiate directly
                new BankAccount("ABC", "BNK:3713", 100M),
                new CheckingAccount("DEF", "CHK:5912", 200M),
                new SavingsAccount("GHI", "SAV:9922", 300M)
            };

            // if credit card type exists and implements IAccountable, add one of those too
            if (creditCardAccountClassType != null &&
                creditCardAccountClassType.GetTypeInfo().ImplementedInterfaces.Any(t => t.Name == AccountableInterfaceName))
            {
                object creditCardAccount = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "JKL", "1245-5232-1231-2141" });
                SafeReflection.SetPropertyValue(creditCardAccount, "Debt", 400M);
                bankAccounts.Add(creditCardAccount);
            }

            if (additionalAccountForAddTest)
            {
                bankAccounts.Add(AdditionalAccountForTest());
            }

            Type typeListOfAccountables = CreateTypeListOfAccountables();
            object listOfAccountables = SafeReflection.CreateInstance(typeListOfAccountables, Array.Empty<object>());
            MethodInfo listAdd = SafeReflection.GetMethod(typeListOfAccountables, "Add");
            foreach (object b in bankAccounts)
            {
                listAdd.Invoke(listOfAccountables, new object[] { b });
            }
            
            return listOfAccountables;
        }

        /// <summary>
        /// Generate a type to represent List<IAccountable> with reflection because IAccountable may not exist.
        /// </summary>
        /// <returns>A type that represents `List<IAccountable>`.</returns>
        private static Type CreateTypeListOfAccountables()
        {
            Type genericClass = typeof(List<>);
            Type constructedClass = genericClass.MakeGenericType(accountableInterfaceType);
            return constructedClass;
        }

        /// <summary>
        /// Generate a type to represent IList<IAccountable> with reflection because IAccountable may not exist.
        /// </summary>
        /// <returns>A type that represents `IList<IAccountable>`.</returns>
        private static Type CreateTypeIListOfAccountables()
        {
            Type genericClass = typeof(IList<>);
            Type constructedClass = genericClass.MakeGenericType(accountableInterfaceType);
            return constructedClass;
        }

        private static BankAccount AdditionalAccountForTest()
        {
            return new BankAccount("MNO", "BNK:2440", 500M);
        }

        private static bool AreListsEqual(object expected, object actual)
        {
            IList expectedList = (IList)expected;
            IList actualList = (IList)actual;

            if (expectedList.Count != actualList.Count) return false;

            // assume order is the same
            for (int i = 0; i < expectedList.Count; i++)
            {
                // if we're not comparing the same type, then they don't match
                if (expectedList[i].GetType().Name != actualList[i].GetType().Name) return false;

                switch (expectedList[i].GetType().Name)
                {
                    case BankAccountClassName:
                    case CheckingAccountClassName:
                    case SavingsAccountClassName:
                        // can cast down to base BankAccount
                        if (!DoBankAccountsMatch((BankAccount)expectedList[i], (BankAccount)actualList[i]))
                        {
                            return false;
                        }
                        break;
                    case CreditCardAccountClassName:
                        if (!DoCreditCardAccountsMatch(expectedList[i], actualList[i]))
                        {
                            return false;
                        }
                        break;
                    default:
                        return false;
                }
            }

            return true;
        }

        private static bool DoBankAccountsMatch(BankAccount expected, BankAccount actual)
        {
            return expected.AccountHolderName == actual.AccountHolderName
                && expected.AccountNumber == actual.AccountNumber
                && expected.Balance == actual.Balance;
        }

        private static bool DoCreditCardAccountsMatch(object expected, object actual)
        {
            object expectedAccountHolderName = SafeReflection.GetPropertyValue(expected, "AccountHolderName");
            object expectedCardNumber = SafeReflection.GetPropertyValue(expected, "CardNumber");
            object expectedDebt = SafeReflection.GetPropertyValue(expected, "Debt");

            object actualAccountHolderName = SafeReflection.GetPropertyValue(actual, "AccountHolderName");
            object actualCardNumber = SafeReflection.GetPropertyValue(actual, "CardNumber");
            object actualDebt = SafeReflection.GetPropertyValue(actual, "Debt");

            return expectedAccountHolderName.ToString() == actualAccountHolderName.ToString()
                && expectedCardNumber.ToString() == actualCardNumber.ToString()
                && (decimal)expectedDebt == (decimal)actualDebt;
        }
    }
}
