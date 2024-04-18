namespace Exercise
{
    public class CheckingAccount : BankAccount
    {
        public const decimal MinimumBalance = -100;
        public const decimal OverdraftFee = 10;

        public CheckingAccount(string accountHolder, string accountNumber) : base(accountHolder, accountNumber)
        {

        }

        public CheckingAccount(string accountHolder, string accountNumber, decimal balance) : base(accountHolder, accountNumber, balance)
        {

        }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            // Only allow the withdrawal if the balance won't go below the minimum
            if (amountToWithdraw > 0 && (Balance - amountToWithdraw > MinimumBalance))
            {
                // Withdraw the amount
                base.Withdraw(amountToWithdraw);

                // If the balance goes below 0, assess overdraft fee
                if (Balance < 0)
                {
                    base.Withdraw(OverdraftFee);
                }
            }
            return Balance;
        }
    }
}
