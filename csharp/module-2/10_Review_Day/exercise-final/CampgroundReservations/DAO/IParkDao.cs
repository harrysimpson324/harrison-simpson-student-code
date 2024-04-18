using CampgroundReservations.Models;
using System.Collections.Generic;

namespace CampgroundReservations.DAO
{
    interface IParkDao
    {
        /// <summary>
        /// Get all parks from the datastore, ordered alphabetically (A-Z) by location.
        /// If there are no parks, return an empty List.
        /// </summary>
        /// <returns>A list of Park objects.</returns>
        IList<Park> GetParks();
    }
}
