package com.techelevator.reservations.model;

import java.time.LocalDate;

public class Member {
    private int memberId;
    private String firstName;
    private String lastName;
    private String email;
    private String phone;
    private LocalDate dateOfBirth;
    private boolean wantsEmails;

    public Member() {

    }

    public Member(int memberId, String firstName, String lastName, String email, String phone, LocalDate dateOfBirth, boolean wantsEmails) {
        this.memberId = memberId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.phone = phone;
        this.dateOfBirth = dateOfBirth;
        this.wantsEmails = wantsEmails;
    }

    public int getMemberId() {
        return memberId;
    }

    public void setMemberId(int memberId) {
        this.memberId = memberId;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public LocalDate getDateOfBirth() {
        return dateOfBirth;
    }

    public void setDateOfBirth(LocalDate dateOfBirth) {
        this.dateOfBirth = dateOfBirth;
    }

    public boolean isWantsEmails() {
        return wantsEmails;
    }

    public void setWantsEmails(boolean wantsEmails) {
        this.wantsEmails = wantsEmails;
    }

    @Override
    public String toString() {
        return String.format("%s, %s (ID: %d)", getFirstName(), getLastName(), getMemberId());
    }
}
