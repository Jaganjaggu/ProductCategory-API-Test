using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCategoryAPI.Models.Domain
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string? Model { get; set; }
        public Decimal? Price { get; set; }
        public Guid CategoryId { get; set; }

        //Navigation Prperty
        [ForeignKey("CategoryId") ]
        public Category Category { get; set; }
    }
}
