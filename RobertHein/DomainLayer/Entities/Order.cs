using Models.Enums;

namespace Models.Entities;

public class Order
{
    private int _id;
    private DateOnly _OrderDate;
    private DateTime _DeliveryDate; 
    private DeliveryOptions _DeliveryOption;
    private Customer _Customer;
    private BonusCard? _BonusCard;
    private ShoppingCart _ShoppingCart;
    private bool _OrderStatus;

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public DateOnly OrderDate
    {
        get => _OrderDate;
        set => _OrderDate = value;
    }

    public DateTime DeliveryDate
    {
        get => _DeliveryDate;
        set => _DeliveryDate = value;
    }

    public DeliveryOptions DeliveryOption
    {
        get => _DeliveryOption;
        set => _DeliveryOption = value;
    }

    public Customer Customer
    {
        get => _Customer;
        set => _Customer = value;
    }
    
    public BonusCard BonusCard
    {
        get => _BonusCard ?? throw new NullReferenceException("Bonus card is not set");
        set => _BonusCard = value;
    }

    public ShoppingCart ShoppingCart
    {
        get => _ShoppingCart;
        set => _ShoppingCart = value;
    }
    public bool OrderStatus
    {
        get => _OrderStatus;
        set => _OrderStatus = value;
    }
    public Order(int id, DateOnly orderDate, DateTime deliveryDate, DeliveryOptions deliveryOption, Customer customer, BonusCard? bonusCard, ShoppingCart shoppingCart, bool orderStatus)
    {
        Id = id;
        OrderDate = orderDate;
        DeliveryDate = deliveryDate;
        DeliveryOption = deliveryOption;
        Customer = customer;
        BonusCard = bonusCard;
        ShoppingCart = shoppingCart;
        OrderStatus = orderStatus;
    }
    

    public Order(DateOnly orderDate, DateTime deliveryDate, DeliveryOptions deliveryOption, Customer customer, BonusCard? bonusCard, ShoppingCart shoppingCart, bool orderStatus)
    {
        OrderDate = orderDate;
        DeliveryDate = deliveryDate;
        DeliveryOption = deliveryOption;
        Customer = customer;
        BonusCard = bonusCard;
        ShoppingCart = shoppingCart;
        OrderStatus = orderStatus;
    }
    
    
    public void OrderComplete()
    {
        OrderStatus = true;
    }
}