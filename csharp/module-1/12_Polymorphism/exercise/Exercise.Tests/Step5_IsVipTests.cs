using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Exercise.Tests.ReflectionTestHelper;

namespace Exercise.Tests
{
    [TestClass]
    public class Step5_IsVipTests
    {
        private const string NamespaceName = "Exercise";
        private const string BankCustomerClassName = "BankCustomer";
        private const string CreditCardAccountClassName = "CreditCardAccount";
        private const string AccountableInterfaceName = "IAccountable";
        private const string MethodName = "IsVip";

        private static Type bankCustomerClassType;
        private static Type creditCardAccountClassType;
        private static Type accountableInterfaceType;

        private const decimal VipAmount = 25000;

        [TestInitialize]
        public void Intialize()
        {
            bankCustomerClassType = SafeReflection.GetType(BankCustomerClassName, NamespaceName);
            creditCardAccountClassType = SafeReflection.GetType(CreditCardAccountClassName, NamespaceName);
            accountableInterfaceType = SafeReflection.GetType(AccountableInterfaceName, NamespaceName);
        }

        [TestMethod]
        public void Test01_MethodWellFormed()
        {
            string wellFormedCheck = MethodWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail(wellFormedCheck);
            }            
        }

        [TestMethod]
        public void Test02_HappyPathTests()
        {
            string wellFormedCheck = MethodWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail($"{MethodName} is not well formed. The Test01_MethodWellFormed tests must pass first.\r\n\t{wellFormedCheck}");
            }

            object bankCustomerInstance = SafeReflection.CreateInstance(bankCustomerClassType, Array.Empty<object>());
            MethodInfo isVip = SafeReflection.GetMethod(bankCustomerClassType, MethodName);

            // one bank account, less than VIP amount
            BankAccount bankAccount = new BankAccount("", "", Math.Round(VipAmount / 2));

