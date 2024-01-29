package com.techelevator.challenge;

import java.math.BigDecimal;

public class SavingsAccount extends BankAccount {

    public SavingsAccount(String accountHolderName, String accountNumber, BigDecimal balance) {
        super(accountHolderName, accountNumber, balance);
    }

    public SavingsAccount(String accountHolderName, String accountNumber) {
        super(accountHolderName, accountNumber);
    }

    @Override
    public BigDecimal withdraw(BigDecimal amountToWithdraw) {

        final BigDecimal SERVICE_FEE = new BigDecimal(2);

        //                            (balance      -      amountToWithdraw)                    <    150
        boolean isBetween0and150 = getBalance().subtract(amountToWithdraw).compareTo(new BigDecimal(150)) < 0
                // AND  balance    -     amountToWithdraw         >=         0
                && getBalance().subtract(amountToWithdraw).compareTo(new BigDecimal(0)) >= 0;
        //                             balance       -     (amountToWithdraw + SERVICE_FEE)         <      0
        boolean isLessThan0WithFee = getBalance().subtract(amountToWithdraw.add(SERVICE_FEE)).compareTo(new BigDecimal(0)) < 0;

        if(isLessThan0WithFee) {
            return getBalance();
        }

        else if(isBetween0and150) {
            return super.withdraw(amountToWithdraw.add(SERVICE_FEE));
        }

        return super.withdraw(amountToWithdraw);
    }

}
