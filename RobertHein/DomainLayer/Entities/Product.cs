using Models.Enums;

namespace Models.Entities;

public class Product
{
  private  int _id;
  private Category _category;
  private string _name;
  private float _price;
  int _stock;
  private Units _unit;
  private string? _unitExtension;
  private byte[] _image;
  private bool _isDiscontinued;
  
 // private List<Bonuses> _bonuses;

public int Id
  {
    get => _id;
    init => _id = value;
  }
public Category Category
  {
    get => _category;
    set => _category = value;
  }
public string Name
  {
    get => _name;
    set => _name = value;
  }
public float Price
  {
    get => _price;
    set => _price = value;
  }
public int Stock
  {
    get => _stock;
    set => _stock = value;
  }
public Units Unit
  {
    get => _unit;
    set => _unit = value;
  }
public string UnitExtension
  {
    get => _unitExtension;
    set => _unitExtension = value;
  }
public byte[] Image
  {
    get => _image;
    set => _image = value;
  }
public bool IsDiscontinued
  {
    get => _isDiscontinued;
    set => _isDiscontinued = value;
  }




public Product(Category category, string name, float price,int stock, Units unit, string unitExtension, byte[] image, bool isDiscontinued)
  {
    _category = category;
    _name = name;
    _price = price;
    _stock = stock;
    _unit = unit;
    _unitExtension = unitExtension;
    _image = image;
    _isDiscontinued = isDiscontinued;
  }
public Product(Category category, string name, float price,int stock, Units unit, byte[] image, bool isDiscontinued)
{
  _category = category;
  _name = name;
  _price = price;
  _stock = stock;
  _unit = unit;
  _image = image;
  _isDiscontinued = isDiscontinued;
}
public Product(int id, Category category, string name, float price,int stock, Units unit, byte[] image, bool isDiscontinued)
{
  _id = id;
  _category = category ?? throw new ArgumentNullException(nameof(category));
  _name = name ?? throw new ArgumentNullException(nameof(name));
  _price = price;
  _stock = stock;
  _unit = unit;
  _image = image ?? throw new ArgumentNullException(nameof(image));
  _isDiscontinued = isDiscontinued;
}


public Product(int id, Category category, string name, float price,int stock, Units unit, string unitExtension, byte[] image, bool isDiscontinued)
{
  _id = id;
  _category = category ?? throw new ArgumentNullException(nameof(category));
  _name = name ?? throw new ArgumentNullException(nameof(name));
  _price = price;
  _stock = stock;
  _unit = unit;
  _unitExtension = unitExtension;
  _image = image ?? throw new ArgumentNullException(nameof(image));
  _isDiscontinued = isDiscontinued;
}
}