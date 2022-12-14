namespace Models.Entities;

public class QuantityDiscount : Bonuses
{
    private double _Quantity;
    
    public double Quantity
    {
        get => _Quantity;
        set => _Quantity = value;
    }

    

    public QuantityDiscount(int id, Product product, DateOnly startDate, DateOnly endDate, float price, double quantity) : base(id, product, startDate, endDate, price)
    {
        _Quantity = quantity;
        Price = price;
    }
}