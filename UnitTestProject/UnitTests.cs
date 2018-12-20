using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCheckoutLibrary;
using System.Collections.Generic;

namespace UnitTestProject
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void Two_apples_and_two_Orange_Should_return_2Pounds_5pences()
    {
      IList<Item> Items = new List<Item>
      {
        new Item(){ Name = "Apple",Offer=0,Price=.60M,Quantity = 3},
        new Item(){ Name = "Orange",Offer=0,Price=.25M,Quantity = 1}
      };
      Dictionary<Item, IPricingStrategy> pricingStrategies = new Dictionary<Item, IPricingStrategy>()
      {
        { Items[0],new PriceStrategy(Items[0].Name)},
        { Items[1],new PriceStrategy(Items[1].Name)},
      };
      PointofSale pointofSale = new PointofSale(pricingStrategies);
      Assert.AreEqual(2.05M, pointofSale.CheckOut(Items));
    }

    [TestMethod]
    public void When_OnOffer_Apples_HalfPrice_and_Orange_2_for_3_Buy_Two_apples_and_tree_Orange_Should_return_1Pounds_10pences()
    {
      IList<Item> Items = new List<Item>
      {
        new Item(){ Name = "Apple",Offer=1,Price=.60M,Quantity = 2},
        new Item(){ Name = "Orange",Offer=1,Price=.25M,Quantity = 3}
      };
      Dictionary<Item, IPricingStrategy> pricingStrategies = new Dictionary<Item, IPricingStrategy>()
      {
        { Items[0],new PriceStrategy(Items[0].Name)},
        { Items[1],new PriceStrategy(Items[1].Name)},
      };
      PointofSale pointofSale = new PointofSale(pricingStrategies);
      Assert.AreEqual(1.10M, pointofSale.CheckOut(Items));
    }

    [TestMethod]
    public void When_OnOffer_Apples_HalfPrice_and_Orange_HalfPrice_Buy_Two_apples_and_Two_Orange_Should_return_85pences()
    {
      IList<Item> Items = new List<Item>
      {
        new Item(){ Name = "Apple",Offer=1,Price=.60M,Quantity = 2},
        new Item(){ Name = "Orange",Offer=1,Price=.25M,Quantity = 2}
      };
      Dictionary<Item, IPricingStrategy> pricingStrategies = new Dictionary<Item, IPricingStrategy>()
      {
        { Items[0],new PriceStrategy(Items[0].Name)},
        { Items[1],new PriceStrategy(Items[1].Name)},
      };
      PointofSale pointofSale = new PointofSale(pricingStrategies);
      Assert.AreEqual(0.85M, pointofSale.CheckOut(Items));
    }
  }
}