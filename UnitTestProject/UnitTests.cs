using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCheckoutLibrary;
using System.Collections.Generic;

namespace UnitTestProject
{
  [TestClass]
  public class UnitTests
  {
    [TestMethod]
    public void Two_apples_and_two_Orange_Should_return_2Pounds_5pences()
    {
      Dictionary<string, decimal> fruitPrices = new Dictionary<string, decimal>(2)
    {
      { "Apple",.60M},{ "Orange",.25M}
    };
      PointofSale pointofSale = new PointofSale(fruitPrices);
      IList<string> items = new List<string>
      {
        "Apple","Apple","Orange","Apple"
      };
      Assert.AreEqual(2.05M, pointofSale.CheckOut(items));
    }
  }
}