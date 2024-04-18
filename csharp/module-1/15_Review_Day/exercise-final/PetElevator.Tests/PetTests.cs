using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetElevator.CRM;

namespace PetElevator.Tests
{
    [TestClass]
    public class PetTests
    {
        [TestMethod]
        public void ListVaccinations_Test()
        {
            Pet pet = new Pet("Fido", "Dog");

            pet.Vaccinations.Add("Rabies");
            pet.Vaccinations.Add("Distemper");
            pet.Vaccinations.Add("Parvo");

            string vaccString = pet.ListVaccinations();

            Assert.AreEqual("Rabies, Distemper, Parvo", vaccString);
        }
    }
}
