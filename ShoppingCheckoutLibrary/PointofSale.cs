using System.Collections.Generic;
using System.Linq;

namespace ShoppingCheckoutLibrary
{
  public class PointofSale
  {
    private readonly Dictionary<string, decimal> fruitPrices;

    public PointofSale(Dictionary<string, decimal> pFruitPrices)
    {
      fruitPrices = pFruitPrices;
    }

    public decimal CheckOut(IList<string> items)
    {
      decimal totalBill = 0;
      items.All(a =>
      {
        totalBill += fruitPrices[a];
        return true;
      });
      return totalBill;
    }
  }
}