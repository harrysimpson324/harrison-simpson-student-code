using System;
using System.Collections.Generic;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public interface IParkDao
    {
        /// <summary>
        /// Get the count of all the parks in the datastore.
        /// If there are no parks in the datastore, return 0;
        /// </summary>
        /// <returns>The number of parks in the datastore.</returns>
        int GetParkCount();

        /// <summary>
        /// Get the average area of all the parks in the datastore.
        /// If there are no parks in the datastore, return 0.
        /// </summary>
        /// <returns>The average area of all the parks.</returns>
        decimal GetAverageParkArea();

        /// <summary>
        /// Get the date established of the oldest park in the datastore.
        /// If there are no parks in the datastore, return DateTime.MinValue.
        /// </summary>
        /// <returns>The date established of the oldest park.</returns>
        DateTime GetOldestParkDate();

        /// <summary>
        /// Get a park from the datastore given the park id.
        /// If the given park id is not found, return null.
        /// </summary>
        /// <param name="parkId">The id of the park to get from the datastore.</param>
        /// <returns>The fully populated Park object.</returns>
        Park GetParkById(int parkId);

        /// <summary>
        /// Get a list of all the park names (ascending order) in the datastore.
        /// The list is never null. It is empty if there are no park names in the datastore.
        /// </summary>
        /// <returns>All the park names as a list of strings.</returns>
        IList<string> GetParkNames();

        /// <summary>
        /// Get a list of parks (unordered) in a state from the datastore given the state abbreviation.
        /// The list is never null. It is empty if there are no parks for the given state abbreviation
        /// in the datastore.
        /// </summary>
        /// <param name="stateAbbreviation">The state abbreviation of the parks to get from the datastore.</param>
        /// <returns>The list of Park objects.</returns>
        IList<Park> GetParksByState(string stateAbbreviation);

        /// <summary>
        /// Get a list of park(s) (unordered) from the datastore given the park name.
        /// The search by park name is always case-insensitive regardless of useWildCard parameter.
        /// The list is never null. It is empty if there are no parks for the given park name in the datastore.
        /// </summary>
        /// <param name="name">The name of the park(s) to get from the datastore.</param>
        /// <param name="useWildCard">The name is wrapped with wildcard characters if useWildCard is true.</param>
        /// <returns>The list of Park objects.</returns>
        IList<Park> GetParksByName(string name, bool useWildCard);

        /// <summary>
        /// Get a list of all the parks with camping from the datastore.
        /// The list is never null. It is empty if there are no parks with camping in the datastore.
        /// </summary>
        /// <returns>The parks with camping as a list of Park objects.</returns>
        IList<Park> GetParksWithCamping();

        /// <summary>
        /// Get a randomly selected park from the datastore.
        /// If there are no parks in the datastore, return null.
        /// </summary>
        /// <returns>The fully populated Park object randomly selected.</returns>
        Park GetRandomPark();
    }
}
