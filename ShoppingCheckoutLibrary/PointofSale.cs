using System.Collections.Generic;
using System.Linq;

namespace ShoppingCheckoutLibrary
{
  public class PointofSale
  {
    private readonly Dictionary<Item, IPricingStrategy> pricingStrategies;

    public PointofSale(Dictionary<Item, IPricingStrategy> priceStrategies)
    {
      pricingStrategies = priceStrategies;
    }

    public decimal CheckOut(IList<Item> items)
    {
      decimal totalBill = 0;
      pricingStrategies.All(strategy =>
      {
        Item item = items.First(i => i.Name == strategy.Key.Name);
        totalBill = totalBill + strategy.Value.GetPrice(item);
        return true;
      });
      return totalBill;
    }
  }
}