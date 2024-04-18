namespace Lecture
{
    public partial class LectureExample
    {
        /*
          8.This method checks a parameter passed to the method to see if it's
            greater than 5 and returns true if it is.
            TOPIC: Comparison Operators & Conditional Logic
        */
        public bool ReturnTrueWhenGreaterThanFive(int number)
        {
            bool greaterThan5 = false;

            if (number > 5)
            {
                greaterThan5 = true;
            }

            return greaterThan5;
        }
    }
}
