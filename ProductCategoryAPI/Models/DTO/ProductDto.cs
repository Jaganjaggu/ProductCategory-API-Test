
using ProductCategoryAPI.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductCategoryAPI.Models.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string? Model { get; set; }
        public Decimal? Price { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
