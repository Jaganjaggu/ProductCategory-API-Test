using Microsoft.EntityFrameworkCore;
using ProductCategoryAPI.Models.Domain;

namespace ProductCategoryAPI.Data
{
    public class ProductCategoryDbContext: DbContext
    {
        //EF Code first approach - Doc
        public ProductCategoryDbContext(DbContextOptions<ProductCategoryDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
