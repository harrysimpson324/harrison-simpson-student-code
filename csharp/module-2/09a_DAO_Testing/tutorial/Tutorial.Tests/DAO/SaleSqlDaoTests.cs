using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tutorial.DAO;
using Tutorial.Models;
using System.Collections.Generic;

namespace Tutorial.Tests.DAO
{
    [TestClass]
    public class SaleSqlDaoTests : BaseDaoTests
    {
        // Step One: Add constants for Madge


        // Step Two: Add constants for customer without sale and non-existent customer
        


        private SaleSqlDao saleSqlDao;

        [TestInitialize]
        public override void Setup()
        {
            // Arrange - new instance of SaleSqlDao before each and every test
            saleSqlDao = new SaleSqlDao(ConnectionString);
            base.Setup();
        }

        [TestMethod]
        public void GetSaleById_Returns_Correct_Sale()
        {
            // Step One: Replace Assert.Fail("Test not implemented.")
            Assert.Fail("Test not implemented.");

        }

        [TestMethod]
        public void GetSalesByCustomerId_With_Valid_Id_Returns_Correct_Sales()
        {
            // Step Two: Replace Assert.Fail("Test not implemented.")
            Assert.Fail("Test not implemented.");

        }

        [TestMethod]
        public void CreateSale_Creates_Sale()
        {
            // Step Three: Replace Assert.Fail("Test not implemented.")
            Assert.Fail("Test not implemented.");

        }

        [TestMethod]
        public void UpdateSale_Updates_Sale()
        {
            // Step Four: Replace Assert.Fail("Test not implemented.")
            Assert.Fail("Test not implemented.");

        }

        [TestMethod]
        public void DeleteSaleById_Deletes_Sale()
        {
            // Step Five: Replace Assert.Fail("Test not implemented.")
            Assert.Fail("Test not implemented.");

        }

        // Convenience method in lieu of a Sale constructor with all the fields as parameters.
        // Similar to MapRowToSale() in SaleSqlDao.
        private static Sale MapValuesToSale(int saleId, decimal total, bool delivery, int? customerId)
        {
            Sale sale = new Sale();
            sale.SaleId = saleId;
            sale.Total = total;
            sale.IsDelivery = delivery;
            sale.CustomerId = customerId;
            return sale;
        }

        private void AssertSalesMatch(Sale expected, Sale actual, string message)
        {
            Assert.AreEqual(expected.SaleId, actual.SaleId, message);
            Assert.AreEqual(expected.Total, actual.Total, message);
            Assert.AreEqual(expected.IsDelivery, actual.IsDelivery, message);
            Assert.AreEqual(expected.CustomerId, actual.CustomerId, message);
        }
    }
}
