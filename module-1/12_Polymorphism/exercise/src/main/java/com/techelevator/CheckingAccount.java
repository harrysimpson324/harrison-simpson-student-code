package com.techelevator;

import java.math.BigDecimal;

public class CheckingAccount extends BankAccount {



    public static final int MINIMUM_BALANCE = -100;
    public static final int OVERDRAFT_FEE = 10;

    public CheckingAccount(String accountHolder, String accountNumber, int balance) {
        super(accountHolder, accountNumber, balance);
        BigDecimal haha = new BigDecimal(0);

        haha.compareTo(new BigDecimal("1"));
    }

    public CheckingAccount(String accountHolder, String accountNumber) {
        super(accountHolder, accountNumber);
    }

    @Override
    public int withdraw(int amountToWithdraw) {
        // Only allow the withdrawal if the balance won't go below the minimum
        if (amountToWithdraw > 0 && (getBalance() - amountToWithdraw > MINIMUM_BALANCE)) {
            // Withdraw the amount
            super.withdraw(amountToWithdraw);

            // If the balance goes below 0, assess overdraft fee
            if (getBalance() < 0) {
                super.withdraw(OVERDRAFT_FEE);
            }
        }
        return getBalance();
    }
}
