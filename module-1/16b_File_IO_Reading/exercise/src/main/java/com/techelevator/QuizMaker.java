package com.techelevator;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class QuizMaker {

	// Use this scanner for all user input. Don't create additional Scanners with System.in
	private final Scanner userInput = new Scanner(System.in);

	public static void main(String[] args) {
		QuizMaker quizMaker = new QuizMaker();
		quizMaker.run();

	}

	public void run() {

		//Scope variables
		Scanner fileReader = getFileFromUser();
		List<QuizQuestion> quiz = new ArrayList<>();

		//Parse input file
		while(fileReader.hasNextLine()) {
			String line = fileReader.nextLine();
			String[] qAndAs = line.split("\\|");

			for ( String q : qAndAs) {
				System.out.println(q);
			}


			String correctAnswer = qAndAs[0];
//			for(int i = 0; i < qAndAs.length; i++) {
//				if (qAndAs[i].contains("*")) {
//					qAndAs[i] = qAndAs[i].substring(0, qAndAs[i].length()-1);
//					correctAnswer = qAndAs[i];
//				}
//			}
//			System.out.println(correctAnswer);
			quiz.add(new QuizQuestion(qAndAs[0], qAndAs[1], qAndAs[2], qAndAs[3], qAndAs[4], correctAnswer));
		}

		//Run the quiz
		int quizScore = 0;
		for(QuizQuestion question : quiz) {

			System.out.println(question.getQuestion());
			String[] answers = question.getAnswers();

			for (int i = 1; i <= answers.length; i++) {
				System.out.println(i + ". " + answers[i-1]);
			}

			System.out.println();
			System.out.print("Enter the number of your answer here: ");
			String userAnswer = "";
			int intAnswer = 0;

			//Get answer
			while (! (userAnswer.equals("1") || userAnswer.equals("2") || userAnswer.equals("3") || userAnswer.equals("4"))) {

				try {
					System.out.print("Enter the number that corresponds to your answer: ");
					userAnswer = userInput.nextLine();
					intAnswer = Integer.parseInt(userAnswer);
				} catch (NumberFormatException e) {
					System.out.print("Looks like that wasn't a valid number!");
				}

			}

			if (answers[intAnswer - 1].equals(question.getCorrectAnswer())) {
				System.out.println("That's right! Great job.");
				quizScore++;
			}
			else {
				System.out.println("Sorry, that's not right.");
			}

		}

		System.out.println("You got " + quizScore + " answer(s) correct out of the " + quiz.size() + " questions asked.");




	}

	public Scanner getFileFromUser() {

		String filePath;
		File file;
		while(true) {
			try {

				System.out.println("Quiz time! Please enter the file path of your quiz (should end in .txt).");
				filePath = userInput.nextLine();
				file = new File(filePath);

				if(!file.exists()) {
					throw new FileNotFoundException(filePath + " is not the file path of a valid file.");
				}
				if(!file.isFile()) {
					throw new IllegalArgumentException(filePath + "is not a file.");
				}

				return new Scanner(file);

			} catch(FileNotFoundException e) {
				System.out.println(e.getMessage() + "Please try again!");

			} catch(IllegalArgumentException e) {
				System.out.println(e.getMessage() + "Please try again!");
			}
		}

	}

}
