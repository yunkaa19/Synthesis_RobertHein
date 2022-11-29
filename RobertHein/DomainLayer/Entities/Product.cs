using Models.Enums;

namespace Models.Entities;

public record Product
{
  private  int _id;
  private Category _category;
  private string _name;
  private float _price;
  private Units _unit;
  private string? _unitExtension;
  
  
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


public Product(int id, Category category, string name, float price, Units unit)
{
  _id = id;
  _category = category ?? throw new ArgumentNullException(nameof(category));
  _name = name ?? throw new ArgumentNullException(nameof(name));
  _price = price;
  _unit = unit;
}

public Product(int id, Category category, string name, float price, Units unit, string? unitExtension)
{
  _id = id;
  _category = category ?? throw new ArgumentNullException(nameof(category));
  _name = name ?? throw new ArgumentNullException(nameof(name));
  _price = price;
  _unit = unit;
  _unitExtension = unitExtension;
}
}