using Movies.Models;
using System.Collections.Generic;

namespace Movies.DAO
{
    public interface IGenreDao
    {

        /// <summary>
        /// Get a genre from the datastore that has the given id.
        /// If the id is not found, return null.
        /// </summary>
        /// <param name="id">the genre id to get from the datastore</param>
        ///<returns>a fully populated Genre object</returns> 
        ///
        Genre GetGenreById(int id);

        /// <summary>
        ///Get a list of all genres from the datastore.
        ///The list is never null. It is empty if there are no genres in the datastore.
        /// </summary>
        /// <returns>all genres as a list of Genre objects</returns>
        List<Genre> GetGenres();

        /// <summary>
        /// Get a list of all the genres from the datastore that match the name. Perform a 
        /// case-insensitive search. Return an empty list when no matching collections are found.
        /// </summary>
        /// <param name="name">the genre name to get from the datastore</param>
        /// <param name="useWildCard">wraps name with wild card characters if true</param>
        /// <returns>all matching genres as a list of Genre objects</returns>
        List<Genre> GetGenresByName(string name, bool useWildCard);
    }
}
