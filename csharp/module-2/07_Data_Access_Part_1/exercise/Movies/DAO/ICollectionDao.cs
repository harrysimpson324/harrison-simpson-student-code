using Movies.Models;
using System.Collections.Generic;

namespace Movies.DAO
{
    public interface ICollectionDao
    {
        /// <summary>
        /// Get a list of all collections from the datastore
        /// The list is never null. It is empty if there are no collections in the datastore
        /// </summary>
        /// <returns>all collections as a list of Collection objects</returns>
        /// 
        List<Collection> GetCollections();

        /// <summary>
        /// Get a collection from the datastore that has the given id.
        /// If the id is not found, return null.
        /// </summary>
        /// <param name="id">the collection id to get from the datastore</param>
        /// <returns>a fully populated Collection object</returns>
        /// 
        Collection GetCollectionById(int id);

        /// <summary>
        /// Get a list of all the collections from the datastore that match the name. Perform a 
        /// case-insensitive search. Return an empty list when no matching collections are found.
        /// </summary>
        /// <param name="name">name the collection name to get from the datastore</param>
        /// <param name="useWildCard">useWildCard wraps name with wild card characters if true</param>
        /// <returns>all matching collections as a list of Collection objects</returns>
        /// 
        List<Collection> GetCollectionsByName(string name, bool useWildCard);
    }
}
