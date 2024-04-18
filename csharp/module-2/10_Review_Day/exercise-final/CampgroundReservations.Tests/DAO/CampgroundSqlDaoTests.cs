using CampgroundReservations.DAO;
using CampgroundReservations.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CampgroundReservations.Tests.DAO
{
    [TestClass]
    public class CampgroundSqlDaoTests : BaseDaoTests
    {
        [TestMethod]
        public void GetCampgroundById_Should_ReturnSpecificCampground()
        {
            // Arrange
            CampgroundSqlDao dao = new CampgroundSqlDao(ConnectionString);

            // Act
            Campground campground = dao.GetCampgroundById(1);

            // Assert
            Assert.AreEqual(1, campground.ParkId, "Incorrect campground returned for ID 1");
        }

        [TestMethod]
        public void GetCampgroundsByParkId_Should_ReturnAllCampgroundsForPark()
        {
            // Arrange
            CampgroundSqlDao dao = new CampgroundSqlDao(ConnectionString);

            // Act
            IList<Campground> campgrounds = dao.GetCampgroundsByParkId(1);

            // Assert
            Assert.AreEqual(2, campgrounds.Count, "Incorrect number of campgrounds returned");
        }
    }
}
