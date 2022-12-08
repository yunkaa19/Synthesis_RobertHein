using System.Data.SqlClient;
using Models.Entities;
using Models.Enums;
using Models.Interfaces.RepositoryInterfaces;

namespace DataAccessLayer.Production;

public class ProductRepository : Repository, IProductRepository
{
    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command =
                    new SqlCommand(
                        "select ProductID, Name, Price, unit, UnitExtension, Discontinued, InStock , C.CategoryID, CategoryName, ParentID from Products as p join Categories C on p.CategoryID = C.CategoryID;",
                        connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int productID = Convert.ToInt32(reader["ProductID"].ToString());
                    string name = reader["Name"].ToString();
                    double price = Convert.ToDouble(reader["Price"].ToString());
                    Units unit = (Units)Convert.ToInt32(reader["Unit"].ToString());
                    byte[] image = (byte[])reader["Image"];
                    bool Discontinued = Convert.ToBoolean(reader["Discontinued"].ToString());
                    int inStock = Convert.ToInt32(reader["InStock"].ToString());
                    int categoryID = Convert.ToInt32(reader["CategoryID"].ToString());
                    string categoryName = reader["CategoryName"].ToString();
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        int parentID = Convert.ToInt32(reader["ParentID"].ToString());
                        Category category = new Category(categoryID, categoryName, parentID);
                        if (reader["UnitExtension"] != DBNull.Value)
                        {
                            string unitExtension = reader["UnitExtension"].ToString();
                            Product product = new Product(productID, category, name, (float)price, inStock, unit,
                                unitExtension, image, Discontinued);
                            products.Add(product);
                        }
                        else
                        {
                            Product product = new Product(productID, category, name, (float)price, inStock, unit, image,
                                Discontinued);
                            products.Add(product);
                        }
                    }
                    else
                    {

                        Category category = new Category(categoryID, categoryName);
                        if (reader["UnitExtension"] != DBNull.Value)
                        {
                            string unitExtension = reader["UnitExtension"].ToString();
                            Product product = new Product(productID, category, name, (float)price, inStock, unit,
                                unitExtension, image, Discontinued);
                            products.Add(product);
                        }
                        else
                        {
                            Product product = new Product(productID, category, name, (float)price, inStock, unit, image,
                                Discontinued);
                            products.Add(product);
                        }
                    }
                }
            }

        }
        catch (Exception ex)
        {

        }

        return products;
    }

    public Product GetProductById(int id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "select ProductID, Name, Price, unit, UnitExtension, Discontinued, InStock , C.CategoryID, CategoryName, ParentID from Products as p join Categories C on p.CategoryID = C.CategoryID where ProductID = @id;",
                    connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int productID = Convert.ToInt32(reader["ProductID"].ToString());
                    string name = reader["Name"].ToString();
                    double price = Convert.ToDouble(reader["Price"].ToString());
                    Units unit = (Units)Convert.ToInt32(reader["Unit"].ToString());
                    bool Discontinued = Convert.ToBoolean(reader["Discontinued"].ToString());
                    int inStock = Convert.ToInt32(reader["InStock"].ToString());
                    int categoryID = Convert.ToInt32(reader["CategoryID"].ToString());
                    string categoryName = reader["CategoryName"].ToString();
                    byte[] image = (byte[])reader["Image"];
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        int parentID = Convert.ToInt32(reader["ParentID"].ToString());
                        Category category = new Category(categoryID, categoryName, parentID);
                        if (reader["UnitExtension"] != DBNull.Value)
                        {
                            string unitExtension = reader["UnitExtension"].ToString();
                            return new Product(productID, category, name, (float)price, inStock, unit, unitExtension,
                                image, Discontinued);
                        }
                        else
                        {
                            return new Product(productID, category, name, (float)price, inStock, unit, image,
                                Discontinued);
                        }
                    }
                    else
                    {
                        Category category = new Category(categoryID, categoryName);
                        if (reader["UnitExtension"] != DBNull.Value)
                        {
                            string unitExtension = reader["UnitExtension"].ToString();
                            return new Product(productID, category, name, (float)price, inStock, unit, unitExtension,
                                image, Discontinued);
                        }
                        else
                        {
                            return new Product(productID, category, name, (float)price, inStock, unit, image,
                                Discontinued);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }

        return null;
    }

    public void AddProduct(Product product)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "insert into Products (Name, Price, Unit, UnitExtension, Discontinued, InStock, CategoryID, Image) values (@name, @price, @unit, @unitExtension, @discontinued, @inStock, @categoryID, @image);",
                    connection);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@unit", product.Unit);
                if (product.UnitExtension != "")
                    command.Parameters.AddWithValue("@unitExtension", product.UnitExtension);
                else
                    command.Parameters.AddWithValue("@unitExtension", DBNull.Value);
                command.Parameters.AddWithValue("@discontinued", product.IsDiscontinued);
                command.Parameters.AddWithValue("@inStock", product.Stock);
                command.Parameters.AddWithValue("@categoryID", product.Category.Id);
                command.Parameters.AddWithValue("@image", product.Image);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void UpdateProduct(Product product)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "update Products set Name = @name, Price = @price, Unit = @unit, UnitExtension = @unitExtension, Discontinued = @discontinued, InStock = @inStock, CategoryID = @categoryID, Image = @image where ProductID = @id;",
                    connection);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@unit", product.Unit);
                if (product.UnitExtension != "")
                    command.Parameters.AddWithValue("@unitExtension", product.UnitExtension);
                else
                    command.Parameters.AddWithValue("@unitExtension", DBNull.Value);
                command.Parameters.AddWithValue("@discontinued", product.IsDiscontinued);
                command.Parameters.AddWithValue("@inStock", product.Stock);
                command.Parameters.AddWithValue("@categoryID", product.Category.Id);
                command.Parameters.AddWithValue("@image", product.Image);
                command.Parameters.AddWithValue("@id", product.Id);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void DeleteProduct(int id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("update Products set Discontinued = 1 where ProductID = @id",
                    connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
    }

    public List<Product> GetProductsByCategory(int categoryId)
    {
        List<Product> products = new List<Product>();
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "select ProductID, Name, Price, unit, UnitExtension, Discontinued, InStock , C.CategoryID, CategoryName, ParentID from Products as p join Categories C on p.CategoryID = C.CategoryID where C.CategoryID = @id;",
                    connection);
                command.Parameters.AddWithValue("@id", categoryId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int productID = Convert.ToInt32(reader["ProductID"].ToString());
                    string name = reader["Name"].ToString();
                    double price = Convert.ToDouble(reader["Price"].ToString());
                    Units unit = (Units)Convert.ToInt32(reader["Unit"].ToString());
                    bool Discontinued = Convert.ToBoolean(reader["Discontinued"].ToString());
                    int inStock = Convert.ToInt32(reader["InStock"].ToString());
                    int categoryID = Convert.ToInt32(reader["CategoryID"].ToString());
                    string categoryName = reader["CategoryName"].ToString();
                    byte[] image = (byte[])reader["Image"];
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        int parentID = Convert.ToInt32(reader["ParentID"].ToString());
                        Category category = new Category(categoryID, categoryName, parentID);
                        if (reader["UnitExtension"] != DBNull.Value)
                        {
                            string unitExtension = reader["UnitExtension"].ToString();
                            products.Add(new Product(productID, category, name, (float)price, inStock, unit,
                                unitExtension, image, Discontinued));
                        }
                        else
                        {
                            products.Add(new Product(productID, category, name, (float)price, inStock, unit, image,
                                Discontinued));
                        }
                    }
                    else
                    {
                        Category category = new Category(categoryID, categoryName);
                        if (reader["UnitExtension"] != DBNull.Value)
                        {
                            string unitExtension = reader["UnitExtension"].ToString();
                            products.Add(new Product(productID, category, name, (float)price, inStock, unit,
                                unitExtension, image, Discontinued));
                        }
                        else
                        {
                            products.Add(new Product(productID, category, name, (float)price, inStock, unit, image,
                                Discontinued));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }

        return products;
    }

    public List<Product> GetCustomerFavoriteProducts(int customerId)
    {
        List<Product> products = new List<Product>();
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "select ProductID, Name, Price, unit, UnitExtension, Discontinued, InStock , C.CategoryID, CategoryName, ParentID from Products as p join Categories C on p.CategoryID = C.CategoryID join CustomerFavorites CF on p.ProductID = CF.ProductID where CF.CustomerID = @id;",
                    connection);
                command.Parameters.AddWithValue("@id", customerId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int productID = Convert.ToInt32(reader["ProductID"].ToString());
                    string name = reader["Name"].ToString();
                    double price = Convert.ToDouble(reader["Price"].ToString());
                    Units unit = (Units)Convert.ToInt32(reader["Unit"].ToString());
                    bool Discontinued = Convert.ToBoolean(reader["Discontinued"].ToString());
                    int inStock = Convert.ToInt32(reader["InStock"].ToString());
                    int categoryID = Convert.ToInt32(reader["CategoryID"].ToString());
                    string categoryName = reader["CategoryName"].ToString();
                    byte[] image = (byte[])reader["Image"];
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        int parentID = Convert.ToInt32(reader["ParentID"].ToString());
                        Category category = new Category(categoryID, categoryName, parentID);
                        if (reader["UnitExtension"] != DBNull.Value)
                        {
                            string unitExtension = reader["UnitExtension"].ToString();
                            products.Add(new Product(productID, category, name, (float)price, inStock, unit,
                                unitExtension, image, Discontinued));
                        }
                        else
                        {
                            products.Add(new Product(productID, category, name, (float)price, inStock, unit, image,
                                Discontinued));
                        }
                    }
                    else
                    {
                        Category category = new Category(categoryID, categoryName);
                        if (reader["UnitExtension"] != DBNull.Value)
                        {
                            string unitExtension = reader["UnitExtension"].ToString();
                            products.Add(new Product(productID, category, name, (float)price, inStock, unit,
                                unitExtension, image, Discontinued));
                        }
                        else
                        {
                            products.Add(new Product(productID, category, name, (float)price, inStock, unit, image,
                                Discontinued));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }

        return products;
    }
}