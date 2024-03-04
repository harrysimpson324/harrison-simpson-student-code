package com.techelevator;

import com.techelevator.dao.*;
import com.techelevator.exception.DaoException;
import com.techelevator.model.*;
import org.apache.commons.dbcp2.BasicDataSource;

import javax.sql.DataSource;

import java.time.LocalDate;
import java.time.format.DateTimeParseException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class MeetupsCLI {

    private final Scanner userInput = new Scanner(System.in);

    private final MemberDao memberDao;

    public static void main(String[] args) {
        BasicDataSource dataSource = new BasicDataSource();
        dataSource.setUrl("jdbc:postgresql://localhost:5432/meetups");
        dataSource.setUsername("postgres");
        dataSource.setPassword("postgres1");

        MeetupsCLI application = new MeetupsCLI(dataSource);
        application.run();
    }

    public MeetupsCLI(DataSource dataSource) {
        memberDao = new JdbcMemberDao(dataSource);
    }

    private void run() {
        displayBanner();
        boolean running = true;
        while (running) {
            displayMenu();
            int selection = promptForInt("Please select an option: ");
            if (selection == 1) {
                Member member= getFirstMember();
                System.out.println(member);
            }
            else if (selection == 2) {
                displayMembers();
            } else if (selection == 3) {
                running = false;
            } else {
                displayError("Invalid option selected.");
            }
        }
    }

    private Member getFirstMember() {
        Member member = null;
        try {
            member = memberDao.getMemberById(1);
        } catch (DaoException e) {
            displayError("Error occurred: " + e.getMessage());
        }
        return member;
    }

    private List<Member> getMembers() {
        List<Member> members = null;
        try {
            members = memberDao.getMembers();
        } catch (DaoException e) {
            displayError("Error occurred: " + e.getMessage());
        }
        return members;
    }

    private void displayMembers() {
        System.out.println("Members: ");
        try {
            for (Member member : memberDao.getMembers()) {
                System.out.println(member.getLastName() + ", " + member.getFirstName() + " (" + member.getEmail()+ ")");
            }
        } catch (DaoException e) {
            displayError("Error occurred: " + e.getMessage());
        }
    }

    private void displayBanner() {
        System.out.println("-----------------");
        System.out.println("|    Meetups    |");
        System.out.println("-----------------");
    }

    private void displayMenu() {
        System.out.println();
        System.out.println("1. View first member");
        System.out.println("2. View all members");
        System.out.println("3. Exit");
    }

    private void displayError(String message) {
        System.out.println();
        System.out.println("***" + message + "***");
    }

    private int promptForInt(String prompt) {
        return (int) promptForDouble(prompt);
    }

    private double promptForDouble(String prompt) {
        while (true) {
            System.out.print(prompt);
            String response = userInput.nextLine();
            try {
                return Double.parseDouble(response);
            } catch (NumberFormatException e) {
                if (response.isBlank()) {
                    return -1; //Assumes negative numbers are never valid entries.
                } else {
                    displayError("Numbers only, please.");
                }
            }
        }
    }

    private String promptForString(String prompt) {
        System.out.print(prompt);
        return userInput.nextLine();
    }

    private LocalDate promptForDate(String prompt) {
        while (true) {
            System.out.print(prompt);
            String response = userInput.nextLine();
            try {
                return LocalDate.parse(response);
            }  catch (DateTimeParseException e) {
                if (response.isBlank()) {
                    return null;
                } else {
                    displayError("Please format as YYYY-MM-DD.");
                }
            }
        }
    }


}
