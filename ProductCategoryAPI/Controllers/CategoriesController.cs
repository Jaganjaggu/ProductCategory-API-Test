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
    public class CategoriesController : ControllerBase
    {
        private readonly ProductCategoryDbContext productCategoryDbContext;
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ProductCategoryDbContext productCategoryDbContext, IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.productCategoryDbContext = productCategoryDbContext;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoryDomain = await categoryRepository.GetAllCategory();

            var categoryDTO = mapper.Map<List<CategoryDto>>(categoryDomain);
            
            return Ok(categoryDTO);
        }

        // GET api/<CategoriesController>/5
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var categoryDomain = await categoryRepository.GetCategoryById(id);

            return Ok(mapper.Map<CategoryDto>(categoryDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCategoryDto addCategoryDto)
        {
            //Map DTO to Domain
            var categoryDomain = mapper.Map<Category>(addCategoryDto);
            
            var result = await categoryRepository.AddCategory(categoryDomain);

            if(result == null)
            {
                return BadRequest("Category id not added");
            }

            //Map Domain to DTO
            var responseDto = mapper.Map<AddCategoryDto>(result);
            return Ok(responseDto);
            //return CreatedAtAction(nameof(GetById), new { id = responseDto.CategoryId }, responseDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var response = await categoryRepository.DeleteCategoryByIdAsync(id);

            if (response == null)
            {
                return BadRequest("Item not found for deletion");
            }

            return Ok(mapper.Map<AddCategoryDto>(response));
        }

    }
}
