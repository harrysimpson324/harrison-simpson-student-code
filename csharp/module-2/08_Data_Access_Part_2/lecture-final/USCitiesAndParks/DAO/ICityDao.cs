using System.Collections.Generic;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public interface ICityDao
    {
        /// <summary>
        /// Get the count of all the cities in the datastore.
        /// If there are no cities in the datastore, return 0.
        /// </summary>
        /// <returns>The number of cities in the datastore.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        int GetCityCount();

        /// <summary>
        /// Get a list of all the city names (ascending order) in the datastore.
        /// The list is never null. It is empty if there are no city names in the datastore.
        /// </summary>
        /// <returns>All the city names as a list of strings.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        IList<string> GetCityNames();

        /// <summary>
        /// Get a randomly selected city from the datastore.
        /// If there are no cities in the datastore, return null.
        /// </summary>
        /// <returns>The fully populated City object randomly selected.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        City GetRandomCity();

        /// <summary>
        /// Get a city from the datastore given the city id.
        /// If the given city id is not found, return null.
        /// </summary>
        /// <param name="cityId">The id of the city to get from the datastore.</param>
        /// <returns>The fully populated City object.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        City GetCityById(int cityId);

        /// <summary>
        /// Get a list of cities (unordered) in a state from the datastore given the state abbreviation.
        /// The list is never null. It is empty if there are no cities for the given state abbreviation
        /// in the datastore.
        /// </summary>
        /// <param name="stateAbbreviation">The state abbreviation of the cities to get from the datastore.</param>
        /// <returns>The list of City objects.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        IList<City> GetCitiesByState(string stateAbbreviation);

        /// <summary>
        /// Add a new city to the datastore based upon the given City object.
        /// The given City object does not need to be fully populated, only the properties required by
        /// the target datastore.
        /// </summary>
        /// <param name="city">The City object to add to the datastore.</param>
        /// <returns>A fully populated City object.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        City CreateCity(City city);

        /// <summary>
        /// Update an existing city in the datastore with the property values of the given City object.
        /// The given City object needs to be fully populated, not just the properties to be updated.
        /// </summary>
        /// <param name="city">The City object to update in the datastore.</param>
        /// <returns>A fully populated updated City object.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems. Also thrown if method updates zero records.
        /// </exception>
        City UpdateCity(City city);

        /// <summary>
        /// Remove an existing city from the datastore given a city id.
        /// If the city id is not found, return 0.
        /// </summary>
        /// <param name="cityId">The id of the city to remove from the datastore.</param>
        /// <returns>The number of cities removed from the datastore.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        int DeleteCityById(int cityId);
    }
}
