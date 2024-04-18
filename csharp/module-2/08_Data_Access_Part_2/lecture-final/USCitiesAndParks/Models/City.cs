namespace USCitiesAndParks.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string StateAbbreviation { get; set; }
        public int Population { get; set; }
        public decimal Area { get; set; }

        public override string ToString()
        {
            return $"{CityName}, {StateAbbreviation} (ID: {CityId})";
        }
    }
}
