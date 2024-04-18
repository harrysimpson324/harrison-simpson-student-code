using CampgroundReservations.Models;
using System.Collections.Generic;

namespace CampgroundReservations.DAO
{
    interface ISiteDao
    {
        /// <summary>
        /// Get all sites that allow RVs in a park with the given id.
	    /// A site allows RVs if its max RV length is greater than 0.
	    /// If no sites are found, return an empty List.
        /// </summary>
        /// <param name="parkId">The id of the park to retrieve sites from.</param>
        /// <returns>A list of Site objects.</returns>
        IList<Site> GetSitesWithRVAccessByParkId(int parkId);

        /// <summary>
        /// Get all sites that don't have a reservation today in the park
        /// with the given id.
        /// </summary>
        /// <param name="parkId">The id of the park to retrieve sites from.</param>
        /// <returns>A list of Site objects.</returns>
        IList<Site> GetSitesAvailableTodayByParkId(int parkId);
    }
}
