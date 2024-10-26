using Microsoft.EntityFrameworkCore;
using ProductCategoryAPI.Data;
using ProductCategoryAPI.Models.Domain;

namespace ProductCategoryAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductCategoryDbContext dbContext;

        public CategoryRepository(ProductCategoryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> AddCategory(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllCategory()
        {
           return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x=>x.CategoryId==id);
        }
    }
}
