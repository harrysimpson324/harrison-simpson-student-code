using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechElevator.Bookstore;

namespace Tutorial.Tests
{
    [TestClass]
    public class CoffeeTests
    {
        [TestMethod]
        public void Constructor_ValidParameters_SetsProperties()
        {
            // Arrange - since this is testing a constructor, there's nothing to set up

            // Act - call the constructor by creating a new object, passing valid parameters
            Coffee coffee =
                new Coffee("Large", "Decaf", new string[] { "cream", "sugar" }, 2.99M);

            // Assert - verify the properties are set appropriately
            Assert.AreEqual("Large", coffee.Size);
            Assert.AreEqual("Decaf", coffee.Blend);
            Assert.AreEqual(2.99M, coffee.Price);
            Assert.AreEqual(2, coffee.Additions.Length);
        }
    }
}
