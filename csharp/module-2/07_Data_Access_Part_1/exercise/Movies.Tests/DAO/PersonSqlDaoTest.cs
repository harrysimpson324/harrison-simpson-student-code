using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.DAO;
using Movies.Models;
using System;
using System.Collections.Generic;

namespace Movies.Tests.DAO
{
    [TestClass]
    public class PersonSqlDaoTest : BaseDaoTests
    {
        private PersonSqlDao sut;
        private static readonly Person PERSON_1 =
            new Person(1,
                    "George Lucas",
                    new DateTime(1944, 5, 14),
                    null,
                    null,
                    "https://image.tmdb.org/t/p/w185/WCSZzWdtPmdRxH9LUCVi2JPCSJ.jpg",
                    null
            );

        [TestInitialize]
        public void Setup()
        {
            sut = new PersonSqlDao(ConnectionString);
        }

        [TestMethod]
        public void GetPersons_Returns_Correct_Number_Of_Persons()
        {

            List<Person> persons = sut.GetPersons();
            Assert.IsNotNull(persons, "GetPersons returned a null list of persons.");
            Assert.AreEqual(331, persons.Count, "GetPersons returned the wrong number of persons in the list.");
        }

        [TestMethod]
        public void GetPersonById_With_Valid_Id_Returns_Correct_Person()
        {

            Person person = sut.GetPersonById(1);
            Assert.IsNotNull(person, "GetPersonById with valid id returned a null person.");
            AssertPersonsMatch(PERSON_1, person, "GetPersonById with valid id returned the incorrect/incomplete person.");
        }

        [TestMethod]
        public void GetPersonById_With_Invalid_Id_Returns_Null_Person()
        {

            Person person = sut.GetPersonById(0); // IDs begin with 1, cannot be 0
            Assert.IsNull(person, "GetPersonById with invalid id returned a person rather than null.");
        }

        [TestMethod]
        public void GetPersonsByName_With_Full_Name_Exact_Match_Returns_Correct_Number_Of_Persons()
        {

            List<Person> persons = sut.GetPersonsByName("George lucas", false);
            Assert.IsNotNull(persons, "GetPersonsByName with full name exact match returned a null list of persons.");
            Assert.AreEqual(1, persons.Count, "GetPersonsByName with full name exact match returned the wrong number of persons in the list.");
        }

        [TestMethod]
        public void GetPersonsByName_With_Partial_Name_Exact_Match_Returns_Correct_Number_Of_Persons()
        {

            List<Person> persons = sut.GetPersonsByName("rge Luc", false);

            Assert.IsNotNull(persons, "GetPersonsByName with partial name exact match returned a null list of persons.");
            Assert.AreEqual(0, persons.Count, "GetPersonsByName with partial name exact match returned the wrong number of persons in the list.");
        }

        [TestMethod]
        public void GetPersonsByName_With_Empty_Name_Exact_Match_Returns_Correct_Number_Of_Persons()
        {

            List<Person> persons = sut.GetPersonsByName("", false);

            Assert.IsNotNull(persons, "GetPersonsByName with empty name exact match returned a null list of persons.");
            Assert.AreEqual(0, persons.Count, "GetPersonsByName with empty name exact match returned the wrong number of persons in the list.");
        }

        [TestMethod]
        public void GetPersonsByName_With_Partial_Name_Wildcard_Match_Returns_Correct_Number_Of_Persons()
        {

            List<Person> persons = sut.GetPersonsByName("rge Luc", true);
            Assert.IsNotNull(persons, "GetPersonsByName with partial name wildcard match returned a null list of persons.");
            Assert.AreEqual(1, persons.Count, "GetPersonsByName with partial name wildcard match returned the wrong number of persons in the list.");
        }

        [TestMethod]
        public void GetPersonsByName_With_Empty_Name_Wildcard_Match_Returns_Correct_Number_Of_Persons()
        {

            List<Person> persons = sut.GetPersonsByName("", true);
            Assert.IsNotNull(persons, "GetPersonsByName with empty name wildcard match returned a null list of persons.");
            Assert.AreEqual(331, persons.Count, "GetPersonsByName with empty name wildcard match returned the wrong number of persons in the list.");
        }

        [TestMethod]
        public void GetPersonsByCollectionName_With_Full_Collection_Name_Exact_Match_Returns_Correct_Number_Of_Persons()
        {

            List<Person> persons = sut.GetPersonsByCollectionName("Star Wars Collection", false);

            Assert.IsNotNull(persons, "GetPersonsByCollectionName with full collection name exact match returned a null list of persons.");
            Assert.AreEqual(45, persons.Count, "GetPersonsByCollectionName with full collection name exact match returned the wrong number of persons in the list.");
        }

        [TestMethod]
        public void GetPersonsByCollectionName_With_Partial_Collection_Name_Exact_Match_Returns_Correct_Number_Of_Persons()
        {

            List<Person> persons = sut.GetPersonsByCollectionName("tar wars col", false);

            Assert.IsNotNull(persons, "GetPersonsByCollectionName with partial name exact match returned a null list of persons.");
            Assert.AreEqual(0, persons.Count, "GetPersonsByCollectionName with partial name exact match returned the wrong number of persons in the list.");
        }

        [TestMethod]
        public void GetPersonsByCollectionName_With_Partial_Collection_Name_Wildcard_Match_Returns_Correct_Number_Of_Persons()
        {

            List<Person> persons = sut.GetPersonsByCollectionName("F", true);

            Assert.IsNotNull(persons, "GetPersonsByCollectionName with partial name wildcard match returned a null list of persons.");
            Assert.AreEqual(29, persons.Count, "GetPersonsByCollectionName with partial name wildcard match returned the wrong number of persons in the list.");
        }

        private void AssertPersonsMatch(Person expected, Person actual, string message)
        {

            Assert.AreEqual(expected.Id, actual.Id, message);
            Assert.AreEqual(expected.Name, actual.Name, message);
            Assert.AreEqual(expected.Birthday, actual.Birthday, message);
            Assert.AreEqual(expected.DeathDate, actual.DeathDate, message);
            Assert.AreEqual(expected.Biography, actual.Biography, message);
            Assert.AreEqual(expected.ProfilePath, actual.ProfilePath, message);
            Assert.AreEqual(expected.HomePage, actual.HomePage, message);
        }
    }
}
