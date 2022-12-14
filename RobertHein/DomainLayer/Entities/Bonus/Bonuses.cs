using Models.Enums;

namespace Models.Entities;

public class Bonuses
{
    protected int _id;
    protected Product _product;
    protected DateOnly _startDate;
    protected DateOnly _endDate;
    protected float _price;

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public Product Product
    {
        get => _product;
        set => _product = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateOnly StartDate
    {
        get => _startDate;
        set => _startDate = value;
    }

    public DateOnly EndDate
    {
        get => _endDate;
        set => _endDate = value;
    }

    public float Price
    {
        get => _price;
        set => _price = value;
    }

    public Bonuses(int id, Product product, DateOnly startDate, DateOnly endDate, float price)
    {
        Id = id;
        Product = product;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;
    }
}