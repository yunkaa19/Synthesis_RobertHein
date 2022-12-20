using Models.Entities.Bonus;

namespace Models.Entities;

public class SecondHalfPrice : Bonuses
{
    public SecondHalfPrice(int id, Product product, DateOnly startDate, DateOnly endDate, float price) : base(id, product, startDate, endDate, price)
    {
        Price = price + (price / 2);
        Price = MathF.Round(Price, 2);
    }
    public SecondHalfPrice(Product product, DateOnly startDate, DateOnly endDate) : base(product, startDate, endDate)
    {
        Price = product.Price + (product.Price / 2);
        Price = (float)Math.Round(Price, 2);
    }
}