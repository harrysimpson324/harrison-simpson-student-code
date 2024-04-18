using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Exercises.LogicalBranching
{
    /*
     * Grade-o-matic Incorporated has a program to grade student tests.
     * The problems below ask you to implement the logic for returning a grade based on a student's test score.
     */
    public class TestGrading
    {
        /*
         * Grade-o-matic v1.0 scores tests as pass-fail.
         * A score of 70 or higher is a passing score. Anything lower is a failing score.
         * Return true for a passing score and false for a failing score.
         * 
         * GradeTestPassFail(90) ➔ true
         * GradeTestPassFail(70) ➔ true
         * GradeTestPassFail(45) ➔ false
         */
        public bool GradeTestPassFail(int score)
        {
            return false;
        }

        /*
         * Grade-o-matic received numerous requests from customers to grade using a point-based system.
         * Grade-o-matic v2.0 can now also score tests on a 0-3 scale.
         * 
         * Implement the logic to grade tests using this new scale:
         * - For a score of 90 or higher, return 3
         * - For a score of 50-89, return 2
         * - For a score of 25-49, return 1
         * - For a score of less than 25, return 0
         *
         * GradeTestNumeric(90) ➔ 3
         * GradeTestNumeric(70) ➔ 2
         * GradeTestNumeric(45) ➔ 1
         * GradeTestNumeric(10) ➔ 0
         */
        public int GradeTestNumeric(int score)
        {
            return 0;
        }

        /*
         * Grade-o-matic has received even more requests to grade using the classic letter scale.
         * Grade-o-matic v3.0 can now score tests on a letter scale.
         * Implement the logic to grade tests using this new scale:
         * - For a score of 90 or higher, return 'A'
         * - For a score of 80-89, return 'B'
         * - For a score of 70-79, return 'C'
         * - For a score of 60-69, return 'D'
         * - For a score less than 60, return 'F'
         *
         * GradeTestLetter(90) ➔ 'A'
         * GradeTestLetter(70) ➔ 'C'
         * GradeTestLetter(45) ➔ 'F'
         */
        public char GradeTestLetter(int score)
        {
            return ' ';
        }
    }
}
