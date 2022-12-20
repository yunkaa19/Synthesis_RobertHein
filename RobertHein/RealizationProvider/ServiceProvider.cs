using DataAccessLayer;
using DataAccessLayer.Production;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer.Interfaces;

namespace RealizationProvider;

public static class ServiceProvider
{
    public static IServiceCollection Get()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IBonusRepository>(new BonusRepository());
        serviceCollection.AddSingleton<IBonusCardRepository>(new BonusCardRepository());
        serviceCollection.AddSingleton<ICategoryRepository>(new CategoryRepository());
        serviceCollection.AddSingleton<IOrderRepository>(new OrderRepository());
        serviceCollection.AddSingleton<IProductRepository>(new ProductRepository());
        serviceCollection.AddSingleton<ICustomerRepository>(new CustomerRepository());
        
        return serviceCollection;
    }
}