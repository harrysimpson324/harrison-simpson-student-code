using System.Collections.Generic;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public interface IParkDao
    {
        /// <summary>
        /// Get a park from the datastore given the park id.
        /// If the given park id is not found, return null.
        /// </summary>
        /// <param name="parkId">The id of the park to get from the datastore.</param>
        /// <returns>The fully populated Park object.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        Park GetParkById(int parkId);

        /// <summary>
        /// Get a list of parks (unordered) in a state from the datastore given the state abbreviation.
        /// The list is never null. It is empty if there are no parks for the given state abbreviation
        /// in the datastore.
        /// </summary>
        /// <param name="stateAbbreviation">The state abbreviation of the parks to get from the datastore.</param>
        /// <returns>The list of Park objects.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        IList<Park> GetParksByState(string stateAbbreviation);

        /// <summary>
        /// Add a new park to the datastore based upon the given Park object.
        /// The given Park object does not need to be fully populated, only the properties required by
        /// the target datastore.
        /// </summary>
        /// <param name="park">The Park object to add to the datastore.</param>
        /// <returns>A fully populated Park object.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        Park CreatePark(Park park);

        /// <summary>
        /// Update an existing park in the datastore with the property values of the given Park object.
        /// The given Park object needs to be fully populated, not just the properties to be updated.
        /// </summary>
        /// <param name="park">The Park object to add to the datastore.</param>
        /// <returns>A fully populated updated Park object.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems. Also thrown if method updates zero records.
        /// </exception>
        Park UpdatePark(Park park);

        /// <summary>
        /// Remove an existing park from the datastore given a park id.
        /// If the park id is not found, return 0.
        /// </summary>
        /// <param name="parkId">The id of the park to remove from the datastore.</param>
        /// <returns>The number of parks removed from the datastore.</returns>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        int DeleteParkById(int parkId);

        /// <summary>
        /// Create a relationship/association between the park identified by parkId and
        /// the state identified by stateAbbreviation in the datastore.
        /// </summary>
        /// <param name="parkId">The id of the park to relate with the state.</param>
        /// <param name="stateAbbreviation">The state abbreviation of the state to relate with the park.</param>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        void LinkParkState(int parkId, string stateAbbreviation);

        /// <summary>
        /// Remove the relationship/association between the park identified by parkId and
        /// the state identified by stateAbbreviation in the datastore.
        /// </summary>
        /// <param name="parkId">The id of the park to disassociate from the state./param>
        /// <param name="stateAbbreviation">The state abbreviation of the state to disassociate from the park.</param>
        /// <exception cref="DaoException">
        /// Thrown if an error occurs such as failure to connect with the datastore
        /// or other datastore-specific problems.
        /// </exception>
        void UnlinkParkState(int parkId, string stateAbbreviation);
    }
}
