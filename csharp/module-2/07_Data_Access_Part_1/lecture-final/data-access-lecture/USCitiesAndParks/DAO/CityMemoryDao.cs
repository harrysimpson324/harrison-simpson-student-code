
using System;
using System.Collections.Generic;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public class CityMemoryDao : ICityDao
    {
        private IList<City> cities = new List<City>();

        public CityMemoryDao()
        {
            InitializeCityData();
        }

        public int GetCityCount()
        {
            int count = 0;
            count = cities.Count;
            return count;
        }

        public int GetMostPopulatedCity()
        {
            int highestPop = 0;
            foreach (City city in cities)
            {
                if (city.Population > highestPop)
                {
                    highestPop = city.Population;
                }
            }
            return highestPop;
        }

        public int GetLeastPopulatedCity()
        {
            int lowestPop = Int32.MaxValue;
            foreach (City city in cities)
            {
                if (city.Population < lowestPop)
                {
                    lowestPop = city.Population;
                }
            }
            return lowestPop;
        }

        public decimal GetAverageCityArea()
        {
            decimal sumArea = 0.0M;
            decimal avgArea = 0.0M;
            foreach (City city in cities)
            {
                sumArea += city.Area;
            }
            avgArea = sumArea / cities.Count;
            return avgArea;
        }

        public IList<string> GetCityNames()
        {
            IList<string> cityNames = new List<string>();
            foreach (City city in cities)
            {
                cityNames.Add(city.CityName);
            }
            return cityNames;
        }

        public City GetRandomCity()
        {
            City randomCity = null;
            Random rand = new Random();
            randomCity = cities[rand.Next(cities.Count)];
            return randomCity;
        }

        public City GetCityById(int cityId)
        {
            foreach (City city in cities)
            {
                if (city.CityId == cityId)
                {
                    return city;
                }
            }
            return null;
        }

        public IList<City> GetCitiesByState(string stateAbbreviation)
        {
            IList<City> returnCities = new List<City>();
            stateAbbreviation = stateAbbreviation.ToLower();
            foreach (City city in cities)
            {
                if (city.StateAbbreviation.ToLower() == stateAbbreviation)
                {
                    returnCities.Add(city);
                }
            }
            return returnCities;
        }

        private void InitializeCityData()
        {
            cities.Add(new City(3, "Albany", "NY", 96460, 56.8M));
            cities.Add(new City(12, "Annapolis", "MD", 39223, 21.0M));
            cities.Add(new City(17, "Atlanta", "GA", 506811, 345.8M));
            cities.Add(new City(19, "Augusta", "ME", 18697, 150.3M));
            cities.Add(new City(22, "Austin", "TX", 978908, 809.9M));
            cities.Add(new City(25, "Baton Rouge", "LA", 220236, 222.5M));
            cities.Add(new City(33, "Bismarck", "ND", 73529, 90.1M));
            cities.Add(new City(34, "Boise", "ID", 228959, 212.6M));
            cities.Add(new City(35, "Boston", "MA", 692600, 125.1M));
            cities.Add(new City(49, "Carson City", "NV", 55916, 407.3M));
            cities.Add(new City(55, "Charleston", "WV", 46536, 84.5M));
            cities.Add(new City(57, "Charlotte Amalie", "VI", 18481, 3.1M));
            cities.Add(new City(60, "Cheyenne", "WY", 64235, 83.8M));
            cities.Add(new City(72, "Columbia", "SC", 131674, 345.8M));
            cities.Add(new City(74, "Columbus", "OH", 898553, 565.9M));
            cities.Add(new City(77, "Concord", "NH", 43627, 174.0M));
            cities.Add(new City(88, "Denver", "CO", 727211, 397.0M));
            cities.Add(new City(89, "Des Moines", "IA", 214237, 230.2M));
            cities.Add(new City(91, "Dover", "DE", 36047, 62.1M));
            cities.Add(new City(113, "Frankfort", "KY", 27755, 39.0M));
            cities.Add(new City(130, "Hagåtña", "GU", 1051, 2.6M));
            cities.Add(new City(132, "Harrisburg", "PA", 49528, 30.7M));
            cities.Add(new City(133, "Hartford", "CT", 122105, 45.1M));
            cities.Add(new City(135, "Helena", "MT", 33124, 43.7M));
            cities.Add(new City(141, "Honolulu", "HI", 345064, 156.7M));
            cities.Add(new City(146, "Indianapolis", "IN", 876384, 936.3M));
            cities.Add(new City(150, "Jackson", "MS", 160628, 287.5M));
            cities.Add(new City(152, "Jefferson City", "MO", 42708, 97.5M));
            cities.Add(new City(155, "Juneau", "AK", 31276, 8429.6M));
            cities.Add(new City(167, "Lansing", "MI", 118210, 101.3M));
            cities.Add(new City(174, "Lincoln", "NE", 289102, 238.5M));
            cities.Add(new City(175, "Little Rock", "AR", 197312, 307.4M));
            cities.Add(new City(182, "Madison", "WI", 259680, 199.4M));
            cities.Add(new City(198, "Montgomery", "AL", 198525, 413.9M));
            cities.Add(new City(199, "Montpelier", "VT", 7372, 26.5M));
            cities.Add(new City(204, "Nashville", "TN", 670820, 1232.6M));
            cities.Add(new City(218, "Oklahoma City", "OK", 655057, 1570.3M));
            cities.Add(new City(220, "Olympia", "WA", 52882, 52.0M));
            cities.Add(new City(227, "Pago Pago", "AS", 3656, 2.1M));
            cities.Add(new City(238, "Phoenix", "AZ", 1680992, 1340.6M));
            cities.Add(new City(239, "Pierre", "SD", 13867, 33.8M));
            cities.Add(new City(247, "Providence", "RI", 179883, 47.7M));
            cities.Add(new City(250, "Raleigh", "NC", 474069, 375.8M));
            cities.Add(new City(256, "Richmond", "VA", 230436, 154.9M));
            cities.Add(new City(264, "Sacramento", "CA", 513624, 253.6M));
            cities.Add(new City(265, "Saint Paul", "MN", 308096, 134.7M));
            cities.Add(new City(266, "Saipan", "MP", 47565, 118.9M));
            cities.Add(new City(267, "Salem", "OR", 174365, 125.9M));
            cities.Add(new City(269, "Salt Lake City", "UT", 200567, 288.0M));
            cities.Add(new City(276, "San Juan", "PR", 318441, 102.3M));
            cities.Add(new City(282, "Santa Fe", "NM", 84683, 135.6M));
            cities.Add(new City(297, "Springfield", "IL", 114230, 155.7M));
            cities.Add(new City(308, "Tallahassee", "FL", 194500, 260.0M));
            cities.Add(new City(315, "Topeka", "KS", 125310, 159.3M));
            cities.Add(new City(317, "Trenton", "NJ", 83203, 21.3M));
            cities.Add(new City(332, "Washington", "DC", 705749, 158.2M));
        }
    }
}
