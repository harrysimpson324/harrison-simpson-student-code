namespace Lecture
{
    public partial class LectureExample
    {
        /*
        14. Write an if statement that checks
            if the parameter number is either equal to or greater than 18.
            Return "Adult" if it is or "Minor" if it's not.
            Topic: Comparison Operators
        */
        public string ReturnAdultOrMinor(int number)
        {
            string status = "";

            // IF age is greater than or equal to 18
            if (number >= 18)
            {
                status = "Adult";
            }
            else
            {
                status = "Minor";
            }

            return status;
        }
    }
}
