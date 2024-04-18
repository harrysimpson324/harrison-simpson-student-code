using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Exercise.Tests.ReflectionTestHelper;

namespace Exercise.Tests
{
    [TestClass]
    public class Step2_IAccountableTests
    {
        private const string NamespaceName = "Exercise";
        private const string BankAccountClassName = "BankAccount";
        private const string CheckingAccountClassName = "CheckingAccount";
        private const string SavingsAccountClassName = "SavingsAccount";
        private const string AccountableInterfaceName = "IAccountable";

        private static Type bankAccountClassType;
        private static Type checkingAccountClassType;
        private static Type savingsAccountClassType;
        private static Type accountableInterfaceType;

        [TestInitialize]
        public void Intialize()
        {
            bankAccountClassType = SafeReflection.GetType(BankAccountClassName, NamespaceName);
            checkingAccountClassType = SafeReflection.GetType(CheckingAccountClassName, NamespaceName);
            savingsAccountClassType = SafeReflection.GetType(SavingsAccountClassName, NamespaceName);
            accountableInterfaceType = SafeReflection.GetType(AccountableInterfaceName, NamespaceName);
        }

        [TestMethod]
        public void Test01_InterfaceWellFormed()
        {
            string wellFormedCheck = InterfaceWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail(wellFormedCheck);
            }
        }

        [TestMethod]
        public void Test02_ClassesImplementIAccountable()
        {
            string wellFormedCheck = InterfaceWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail($"{AccountableInterfaceName} is not well formed. The Test01_InterfaceWellFormed tests must pass first.\r\n\t{wellFormedCheck}");
            }

            // Assert the classes implement IAccountable interface
            Assert.IsTrue(bankAccountClassType.GetTypeInfo().ImplementedInterfaces.Any(t => t.Name == AccountableInterfaceName), $"{BankAccountClassName} must implement {AccountableInterfaceName} interface.");
            Assert.IsTrue(checkingAccountClassType.GetTypeInfo().ImplementedInterfaces.Any(t => t.Name == AccountableInterfaceName), $"{CheckingAccountClassName} must implement {AccountableInterfaceName} interface.");
            Assert.IsTrue(savingsAccountClassType.GetTypeInfo().ImplementedInterfaces.Any(t => t.Name == AccountableInterfaceName), $"{SavingsAccountClassName} must implement {AccountableInterfaceName} interface.");
        }

        private string InterfaceWellFormedCheck()
        {
            // Assert class exists
            if (accountableInterfaceType == null) { return $"{AccountableInterfaceName} interface not found. Have you declared it yet? Make sure the name is '{AccountableInterfaceName}' and the namespace is '{NamespaceName}'."; }

            // Assert is an interface
            if (!accountableInterfaceType.IsInterface) { return $"{AccountableInterfaceName} must be an interface. Make sure you declared it as an 'interface' and not a 'class'."; }

            // Assert properties exist, are of correct type and access
            string propertyCheck = CheckProperty(accountableInterfaceType, "Balance", typeof(decimal), AccessModifier.Public, AccessModifier.None);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            return "";
        }

    }
}
