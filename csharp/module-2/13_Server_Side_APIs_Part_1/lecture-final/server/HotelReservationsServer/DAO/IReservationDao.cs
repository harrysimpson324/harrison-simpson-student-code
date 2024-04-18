using HotelReservations.Models;
using System.Collections.Generic;

namespace HotelReservations.DAO
{
    public interface IReservationDao
    {
        Reservation CreateReservation(Reservation reservation);

        List<Reservation> GetReservationsByHotel(int hotelId);

        Reservation GetReservationById(int id);

        List<Reservation> GetReservations();
    }
}
