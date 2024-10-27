using ProductCategoryAPI.Models.Domain;

namespace ProductCategoryAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategory();
        Task<Category?> GetCategoryById(Guid id);
        Task<Category> AddCategory(Category category);
        Task<Category?> DeleteCategoryByIdAsync(Guid id);
    }
}
