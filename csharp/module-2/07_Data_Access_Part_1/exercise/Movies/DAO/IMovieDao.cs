using Movies.Models;
using System.Collections.Generic;

namespace Movies.DAO
{
    public interface IMovieDao
    {
        /// <summary>
        /// Get a list of all movies from the datastore.
        /// The list is never null. It is empty if there are no movies in the datastore.
        /// </summary>
        /// <returns>all movies as a list of Movie objects</returns>
        /// 
        List<Movie> GetMovies();

        /// <summary>
        /// Get a movie from the datastore that has the given id.
        /// If the id is not found, return null.
        /// </summary>
        /// <param name="id">the movie id to get from the datastore</param>
        /// <returns>a fully populated Movie object</returns>
        /// 
        Movie GetMovieById(int id);

        /// <summary>
        /// Get a list of all the movies from the datastore that match the title. Perform a 
        /// case-insensitive search. Return an empty list when no matching collections are found.
        /// </summary>
        /// <param name="title">the movie title to get from the datastore</param>
        /// <param name="useWildCard">useWildCard wraps title with wild card characters if true</param>
        /// <returns>all matching movies as a list of Movie objects</returns>
        /// 
        List<Movie> GetMoviesByTitle(string title, bool useWildCard);

        /// <summary>
        /// Get a list of all the movies directed by a given director (case-insensitive) and released 
        /// between a range of years (inclusive) from the datastore. The movies are sorted from oldest 
        /// to newest. Return an empty list when no matching collections are found.
        /// </summary>
        /// <param name="directorName">the name of the director</param>
        /// <param name="startYear">the starting release year of the range of years</param>
        /// <param name="endYear">the ending release year of the range of years</param>
        /// <param name="useWildCard">wraps directorName with wild card characters if true</param>
        /// <returns>all matching movies as a list of Movie objects</returns>
        /// 
        List<Movie> GetMoviesByDirectorNameAndBetweenYears(string directorName, int startYear, int endYear,
            bool useWildCard);
    }
}
