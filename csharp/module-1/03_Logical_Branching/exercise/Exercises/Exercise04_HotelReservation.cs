using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Exercises.LogicalBranching
{
    /*
     * Innovator's Inn is a new hotel chain with two simple rates:
     *    $99.99 per night for stays of 1 or 2 nights
     *    $89.99 per night for stays of 3 nights or more
     * The problems below ask you to implement the logic for determining a guest's total amount for their stay.
     */
    public class HotelReservation
    {
        // You can use these constants in your solutions.
        private const double DailyRate = 99.99;
        private const double DiscountRate = 89.99;
        private const double ParkingRate = 25.0;
        private const double LateCheckoutFee = 20.0;
        private const int MinimumNightsForDiscountRate = 3;

        /* 
         * Using the rates from above, implement the logic to determine the total amount based on
         * the number of nights a guest stays.
         * 
         * See the summary at the top of this file for rates and rules around extended stays.
         *
         * CalculateStayTotal(1) ➔ 99.99
         * CalculateStayTotal(2) ➔ 199.98
         * CalculateStayTotal(3) ➔ 269.97
         */
        public double CalculateStayTotal(int numberOfNights)
        {
            return 0.0;
        }

        /*
         * The owners of Innovator's Inn offer parking at an additional cost of $25.00 per night.
         * Calculate the stay total based on the number of nights (int) 
         * and on whether the guest requires parking (bool).
         * 
         * Examples:
         * CalculateStayTotal(2, false) ➔ 199.98
         * CalculateStayTotal(2, true) ➔ 249.98
         * CalculateStayTotal(3, false) ➔ 269.97
         * CalculateStayTotal(3, true) ➔ 344.97
         */
        public double CalculateStayTotal(int numberOfNights, bool includesParking)
        {
            return 0.0;
        }

        /*
         * Innovator's Inn offers late checkout—but it comes at a price.
         * A guest can reserve a late checkout for an additional fee of $20. 
         * Calculate the stay total given the number of nights (int), 
         * whether they require parking (bool), and whether they require a late checkout (bool). 
         * 
         * Examples:
         * CalculateStayTotal(2, false, false) ➔ 199.98
         * CalculateStayTotal(2, false, true) ➔ 219.98
         * CalculateStayTotal(2, true, false) ➔ 249.98
         * CalculateStayTotal(2, true, true) ➔ 269.98
         * CalculateStayTotal(3, false, false) ➔ 269.97
         * CalculateStayTotal(3, false, true) ➔ 289.97
         * CalculateStayTotal(3, true, false) ➔ 344.97
         * CalculateStayTotal(3, true, true) ➔ 364.97
         */
        public double CalculateStayTotal(int numberOfNights, bool includesParking, bool includesLateCheckout)
        {
            return 0.0;
        }
    }
}
