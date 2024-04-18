using System.Collections.Generic;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public interface ICityDao
    {
        /// <summary>
        /// Get a city from the datastore given the city id.
        /// If the given city id is not found, return null.
        /// </summary>
        /// <param name="cityId">The id of the city to get from the datastore.</param>
        /// <returns>The fully populated City object.</returns>
        City GetCityById(int cityId);

        /// <summary>
        /// Get a list of all the city names (ascending order) in the datastore.
        /// The list is never null. It is empty if there are no city names in the datastore.
        /// </summary>
        /// <returns>All the city names as a list of strings.</returns>
        IList<string> GetCityNames();

        /// <summary>
        /// Get a list of cities (unordered) in a state from the datastore given the state abbreviation.
        /// The list is never null. It is empty if there are no cities for the given state abbreviation
        /// in the datastore.
        /// </summary>
        /// <param name="stateAbbreviation">The state abbreviation of the cities to get from the datastore.</param>
        /// <returns>A list of City objects.</returns>
        IList<City> GetCitiesByState(string stateAbbreviation);

        /// <summary>
        /// Get the count of all the cities in the datastore.
        /// If there are no cities in the datastore, return 0.
        /// </summary>
        /// <returns>The number of cities in the datastore.</returns>
        int GetCityCount();

        /// <summary>
        /// Get a randomly selected city from the datastore.
        /// If there are no cities in the datastore, return null.
        /// </summary>
        /// <returns>The fully populated City object randomly selected.</returns>
        City GetRandomCity();

        /// <summary>
        /// Get the population of the largest city in the datastore.
        /// If there are no cities in the datastore, return 0.
        /// </summary>
        /// <returns>The population of the largest city.</returns>
        int GetMostPopulatedCity();

        /// <summary>
        /// Get the population of the smallest city in the datastore.
        /// If there are no cities in the datastore, return 0.
        /// </summary>
        /// <returns>The population of the smallest city.</returns>
        int GetLeastPopulatedCity();

        /// <summary>
        /// Get the average area of all the cities in the datastore.
        /// If there are no cities in the datastore, return 0.
        /// </summary>
        /// <returns>The average area of all the cities.</returns>
        decimal GetAverageCityArea();
    }
}
