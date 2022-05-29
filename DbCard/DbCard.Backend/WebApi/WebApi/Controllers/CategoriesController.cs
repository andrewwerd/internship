using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Infrastructure.DTO.Category;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return Ok(await _categoryService.GetAll());
        }
        // GET: api/Categories/getSubcategories
        [AllowAnonymous]
        [HttpGet("getSubcategories/{id}")]
        public async Task<ActionResult<IEnumerable<Subcategory>>> GetSubcategories(long id)
        {
            return Ok(await _categoryService.GetSubcategories(id));
        }

    }
}
