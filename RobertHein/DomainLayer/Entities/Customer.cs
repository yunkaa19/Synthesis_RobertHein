using Models.DTO;
using Models.Managers;

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
    private DateOnly _dateOfBirth;

    //private BonusCard? _card; //Maybe
    private List<Product> _favorites = new List<Product>(); //


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

    public DateOnly DateOfBirth
    {
        get => _dateOfBirth;
        set => _dateOfBirth = value;
    }


    public List<Product> Favorites
    {
        get => _favorites;
        set => _favorites = value ?? throw new ArgumentNullException(nameof(value));
    }

    //validation inside Register
    public Customer(Register r)
    {
        Name = r.firstName + " " + r.lastName;
        Email = r.email;
        Password = PasswordHasher.HashPassword(r.password);
        DateOfBirth = DateOnly.Parse(Convert.ToDateTime(r.birthdayDate).ToShortDateString());
        Address = r.address;
        City = r.city;
        ZipCode = r.postalCode;
        Phone = r.phoneNumber;
    }
    public Customer(int id, string name, string address, string city, string zipCode, string phone, DateOnly dateOfBirth, string email, string password)
    {
        _id = id;
        _name = name;
        _address = address;
        _city = city;
        _zipCode = zipCode;
        _phone = phone;
        _email = email;
        _password = password;
        _dateOfBirth = dateOfBirth;
    }
    
    
    bool AddToFavorites(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        if (_favorites.Contains(product))
        {
            return false;
        }
        _favorites.Add(product);
        return true;
    }
    bool RemoveFromFavorites(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        if (_favorites.Contains(product))
        {
            _favorites.Remove(product);
            return true;
        }
        return false;
    }
    
}