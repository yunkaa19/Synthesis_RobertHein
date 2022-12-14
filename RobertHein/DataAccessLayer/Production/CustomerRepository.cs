using Models.Interfaces.RepositoryInterfaces;
using System.Data.SqlClient;
using System.Security;
using Models.Entities;

namespace DataAccessLayer.Production;

public class CustomerRepository : Repository, ICustomerRepository

{

    public List<Customer> GetAllCustomers()
    {
        List<Customer> customers = new List<Customer>();
        try
        {
        
            using (SqlConnection connection = new SqlConnection(ConnectionString))

            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Customer", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"].ToString().Trim());
                    string name = reader["FirstName"].ToString().Trim() + " " + reader["LastName"].ToString().Trim();
                    string email = reader["Email"].ToString().Trim();
                    string phone = reader["Phone"].ToString().Trim();
                    string address = reader["Address"].ToString().Trim();
                    string city = reader["City"].ToString().Trim();
                    string zipCode = reader["ZipCode"].ToString().Trim();
                    DateOnly birthday = DateOnly.FromDateTime(Convert.ToDateTime(reader["Birthday"].ToString().Trim()));
                    string password = reader["Password"].ToString().Trim();
                    Customer customer =
                        new Customer(id, name, address, city, zipCode, phone, birthday, email, password);

                    customers.Add(customer);
                }
            }
        }
        catch (Exception ex)
        {
            
        }
        return customers;
    }
    

    public Customer GetCustomerById(int id)
    {
        Customer? customer = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["FirstName"].ToString().Trim() + " " + reader["LastName"].ToString().Trim();
                    string email = reader["Email"].ToString().Trim();
                    string phone = reader["Phone"].ToString().Trim();
                    string address = reader["Address"].ToString().Trim();
                    string city = reader["City"].ToString().Trim();
                    string zipCode = reader["ZipCode"].ToString().Trim();
                    DateOnly birthday = DateOnly.FromDateTime(Convert.ToDateTime(reader["Birthday"].ToString().Trim()));
                    string password = reader["Password"].ToString().Trim();
                    customer = new Customer(id, name, address, city, zipCode, phone, birthday, email, password);
                }
            }
        }
        catch (Exception ex)
        {
            
        }
        return customer;
        
    }

    public Customer GetCustomerByEmail(string email)
    {
        Customer? customer = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE Email = @email", connection);
                command.Parameters.AddWithValue("@email",email);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"].ToString().Trim());
                    string name = reader["FirstName"].ToString().Trim() + " " + reader["LastName"].ToString().Trim();
                    string phone = reader["Phone"].ToString().Trim();
                    string address = reader["Address"].ToString().Trim();
                    string city = reader["City"].ToString().Trim();
                    string zipCode = reader["ZipCode"].ToString().Trim();
                    DateOnly birthday = DateOnly.FromDateTime(Convert.ToDateTime(reader["Birthday"].ToString().Trim()));
                    string password = reader["Password"].ToString().Trim();
                    customer = new Customer(id, name, address, city, zipCode, phone, birthday, email, password);
                }
            }
        }
        catch (Exception ex)
        {
            
        }
        return customer;
    }

    public void AddCustomer(Customer customer)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Customer (FirstName, LastName, Email, Phone, Address, City, ZipCode, Birthday, Password) VALUES (@firstName, @lastName, @email, @phone, @address, @city, @zipCode, @birthday, @password)", connection);
                string firstName = customer.Name.Split(" ")[0];
                string lastName = customer.Name.Split(" ")[1];
                command.Parameters.AddWithValue("@firstName",firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@email", customer.Email);
                command.Parameters.AddWithValue("@phone", customer.Phone);
                command.Parameters.AddWithValue("@address", customer.Address);
                command.Parameters.AddWithValue("@city", customer.City);
                command.Parameters.AddWithValue("@zipCode", customer.ZipCode);
                command.Parameters.AddWithValue("@birthday", customer.DateOfBirth);
                command.Parameters.AddWithValue("@password", customer.Password);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    public void UpdateCustomer(Customer customer)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Customer SET FirstName = @firstName, LastName = @lastName, Email = @email, Phone = @phone, Address = @address, City = @city, ZipCode = @zipCode, Birthday = @birthday, Password = @password WHERE Id = @id", connection);
                string firstName = customer.Name.Split(" ")[0];
                string lastName = customer.Name.Split(" ")[1];
                command.Parameters.AddWithValue("@firstName",firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@email", customer.Email);
                command.Parameters.AddWithValue("@phone", customer.Phone);
                command.Parameters.AddWithValue("@address", customer.Address);
                command.Parameters.AddWithValue("@city", customer.City);
                command.Parameters.AddWithValue("@zipCode", customer.ZipCode);
                command.Parameters.AddWithValue("@birthday", customer.DateOfBirth);
                command.Parameters.AddWithValue("@password", customer.Password);
                command.Parameters.AddWithValue("@id", customer.Id);
                command.ExecuteNonQuery();
                
            }
        }
        catch (Exception ex)
        {
            
        }
        
    }

    public void DeleteCustomer(int id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Customer WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            
        }
    }
}