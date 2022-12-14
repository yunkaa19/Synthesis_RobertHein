using Models.Entities;

namespace Models.Interfaces.RepositoryInterfaces;

public interface IProductRepository
{
    List<Product> GetAllProducts();
    Product GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);

    
    List<Product> GetProductsByCategory(int categoryId);
    List<Product> GetCustomerFavoriteProducts(int customerId);
    
}