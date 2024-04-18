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
        private const int MadgeCustomerId = 3;
        private const int MadgeFirstSaleId = 5;

        // Step Two: Add constants for customer without sale and non-existent customer
        private const int CustomerWithoutSalesId = 5;
        private const int NonExistentCustomerId = 7;

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
            // Assert.Fail("Test not implemented.");

            // Arrange - create an instance of Madge's first Sale object
            Sale madgeFirstSale = MapValuesToSale(MadgeFirstSaleId, 23.98M, true, MadgeCustomerId);

            // Act - retrieve Madge's first sale
            Sale sale = saleSqlDao.GetSaleById(MadgeFirstSaleId);

            // Assert - retrieved sale is not null and matches expected sale
            Assert.IsNotNull(sale, "GetSaleById(" + MadgeFirstSaleId + ") returned null");
            AssertSalesMatch(madgeFirstSale, sale, "GetSaleById(" + MadgeFirstSaleId + ") returned wrong or partial data");
        }

        [TestMethod]
        public void GetSalesByCustomerId_With_Valid_Id_Returns_Correct_Sales()
        {
            // Step Two: Replace Assert.Fail("Test not implemented.")
            // Assert.Fail("Test not implemented.");

            // Act - retrieve sales for Madge
            IList<Sale> sales = saleSqlDao.GetSalesByCustomerId(MadgeCustomerId);
            // Assert - Madge has two existing sales
            Assert.AreEqual(2, sales.Count, "GetSalesByCustomerId(" + MadgeCustomerId + ") returned wrong number of sales");

            // Act - retrieve customer with no sales
            sales = saleSqlDao.GetSalesByCustomerId(CustomerWithoutSalesId);
            // Assert - list of sales is empty for customer with no sales
            Assert.AreEqual(0, sales.Count, "GetSalesByCustomerId(" + CustomerWithoutSalesId + ") without sales returned wrong number of sales");

            // Act - retrieve customer that doesn't exist
            sales = saleSqlDao.GetSalesByCustomerId(NonExistentCustomerId);
            // Assert - list of sales is empty for customer that doesn't exist
            Assert.AreEqual(0, sales.Count, "Customer doesn't exist, GetSalesByCustomerId(" + NonExistentCustomerId + ") returned the wrong number of sales");
        }

        [TestMethod]
        public void CreateSale_Creates_Sale()
        {
            // Step Three: Replace Assert.Fail("Test not implemented.")
            // Assert.Fail("Test not implemented.");

            // Arrange - instantiate a new Sale object for Madge
            Sale newSale = new Sale();
            newSale.Total = 34.56M;
            newSale.IsDelivery = true;
            newSale.CustomerId = MadgeCustomerId;

            // Act - create sale from instantiated Sale object
            Sale createdSale = saleSqlDao.CreateSale(newSale);

            // retrieve newly created sale
            int newId = createdSale.SaleId;
            Sale retrievedSale = saleSqlDao.GetSaleById(newId);

            // Assert - created sale is correct
            Assert.AreNotEqual(0, createdSale.SaleId, "SaleId not set when created, remained 0");
            Assert.AreEqual(createdSale.Total, retrievedSale.Total);
            Assert.AreEqual(createdSale.IsDelivery, retrievedSale.IsDelivery);
            Assert.AreEqual(createdSale.CustomerId, retrievedSale.CustomerId);
        }

        [TestMethod]
        public void UpdateSale_Updates_Sale()
        {
            // Step Four: Replace Assert.Fail("Test not implemented.")
            // Assert.Fail("Test not implemented.");

            // Arrange - retrieve Madge's first sale and change values
            Sale saleToUpdate = saleSqlDao.GetSaleById(MadgeFirstSaleId);
            saleToUpdate.Total = 89.32M;
            saleToUpdate.IsDelivery = false;

            // Act - update the existing sale with changed values and re-retrieve
            Sale updatedSale = saleSqlDao.UpdateSale(saleToUpdate);
            Sale retrievedSale = saleSqlDao.GetSaleById(MadgeFirstSaleId);

            // Assert - sale has been updated correctly
            AssertSalesMatch(updatedSale, retrievedSale, "Updated Madge's first sale returned wrong or partial data");
        }

        [TestMethod]
        public void DeleteSaleById_Deletes_Sale()
        {
            // Step Five: Replace Assert.Fail("Test not implemented.")
            // Assert.Fail("Test not implemented.");

            // Act - delete existing first sale for Madge
            int rowsAffected = saleSqlDao.DeleteSaleById(MadgeFirstSaleId);

            // Assert - Madge's deleted sale can't be retrieved
            Assert.AreEqual(1, rowsAffected, "Sale not deleted");
            Sale retrievedSale = saleSqlDao.GetSaleById(MadgeFirstSaleId);
            Assert.IsNull(retrievedSale, "Deleted sale can still be retrieved");
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
