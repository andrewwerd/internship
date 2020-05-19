using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbCard.Context;
using DbCard.Domain;
using DbCard.Services;
using Microsoft.AspNetCore.Authorization;

namespace DbCard.Controllers
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
        public async Task<ActionResult<IEnumerable<Infrastructure.Dto.Category.Category>>> GetCategories()
        {
            return Ok(await _categoryService.GetAll());
        }
        // GET: api/Categories/getSubcategories
        [AllowAnonymous]
        [HttpGet("getSubcategories/{id}")]
        public async Task<ActionResult<IEnumerable<Infrastructure.Dto.Category.Subcategory>>> GetSubcategories(long id)
        {
            return Ok(await _categoryService.GetSubcategories(id));
        }

    }
}
