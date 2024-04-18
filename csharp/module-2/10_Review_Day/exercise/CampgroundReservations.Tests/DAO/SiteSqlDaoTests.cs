using CampgroundReservations.DAO;
using CampgroundReservations.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CampgroundReservations.Tests.DAO
{
    [TestClass]
    public class SiteSqlDaoTests : BaseDaoTests
    {
        [TestMethod]
        public void GetSitesWithRVAccessByParkId_Should_ReturnSitesWithPositiveRVLength()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetSitesAvailableTodayByParkId_Should_ReturnAvailableParks()
        {
            // Arrange
            SiteSqlDao dao = new SiteSqlDao(ConnectionString);

            // Act
            IList<Site> sites = dao.GetSitesAvailableTodayByParkId(1);

            // Assert
            Assert.AreEqual(7, sites.Count, "Incorrect count of currently available sites");
        }
    }
}
