using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HelloWorldTests
{
    [TestClass]
    public class HelloWorldTests
    {
        [TestMethod]
        public void TwoPlusTwoEqualsFour()
        {
            Assert.AreEqual(4, 2 + 2);
        }
        [TestMethod]
        public void SevenDividedByTwoIsThree()
        {
            int result = 7 / 2;
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void SevenDividedByTwoIsThreeAndOneHalf()
        {
            double result = 7.0 / 2;
            Assert.AreEqual(3.5, result, 0.01);
        }
    }
}