            object listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            object isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsFalse((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return false for one account with total balance under VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}");

            // one bank account, greater than VIP amount
            bankAccount = new BankAccount("", "", VipAmount * 2);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsTrue((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return true for one account with total balance over VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}");

            // two bank accounts, less than VIP amount
            bankAccount = new BankAccount("", "", Math.Round(VipAmount / 3));
            CheckingAccount checkingAccount = new CheckingAccount("", "", Math.Round(VipAmount / 3));

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, checkingAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsFalse((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return false for two accounts with total balance under VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CheckingAccount balance: {checkingAccount.Balance}, Total: {bankAccount.Balance + checkingAccount.Balance}");

            // two bank accounts, greater than VIP amount
            bankAccount = new BankAccount("", "", Math.Round(VipAmount / 1.5M));
            checkingAccount = new CheckingAccount("", "", Math.Round(VipAmount / 1.5M));

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, checkingAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsTrue((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return true for two accounts with total balance over VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CheckingAccount balance: {checkingAccount.Balance}, Total: {bankAccount.Balance + checkingAccount.Balance}");

            // three bank accounts, less than VIP amount
            bankAccount = new BankAccount("", "", Math.Round(VipAmount / 4));
            checkingAccount = new CheckingAccount("", "", Math.Round(VipAmount / 4));
            SavingsAccount savingsAccount = new SavingsAccount("", "", Math.Round(VipAmount / 4));

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, checkingAccount, savingsAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsFalse((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return false for three accounts with total balance under VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CheckingAccount balance: {checkingAccount.Balance}, SavingsAccount balance: {savingsAccount.Balance}, Total: {bankAccount.Balance + checkingAccount.Balance + savingsAccount.Balance}");

            // three bank accounts, greater than VIP amount
            bankAccount = new BankAccount("", "", Math.Round(VipAmount / 2));
            checkingAccount = new CheckingAccount("", "", Math.Round(VipAmount / 2));
            savingsAccount = new SavingsAccount("", "", Math.Round(VipAmount / 2));

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, checkingAccount, savingsAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsTrue((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return true for three accounts with total balance over VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CheckingAccount balance: {checkingAccount.Balance}, SavingsAccount balance: {savingsAccount.Balance}, Total: {bankAccount.Balance + checkingAccount.Balance + savingsAccount.Balance}");


            // ensure credit card class exists before continuing
            if (creditCardAccountClassType == null)
            {
                Assert.Fail($"{CreditCardAccountClassName} must exist to continue IsVip tests.");
            } 
            if (!creditCardAccountClassType.GetTypeInfo().ImplementedInterfaces.Any(t => t.Name == AccountableInterfaceName))
            {
                Assert.Fail($"{CreditCardAccountClassName} must implement IAccountable to continue IsVip tests.");
            }

            // one credit card, no debt, less than VIP amount
            object creditCardAccount = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });
            SafeReflection.SetPropertyValue(creditCardAccount, "Debt", 0M);

            listOfAccountables = CreateListOfAccountables(new List<object> { creditCardAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsFalse((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return false for one credit card account with total balance under VIP amount of {VipAmount}. " +
                $"CreditCardAccount balance: 0");


            // two accounts (one credit card), less than VIP amount
            bankAccount = new BankAccount("", "", VipAmount + 500);
            creditCardAccount = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });
            SafeReflection.SetPropertyValue(creditCardAccount, "Debt", 1000M);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, creditCardAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsFalse((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return false for one bank account and one credit card account with total balance under VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CreditCardAccount balance: -1000, Total: {bankAccount.Balance - 1000}");

            // two accounts (one credit card), greater than VIP amount
            bankAccount = new BankAccount("", "", VipAmount + 500);
            creditCardAccount = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });
            SafeReflection.SetPropertyValue(creditCardAccount, "Debt", 100M);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, creditCardAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsTrue((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return true for one bank account and one credit card account with total balance over VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CreditCardAccount balance: -100, Total: {bankAccount.Balance - 100}");


            // three accounts (one credit card), less than VIP amount
            bankAccount = new BankAccount("", "", VipAmount + 1000);
            checkingAccount = new CheckingAccount("", "", Math.Round(VipAmount / 1.5M));
            creditCardAccount = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });
            SafeReflection.SetPropertyValue(creditCardAccount, "Debt", VipAmount);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, checkingAccount, creditCardAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsFalse((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return false for two bank accounts and one credit card account with total balance under VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CheckingAccount balance: {checkingAccount.Balance}, CreditCardAccount balance: {-VipAmount}, Total: {bankAccount.Balance + checkingAccount.Balance - VipAmount}");

            // three accounts (one credit card), greater than VIP amount
            bankAccount = new BankAccount("", "", VipAmount + 1000);
            checkingAccount = new CheckingAccount("", "", Math.Round(VipAmount / 1.5M));
            creditCardAccount = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });
            SafeReflection.SetPropertyValue(creditCardAccount, "Debt", 1500M);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, checkingAccount, creditCardAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsTrue((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return true for two bank accounts and one credit card account with total balance over VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CheckingAccount balance: {checkingAccount.Balance}, CreditCardAccount balance: -1500, Total: {bankAccount.Balance + checkingAccount.Balance - 1500}");


            // three accounts (two credit cards), less than VIP amount
            bankAccount = new BankAccount("", "", VipAmount + 1000);
            creditCardAccount = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });
            object creditCardAccount2 = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });
            SafeReflection.SetPropertyValue(creditCardAccount, "Debt", 500M);
            SafeReflection.SetPropertyValue(creditCardAccount2, "Debt", 600M);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, creditCardAccount, creditCardAccount2 });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsFalse((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return false for one bank accounts and two credit card accounts with total balance under VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CreditCardAccount 1 balance: -500, CreditCardAccount 2 balance: -600, Total: {bankAccount.Balance - 500 - 600}");

            // three accounts (two credit cards), greater than VIP amount
            bankAccount = new BankAccount("", "", VipAmount + 1000);
            creditCardAccount = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });
            creditCardAccount2 = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });
            SafeReflection.SetPropertyValue(creditCardAccount, "Debt", 100M);
            SafeReflection.SetPropertyValue(creditCardAccount2, "Debt", 200M);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, creditCardAccount, creditCardAccount2 });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsTrue((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return true for one bank accounts and two credit card accounts with total balance over VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CreditCardAccount 1 balance: -100, CreditCardAccount 2 balance: -200, Total: {bankAccount.Balance - 100 - 200}");
        }

        [TestMethod]
        public void Test03_EdgeCaseTests()
        {
            string wellFormedCheck = MethodWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail($"{MethodName} is not well formed. The Test01_MethodWellFormed tests must pass first.\r\n\t{wellFormedCheck}");
            }

            object bankCustomerInstance = SafeReflection.CreateInstance(bankCustomerClassType, Array.Empty<object>());
            MethodInfo isVip = SafeReflection.GetMethod(bankCustomerClassType, MethodName);

            // one account with balance one cent under VIP amount
            BankAccount bankAccount = new BankAccount("", "", VipAmount - 0.01M);

            object listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            object isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsFalse((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return false for one account with total balance one cent under VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}");

            // one account with balance exactly VIP amount
            bankAccount = new BankAccount("", "", VipAmount);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsTrue((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return true for one account with total balance exactly the VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}");


            // two accounts with balance one cent under VIP amount
            bankAccount = new BankAccount("", "", VipAmount - 2M);
            CheckingAccount checkingAccount = new CheckingAccount("", "", 1.99M);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, checkingAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsFalse((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return false for two accounts with total balance one cent under the VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CheckingAccount balance: {checkingAccount.Balance}, Total: {bankAccount.Balance + checkingAccount.Balance}");

            // two accounts with balance exactly VIP amount
            bankAccount = new BankAccount("", "", VipAmount - 1M);
            checkingAccount = new CheckingAccount("", "", 1M);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, checkingAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsTrue((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return true for two accounts with total balance exactly the VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CheckingAccount balance: {checkingAccount.Balance}, Total: {bankAccount.Balance + checkingAccount.Balance}");


            // ensure credit card class exists before continuing
            if (creditCardAccountClassType == null)
            {
                Assert.Fail($"{CreditCardAccountClassName} must exist to continue IsVip tests.");
            }
            if (!creditCardAccountClassType.GetTypeInfo().ImplementedInterfaces.Any(t => t.Name == AccountableInterfaceName))
            {
                Assert.Fail($"{CreditCardAccountClassName} must implement IAccountable to continue IsVip tests.");
            }

            // three accounts (one credit card) with balance one cent under VIP amount
            bankAccount = new BankAccount("", "", VipAmount - 1M);
            checkingAccount = new CheckingAccount("", "", 1M);
            object creditCardAccount = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });
            SafeReflection.SetPropertyValue(creditCardAccount, "Debt", 0.01M);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, checkingAccount, creditCardAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsFalse((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return false for two bank accounts and one credit card account with total balance one cent under the VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CheckingAccount balance: {checkingAccount.Balance}, CreditCardAccount balance: -0.01, Total: {bankAccount.Balance + checkingAccount.Balance - 0.01M}");

            // three accounts (one credit card) with balance exactly VIP amount
            bankAccount = new BankAccount("", "", VipAmount - 1M);
            checkingAccount = new CheckingAccount("", "", 1.01M);
            creditCardAccount = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });
            SafeReflection.SetPropertyValue(creditCardAccount, "Debt", 0.01M);

            listOfAccountables = CreateListOfAccountables(new List<object> { bankAccount, checkingAccount, creditCardAccount });
            SafeReflection.SetFieldValue(bankCustomerInstance, "accounts", listOfAccountables);
            isVipReturnValue = isVip.Invoke(bankCustomerInstance, Array.Empty<object>());
            Assert.IsTrue((bool)isVipReturnValue, $"{BankCustomerClassName} method {MethodName} should return true for two bank accounts and one credit card account with total balance exactly the VIP amount of {VipAmount}. " +
                $"BankAccount balance: {bankAccount.Balance}, CheckingAccount balance: {checkingAccount.Balance}, CreditCardAccount balance: -0.01, Total: {bankAccount.Balance + checkingAccount.Balance - 0.01M}");
        }

        private string MethodWellFormedCheck()
        {
            // Assert class exists
            if (bankCustomerClassType == null) { return $"{BankCustomerClassName} class not found. Have you declared it yet? Make sure the class name is '{BankCustomerClassName}' and the namespace is '{NamespaceName}'."; }

            MethodInfo isVip = SafeReflection.GetMethod(bankCustomerClassType, MethodName);

            // Assert method exists
            if (isVip == null) { return $"{MethodName} not found in {BankCustomerClassName}. Have you declared it yet? Make sure the method name is '{MethodName}'."; }

            // Assert parameters and return type
            string methodCheck = CheckMethod(bankCustomerClassType, MethodName, typeof(bool), true, false, new Type[] { });
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }

            return "";
        }

        /// <summary>
        /// Create a List<IAccountable> with reflection because IAccountable type might not exist, and populate it with the data passed to method.
        /// </summary>
        /// <param name="accounts">List of objects to add to list.</param>
        /// <returns>An object that is `List<IAccountable>`.</returns>
        private static object CreateListOfAccountables(List<object> accounts)
        {
            Type genericClass = typeof(List<>);
            Type constructedClass = genericClass.MakeGenericType(accountableInterfaceType);
            object listOfAccountables = SafeReflection.CreateInstance(constructedClass, Array.Empty<object>());
            MethodInfo listAdd = SafeReflection.GetMethod(constructedClass, "Add");
            foreach (object b in accounts)
            {
                listAdd.Invoke(listOfAccountables, new object[] { b });
            }

            return listOfAccountables;
        }
    }
}
