using Models.Entities;

namespace DataAccessLayer.Interfaces;

public interface ICustomerRepository
{
    List<Customer> GetAllCustomers();
    Customer GetCustomerById(int id);
    Customer GetCustomerByEmail(string email);
    void AddCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(int id);
    
}