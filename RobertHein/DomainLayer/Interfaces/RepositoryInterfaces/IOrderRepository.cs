using Models.Entities;

namespace Models.Interfaces.RepositoryInterfaces;

public interface IOrderRepository
{
    List<Order> GetOrders(List<Product> allProducts, List<Customer> allCustomers, List<BonusCard> allBonusCards);
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(int id);
}