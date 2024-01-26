package com.techelevator;

public class HomeworkAssignment {

    private int earnedMarks;
    private int possibleMarks;
    private String submitterName;

    public HomeworkAssignment(int possibleMarks, String submitterName) {
        this.submitterName = submitterName;
        this.possibleMarks = possibleMarks;
    }

    public void setEarnedMarks(int earnedMarks) {
        this.earnedMarks = earnedMarks;
    }

    public int getEarnedMarks() {
        return earnedMarks;
    }

    public int getPossibleMarks() {
        return possibleMarks;
    }

    public String getSubmitterName() {
        return submitterName;
    }

    public String getLetterGrade() {
        double percentage = (double) earnedMarks/(double)possibleMarks;
        if (percentage >= 0.90) {
            return "A";
        }
        else if(percentage >= 0.80 ){
            return "B";
        }
        else if(percentage >= 0.70) {
            return "C";
        }
        else if(percentage >= 0.60) {
            return "D";
        }
        return "F";
    }

}
