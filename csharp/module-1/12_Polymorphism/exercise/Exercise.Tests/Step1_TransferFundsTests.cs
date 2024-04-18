using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Exercise.Tests.ReflectionTestHelper;

namespace Exercise.Tests
{
    [TestClass]
    public class Step1_TransferFundsTests
    {
        private const string NamespaceName = "Exercise";
        private const string BankAccountClassName = "BankAccount";
        private const string CheckingAccountClassName = "CheckingAccount";
        private const string SavingsAccountClassName = "SavingsAccount";
        private const string MethodName = "TransferFunds";

        private static Type bankAccountClassType;
        private static Type checkingAccountClassType;
        private static Type savingsAccountClassType;

        [TestInitialize]
        public void Intialize()
        {
            bankAccountClassType = SafeReflection.GetType(BankAccountClassName, NamespaceName);
            checkingAccountClassType = SafeReflection.GetType(CheckingAccountClassName, NamespaceName);
            savingsAccountClassType = SafeReflection.GetType(SavingsAccountClassName, NamespaceName);
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

            BankAccount account1, account2;
            decimal balanceAccount1, balanceAccount2, balanceExpected1, balanceExpected2, transferAmount;
            object returnValue;


            /// FROM BANK
            // bank to bank
            balanceAccount1 = 100;
            balanceAccount2 = 20;
            transferAmount = 30;
            balanceExpected1 = balanceAccount1 - transferAmount;
            balanceExpected2 = balanceAccount2 + transferAmount;
            account1 = new BankAccount(string.Empty, "BNK:1234", balanceAccount1);
            account2 = new BankAccount(string.Empty, "BNK:5678", balanceAccount2);
            
            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"Bank to bank {MethodName} did not return the correct value. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"Bank to bank {MethodName} did not correctly set balance for the 'from' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected2, account2.Balance, $"Bank to bank {MethodName} did not correctly set balance for the 'to' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 2 balance expected: {balanceExpected2}.");

            // bank to checking
            balanceAccount1 = 100;
            balanceAccount2 = 20;
            transferAmount = 35;
            balanceExpected1 = balanceAccount1 - transferAmount;
            balanceExpected2 = balanceAccount2 + transferAmount;
            account1 = new BankAccount(string.Empty, "BNK:1234", balanceAccount1);
            account2 = new CheckingAccount(string.Empty, "CHK:1234", balanceAccount2);

            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"Bank to checking {MethodName} did not return the correct value. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"Bank to checking {MethodName} did not correctly set balance for the 'from' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected2, account2.Balance, $"Bank to checking {MethodName} did not correctly set balance for the 'to' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 2 balance expected: {balanceExpected2}.");

