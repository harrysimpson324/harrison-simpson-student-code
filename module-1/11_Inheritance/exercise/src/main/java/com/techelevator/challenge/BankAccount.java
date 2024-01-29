package com.techelevator.challenge;


import java.math.BigDecimal;

public class BankAccount {

    private BigDecimal balance;
    private String accountHolderName;
    private String accountNumber;

    public BankAccount(String accountHolderName, String accountNumber) {
        this(accountHolderName, accountNumber, new BigDecimal(0));
    }

    public BankAccount(String accountHolderName, String accountNumber, BigDecimal balance) {
        this.accountHolderName = accountHolderName;
        this.accountNumber = accountNumber;
        this.balance = balance;
    }

    //getters & setters:

    public String getAccountHolderName() {
        return accountHolderName;
    }
    public String getAccountNumber() {
        return accountNumber;
    }
    public BigDecimal getBalance() {
        return balance;
    }

    //other methods

    public BigDecimal deposit(BigDecimal amountToDeposit) {
        if (amountToDeposit.compareTo(new BigDecimal(0)) > 0) {
            balance.add(amountToDeposit);
        }
        return balance;
    }

    public BigDecimal withdraw(BigDecimal amountToWithdraw) {
        if(amountToWithdraw.compareTo(balance) <= 0) {
            balance.subtract(amountToWithdraw);
        }
        return balance;
    }
}
