using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using USCitiesAndParks.DAO;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.Tests
{
    [TestClass]
    public class CitySqlDaoTests : BaseDaoTests
    {
        private static readonly City CITY_1 = new City(1, "City 1", "AA", 11, 111);
        private static readonly City CITY_2 = new City(2, "City 2", "BB", 22, 222);
        private static readonly City CITY_4 = new City(4, "City 4", "AA", 44, 444);

        private City testCity;

        private CitySqlDao dao;

        [TestInitialize]
        public override void Setup()
        {
            dao = new CitySqlDao(ConnectionString);
            testCity = new City(0, "Test City", "CC", 99, 999);
            base.Setup();
        }

        [TestMethod]
        public void GetCityById_With_Valid_Id_Returns_Correct_City()
        {
            City city = dao.GetCityById(1);
            AssertCitiesMatch(CITY_1, city);

            city = dao.GetCityById(2);
            AssertCitiesMatch(CITY_2, city);
        }

        [TestMethod]
        public void GetCityById_With_Invalid_Id_Returns_Null_City()
        {
            City city = dao.GetCityById(99);
            Assert.IsNull(city);
        }

        [TestMethod]
        public void GetCitiesByState_With_Valid_State_Returns_Correct_Cities()
        {
            IList<City> cities = dao.GetCitiesByState("AA");
            Assert.AreEqual(2, cities.Count);
            AssertCitiesMatch(CITY_1, cities[0]);
            AssertCitiesMatch(CITY_4, cities[1]);

            cities = dao.GetCitiesByState("BB");
            Assert.AreEqual(1, cities.Count);
            AssertCitiesMatch(CITY_2, cities[0]);
        }

        [TestMethod]
        public void GetCitiesByState_With_Invalid_State_Returns_Empty_List()
        {
            IList<City> cities = dao.GetCitiesByState("XX");
            Assert.AreEqual(0, cities.Count);
        }

        [TestMethod]
        public void CreateCity_Creates_City()
        {
            City createdCity = dao.CreateCity(testCity);
            Assert.IsNotNull(createdCity);

            int newId = createdCity.CityId;
            Assert.IsTrue(newId > 0);

            City retrievedCity = dao.GetCityById(newId);
            AssertCitiesMatch(createdCity, retrievedCity);
        }

        [TestMethod]
        public void UpdateCity_Updates_City()
        {
            City cityToUpdate = dao.GetCityById(1);

            cityToUpdate.CityName = "Updated";
            cityToUpdate.StateAbbreviation = "CC";
            cityToUpdate.Population = 99;
            cityToUpdate.Area = 999;

            City updatedCity = dao.UpdateCity(cityToUpdate);
            Assert.IsNotNull(updatedCity);

            City retrievedCity = dao.GetCityById(1);
            AssertCitiesMatch(updatedCity, retrievedCity);
        }

        [TestMethod]
        public void DeleteCityById_Deletes_City()
        {
            int rowsAffected = dao.DeleteCityById(4);
            Assert.AreEqual(1, rowsAffected);

            City retrievedCity = dao.GetCityById(4);
            Assert.IsNull(retrievedCity);
        }

        private void AssertCitiesMatch(City expected, City actual)
        {
            Assert.AreEqual(expected.CityId, actual.CityId);
            Assert.AreEqual(expected.CityName, actual.CityName);
            Assert.AreEqual(expected.StateAbbreviation, actual.StateAbbreviation);
            Assert.AreEqual(expected.Population, actual.Population);
            Assert.AreEqual(expected.Area, actual.Area);
        }
    }
}
