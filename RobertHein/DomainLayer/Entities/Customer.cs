namespace Models.Entities;

public class Customer
{
    private int _id;
    private string _name;
    private string _address;
    private string _city;
    private string _zipCode;
    private string _phone;
    private string _email;
    private string _password;

    private List<Product> _cart = new List<Product>();



    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Address
    {
        get => _address;
        set => _address = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string City
    {
        get => _city;
        set => _city = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string ZipCode
    {
        get => _zipCode;
        set => _zipCode = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Phone
    {
        get => _phone;
        set => _phone = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Email
    {
        get => _email;
        set => _email = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Password
    {
        get => _password;
        set => _password = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Product> Cart
    {
        get => _cart;
        set => _cart = value ?? throw new ArgumentNullException(nameof(value));
    }


    public Customer(int id, string name, string address, string city, string zipCode, string phone, string email, string password)
    {
        _id = id;
        _name = name;
        _address = address;
        _city = city;
        _zipCode = zipCode;
        _phone = phone;
        _email = email;
        _password = password;
    }
}