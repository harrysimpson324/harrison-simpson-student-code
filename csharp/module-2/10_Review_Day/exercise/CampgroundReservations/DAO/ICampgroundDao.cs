using CampgroundReservations.Models;
using System.Collections.Generic;

namespace CampgroundReservations.DAO
{
    interface ICampgroundDao
    {
        /// <summary>
        /// Get a specific campground with the given id.
        /// If the id is not found, return null.
        /// </summary>
        /// <param name="id">The id of the campground to retrieve.</param>
        /// <returns>A Campground object.</returns>
        Campground GetCampgroundById(int id);

        /// <summary>
        /// Get all the campsites from a park with the given id. 
        /// If the id is not found, return an empty List.
        /// </summary>
        /// <param name="parkId">The id of the park to retrieve campgrounds from.</param>
        /// <returns>A list of Campground objects.</returns>
        IList<Campground> GetCampgroundsByParkId(int parkId);
    }
}
