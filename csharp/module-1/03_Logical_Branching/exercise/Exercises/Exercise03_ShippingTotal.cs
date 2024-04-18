using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Exercises.LogicalBranching
{
    /*
     * Scamper Shipping Company specializes in small, local deliveries.
     * The problems below ask you to implement the logic to calculate a shipping
     * amount for a package.
     */
    public class ShippingTotal
    {
        // You can use these constants in your solutions.
        private const int MaxWeightPounds = 40;
        private const double UpTo40PoundRate = 0.50;
        private const double Over40PoundRate = 0.75;

        /*
         * Scamper Shipping Company charges $0.50 per pound for items up to and
         * including 40 pounds. It charges $0.75 per pound for items over 40 pounds.
         * Return the shipping rate when provided a weight in pounds.
         * 
         * Examples:
         * CalculateShippingRate(10) ➔ 0.50
         * CalculateShippingRate(25) ➔ 0.50
         * CalculateShippingRate(40) ➔ 0.50
         * CalculateShippingRate(45) ➔ 0.75
         */
        public double CalculateShippingRate(int weightInPounds)
        {
            return 0.0;
        }

        /*
         * Scamper Shipping Company charges $0.50 per pound for items up to and
         * including 40 pounds. It charges $0.75 per pound for items over 40 pounds.
         * Implement the logic needed to calculate the shipping cost when provided a
         * weight in pounds.
         * 
         * You may use CalculateShippingRate() in your solution.
         * 
         * Examples:
         * CalculateShippingTotal(10) ➔ 5.0
         * CalculateShippingTotal(25) ➔ 12.5
         * CalculateShippingTotal(40) ➔ 20.0
         * CalculateShippingTotal(45) ➔ 33.75
         */
        public double CalculateShippingTotal(int weightPounds)
        {
            return 0.0;
        }

        /*
         * Scamper Shipping Company now allows customers to provide a discount code to
         * give them 10% off of their order.
         * Implement the logic to calculate the correct shipping rate when provided a
         * weight in pounds and a boolean value for hasDiscount.
         * 
         * You may use any previous methods in your solution.
         * 
         * Examples:
         * CalculateShippingTotal(10, false) ➔ 5.0
         * CalculateShippingTotal(10, true) ➔ 4.5
         * CalculateShippingTotal(25, false) ➔ 12.5
         * CalculateShippingTotal(25, true) ➔ 11.25
         * CalculateShippingTotal(40, false) ➔ 20.0
         * CalculateShippingTotal(40, true) ➔ 18.0
         * CalculateShippingTotal(45, false) ➔ 33.75
         * CalculateShippingTotal(45, true) ➔ 30.375
         */
        public double CalculateShippingTotal(int weightPounds, bool hasDiscount)
        {
            return 0.0;
        }
    }
}
