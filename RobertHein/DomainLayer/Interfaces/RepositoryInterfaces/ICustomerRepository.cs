using Models.Entities;

namespace Models.Interfaces.RepositoryInterfaces;

public interface ICustomerRepository
{
    List<Customer> GetAllCustomers();
    Customer GetCustomerById(int id);
    Customer GetCustomerByEmail(string email);
    void AddCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(int id);
    
}