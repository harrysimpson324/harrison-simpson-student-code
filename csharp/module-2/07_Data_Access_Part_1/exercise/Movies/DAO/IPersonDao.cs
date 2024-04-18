using Movies.Models;
using System.Collections.Generic;

namespace Movies.DAO
{
    public interface IPersonDao
    {
        /// <summary>
        /// Get a list of all persons from the datastore.
        /// The list is never null. It is empty if there are no persons in the datastore.
        /// </summary>
        /// <returns>all persons as a list of Person objects</returns>
        /// 
        List<Person> GetPersons();

        /// <summary>
        /// Get a person from the datastore that has the given id.
        /// If the id is not found, return null.
        /// </summary>
        /// <param name="id">the person id to get from the datastore</param>
        /// <returns>a fully populated Person object</returns>
        /// 
        Person GetPersonById(int id);

        /// <summary>
        /// Get a list of all the persons from the datastore that match the name. Perform a 
        /// case-insensitive search. Return an empty list when no matching collections are found.
        /// </summary>
        /// <param name="name">the person name to get from the datastore</param>
        /// <param name="useWildCard">wraps name with wild card characters if true</param>
        /// <returns>all matching persons as a list of Person objects</returns>
        /// 
        List<Person> GetPersonsByName(string name, bool useWildCard);

        /// <summary>
        /// Get all the actors in the movies that make up a given collection. Perform a 
        /// case-insensitive search. The list is ordered by the actors' names. Return an 
        /// empty list when no matching collections are found.
        /// 
        /// The actors must appear only once in the list Hint: Use DISTINCT
        /// </summary>
        /// <param name="collectionName">the name of the given collection</param>
        /// <param name="useWildCard">wraps collectionName with wild card characters if true</param>
        /// <returns>all matching persons (actors) as a list of Person objects</returns>
        /// 
        List<Person> GetPersonsByCollectionName(string collectionName, bool useWildCard);
    }
}
