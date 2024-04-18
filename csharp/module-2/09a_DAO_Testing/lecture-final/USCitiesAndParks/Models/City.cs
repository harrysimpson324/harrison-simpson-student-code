namespace USCitiesAndParks.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string StateAbbreviation { get; set; }
        public int Population { get; set; }
        public decimal Area { get; set; }

        public City() { }

        public City(int cityId, string cityName, string stateAbbreviation, int population, decimal area)
        {
            CityId = cityId;
            CityName = cityName;
            StateAbbreviation = stateAbbreviation;
            Population = population;
            Area = area;
        }

        public override string ToString()
        {
            return $"{CityName}, {StateAbbreviation} (ID: {CityId})";
        }
    }
}
