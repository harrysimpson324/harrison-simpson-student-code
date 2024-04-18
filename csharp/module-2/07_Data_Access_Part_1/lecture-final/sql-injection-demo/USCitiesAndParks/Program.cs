using System.IO;
using Microsoft.Extensions.Configuration;
using USCitiesAndParks.DAO;

namespace USCitiesAndParks
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("SqlInjectionDemo");

            IStateDao stateDao = new StateSqlDao(connectionString);
            IParkDao parkDao = new ParkSqlDao(connectionString);

            SQLInjectionDemoCLI cli = new SQLInjectionDemoCLI(stateDao, parkDao);
            cli.RunCLI();
        }
    }
}
