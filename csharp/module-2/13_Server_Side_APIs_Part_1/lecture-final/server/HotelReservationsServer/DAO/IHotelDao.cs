using System.Collections.Generic;
using HotelReservations.Models;

namespace HotelReservations.DAO
{
    public interface IHotelDao
    {
        List<Hotel> GetHotels();

        List<Hotel> GetHotelsByStateAndCity(string state, string city);

        Hotel GetHotelById(int id);
    }
}
