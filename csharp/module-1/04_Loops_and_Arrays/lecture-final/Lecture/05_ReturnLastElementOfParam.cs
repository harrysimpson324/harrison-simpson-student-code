namespace Lecture
{
    public partial class LectureProblem
    {
        /*
        5a. Sometimes we don't know how large the array is that we're given.
            Return the last element of the array from the parameters
            TOPIC: Accessing Array Elements
        */
        public int ReturnLastElementOfParam(int[] passedInArray)
        {
            int lastElement = passedInArray[passedInArray.Length - 1];
            return lastElement;
        }

        /*
        5b. Return the second to last element of the array from the parameters
            TOPIC: Accessing Array Elements
        */
        public int ReturnSecondToLastElementOfParam(int[] passedInArray)
        {
            int secondToLastElement = passedInArray[passedInArray.Length - 2];
            return secondToLastElement;
        }

        /*
        5c. Set the last element in the array to 100.
            TOPIC: Setting Array Elements
        */
        public void SetLastElement(int[] passedInArray)
        {
            passedInArray[passedInArray.Length - 1] = 100;
            return;
        }
    }
}
