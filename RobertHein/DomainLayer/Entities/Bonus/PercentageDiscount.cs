using Models.Entities.Bonus;

namespace Models.Entities;

public class PercentageDiscount : Bonuses
{
    private double _percentage;

    public double Percentage
    {
        get => _percentage;
        set => _percentage = value;
    }
    public PercentageDiscount(int id, Product product, DateOnly startDate, DateOnly endDate, double percentage) : base(id,product,startDate,endDate)
    {
        _percentage = percentage;
        Price = (float)(product.Price - (product.Price * percentage / 100));
        Price = (float)Math.Round(Price, 2);
    }
    public PercentageDiscount(Product product, DateOnly startDate, DateOnly endDate, double percentage) : base(product,startDate,endDate)
    {
        _percentage = percentage;
        Price = (float)(product.Price - (product.Price * percentage / 100));
        Price = (float)Math.Round(Price, 2);
    }
}