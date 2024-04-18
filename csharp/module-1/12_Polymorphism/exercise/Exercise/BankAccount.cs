namespace Exercise
{
    public class BankAccount
    {
        public string AccountHolderName { get; private set; }
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountHolder, string accountNumber)
        {
            AccountHolderName = accountHolder;
            AccountNumber = accountNumber;
            Balance = 0;
        }

        public BankAccount(string accountHolder, string accountNumber, decimal balance)
        {
            AccountHolderName = accountHolder;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public decimal Deposit(decimal amountToDeposit)
        {
            if (amountToDeposit > 0)
            {
                Balance += amountToDeposit;
            }
            return Balance;
        }

        public virtual decimal Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > 0)
            {
                Balance -= amountToWithdraw;
            }
            return Balance;
        }

    }
}
