using Models.Entities;

namespace Models.Interfaces.RepositoryInterfaces;

public interface ICategoryRepository
{
    List<Category> GetAllCategories();
    Category GetCategory(int id);
    void AddCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(int id);
    
}