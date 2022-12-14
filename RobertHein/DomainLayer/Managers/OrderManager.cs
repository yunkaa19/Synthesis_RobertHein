using Models.Entities;
using Models.Interfaces.RepositoryInterfaces;

namespace Models.Managers;

public class OrderManager
{
    private List<Order> _orders;
    private IOrderRepository _orderRepository;
    
    public OrderManager(IOrderRepository orderRepository,List<Product> products, List<Customer> customers, List<BonusCard> bonusCards)
    {
        _orderRepository = orderRepository;
        _orders = _orderRepository.GetOrders(products, customers, bonusCards);
    }
    
    public void Refresh(List<Product> products, List<Customer> customers, List<BonusCard> bonusCards)
    {
        _orders = _orderRepository.GetOrders(products, customers, bonusCards);
    }
    
    public List<Order> GetOrders()
    {
        return _orders;
    }
    
    public void AddOrder(Order order)
    {
        _orders.Add(order);
        _orderRepository.AddOrder(order);
    }

    public void Update(Order order)
    {
        _orderRepository.UpdateOrder(order);
        var orderToUpdate = _orders.Find(o => o.Id == order.Id);
        orderToUpdate = order;
    }
    
    public void DeleteOrder(Order order)
    {
        _orders.Remove(order);
        _orderRepository.DeleteOrder(order.Id);
    }
    
    public void CompleteOrder(Order order)
    {
        var orderToUpdate = _orders.Find(o => o.Id == order.Id);
        orderToUpdate.OrderComplete();
        _orderRepository.UpdateOrder(orderToUpdate);
    }
}