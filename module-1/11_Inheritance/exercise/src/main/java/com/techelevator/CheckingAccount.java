package com.techelevator;

public class CheckingAccount extends BankAccount {

    //properties are 'implied'

    //constructor:

    public CheckingAccount(String accountHolderName, String accountNumber, int balance) {
        super(accountHolderName, accountNumber, balance);
    }

    public CheckingAccount(String accountHolderName, String accountNumber) {
        super(accountHolderName, accountNumber);
    }

    @Override
    public int withdraw(int amountToWithdraw) {
        final int OVERDRAFT_FEE = 10;
        int diff = getBalance() - amountToWithdraw;
        if (diff < 0 && diff > -100) {
            super.withdraw(amountToWithdraw + OVERDRAFT_FEE);
        }
        else if (diff <= -100) {
            return getBalance();
        }

        else {
            super.withdraw(amountToWithdraw);
        }


        return getBalance();
    }


}
