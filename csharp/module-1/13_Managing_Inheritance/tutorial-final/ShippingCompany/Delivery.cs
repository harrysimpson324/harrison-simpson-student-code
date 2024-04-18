using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingCompany
{
    public abstract class Delivery
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }
        public Shipment Shipment { get; set; }

        public abstract int GetDuration();

        protected int ConvertHoursToMinutes(double decimalHours)
        {
            int hours = (int)decimalHours;
            int minutes = (int)Math.Round((decimalHours - hours) * 60);
            return (hours * 60) + minutes; //duration in minutes;
        }

        public DateTime GetExpectedArrival(DateTime departure)
        {
            return departure.AddMinutes(GetDuration());
        }
    }
}
