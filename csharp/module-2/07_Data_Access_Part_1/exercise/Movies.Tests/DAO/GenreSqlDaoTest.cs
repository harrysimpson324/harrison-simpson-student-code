using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.DAO;
using Movies.Models;
using System.Collections.Generic;

namespace Movies.Tests.DAO
{
    [TestClass]
    public class GenreSqlDaoTest : BaseDaoTests
    {
        private static readonly Genre GENRE_878 = new Genre(878, "Science Fiction");
        private GenreSqlDao sut;

        [TestInitialize]
        public void Setup()
        {
            sut = new GenreSqlDao(ConnectionString);
        }

        [TestMethod]
        public void GetGenres_Returns_Correct_Number_Of_Genres()
        {

            List<Genre> genres = sut.GetGenres();
            Assert.IsNotNull(genres, "GetGenres returned a null list of genres.");
            Assert.AreEqual(19, genres.Count, "GetGenres returned the wrong number of genres in the list.");
        }

        [TestMethod]
        public void GetGenreById_With_Valid_Id_Returns_Correct_Genre()
        {

            Genre genre = sut.GetGenreById(878);
            Assert.IsNotNull(genre, "GetGenreById with valid id returned a null genre.");
            AssertGenresMatch(GENRE_878, genre, "GetGenreById with valid id returned the incorrect/incomplete genre.");
        }

        [TestMethod]
        public void GetGenreById_With_Invalid_Id_Returns_Null_Genre()
        {

            Genre genre = sut.GetGenreById(0); // IDs begin with 1, cannot be 0
            Assert.IsNull(genre, "GetGenreById with invalid id returned a genre rather than null.");
        }

        [TestMethod]
        public void GetGenresByName_With_Full_Name_Exact_Match_Returns_Correct_Number_Of_Genres()
        {

            List<Genre> genres = sut.GetGenresByName("Science fiction", false);
            Assert.IsNotNull(genres, "GetGenresByName with full name exact match returned a null list of genres.");
            Assert.AreEqual(1, genres.Count, "GetGenresByName with full name exact match returned the wrong number of genres in the list.");
        }

        [TestMethod]
        public void GetGenresByName_With_Partial_Name_Exact_Match_Returns_Correct_Number_Of_Genres()
        {

            List<Genre> genres = sut.GetGenresByName("ience fict", false);
            Assert.IsNotNull(genres, "GetGenresByName with partial name exact match returned a null list of genres.");
            Assert.AreEqual(0, genres.Count, "GetGenresByName with partial name exact match returned the wrong number of genres in the list.");
        }

        [TestMethod]
        public void GetGenresByName_With_Empty_Name_Exact_Match_Returns_Correct_Number_Of_Genres()
        {

            List<Genre> genres = sut.GetGenresByName("", false);
            Assert.IsNotNull(genres, "GetGenresByName with empty name exact match returned a null list of genres.");
            Assert.AreEqual(0, genres.Count, "GetGenresByName with empty name exact match returned the wrong number of genres in the list.");
        }

        [TestMethod]
        public void GetGenresByName_With_Partial_Name_Wildcard_Match_Returns_Correct_Number_Of_Genres()
        {
            List<Genre> genres = sut.GetGenresByName("ience fict", true);
            Assert.IsNotNull(genres, "GetGenresByName with partial name wildcard match returned a null list of genres.");
            Assert.AreEqual(1, genres.Count, "GetGenresByName with partial name wildcard match returned the wrong number of genres in the list.");
        }

        [TestMethod]
        public void GetGenresByName_With_Empty_Name_Wildcard_Match_Returns_Correct_Number_Of_Genres()
        {

            List<Genre> genres = sut.GetGenresByName("", true);
            Assert.IsNotNull(genres, "GetGenresByName with empty name wildcard match returned a null list of genres.");
            Assert.AreEqual(19, genres.Count, "GetGenresByName with empty name wildcard match returned the wrong number of genres in the list.");
        }

        private void AssertGenresMatch(Genre expected, Genre actual, string message)
        {

            Assert.AreEqual(expected.Id, actual.Id, message);
            Assert.AreEqual(expected.Name, actual.Name, message);
        }
    }
}
