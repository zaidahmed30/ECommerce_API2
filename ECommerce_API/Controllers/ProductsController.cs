using ECommerce_API.DTOs.Product;
using ECommerce_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductsController(IProduct product)
        {
            _product = product;
        }
     
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _product.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _product.GetProductById(id);
            if (result == null)
            {
                return NotFound("Product not found");
            }                
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO product)
        {
            int newId = await _product.CreateProduct(product);
            return Ok(new
            {
                Message = "Product created successfully",
                Id = newId
            });
        }
      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDTO product)
        {
            bool result = await _product.UpdateProduct(id, product);
            if (!result)
            {
                return NotFound("Product not found");
            }                
            return Ok("Product updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool result = await _product.DeleteProduct(id);
            if (!result)
            {
                return NotFound("Product not found");
            }
            return Ok("Product deleted successfully");
        }
    }
}