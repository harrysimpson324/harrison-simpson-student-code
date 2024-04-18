using TodosServer.Models;

namespace TodosServer.DAO
{
    public interface IUserDao
    {
        User GetUserByUsername(string username);
    }
}
