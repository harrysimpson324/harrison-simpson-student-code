using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingCompany
{
    public class DroneDelivery : Delivery
    {
        public const double DroneTopSpeed = 100.0;

        public override int GetDuration()
        {
            ////Original version
            //double topSpeedWithWeight = DroneTopSpeed / Shipment.Weight;
            //double decimalHours = base.Distance / topSpeedWithWeight;
            //int hours = (int) decimalHours;
            //int minutes = (int) Math.Round((decimalHours - hours) * 60);
            //return (hours * 60) + minutes;              

            //Refactored version
            double topSpeedWithWeight = DroneTopSpeed / Shipment.Weight;
            double decimalHours = base.Distance / topSpeedWithWeight;
            return ConvertHoursToMinutes(decimalHours);
        }
    }
}
