using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Exercise.Tests.ReflectionTestHelper;

namespace Exercise.Tests
{
    [TestClass]
    public class Step3_CreditCardTests
    {
        private const string NamespaceName = "Exercise";
        private const string CreditCardAccountClassName = "CreditCardAccount";
        private const string AccountableInterfaceName = "IAccountable";

        private static Type creditCardAccountClassType;

        [TestInitialize]
        public void Intialize()
        {
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
                Assert.Fail($"{CreditCardAccountClassName} is not well formed. The Test01_ClassWellFormed tests must pass first.\r\n\t{wellFormedCheck}");
            }

            // Assert constructors set properties
            string testAccountHolderName = "Tester Testerson";
            string testCardNumber = "1234-5678-9012-3456";

            // Two arg constructor
            object instance = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { testAccountHolderName, testCardNumber });
            object instanceAccountHolderName = SafeReflection.GetPropertyValue(instance, "AccountHolderName");
            object instanceCardNumber = SafeReflection.GetPropertyValue(instance, "CardNumber");
            object instanceDebt = SafeReflection.GetPropertyValue(instance, "Debt");
            Assert.AreEqual(testAccountHolderName, instanceAccountHolderName, $"{CreditCardAccountClassName} constructor {CreditCardAccountClassName}(string, string) does not correctly set the property AccountHolderName.");
            Assert.AreEqual(testCardNumber, instanceCardNumber, $"{CreditCardAccountClassName} constructor {CreditCardAccountClassName}(string, string) does not correctly set the property CardNumber.");
            Assert.AreEqual(0M, instanceDebt, $"{CreditCardAccountClassName} constructor {CreditCardAccountClassName}(string, string) does not correctly default Debt to 0.");

            // Assert debt is balance as negative number
            decimal testDebt = 100M;
            SafeReflection.SetPropertyValue(instance, "Debt", testDebt);
            object instanceBalance = SafeReflection.GetPropertyValue(instance, "Balance");
            Assert.AreEqual(testDebt * -1, instanceBalance, $"{CreditCardAccountClassName} property Balance must equal the Debt value as a negative number.");

            // Assert pay decreases debt
            MethodInfo pay = SafeReflection.GetMethod(creditCardAccountClassType, "Pay");
            decimal payParamValue = 23;
            decimal payExpectedReturnValue = testDebt - payParamValue;
            object payActualReturnValue = pay.Invoke(instance, new object[] { payParamValue });
            Assert.AreEqual(payExpectedReturnValue, payActualReturnValue, $"{CreditCardAccountClassName} Pay method fails to decrease debt by correct amount. Starting debt: {testDebt}, pay: {payParamValue}, new debt should be {payExpectedReturnValue}.");

