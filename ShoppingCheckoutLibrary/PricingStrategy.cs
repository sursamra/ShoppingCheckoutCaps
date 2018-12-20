namespace ShoppingCheckoutLibrary
{
  public interface IPricingStrategy
  {
    string Name { get; set; }

    decimal GetPrice(Item item);
  }

  public class PriceStrategy : IPricingStrategy
  {
    public PriceStrategy(string name)
    {
      Name = name;
    }

    public string Name { get; set; }

    public decimal GetPrice(Item item)
    {
      return (item.Quantity - item.Offer) * item.Price;
    }
  }

  public struct Item
  {
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Offer { get; set; }
    public decimal Price { get; set; }
  }
}