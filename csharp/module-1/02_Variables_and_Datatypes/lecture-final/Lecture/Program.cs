using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES & DATA TYPES */

            /*
		    1. Create a variable to hold an int and call it numberOfExercises.
			Then set it to 26.
		    */
            int numberOfExercises;
            numberOfExercises = 26;

            Console.WriteLine(numberOfExercises);

            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */
            double half;
            half = 0.5;

            Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */
            string name = "TechElevator";

            Console.WriteLine(name);

            /*
            4. Create a variable called seasonsOfFirefly and set it to 1.
            */
            int seasonsOfFirefly = 1;

            Console.WriteLine(seasonsOfFirefly);

            /*
            5. Create a variable called myFavoriteLanguage and set it to "C#".
            */
            string myFavoriteLanguage = "C#";

            Console.WriteLine(myFavoriteLanguage);

            /*
            6. Create a variable called pi and set it to 3.1416.
            */
            double pi = 3.1416;
            Console.WriteLine(pi);

            /*
            7. Create and set a variable that holds your name.
            */
            string myFirstName = "Clark";
            Console.WriteLine("My name is " + myFirstName);

            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */
            int numberOfMouseButtons = 3;
            Console.WriteLine(numberOfMouseButtons);

            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */
            double percentBatteryRemaining = 75.2;
            Console.WriteLine(percentBatteryRemaining);


            /* EXPRESSIONS */

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int difference = 121 - 27;
            Console.WriteLine(difference);

            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            double sum = 12.3 + 32.1;
            Console.WriteLine(sum);

            /*
            12. Create a string that holds your full name.
            */
            string myName = "Clark Griswold";

            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string greeting = "Hello, " + myName;

            /*
            14. Add " Esquire" onto the end of your full name and save it back to
            the same variable.
            */
            greeting = greeting + " Esquire";

            Console.WriteLine(greeting);
            /*
            15. Now do the same as exercise 14, but use the += operator.
            */

            greeting += ", all-around good guy";
            Console.WriteLine(greeting);

            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */
            int val = 2;
            string saw = "Saw";
            saw += val;
            Console.WriteLine(saw);

            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */
            saw += 0;
            Console.WriteLine(saw);

            /*
            18. What is 4.4 divided by 2.2? It's 2
            */
            double result = 4.4 / 2.2;
            Console.WriteLine(result);

            /*
            19. What is 5.4 divided by 2?
            */
            Console.WriteLine(5.4 / 2);

            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */
            double quotient = 5 / 2;
            Console.WriteLine("5 / 2 = " + quotient);

            /*
            21. What is 5.0 divided by 2?
            */
            quotient = (float)5 / 2;
            Console.WriteLine("(float)5 / 2 = " + quotient);

            /*
            22. What is 66.6 divided by 100? Is the answer you get right or wrong?
            */
            Console.WriteLine(66.6 / 100);

            /*
            23. If I divide 5 by 2, what's my remainder?
            */
            int remainder = 5 % 2;
            Console.WriteLine("5 % 2 = " + remainder);

            /*
            24. Create two variables: 3 and 1,000,000,000 and multiple them together.
                What is the result?
            */
            //int three = 3;
            //int billion = 1000000000;
            //int threeBillion = three * billion;
            //Console.WriteLine(threeBillion);

            // Now try it with variable type long
            int three = 3;
            long billion = 1000000000;
            long threeBillion = three * billion;
            Console.WriteLine(threeBillion);

            /*
            25. Create a variable that holds a boolean called isDoneWithExercises and
            set it to false.
            */
            bool isDoneWithExercises = false;

            /*
            26. Now set isDoneWithExercise to true.
            */
            isDoneWithExercises = true;
            Console.WriteLine(isDoneWithExercises);
        }
    }
}
