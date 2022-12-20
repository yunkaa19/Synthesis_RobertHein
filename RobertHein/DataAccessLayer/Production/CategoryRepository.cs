using Models.Entities;
using DataAccessLayer.Interfaces;
using System.Data.SqlClient;

namespace DataAccessLayer.Production;

public class CategoryRepository : Repository, ICategoryRepository
{
    public List<Category> GetAllCategories()
    {
        List<Category> categories = new List<Category>();
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Categories", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["ParentId"] == DBNull.Value)
                    {
                        int Id = Convert.ToInt32(reader["CategoryID"].ToString());
                        string Name = reader["CategoryName"].ToString();
                        Category category = new Category(Id, Name);
                        categories.Add(category);
                    }
                    else
                    {
                        int Id = Convert.ToInt32(reader["CategoryID"].ToString());
                        string Name = reader["Name"].ToString();
                        int ParentId = Convert.ToInt32(reader["ParentID"].ToString());
                        Category category = new Category(Id, Name, ParentId);
                        categories.Add(category);
                    }
                }


            }
        }
        catch (Exception ex)
        {
            
        } 
        return categories;
        
    }

    public Category GetCategory(int id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Categories WHERE CategoryID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["ParentId"] == DBNull.Value)
                    {
                        int Id = Convert.ToInt32(reader["Id"].ToString());
                        string Name = reader["Name"].ToString();
                        Category category = new Category(Id, Name);
                        return category;
                    }
                    else
                    {
                        int Id = Convert.ToInt32(reader["Id"].ToString());
                        string Name = reader["Name"].ToString();
                        int ParentId = Convert.ToInt32(reader["ParentId"].ToString());
                        Category category = new Category(Id, Name, ParentId);
                        return category;
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }

        return null;
    }

    public void AddCategory(Category category)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                if (category.ParentId == null)
                {
                    connection.Open();
                    SqlCommand command =
                        new SqlCommand("INSERT INTO Categories (CategoryName) VALUES (@Name)",
                            connection);
                    command.Parameters.AddWithValue("@Name", category.Name);
                    command.ExecuteNonQuery();
                }
                else
                {
                    connection.Open();
                    SqlCommand command =
                        new SqlCommand("INSERT INTO Categories (CategoryName, ParentId) VALUES (@Name, @ParentId)",
                            connection);
                    command.Parameters.AddWithValue("@Name", category.Name);
                    command.Parameters.AddWithValue("@ParentId", category.ParentId);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateCategory(Category category)
    {
        try
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                if (category.ParentId != null)
                {
                    connection.Open();
                    SqlCommand command =
                        new SqlCommand(
                            "UPDATE Categories SET CategoryName = @Name, ParentId = @ParentID WHERE CategoryID = @Id",
                            connection);
                    command.Parameters.AddWithValue("@Name", category.Name);
                    command.Parameters.AddWithValue("@ParentId", category.ParentId);
                    command.Parameters.AddWithValue("@Id", category.Id);
                    command.ExecuteNonQuery();
                }
                else
                {
                    connection.Open();
                    SqlCommand command =
                        new SqlCommand(
                            "UPDATE Categories SET CategoryName = @Name WHERE CategoryID = @Id",
                            connection);
                    command.Parameters.AddWithValue("@Name", category.Name);
                    command.Parameters.AddWithValue("@Id", category.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void DeleteCategory(int id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Categories WHERE CategoryID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
    }
}