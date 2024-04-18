using DataSecurity.Cli.DAO;
using DataSecurity.Cli.Security;
using Microsoft.Extensions.Configuration;

namespace DataSecurity.Cli
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("UserManagerConnection");

            IUserDao userDao = new UserSqlDao(connectionString);

            IPasswordHasher passwordHasher = new PasswordHasher();
            UserManagerCli application = new UserManagerCli(userDao, passwordHasher);

            application.Run();
        }
    }
}
