package com.techelevator;

import java.util.Map;
import java.util.HashMap;

public class QuizQuestion {

    private String question;

    private Map<String, Boolean> answers;

    public QuizQuestion(String question, String answer1, String answer2, String answer3, String answer4, String correctAnswer) {
        answers = new HashMap<>();
        this.question = question;
        answers.put(answer1 , false);
        answers.put(answer2, false);
        answers.put(answer3, false);
        answers.put(answer4, false);
        answers.put(correctAnswer, true);
    }

    public boolean isAnswerRight(String answer) {
        return answers.get(answer);
    }

    public boolean isValidAnswer(String answer) {
        return answers.containsKey(answer);
    }

    public String getQuestion() {
        return question;
    }

    public String[] getAnswers() {
        String[] result = new String[answers.size()];
        int count = 0;
        for(String answer: answers.keySet()) {
            result[count] = answer;
            count++;
        }
        return result;
    }

    public String getCorrectAnswer() {
        for (String answer : answers.keySet()) {
            if (answers.get(answer)) {
                return answer;
            }
        }
        return "";
    }



}
