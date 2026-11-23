using ECommerce_API.DTOs.Category;
using ECommerce_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoriesController(ICategory category)
        {
            _category = category;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _category.GetAllCategories();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _category.GetCategoryById(id);
            if (result == null)
            {
                return NotFound("Category not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO category)
        {
            int newId = await _category.CreateCategory(category);
            return Ok(new
            {
                Message = "Category created successfully",
                Id = newId
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDTO category)
        {
            bool result = await _category.UpdateCategory(id, category);
            if (!result)
            {
                return NotFound("Category not found");
            }
            return Ok("Category updated successfully");
        }
    }
}