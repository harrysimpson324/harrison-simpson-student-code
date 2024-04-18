namespace Lecture
{
    public partial class LectureExample
    {
        /*
        7. This method uses an if to check to make sure that one is equal to one.
            Make sure it returns TRUE when one equals one.
            TOPIC: Boolean Expression & Conditional Logic
        */
        public bool ReturnTrueWhenOneEqualsOne()
        {
            // Declare our output variable
            bool output = false;

            // IF 1 is equal to 1
            if (1 == 1)
            {
                output = true;
            }

            // Return the value of our output variable
            return output;
        }
    }
}
