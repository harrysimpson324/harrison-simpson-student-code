namespace Lecture
{
    public partial class LectureExample
    {
        /*
        6. This method uses an if statement to define what to return. Have it
            return true if the if statement passes.
            TOPIC: Conditional Logic
        */
        public bool ReturnTrueFromIf()
        {
            // Declare our return variable
            bool output = false;

            // If some condition were true
            if (true)
            {
                output = true;
            }

            // Return our answer
            return output;
        }
    }
}
