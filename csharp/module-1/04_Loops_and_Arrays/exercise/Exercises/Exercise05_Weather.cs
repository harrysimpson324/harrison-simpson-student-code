using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    public class Exercise05_Weather
    {
        private const int FreezingTemperatureF = 32;

        /*
        GaleForce Meteorologists recently developed a new weather station and need it to perform
        some common measurements for reporting.

        Note: Assume all temperatures are in Fahrenheit (°F) unless otherwise
        noted.
        */

        /*
        GaleForce needs to know the number of days in the upcoming forecast
        where the temperature is at or below freezing.

        Given an array of high temperatures, count the number of days when
        the high temperature is freezing (32° F) or below.

        Examples:
        BelowFreezing([33, 30, 32, 37, 44, 31, 41]) → 3
        BelowFreezing([-7, -3, 19, 35, 30])  → 4
        BelowFreezing([]) → 0
        */
        public int BelowFreezing(int[] dailyHighs)
        {
            return 0;
        }

        /*
        GaleForce also needs to determine the hottest day when given an upcoming forecast.

        Given an array of high temperatures, determine the hottest temperature.

        Note: The array of high temperatures is guaranteed to have at least one
        element.

        Examples:
        HottestDay([81, 93, 94, 105, 99, 95, 101, 90, 89, 92]) → 105
        HottestDay([23, 24] → 24
        HottestDay([34, 33] → 34
        HottestDay([55]) → 55
        */
        public int HottestDay(int[] dailyHighs)
        {
            return 0;
        }

        /*
        GaleForce discovered an equipment malfunction. Every other reading, starting with the first,
        was off by 2 degrees Fahrenheit (°F).

        Given an array of Fahrenheit temperatures, fix each of the incorrect readings by adding
        2 degrees to its current value.

        Examples:
        FixTemperatures([33, 30, 32, 37, 44, 31, 41]) → [35, 30, 34, 37, 46, 31, 43]
        FixTemperatures([-7, -33, 19, 35]) → [-5, -33, 21, 35]
        FixTemperatures([-1, 0, 1] → [1, 0, 3]
        FixTemperatures([-1] → [1]
        FixTemperatures([]) → []
        */
        public int[] FixTemperatures(int[] temperatures)
        {
            return new int[] { };
        }
    }
}
