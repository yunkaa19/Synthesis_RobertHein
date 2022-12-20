using System.Diagnostics;
using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer.Interfaces;
using RealizationProvider;


namespace RobertHeinDesktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        private static readonly IServiceCollection Services = RealizationProvider.ServiceProvider.Get();

        private static readonly IServiceProvider Provider = Services.BuildServiceProvider();
        
        [STAThread]
        static void Main()
        {
            var bonusRepository = Provider.GetService<IBonusRepository>();
            var bonusCardRepository = Provider.GetService<IBonusCardRepository>();
            var categoryRepository = Provider.GetService<ICategoryRepository>();
            var customerRepository = Provider.GetService<ICustomerRepository>();
            var orderRepository = Provider.GetService<IOrderRepository>();
            var productRepository = Provider.GetService<IProductRepository>();
            
            
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (productRepository != null && categoryRepository != null && bonusRepository != null && bonusCardRepository != null && customerRepository != null && orderRepository != null)
            {
                Application.Run(new RobertHein(productRepository, categoryRepository, bonusRepository,
                    bonusCardRepository, customerRepository, orderRepository));
            }
        }
    }
}