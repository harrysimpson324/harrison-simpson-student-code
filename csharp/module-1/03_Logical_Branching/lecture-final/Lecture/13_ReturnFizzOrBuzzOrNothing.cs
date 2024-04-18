namespace Lecture
{
    public partial class LectureExample
    {
        /*
         13. Write an if/else statement that returns
            "Fizz" if the parameter is 3,
            "Buzz" if the parameter is 5
            and an empty string "" for anything else.
            TOPIC: Conditional Logic
         */
        public string ReturnFizzOrBuzzOrNothing(int number)
        {
            // Create our output variable
            string output = "";

            // If number is 3
            if (number == 3)
            {
                output = "Fizz";
            }
            else if (number == 5) //OR number is 5
            {
                output = "Buzz";
            }

            // Return our answer
            return output;
        }
    }
}
