using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechElevator.Bookstore;

namespace Tutorial.Tests
{
    [TestClass]
    public class ShoppingCartTests
    {
        private ShoppingCart cart;

        [TestInitialize]
        public void CreateAndFillCart()
        {
            // Create a shopping cart and add both taxable and non-taxable items to it.
            this.cart = new ShoppingCart(0.10);     // 10% tax rate

            // Taxable $10 plus $1 tax
            cart.Add(new Book("Dynamics of Software Development", "Jim McCarthy", 10.00M));
            // Taxable $20 plus $2 tax
            cart.Add(new Movie("Free Guy", "PG-13", 115, 20.00M));
            // Not taxable $10
            cart.Add(new Coffee("Jumbo", "Bold", new string[] { "cream" }, 10.00M));
        }

        [TestMethod]
        public void Subtotal_ValidItems_EqualsSumOfAllItems()
        {
            // Arrange - Create a shopping cart with items

            // Act - get the subtotal
            decimal subtotal = cart.SubtotalPrice;

            // Assert - Make sure value is correct
            Assert.AreEqual(40.00M, subtotal);
        }

        [TestMethod]
        public void Tax_TaxableItemMix_EqualsTaxOnTaxableItems()
        {
            // Arrange - the [TestInitialize] method creates a cart before every test

            // Act - get the tax
            decimal tax = cart.Tax;

            // Assert - Make sure value is correct
            Assert.AreEqual(3.00M, tax);
        }

        [TestMethod]
        public void Total_TaxableMix_EqualsSumOfItemsPlusTax()
        {
            // Arrange - the [TestInitialize] method creates a cart before every test

            // Act - get the total
            decimal total = cart.TotalPrice;

            // Assert - Make sure value is correct
            Assert.AreEqual(43.00M, total);
        }
    }
}
