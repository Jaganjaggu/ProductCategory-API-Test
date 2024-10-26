namespace ProductCategoryAPI.Models.DTO
{
    public class AddProductDto
    {
        public string Brand { get; set; }
        public string? Model { get; set; }
        public Decimal? Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
