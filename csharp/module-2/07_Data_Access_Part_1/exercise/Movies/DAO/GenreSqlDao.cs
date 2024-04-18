using Movies.Models;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Movies.DAO
{
    public class GenreSqlDao : IGenreDao
    {
        private readonly string connectionString;

        public GenreSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Genre GetGenreById(int id)
        {
            return new Genre();
        }

        public List<Genre> GetGenres()
        {
            return null;
        }

        public List<Genre> GetGenresByName(string name, bool useWildCard)
        {
            return null;
        }
    }
}
