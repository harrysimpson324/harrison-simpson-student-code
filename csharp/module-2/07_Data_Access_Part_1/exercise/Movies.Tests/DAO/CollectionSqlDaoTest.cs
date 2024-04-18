using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.DAO;
using Movies.Models;
using System.Collections.Generic;

namespace Movies.Tests.DAO
{
    [TestClass]
    public class CollectionSqlDaoTest : BaseDaoTests
    {
        private readonly Collection COLLECTION_86311 = new Collection(86311, "The Avengers Collection");

        private CollectionSqlDao sut;

        [TestInitialize]
        public void Setup()
        {
            sut = new CollectionSqlDao(ConnectionString);
        }

        [TestMethod]
        public void GetCollections_Returns_Correct_Number_Of_Collections()
        {

            List<Collection> collections = sut.GetCollections();
            Assert.IsNotNull(collections, "GetCollections returned a null list of collections.");
            Assert.AreEqual(6, collections.Count, "GetCollections returned the wrong number of collections in the list.");
        }

        [TestMethod]
        public void GetCollectionById_With_Valid_Id_Returns_Correct_Collection()
        {

            Collection collection = sut.GetCollectionById(86311);
            Assert.IsNotNull(collection, "GetCollectionById with valid id returned a null collection.");
            AssertCollectionsMatch(COLLECTION_86311, collection, "GetCollectionById with valid id returned the incorrect/incomplete collection.");
        }

        [TestMethod]
        public void GetCollectionById_With_Invalid_Id_Returns_Null_Collection()
        {

            Collection collection = sut.GetCollectionById(0); // IDs begin with 1, cannot be 0
            Assert.IsNull(collection, "GetCollectionById with invalid id returned a collection rather than null.");
        }

        [TestMethod]
        public void GetCollectionsByName_With_Full_Name_Exact_Match_Returns_Correct_Number_Of_Collections()
        {

            List<Collection> collections = sut.GetCollectionsByName("the avengers collection", false);
            Assert.IsNotNull(collections, "GetCollectionsByName with full name exact match returned a null list of collections.");
            Assert.AreEqual(1, collections.Count, "GetCollectionsByName with full name exact match returned the wrong number of collections in the list.");
        }

        [TestMethod]
        public void GetCollectionsByName_With_Partial_Name_Exact_Match_Returns_Correct_Number_Of_Collections()
        {

            List<Collection> collections = sut.GetCollectionsByName("e avengers c", false);
            Assert.IsNotNull(collections, "GetCollectionsByName with partial name exact match returned a null list of collections.");
            Assert.AreEqual(0, collections.Count, "GetCollectionsByName with partial name exact match returned the wrong number of collections in the list.");
        }

        [TestMethod]
        public void GetCollectionsByName_With_Empty_Name_Exact_Match_Returns_Correct_Number_Of_Collections()
        {

            List<Collection> collections = sut.GetCollectionsByName("", false);
            Assert.IsNotNull(collections, "GetCollectionsByName with empty name exact match returned a null list of collections.");
            Assert.AreEqual(0, collections.Count, "GetCollectionsByName with empty name exact match returned the wrong number of collections in the list.");
        }

        [TestMethod]
        public void GetCollectionsByName_With_Partial_Name_Wildcard_Match_Returns_Correct_Number_Of_Collections()
        {

            List<Collection> collections = sut.GetCollectionsByName("e avengers c", true);
            Assert.IsNotNull(collections, "GetCollectionsByName with partial name wildcard match returned a null list of collections.");
            Assert.AreEqual(1, collections.Count, "GetCollectionsByName with partial name wildcard match returned the wrong number of collections in the list.");
        }

        [TestMethod]
        public void GetCollectionsByName_With_Empty_Name_Wildcard_Match_Returns_Correct_Number_Of_Collections()
        {

            List<Collection> collections = sut.GetCollectionsByName("", true);
            Assert.IsNotNull(collections, "GetCollectionsByName with empty name wildcard match returned a null list of collections.");
            Assert.AreEqual(6, collections.Count, "GetCollectionsByName with empty name wildcard match returned the wrong number of collections in the list.");
        }

        private void AssertCollectionsMatch(Collection expected, Collection actual, string message)
        {

            Assert.AreEqual(expected.Id, actual.Id, message);
            Assert.AreEqual(expected.Name, actual.Name, message);
        }
    }
}
