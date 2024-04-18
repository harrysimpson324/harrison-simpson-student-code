using System;

namespace LoopsArraysTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // write your code here

            int i;

            for (i = 0; i <= 5; i++)
            {
                Console.WriteLine(i);
            }

            for (i = 10; i >= 0; i--)
            {
                Console.WriteLine(i);
            }

            int[] forecastTemperatures = new int[5];
            forecastTemperatures[0] = 72;
            forecastTemperatures[1] = 78;
            forecastTemperatures[2] = 58;
            forecastTemperatures[3] = 79;
            forecastTemperatures[4] = 74;

            forecastTemperatures[2] = forecastTemperatures[2] + 10;
            // or forecastTemperatures[2] += 10;

            for (i = 0; i < forecastTemperatures.Length; i++)
            {
                Console.WriteLine(forecastTemperatures[i]);
            }

            int highestTemperatureValue = forecastTemperatures[0];
            int highestTemperatureIndex = 0;

            for (int j = 1; j < forecastTemperatures.Length; j++)
            {
                if (forecastTemperatures[j] > highestTemperatureValue)
                {
                    highestTemperatureValue = forecastTemperatures[j];
                    highestTemperatureIndex = j;
                }
            }

            Console.WriteLine("The highest temperature is " + highestTemperatureValue);
            Console.WriteLine("The highest temperature is in " + (highestTemperatureIndex + 1) + " days");

        }
    }
}
