using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Movies.DAO
{
    public class CollectionSqlDao : ICollectionDao
    {
        private readonly string connectionString;

        public CollectionSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Collection GetCollectionById(int id)
        {
            return new Collection();
        }

        public List<Collection> GetCollections()
        {
            return null;
        }

        public List<Collection> GetCollectionsByName(string name, bool useWildCard)
        {
            return null;
        }
    }
}
