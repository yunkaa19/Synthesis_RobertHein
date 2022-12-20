namespace Models.Entities.Bonus;

public class Bonuses
{
    private Product _product;

    public int Id { get; private init; }

    public Product Product
    {
        get => _product;
        private init => _product = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public float Price { get; set; }

    protected Bonuses(int id, Product product, DateOnly startDate, DateOnly endDate, float price)
    {
        Id = id;
        _product = product;
        Product = product;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;
    }
    public Bonuses(Product product, DateOnly startDate, DateOnly endDate, float price)
    {
        Product = product;
        _product = product;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;
    }
    public Bonuses(int id, Product product, DateOnly startDate, DateOnly endDate)
    {
        Id = id;
        _product = product;
        Product = product;
        StartDate = startDate;
        EndDate = endDate;
    }
    public Bonuses(Product product, DateOnly startDate, DateOnly endDate)
    {
        Product = product;
        _product = product;
        StartDate = startDate;
        EndDate = endDate;
    }
}