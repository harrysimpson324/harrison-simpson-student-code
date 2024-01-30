package com.techelevator;

import java.util.List;

public class BankCustomer {

    private String name;
    private String address;
    private String phoneNumber;
    private List<Accountable> accounts;



    //no constructor?

    // getters and setters
    public String getAddress() {
        return address;
    }
    public String getName() {
        return name;
    }
    public String getPhoneNumber() {
        return phoneNumber;
    }
    public void setAddress(String address) {
        this.address = address;
    }
    public void setName(String name) {
        this.name = name;
    }
    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    //get/set for accounts

    public void addAccount(Accountable newAccount) {
        accounts.add(newAccount);
    }

    public Accountable[] getAccounts() {
        return accounts.toArray(new Accountable[0]);
    }

    public boolean isVip() {

        int total = 0;

        for(Accountable account : accounts) {
            total += account.getBalance();
        }

        if (total >= 25000) {
            return true;
        }
        return false;
    }

}
