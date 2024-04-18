using Microsoft.Extensions.Configuration;
using Movies.DAO;
using System.IO;

namespace Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("MoviesDb");

            ICollectionDao collectionDao = new CollectionSqlDao(connectionString);
            IGenreDao genreDao = new GenreSqlDao(connectionString);
            IMovieDao movieDao = new MovieSqlDao(connectionString);
            IPersonDao personDao = new PersonSqlDao(connectionString);

            MoviesCLI application = new MoviesCLI(collectionDao, genreDao, movieDao, personDao);
            application.Run();
        }
    }
}
