using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingCompany
{
    public class TruckDelivery : Delivery
    {
        /**
         * The top speed of the truck represented in mph
         */
        public const double TruckTopSpeed = 60.0;

        public override int GetDuration()
        {
            ////Original version
            //double decimalHours = base.Distance / TruckTopSpeed;
            //int hours = (int) decimalHours;
            //int minutes = (int) Math.Round((decimalHours - hours) * 60);
            //return (hours * 60) + minutes; //duration in minutes

            //Refactored version
            double decimalHours = (double)base.Distance / TruckTopSpeed;
            return ConvertHoursToMinutes(decimalHours);
        }
    }
}
