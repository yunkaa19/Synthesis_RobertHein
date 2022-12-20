using Models.Entities;
using Models.Interfaces.RepositoryInterfaces;

namespace Models.Managers;

public class ProductManager
{
    private List<Product> _products;
    
    private IProductRepository _productRepository;
    
    public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        
        _products = _productRepository.GetAllProducts();
        
    }

    public void Refresh()
    {
        _products = _productRepository.GetAllProducts();
    }
    
    public List<Product> GetAll(bool getOnlyActive = true)
    {
        if (getOnlyActive)
        {
            return _products.FindAll(p => p.IsDiscontinued == false);
        }
        else
        {
            return _products;
        }
    }
    public Product GetProductById(int id)
    {
        return _products.Find(p => p.Id == id);
    }
    public void DiscontinueProduct(Product product)
    {
        Product productToDiscontinue = _products.Find(p => p.Id == product.Id);
        if (productToDiscontinue is not null)
        {
            productToDiscontinue.IsDiscontinued = true;
            _productRepository.DeleteProduct(product.Id);
        }
    }
    
    public void ReenableProduct(Product product)
    {
        Product productToReenable = _products.Find(p => p.Id == product.Id);
        if (productToReenable is not null)
        {
            productToReenable.IsDiscontinued = false;
            _productRepository.UpdateProduct(product);
        }
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
        _productRepository.AddProduct(product);
    }
    public void UpdateProduct(Product product)
    {
        Product productToUpdate = _products.Find(p => p.Id == product.Id);
        if (productToUpdate is not null)
        {
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.IsDiscontinued = product.IsDiscontinued;
            _productRepository.UpdateProduct(product);
        }
    }
    
    public List<Product> GetProductsByCategory(int id)
    {
        return _products.FindAll(p => p.Category.Id == id);
    }
    
    public List<Product> GetCustomerFavorites(int id)
    {
        return _productRepository.GetCustomerFavoriteProducts(id);
    }
    
}