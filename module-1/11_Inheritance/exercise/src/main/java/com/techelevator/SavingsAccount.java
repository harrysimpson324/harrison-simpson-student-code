package com.techelevator;

public class SavingsAccount extends BankAccount {

    public SavingsAccount(String accountHolderName, String accountNumber, int balance) {
        super(accountHolderName, accountNumber, balance);
    }

    public SavingsAccount(String accountHolderName, String accountNumber) {
        super(accountHolderName, accountNumber);
    }

    @Override
    public int withdraw(int amountToWithdraw) {
        final int SERVICE_CHARGE = 2;
        if(amountToWithdraw + SERVICE_CHARGE > getBalance()) {
            return getBalance();
        }
        if(getBalance() - amountToWithdraw < 150) {
            return super.withdraw(amountToWithdraw + SERVICE_CHARGE);
        }
        return super.withdraw(amountToWithdraw);
    }


}
