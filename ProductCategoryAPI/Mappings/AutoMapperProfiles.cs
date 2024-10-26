using AutoMapper;
using ProductCategoryAPI.Models.Domain;
using ProductCategoryAPI.Models.DTO;

namespace ProductCategoryAPI.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();

            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, option => option.MapFrom(src => src.Category.CategoryName))
            .ReverseMap();

            CreateMap<Product, AddProductDto>().ReverseMap();
        }
    }
}
