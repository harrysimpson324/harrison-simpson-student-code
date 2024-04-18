using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.DAO;
using Movies.Models;
using System;
using System.Collections.Generic;

namespace Movies.Tests.DAO
{
    [TestClass]
    public class MovieSqlDaoTest : BaseDaoTests
    {
        private MovieSqlDao sut;
        private readonly Movie MOVIE_311 =
            new Movie(311,
                    "Once Upon a Time in America",
                    "A former Prohibition-era Jewish gangster returns to the Lower East Side of Manhattan over thirty years later, where he once again must confront the ghosts and regrets of his old life.",
                    "Crime, passion and lust for power.",
                    "https://image.tmdb.org/t/p/w500/i0enkzsL5dPeneWnjl1fCWm6L7k.jpg",
                    null,
                    new DateTime(1984, 5, 23),
                    229,
                    4385,
                    null
                );

        [TestInitialize]
        public void Setup()
        {
            sut = new MovieSqlDao(ConnectionString);
        }

        [TestMethod]
        public void GetMovies_Returns_Correct_Number_Of_Movies()
        {
            List<Movie> movies = sut.GetMovies();
            Assert.IsNotNull(movies, "GetMovies returned a null list of movies.");
            Assert.AreEqual(44, movies.Count, "GetMovies returned the wrong number of movies in the list.");
        }

        [TestMethod]
        public void GetMovieById_With_Valid_Id_Returns_Correct_Movie()
        {
            Movie movie = sut.GetMovieById(311);
            Assert.IsNotNull(movie, "GetMovieById with valid id returned a null movie.");
            AssertMoviesMatch(MOVIE_311, movie, "GetMovieById with valid id returned the incorrect/incomplete movie.");
        }

        [TestMethod]
        public void GetMovieById_With_Invalid_Id_Returns_Null_Movie()
        {
            Movie movie = sut.GetMovieById(0); // IDs begin with 1, cannot be 0
            Assert.IsNull(movie, "GetMovieById with invalid id returned a movie rather than null.");
        }

        [TestMethod]
        public void GetMoviesByTitle_With_Full_Title_Exact_Match_Returns_Correct_Number_Of_Movies()
        {
            List<Movie> movies = sut.GetMoviesByTitle("Once upon a time in America", false);

            Assert.IsNotNull(movies, "GetMoviesByTitle with full title exact match returned a null list of movies.");
            Assert.AreEqual(1, movies.Count, "GetMoviesByTitle with full title exact match returned the wrong number of movies in the list.");
        }

        [TestMethod]
        public void GetMoviesByTitle_With_Partial_Title_Exact_Match_Returns_Correct_Number_Of_Movies()
        {
            List<Movie> movies = sut.GetMoviesByTitle("upon a time", false);

            Assert.IsNotNull(movies, "GetMoviesByTitle with partial title exact match returned a null list of movies.");
            Assert.AreEqual(0, movies.Count, "GetMoviesByTitle with partial title exact match returned the wrong number of movies in the list.");
        }

        [TestMethod]
        public void GetMoviesByTitle_With_Empty_Title_Exact_Match_Returns_Correct_Number_Of_Movies()
        {
            List<Movie> movies = sut.GetMoviesByTitle("", false);

            Assert.IsNotNull(movies, "GetMoviesByTitle with empty title exact match returned a null list of movies.");
            Assert.AreEqual(0, movies.Count, "GetMoviesByTitle with empty title exact match returned the wrong number of movies in the list.");
        }

        [TestMethod]
        public void GetMoviesByTitle_With_Partial_Title_Wildcard_Match_Returns_Correct_Number_Of_Movies()
        {
            List<Movie> movies = sut.GetMoviesByTitle("upon a time", true);

            Assert.IsNotNull(movies, "GetMoviesByTitle unexpectedly returned null");
            Assert.AreNotEqual(0, movies.Count, "GetMoviesByTitle with partial title wildcard match returned a null list of movies.");
            Assert.AreEqual(1, movies.Count, "GetMoviesByTitle with partial title wildcard match returned the wrong number of movies in the list.");
        }

        [TestMethod]
        public void GetMoviesByTitle_With_Empty_Title_Wildcard_Match_Returns_Correct_Number_Of_Movies()
        {
            List<Movie> movies = sut.GetMoviesByTitle("", true);

            Assert.IsNotNull(movies, "GetMoviesByTitle with empty title wildcard match returned a null list of movies.");
            Assert.AreEqual(44, movies.Count, "GetMoviesByTitle with empty title wildcard match returned the wrong number of movies in the list.");
        }

        [TestMethod]
        public void GetMoviesByDirectorNameAndBetweenYears_With_Valid_Arguments_Returns_Correct_Number_Of_Movies()
        { 
            List<Movie> movies = sut.GetMoviesByDirectorNameAndBetweenYears("Alfred Hitchcock", 1950, 1959, false);

            Assert.IsNotNull(movies, "GetMoviesByDirectorNameAndBetweenYears with valid arguments returned a null list of movies.");
            Assert.AreEqual(7, movies.Count, "GetMoviesByDirectorNameAndBetweenYears with valid arguments returned the wrong number of movies in the list.");
        }

        [TestMethod]
        public void GetMoviesByDirectorNameAndBetweenYears_With_Valid_Arguments_And_Wildcard_Returns_Correct_Number_Of_Movies()
        {
            List<Movie> movies = sut.GetMoviesByDirectorNameAndBetweenYears("Chris", 1980, 2020, true);

            Assert.IsNotNull(movies, "GetMoviesByDirectorNameAndBetweenYears with valid arguments and wildcard returned a null list of movies.");
            Assert.AreEqual(2, movies.Count, "GetMoviesByDirectorNameAndBetweenYears with valid arguments and wildcard returned the wrong number of movies in the list.");
        }

        private void AssertMoviesMatch(Movie expected, Movie actual, string message)
        {
            Assert.AreEqual(expected.Id, actual.Id, message);
            Assert.AreEqual(expected.Title, actual.Title, message);
            Assert.AreEqual(expected.Tagline, actual.Tagline, message);
            Assert.AreEqual(expected.PosterPath, actual.PosterPath, message);
            Assert.AreEqual(expected.HomePage, actual.HomePage, message);
            Assert.AreEqual(expected.ReleaseDate, actual.ReleaseDate, message);
            Assert.AreEqual(expected.LengthMinutes, actual.LengthMinutes, message);
            Assert.AreEqual(expected.DirectorId, actual.DirectorId, message);
            Assert.AreEqual(expected.CollectionId, actual.CollectionId, message);
        }
    }
}