            // bank to savings
            balanceAccount1 = 100;
            balanceAccount2 = 25;
            transferAmount = 40;
            balanceExpected1 = balanceAccount1 - transferAmount;
            balanceExpected2 = balanceAccount2 + transferAmount;
            account1 = new BankAccount(string.Empty, "BNK:1234", balanceAccount1);
            account2 = new SavingsAccount(string.Empty, "SAV:1234", balanceAccount2);

            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"Bank to savings {MethodName} did not return the correct value. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"Bank to savings {MethodName} did not correctly set balance for the 'from' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected2, account2.Balance, $"Bank to savings {MethodName} did not correctly set balance for the 'to' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 2 balance expected: {balanceExpected2}.");


            /// FROM CHECKING
            // checking to bank
            balanceAccount1 = 100;
            balanceAccount2 = 20;
            transferAmount = 30;
            balanceExpected1 = balanceAccount1 - transferAmount;
            balanceExpected2 = balanceAccount2 + transferAmount;
            account1 = new CheckingAccount(string.Empty, "CHK:1234", balanceAccount1);
            account2 = new BankAccount(string.Empty, "BNK:1234", balanceAccount2);

            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"Checking to bank {MethodName} did not return the correct value. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"Checking to bank {MethodName} did not correctly set balance for the 'from' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected2, account2.Balance, $"Checking to bank {MethodName} did not correctly set balance for the 'to' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 2 balance expected: {balanceExpected2}.");

            // checking to checking
            balanceAccount1 = 80;
            balanceAccount2 = 30;
            transferAmount = 40;
            balanceExpected1 = balanceAccount1 - transferAmount;
            balanceExpected2 = balanceAccount2 + transferAmount;
            account1 = new CheckingAccount(string.Empty, "CHK:1234", balanceAccount1);
            account2 = new CheckingAccount(string.Empty, "CHK:5678", balanceAccount2);

            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"Checking to checking {MethodName} did not return the correct value. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"Checking to checking {MethodName} did not correctly set balance for the 'from' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected2, account2.Balance, $"Checking to checking {MethodName} did not correctly set balance for the 'to' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 2 balance expected: {balanceExpected2}.");

            // checking to savings
            balanceAccount1 = 80;
            balanceAccount2 = 60;
            transferAmount = 40;
            balanceExpected1 = balanceAccount1 - transferAmount;
            balanceExpected2 = balanceAccount2 + transferAmount;
            account1 = new CheckingAccount(string.Empty, "CHK:1234", balanceAccount1);
            account2 = new SavingsAccount(string.Empty, "SAV:1234", balanceAccount2);

            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"Checking to savings {MethodName} did not return the correct value. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"Checking to savings {MethodName} did not correctly set balance for the 'from' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected2, account2.Balance, $"Checking to savings {MethodName} did not correctly set balance for the 'to' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 2 balance expected: {balanceExpected2}.");


            /// FROM SAVINGS
            // savings to bank
            balanceAccount1 = 465;
            balanceAccount2 = 20;
            transferAmount = 30;
            balanceExpected1 = balanceAccount1 - transferAmount;
            balanceExpected2 = balanceAccount2 + transferAmount;
            account1 = new SavingsAccount(string.Empty, "SAV:1234", balanceAccount1);
            account2 = new BankAccount(string.Empty, "BNK:1234", balanceAccount2);

            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"Savings to bank {MethodName} did not return the correct value. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"Savings to bank {MethodName} did not correctly set balance for the 'from' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected2, account2.Balance, $"Savings to bank {MethodName} did not correctly set balance for the 'to' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 2 balance expected: {balanceExpected2}.");

            // savings to checking
            balanceAccount1 = 255;
            balanceAccount2 = 10;
            transferAmount = 30;
            balanceExpected1 = balanceAccount1 - transferAmount;
            balanceExpected2 = balanceAccount2 + transferAmount;
            account1 = new SavingsAccount(string.Empty, "SAV:1234", balanceAccount1);
            account2 = new CheckingAccount(string.Empty, "CHK:1234", balanceAccount2);

            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"Savings to checking {MethodName} did not return the correct value. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"Savings to checking {MethodName} did not correctly set balance for the 'from' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected2, account2.Balance, $"Savings to checking {MethodName} did not correctly set balance for the 'to' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 2 balance expected: {balanceExpected2}.");

            // savings to savings
            balanceAccount1 = 290;
            balanceAccount2 = 100;
            transferAmount = 60;
            balanceExpected1 = balanceAccount1 - transferAmount;
            balanceExpected2 = balanceAccount2 + transferAmount;
            account1 = new SavingsAccount(string.Empty, "SAV:1234", balanceAccount1);
            account2 = new SavingsAccount(string.Empty, "SAV:5678", balanceAccount2);

            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"Savings to savings {MethodName} did not return the correct value. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"Savings to savings {MethodName} did not correctly set balance for the 'from' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected2, account2.Balance, $"Savings to savings {MethodName} did not correctly set balance for the 'to' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 2 balance expected: {balanceExpected2}.");
        }

        [TestMethod]
        public void Test03_EdgeCaseTests()
        {
            string wellFormedCheck = MethodWellFormedCheck();
            if (!string.IsNullOrEmpty(wellFormedCheck))
            {
                Assert.Fail($"{MethodName} is not well formed. The Test01_MethodWellFormed tests must pass first.\r\n\t{wellFormedCheck}");
            }

            BankAccount account1, account2;
            decimal balanceAccount1, balanceAccount2, balanceExpected1, balanceExpected2, transferAmount;
            object returnValue;

            // negative transfer values
            balanceAccount1 = 100;
            balanceAccount2 = 20;
            transferAmount = -30;
            balanceExpected1 = balanceAccount1; // no change
            balanceExpected2 = balanceAccount2; // no change
            account1 = new BankAccount(string.Empty, "BNK:1234", balanceAccount1);
            account2 = new BankAccount(string.Empty, "BNK:5678", balanceAccount2);

            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"{MethodName} with a negative transfer amount returned a value besides zero. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"{MethodName} with a negative transfer amount should not change the balance for the 'from' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected2, account2.Balance, $"{MethodName} with a negative transfer amount should not change the balance for the 'to' account. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 2 balance expected: {balanceExpected2}.");


            // checking account overdraft 
            balanceAccount1 = 1;
            balanceAccount2 = 100;
            transferAmount = 2;
            balanceExpected1 = balanceAccount1 - transferAmount - CheckingAccount.OverdraftFee;
            account1 = new CheckingAccount(string.Empty, "CHK:1234", balanceAccount1);
            account2 = new BankAccount(string.Empty, "BNK:1234", balanceAccount2);

            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"CheckingAccount {MethodName} should incur an overdraft fee if the 'from' account balance falls below zero. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"CheckingAccount {MethodName} should incur an overdraft fee if the 'from' account balance falls below zero. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");


            // savings account service charge
            balanceAccount1 = 150;
            balanceAccount2 = 100;
            transferAmount = 1;
            balanceExpected1 = balanceAccount1 - transferAmount - SavingsAccount.ServiceCharge;
            account1 = new SavingsAccount(string.Empty, "SAV:1234", balanceAccount1);
            account2 = new BankAccount(string.Empty, "BNK:1234", balanceAccount2);

            returnValue = SafeReflection.InvokeMethod(account1, MethodName, new object[] { account2, transferAmount });
            Assert.AreEqual(balanceExpected1, returnValue, $"SavingsAccount {MethodName} should incur a service change if the 'from' account balance falls below the minimum. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Return value expected: {balanceExpected1}.");
            Assert.AreEqual(balanceExpected1, account1.Balance, $"SavingsAccount {MethodName}  should incur a service change if the 'from' account balance falls below the minimum. Account 1 balance: {balanceAccount1}, Account 2 balance: {balanceAccount2}, Transfer: {transferAmount}, Account 1 balance expected: {balanceExpected1}.");
        }

        private string MethodWellFormedCheck()
        {
            MethodInfo bankAccountTransferFunds = SafeReflection.GetMethod(bankAccountClassType, MethodName);
            MethodInfo checkingAccountTransferFunds = SafeReflection.GetMethod(checkingAccountClassType, MethodName);
            MethodInfo savingsAccountTransferFunds = SafeReflection.GetMethod(savingsAccountClassType, MethodName);

            // Assert method exists
            if (bankAccountTransferFunds == null) { return $"{MethodName} not found in {BankAccountClassName}. Have you declared it yet? Make sure the method name is '{MethodName}'."; }
            if (checkingAccountTransferFunds == null) { return $"{MethodName} not found in {CheckingAccountClassName}. Have you declared it yet? Make sure the method name is '{MethodName}'."; }
            if (savingsAccountTransferFunds == null) { return $"{MethodName} not found in {SavingsAccountClassName}. Have you declared it yet? Make sure the method name is '{MethodName}'."; }

            // Assert methods are of correct type and access
            string methodCheck = CheckMethod(bankAccountClassType, MethodName, typeof(decimal), true, false, new Type[] { bankAccountClassType, typeof(decimal) });
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }

            methodCheck = CheckMethod(checkingAccountClassType, MethodName, typeof(decimal), true, false, new Type[] { bankAccountClassType, typeof(decimal) });
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }

            methodCheck = CheckMethod(savingsAccountClassType, MethodName, typeof(decimal), true, false, new Type[] { bankAccountClassType, typeof(decimal) });
            if (!string.IsNullOrEmpty(methodCheck)) { return methodCheck; }

            // Assert method in correct class and inherited
            if (checkingAccountTransferFunds.DeclaringType.Name != BankAccountClassName) { return $"{CheckingAccountClassName} must not declare {MethodName} method, it should inherit from the {BankAccountClassName} class."; }
            if (savingsAccountTransferFunds.DeclaringType.Name != BankAccountClassName) { return $"{SavingsAccountClassName} must not declare {MethodName} method, it should inherit from the {BankAccountClassName} class."; }

            return "";
        }
    }
}
