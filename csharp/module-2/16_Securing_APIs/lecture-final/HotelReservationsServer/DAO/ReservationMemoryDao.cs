using HotelReservations.Exceptions;
using HotelReservations.Models;
using System;
using System.Collections.Generic;

namespace HotelReservations.DAO
{
    public class ReservationMemoryDao : IReservationDao
    {
        // Each request of the controller may create a new instance of the DAO.
        // This static is to preserve the data on each request until we get to dependency injection
        private static List<Reservation> Reservations { get; set; }

        public ReservationMemoryDao()
        {
            if (Reservations == null)
            {
                Reservations = new List<Reservation>
                {
                    new Reservation(1, 1, "John Smith", DateTime.Today, 3, 2),
                    new Reservation(2, 1, "Sam Turner", DateTime.Today, 5, 4),
                    new Reservation(3, 1, "Mark Johnson", DateTime.Today.AddDays(7), 3, 2),
                    new Reservation(4, 2, "Joseph Williams", DateTime.Today.AddDays(2), 2, 2)
                };
            }
        }

        public List<Reservation> GetReservations()
        {
            return Reservations;
        }

        public Reservation GetReservationById(int id)
        {
            foreach (Reservation reservation in Reservations)
            {
                if (reservation.Id == id)
                {
                    return reservation;
                }
            }

            return null;
        }

        public List<Reservation> GetReservationsByHotel(int hotelId)
        {
            List<Reservation> matched = new List<Reservation>();
            foreach (Reservation r in Reservations)
            {
                if (r.HotelId == hotelId)
                {
                    matched.Add(r);
                }
            }
            return matched;
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            // Calculate the highest id
            int maxId = 0;
            foreach (Reservation res in Reservations)
            {
                if (res.Id > maxId)
                {
                    maxId = res.Id;
                }
            }
            // Set the next Id
            reservation.Id = maxId + 1;
            Reservations.Add(reservation);
            return reservation;
        }

        public Reservation UpdateReservation(Reservation updated)
        {
            Reservation old = GetReservationById(updated.Id);
            if (old != null)
            {
                updated.Id = old.Id;
                Reservations.Remove(old);
                Reservations.Add(updated);
                return updated;
            }

            throw new DaoException("Reservation to update not found");
        }

        public int DeleteReservationById(int id)
        {
            Reservation old = GetReservationById(id);
            if (old != null)
            {
                Reservations.Remove(old);
                return 1;
            }
            return 0;
        }
    }
}
