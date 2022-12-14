namespace Models.Entities;

public class SecondHalfPrice : Bonuses
{
    public SecondHalfPrice(int id, Product product, DateOnly startDate, DateOnly endDate, float price) : base(id, product, startDate, endDate, price)
    {
        Price = price + (price / 2);
    }
}