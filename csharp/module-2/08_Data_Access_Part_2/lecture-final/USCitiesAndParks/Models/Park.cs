using System;

namespace USCitiesAndParks.Models
{
    public class Park
    {
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public DateTime DateEstablished { get; set; }
        public decimal Area { get; set; }
        public bool HasCamping { get; set; }

        public override string ToString()
        {
            return $"{ParkName} (ID: {ParkId})";
        }
    }
}
