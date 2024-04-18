using System;

namespace CommandLineProgramsTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //greet the user and prompt them to enter a start from, end with, and increment value
            Console.Write("Enter a kilometer value to start at: ");
            string value = Console.ReadLine();
            int kilometerStart = int.Parse(value);

            Console.Write("Enter a kilometer value to end with: ");
            value = Console.ReadLine();
            int kilometerEnd = int.Parse(value);

            Console.Write("How many should it increment by: ");
            value = Console.ReadLine();
            int incrementBy = int.Parse(value);

            Console.WriteLine("Going from " + kilometerStart + "km to " + kilometerEnd +
                    "km in increments of " + incrementBy + "km.");

            //print out each value converted into miles from start from to end with
            for (int km = kilometerStart; km <= kilometerEnd; km += incrementBy)
            {
                double miles = KilometersToMiles(km);
                Console.WriteLine(km + "km is " + miles + "mi.");
            }
        }
        public static double KilometersToMiles(int kilometers)
        {
            const double MilesPerKilometer = 0.621371;
            return kilometers * MilesPerKilometer;
        }
    }
}
