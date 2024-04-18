using HotelReservations.Models;

namespace HotelReservations.DAO
{
    public interface IUserDao
    {
        User GetUserByUsername(string username);
    }
}
