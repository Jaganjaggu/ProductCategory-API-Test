using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCategoryAPI.Data;
using ProductCategoryAPI.Models.Domain;
using ProductCategoryAPI.Models.DTO;
using ProductCategoryAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductCategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductCategoryDbContext productCategoryDbContext;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductsController(ProductCategoryDbContext productCategoryDbContext, IMapper mapper, IProductRepository productRepository)
        {
            this.productCategoryDbContext = productCategoryDbContext;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await productRepository.GetProductsWithCategory();

            //Map Domain to Dto
            var productDto = mapper.Map<List<ProductDto>>(response);
            return Ok(productDto);
        }

        // GET api/<ProductsController>/5
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
            var response = await productRepository.GetProductWithId(id);

            //Map Domain to Dto
            var productDto = mapper.Map<ProductDto>(response);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto addProductDto)
        {
            //Map DTO to Domain
            var productDomain = mapper.Map<Product>(addProductDto);
            var response = await productRepository.CreateProduct(productDomain);

            //Map Domain to DTO
            return Ok(mapper.Map<AddProductDto>(response));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateProductByid([FromRoute] Guid id, [FromBody] AddProductDto addProductDto)
        {
            //Map DTO to domain
            var productDomain = mapper.Map<Product>(addProductDto);

            var response = await productRepository.UpdateByIdAsync(id, productDomain);
            
            if (response == null)
            {
                return NotFound();
            }

            //Map Domain to DTO
            return Ok(mapper.Map<Product>(response));
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteProductByIdAsync([FromRoute] Guid id)
        {
            var response = await productRepository.DeleteByIdAsync(id);

            if(response == null)
            {
                return BadRequest("Item not found for deletion");
            }

            return Ok(mapper.Map<AddProductDto>(response));
        }
    }
}
