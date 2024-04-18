using System.Collections.Generic;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public interface IStateDao
    {
        /// <summary>
        /// Get a state from the datastore given the state abbreviation.
        /// If the given state abbreviation is not found, return null.
        /// </summary>
        /// <param name="stateAbbreviation">The state abbreviation of the state to get from the datastore.</param>
        /// <returns>The fully populated State object.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        State GetStateByAbbreviation(string stateAbbreviation);

        /// <summary>
        /// Get a state from the datastore given the capital city id.
        /// If the given capital city id is not found, return null.
        /// </summary>
        /// <param name="cityId">The id of the capital city of the state to get from the datastore.</param>
        /// <returns>The fully populated State object.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        State GetStateByCapital(int cityId);

        /// <summary>
        /// Get a list of all the states (unordered) in the datastore.
        /// The list is never null. It is empty if there are no states in the datastore.
        /// </summary>
        /// <returns>All the states as a list of State objects.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        IList<State> GetStates();
    }
}
