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
    
    public List<Product> Refresh()
    {
        return _products.FindAll(p => p.IsDiscontinued == false);
    }
    public Product GetProductById(int id)
    {
        return _products.Find(p => p.Id == id);
    }
    private void DiscontinueProduct(Product product)
    {
        Product productToDiscontinue = _products.Find(p => p.Id == product.Id);
        if (productToDiscontinue is not null)
        {
            productToDiscontinue.IsDiscontinued = true;
            _productRepository.DeleteProduct(product.Id);
        }
    }
    private void ReenableProduct(Product product)
    {
        Product productToReenable = _products.Find(p => p.Id == product.Id);
        if (productToReenable is not null)
        {
            productToReenable.IsDiscontinued = false;
            _productRepository.UpdateProduct(product);
        }
    }
}