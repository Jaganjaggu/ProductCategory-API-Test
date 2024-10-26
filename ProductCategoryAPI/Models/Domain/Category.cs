using System.ComponentModel.DataAnnotations;

namespace ProductCategoryAPI.Models.Domain
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
