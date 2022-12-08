using Models.Entities;

namespace Models.Interfaces.RepositoryInterfaces;

public interface IOrderRepository
{
    List<Order> GetOrders();
    Order GetOrder(int id);
    
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(int id);
}