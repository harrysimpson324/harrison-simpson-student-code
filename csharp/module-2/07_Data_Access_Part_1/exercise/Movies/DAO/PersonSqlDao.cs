using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Movies.DAO
{
    public class PersonSqlDao : IPersonDao
    {
        private readonly string connectionString;

        public PersonSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Person GetPersonById(int id)
        {
            return new Person();
        }

        public List<Person> GetPersons()
        {
            return null;
        }

        public List<Person> GetPersonsByCollectionName(string collectionName, bool useWildCard)
        {
            return null;
        }

        public List<Person> GetPersonsByName(string name, bool useWildCard)
        {
            return null;
        }
    }
}
