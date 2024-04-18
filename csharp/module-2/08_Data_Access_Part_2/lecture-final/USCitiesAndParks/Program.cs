using USCitiesAndParks.DAO;

namespace USCitiesAndParks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //IConfigurationBuilder builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //IConfigurationRoot configuration = builder.Build();
            //string connectionString = configuration.GetConnectionString("UnitedStates");

            string connectionString = @"Server=.\SQLEXPRESS;Database=UnitedStates;Trusted_Connection=True;";

            ICityDao cityDao = new CitySqlDao(connectionString);
            IStateDao stateDao = new StateSqlDao(connectionString);
            IParkDao parkDao = new ParkSqlDao(connectionString);

            USCitiesAndParksCLI cli = new USCitiesAndParksCLI(cityDao, stateDao, parkDao);
            cli.RunCLI();
        }
    }
}
