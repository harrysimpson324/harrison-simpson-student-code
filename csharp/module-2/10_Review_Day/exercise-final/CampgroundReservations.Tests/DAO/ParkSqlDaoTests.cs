using CampgroundReservations.DAO;
using CampgroundReservations.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CampgroundReservations.Tests.DAO
{
    [TestClass]
    public class ParkSqlDaoTests : BaseDaoTests
    {
        [TestMethod]
        public void GetParks_Should_ReturnAllParksInLocationAlphabeticalOrder()
        {
            // Arrange
            ParkSqlDao dao = new ParkSqlDao(ConnectionString);

            // Act
            IList<Park> parks = dao.GetParks();

            // Assert
            Assert.AreEqual(2, parks.Count, "Incorrect number of parks returned");
            Assert.AreEqual("Ohio", parks[0].Location, "Incorrect state for park at index 0");
            Assert.AreEqual("Pennsylvania", parks[1].Location, "Incorrect state for park at index 1");
        }
    }
}
