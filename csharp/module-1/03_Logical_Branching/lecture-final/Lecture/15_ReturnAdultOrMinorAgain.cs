namespace Lecture
{
    public partial class LectureExample
    {
        /*
        15. Now, do it again with a different bool operation.
        TOPIC: Logical Not
        */
        public string ReturnAdultOrMinorAgain(int number)
        {
            string status = "Minor";

            // IF age is greater than or equal to 18
            if (number >= 18)
            {
                status = "Adult";
            }

            return status;
        }
    }
}
