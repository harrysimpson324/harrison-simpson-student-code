namespace Lecture
{
    public partial class LectureProblem
    {
        /*
        10. What code do we need to write so that we can find the highest
             number in the array randomNumbers?
             TOPIC: Looping Through Arrays
        */
        public int FindTheHighestNumber(int[] randomNumbers)
        {
            // VARIABLE to hold highest number
            int highest = randomNumbers[0];

            // LOOP through all numbers
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                // VARIABLE reflecting current value
                int currentValue = randomNumbers[i];

                // IF current value in array is bigger than highest number
                if (currentValue > highest)
                {
                    //  THEN change highest number to current value
                    highest = currentValue;
                }
            }

            // RETURN highest number
            return highest;
        }
    }
}
