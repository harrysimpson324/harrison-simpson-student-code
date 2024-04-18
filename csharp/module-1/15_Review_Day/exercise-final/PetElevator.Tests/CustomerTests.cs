using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetElevator.CRM;
using System.Collections.Generic;

namespace PetElevator.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void GetBalanceDue_Test()
        {
            Customer customer = new Customer("Test", "Testerson");
            Dictionary<string, double> services = new Dictionary<string, double>()
            {
                {"Grooming", 45 },
                {"Sitting", 120 },
                {"Walking", 37.50 }
            };

            double due = customer.GetBalanceDue(services);

            Assert.AreEqual(202.50, due);
        }
    }
}
