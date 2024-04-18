using Locations.Models;

namespace Locations.DAO
{
    public interface IUserDao
    {
        User GetUserByUsername(string username);
    }
}
