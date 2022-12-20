using Models.Entities.Bonus;

namespace Models.Entities;

public class ShoppingCart
{
    private List<Product> _CartItems = new List<Product>();
    public List<Product> CartItems
    {
        get { return _CartItems; }
        set { _CartItems = value; }
    }
    
    public void AddItem(Product product)
    {
        _CartItems.Add(product);
    }
    
    public void RemoveItem(Product product)
    {
        if (CartItems.Contains(product))
        {
            _CartItems.Remove(product);
        }
        
    }

    public float GetTotal()
    {
        float total = 0;
        List<Bonuses> bonuses = new List<Bonuses>();
        foreach (Product product in _CartItems)
        {
            
            
        }
        return total;
    }
    
    public void Clear()
    {
        _CartItems.Clear();
    }
    
    public int GetCount()
    {
        return _CartItems.Count;
    }
    
    public bool IsEmpty()
    {
        return _CartItems.Count == 0;
    }
    
    
    
}