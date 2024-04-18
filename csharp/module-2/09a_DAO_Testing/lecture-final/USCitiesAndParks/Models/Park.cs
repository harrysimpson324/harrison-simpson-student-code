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

        public Park() { }

        public Park(int parkId, string parkName, DateTime dateEstablished, decimal area, bool hasCamping)
        {
            ParkId = parkId;
            ParkName = parkName;
            DateEstablished = dateEstablished;
            Area = area;
            HasCamping = hasCamping;
        }

        public override string ToString()
        {
            return $"{ParkName} (ID: {ParkId})";
        }
    }
}