            // Assert charge increases debt
            MethodInfo charge = SafeReflection.GetMethod(creditCardAccountClassType, "Charge");
            decimal chargeParamValue = 22;
            decimal chargeExpectedReturnValue = payExpectedReturnValue + chargeParamValue;
            object chargeActualReturnValue = charge.Invoke(instance, new object[] { chargeParamValue });
            Assert.AreEqual(chargeExpectedReturnValue, chargeActualReturnValue, $"{CreditCardAccountClassName} Charge method fails to increase debt by correct amount. Starting debt: {payExpectedReturnValue}, charge: {chargeParamValue}, new debt should be {chargeExpectedReturnValue}.");

        }

        [TestMethod]
        public void Test03_EdgeCaseTests()
        {
            string wellFormedCheck = ClassWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail($"{CreditCardAccountClassName} is not well formed. The Test01_ClassWellFormed tests must pass first.\r\n\t{wellFormedCheck}");
            }

            MethodInfo pay = SafeReflection.GetMethod(creditCardAccountClassType, "Pay");
            MethodInfo charge = SafeReflection.GetMethod(creditCardAccountClassType, "Charge");
            object account = SafeReflection.CreateInstance(creditCardAccountClassType, new object[] { "", "" });

            // Assert pay method can handle 0 debt
            SafeReflection.SetPropertyValue(account, "Debt", 1M); // reset Debt
            pay.Invoke(account, new object[] { 1M });
            object debt = SafeReflection.GetPropertyValue(account, "Debt");
            Assert.AreEqual(0M, debt, $"{CreditCardAccountClassName} Pay method fails to decrease debt by correct amount. Starting debt: 1, pay: 1, new debt should be 0.");

            // Assert charge method can handle 0 debt
            SafeReflection.SetPropertyValue(account, "Debt", 0M); // reset Debt
            charge.Invoke(account, new object[] { 1M });
            debt = SafeReflection.GetPropertyValue(account, "Debt");
            Assert.AreEqual(1M, debt, $"{CreditCardAccountClassName} Charge method fails to increase debt by correct amount. Starting debt: 0, charge: 1, new debt should be 1.");

            // Assert can't pay a negative amount
            SafeReflection.SetPropertyValue(account, "Debt", 0M); // reset Debt
            pay.Invoke(account, new object[] { -10M });
            debt = SafeReflection.GetPropertyValue(account, "Debt");
            Assert.AreEqual(0M, debt, $"{CreditCardAccountClassName} Pay method fails to prevent negative pay amount. Starting debt: 0, pay: -10, debt should remain at 0.");

            // Assert can't charge a negative amount
            SafeReflection.SetPropertyValue(account, "Debt", 10M); // reset Debt
            charge.Invoke(account, new object[] { -10M });
            debt = SafeReflection.GetPropertyValue(account, "Debt");
            Assert.AreEqual(10M, debt, $"{CreditCardAccountClassName} Charge method fails to prevent negative charge amount. Starting debt: 10, charge: -10, debt should remain at 10.");
        }

        private string ClassWellFormedCheck()
        {
            // Assert class exists
            if (creditCardAccountClassType == null) { return $"{CreditCardAccountClassName} class not found. Have you declared it yet? Make sure the class name is '{CreditCardAccountClassName}' and the namespace is '{NamespaceName}'."; }

            if (creditCardAccountClassType.IsAbstract) { return $"{CreditCardAccountClassName} class must not be abstract. Remove the 'abstract' modifier on {CreditCardAccountClassName}."; }

            if (!creditCardAccountClassType.GetTypeInfo().ImplementedInterfaces.Any(t => t.Name == AccountableInterfaceName)) { return $"{CreditCardAccountClassName} must implement {AccountableInterfaceName} interface."; }

            // Assert constructors exist
            ConstructorInfo twoArgConstructor = SafeReflection.GetConstructor(creditCardAccountClassType, new Type[] { typeof(string), typeof(string) });
            if (twoArgConstructor == null) { return $"{CreditCardAccountClassName} does not have the required two argument constructor {CreditCardAccountClassName}(string, string). Make sure access for the constructor is public."; }

            // Assert properties exist, are of correct type and access
            string propertyCheck = CheckProperty(creditCardAccountClassType, "AccountHolderName", typeof(string), AccessModifier.Public, AccessModifier.Private);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            propertyCheck = CheckProperty(creditCardAccountClassType, "CardNumber", typeof(string), AccessModifier.Public, AccessModifier.None);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            propertyCheck = CheckProperty(creditCardAccountClassType, "Balance", typeof(decimal), AccessModifier.Public, AccessModifier.None);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            propertyCheck = CheckProperty(creditCardAccountClassType, "Debt", typeof(decimal), AccessModifier.Public, AccessModifier.Private);
            if (!string.IsNullOrEmpty(propertyCheck)) { return propertyCheck; }

            // Assert methods are present -- whether they work is confirmed in other test methods
            string methodCheck = CheckMethod(creditCardAccountClassType, "Pay", typeof(decimal), true, false, new Type[] { typeof(decimal) });
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }

            methodCheck = CheckMethod(creditCardAccountClassType, "Charge", typeof(decimal), true, false, new Type[] { typeof(decimal) });
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }

            return "";
        }
    }
}
