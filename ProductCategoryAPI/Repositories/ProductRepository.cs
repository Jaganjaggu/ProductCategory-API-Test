using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductCategoryAPI.Data;
using ProductCategoryAPI.Models.Domain;

namespace ProductCategoryAPI.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ProductCategoryDbContext dbContext;

        public ProductRepository(ProductCategoryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteByIdAsync(Guid id)
        {
            var exist = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (exist == null)
            {
                return null;
            }
            dbContext.Products.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await dbContext.Products
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Product?> GetProductWithId(Guid id)
        {
            return await dbContext.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product?> UpdateByIdAsync(Guid id, Product product)
        {
            var existData = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (existData == null)
            {
                return null;
            }
            existData.Brand = product.Brand;
            existData.Model = product.Model;
            existData.Price = product.Price;
            existData.CategoryId = product.CategoryId;
            
            await dbContext.SaveChangesAsync();
            return existData;

        }
    }
}
