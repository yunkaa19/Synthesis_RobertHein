using Models.Entities;
using Models.Interfaces.RepositoryInterfaces;

namespace Models.Managers;

public class CategoryManager
{
    private List<Category> _categories;
    private ICategoryRepository _categoryRepository;
    
    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
        _categories = _categoryRepository.GetAllCategories();
    }
    
    public void Refresh()
    {
        _categories = _categoryRepository.GetAllCategories();
    }
    public List<Category> GetAllCategories()
    {
        return _categories;
    }
    
    public Category GetCategoryByName(string name)
    {
        return _categories.FirstOrDefault(c => c.Name == name);
    }
    
    public void RefreshCategories()
    {
        _categories = _categoryRepository.GetAllCategories();
    }
    
    public void AddCategory(Category category)
    {
        _categoryRepository.AddCategory(category);
        RefreshCategories();
    }

    public bool DeleteCategory(Category category)
    {
        if (_categories.Any(c => c.ParentId == category.Id))
        {
            return false;
        }
        else
        {
            _categoryRepository.DeleteCategory(category.Id);
            _categories.Remove(category);
            return true;
        }
    }
    public void UpdateCategory(Category category)
    {
        _categoryRepository.UpdateCategory(category);
        RefreshCategories();
    }
    
    
}