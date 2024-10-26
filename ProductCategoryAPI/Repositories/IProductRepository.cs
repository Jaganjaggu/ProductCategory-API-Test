using ProductCategoryAPI.Data;
using ProductCategoryAPI.Models.Domain;

namespace ProductCategoryAPI.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsWithCategory();
        Task<Product?> GetProductWithId(Guid id);
        Task<Product> CreateProduct(Product product);
        Task<Product?> DeleteByIdAsync(Guid id);
        Task<Product?> UpdateByIdAsync(Guid id, Product product);
    }
}
