using CampgroundReservations.Models;
using System;
using System.Collections.Generic;

namespace CampgroundReservations.DAO
{
    interface IReservationDao
    {
        /// <summary>
        /// Get a reservation from the datastore that has the given id.
        /// If the id is not found, return null.
        /// </summary>
        /// <param name="id">The id of the reservation to get from the datastore.</param>
        /// <returns>The reservation object.</returns>
        Reservation GetReservationById(int id);

        /// <summary>
        /// Inserts a reservation into the datastore.
        /// </summary>
        /// <param name="reservation">The reservation object to insert.</param>
        /// <returns>The reservation object with its new id filled in.</returns>
        Reservation CreateReservation(Reservation reservation);
    }
}
