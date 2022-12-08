using Models.Enums;

namespace Models.Entities;

public class Bonus
{
    private static int _idSeeder = 1;
    private  int _id;
    private Product _product;
    private DateOnly _startDate;
    private DateOnly _endDate;
    private BonusType _bonusType;
    private float _price;
    
    private double? Quantity;
    private double? Percentage;

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

    public BonusType BonusType
    {
        get => _bonusType;
        set => _bonusType = value;
    }

    public float Price
    {
        get => _price;
        set => _price = value;
    }

    public double? Quantity1
    {
        get => Quantity;
        set => Quantity = value;
    }

    public double? Percentage1
    {
        get => Percentage;
        set => Percentage = value;
    }
    
    public Bonus(Product product, DateOnly startDate, DateOnly endDate, BonusType bonusType, float price, double? quantity, double? percentage)
    {
        _id = _idSeeder++;
        _product = product;
        _startDate = startDate;
        _endDate = endDate;
        switch (bonusType)
        {
            case BonusType.Percentage:
                _bonusType = bonusType;
                Percentage = percentage / 100;
                price = product.Price * (float)Percentage;
                break;
            case BonusType.Quantity:
                _bonusType = bonusType;
                Quantity = quantity;
                price = price;
                break;
            case BonusType.SecondHalfPrice:
                _bonusType = bonusType;
                price = product.Price + product.Price / 2;
                break;
            case BonusType.TwoForOne:
                _bonusType = bonusType;
                price = product.Price;
                break;
            case BonusType.TwoForSetPrice:
                _bonusType = bonusType;
                price = price;
                break;
        }
    }
}