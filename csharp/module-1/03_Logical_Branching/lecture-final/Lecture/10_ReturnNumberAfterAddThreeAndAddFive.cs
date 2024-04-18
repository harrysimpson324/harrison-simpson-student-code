namespace Lecture
{
    public partial class LectureExample
    {
        /*
        10.This method will take a number and do the following things to it:
            If addThree is true, we'll add three to that number
            If addFive is true, we'll add five to that number
            We'll then return the result
            TOPIC: Stacking Conditional Logic
        */
        public int ReturnNumberAfterAddThreeAndAddFive(int number, bool addThree, bool addFive)
        {
            // Copy the parameter into a variable
            int result = number;

            // ADD 3 if addThree == true
            if (addThree)
            {
                result += 3;
            }

            // ADD 5 if addFive == true
            if (addFive)
            {
                result += 5;
            }

            // Return the answer
            return result;
        }
    }
}
