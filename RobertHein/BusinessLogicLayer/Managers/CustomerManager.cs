using Models.DTO;
using Models.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Managers;

public class CustomerManager
{
    private List<Customer> _customers;
    private ICustomerRepository _customerRepository;
    
    public CustomerManager(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
        _customers = customerRepository.GetAllCustomers();
    }
    
    public List<Customer> GetCustomers()
    {
        return _customers;
    }
    public void RefreshCustomers()
    {
        _customers = _customerRepository.GetAllCustomers();
    }
    public bool AddCustomer(Register r)
    {
        //check if email already exists
        if (_customers.Any(c => c.Email == r.email))
        {
            return false;
        }

        if (_customerRepository.AddCustomer(new Customer(r)))
        {
            _customers.Add(_customerRepository.GetCustomerByEmail(r.email));
            return true;
        }
        return false;
    }
    public void UpdateCustomer(Customer customer)
    {
        _customerRepository.UpdateCustomer(customer);
        var customerToUpdate = _customers.FirstOrDefault(c => c.Id == customer.Id);
        if (customerToUpdate is not null)
        {
            customerToUpdate.Name = customer.Name;
            customerToUpdate.Email = customer.Email;
            customerToUpdate.Address = customer.Address;
            customerToUpdate.City = customer.City;
            customerToUpdate.Phone = customer.Phone;
            customerToUpdate.ZipCode = customer.ZipCode;
            customerToUpdate.DateOfBirth = customer.DateOfBirth;
        }
        //RefreshCustomers();
    }
    public void UpdatePassword(Customer customer, string newPassword)
    {
        customer.Password = PasswordHasher.HashPassword(newPassword);
        _customerRepository.UpdateCustomer(customer);
        //RefreshCustomers();
    }
    public void DeleteCustomer(Customer customer)
    {
        _customerRepository.DeleteCustomer(customer.Id);
        _customers.Remove(customer);
        //RefreshCustomers();
    }
    
    public Customer GetCustomerById(int id)
    {
        Customer customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer is not null)
        {
            return customer;
        }
        else return _customerRepository.GetCustomerById(id);
    }
    public Customer GetCustomerByIdFromDb(int id)
    {
        return _customerRepository.GetCustomerById(id);
    }
    public void PopulateCustomerFavorites(Customer customer, IProductRepository productRepositoryA)
    {
        IProductRepository productRepository = productRepositoryA;
        customer.Favorites = productRepository.GetCustomerFavoriteProducts(customer.Id);
    }

    public bool Login(string email, string password)
    {
        string hashedPassword = "";
        foreach (var customer in _customers)
        {
            if (customer.Email == email)
            {
                hashedPassword = customer.Password;
            }
        }
        if (hashedPassword == "")
        {
            Customer customer = _customerRepository.GetCustomerByEmail(email);
            if(customer is null)
            {
                return false;
            }
            hashedPassword = customer.Password;
        }
        return PasswordHasher.ValidatePassword(password, hashedPassword);
    }
    
}