using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Movies.DAO
{
    public class MovieSqlDao : IMovieDao
    {
        private readonly string connectionString;

        public MovieSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Movie GetMovieById(int id)
        {
            return new Movie();
        }

        public List<Movie> GetMovies()
        {
            return null;
        }

        public List<Movie> GetMoviesByDirectorNameAndBetweenYears(string directorName, int startYear, int endYear, bool useWildCard)
        {
            return null;
        }

        public List<Movie> GetMoviesByTitle(string title, bool useWildCard)
        {
            return null;
        }
    }
}
