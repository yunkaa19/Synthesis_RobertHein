using Models.Entities.Bonus;

namespace Models.Entities;

public class XForThePriceOfY : Bonuses
{
    private int _numberOfItems;
    private double _price;

    public int NumberOfItems
    {
        get => _numberOfItems;
        set => _numberOfItems = value;
    }
    

    public XForThePriceOfY(int id, Product product, DateOnly startDate, DateOnly endDate, float price, int numberOfItems) : base(id, product, startDate, endDate, price)
    {
        NumberOfItems = numberOfItems;
        Price = price;
    }
    public XForThePriceOfY(Product product, DateOnly startDate, DateOnly endDate, float price, int numberOfItems) : base(product, startDate, endDate, price)
    {
        NumberOfItems = numberOfItems;
        Price = price;
    }
}