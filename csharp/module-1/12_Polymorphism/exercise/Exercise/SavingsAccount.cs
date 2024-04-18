namespace Exercise
{
    public class SavingsAccount : BankAccount
    {
        public const decimal LowBalance = 150;
        public const decimal ServiceCharge = 2;

        public SavingsAccount(string accountHolder, string accountNumber) : base(accountHolder, accountNumber)
        {

        }

        public SavingsAccount(string accountHolder, string accountNumber, decimal balance) : base(accountHolder, accountNumber, balance)
        {

        }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            // Only perform transaction if there's still room for service charge
            if (amountToWithdraw > 0 && (Balance - amountToWithdraw >= ServiceCharge))
            {
                // Withdraw the amount
                base.Withdraw(amountToWithdraw);

                // Assess service charge if balance goes below low balance threshold
                if (Balance < LowBalance)
                {
                    base.Withdraw(ServiceCharge);
                }
            }
            return Balance;
        }
    }
}
