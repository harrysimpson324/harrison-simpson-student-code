package com.techelevator.challenge;

import java.math.BigDecimal;

public class CheckingAccount extends BankAccount {

    public CheckingAccount(String accountHolderName, String accountNumber, BigDecimal balance) {
        super(accountHolderName, accountNumber, balance);
    }

    public CheckingAccount(String accountHolderName, String accountNumber) {
        super(accountHolderName, accountNumber);
    }

    @Override
    public BigDecimal withdraw(BigDecimal amountToWithdraw) {
        BigDecimal zero = new BigDecimal(0);
        final BigDecimal OVERDRAFT_FEE = new BigDecimal(10);
        //   balance       -     ( amountToWithdraw + OVERDRAFT_FEE)  compareTo        -100
        if( getBalance().subtract(amountToWithdraw.add(OVERDRAFT_FEE)).compareTo(new BigDecimal(-100)) <= 0) {
            return getBalance();
        }

        else if(getBalance().subtract(amountToWithdraw).compareTo(zero) < 0) {
            return super.withdraw(amountToWithdraw.add(OVERDRAFT_FEE));
        }

        return super.withdraw(amountToWithdraw);
    }

}
