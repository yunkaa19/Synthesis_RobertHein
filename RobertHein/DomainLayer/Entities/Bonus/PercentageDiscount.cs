namespace Models.Entities;

public class PercentageDiscount : Bonuses
{
    private double _percentage;

    public double Percentage
    {
        get => _percentage;
        set => _percentage = value;
    }
    public PercentageDiscount(int id, Product product, DateOnly startDate, DateOnly endDate, float price, double percentage) : base(id,product,startDate,endDate,price)
    {
        _percentage = percentage;
        Price = (float)(product.Price - (product.Price * percentage / 100));
    }
}