using Models.Entities;
using Models.Interfaces.RepositoryInterfaces;

namespace DataAccessLayer.Production;

public class OrderRepository : Repository, IOrderRepository
{
    public List<Order> GetOrders()
    {
        throw new NotImplementedException();
    }

    public Order GetOrder(int id)
    {
        throw new NotImplementedException();
    }

    public void AddOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public void UpdateOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public void DeleteOrder(int id)
    {
        throw new NotImplementedException();
    }
}