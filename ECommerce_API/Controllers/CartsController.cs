using ECommerce_API.DTOs.Cart;
using ECommerce_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICart _cart;
        public CartsController(ICart cart)
        {
            _cart = cart;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            var result = await _cart.GetAllCarts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(long id)
        {
            var result = await _cart.GetCartById(id);
            if (result == null)
            {
                return NotFound("Cart not found");
            }                
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart(CreateCartDTO cart)
        {
            long newId = await _cart.CreateCart(cart);
            return Ok(new
            {
                Message = "Cart created successfully",
                Id = newId
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(long id)
        {
            bool result = await _cart.UpdateCart(id);
            if (!result)
            {
                return NotFound("Cart not found");
            }                
            return Ok("Cart updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(long id)
        {
            bool result = await _cart.DeleteCart(id);
            if (!result)
            {
                return NotFound("Cart not found");
            }
            return Ok("Cart deleted successfully");
        }
    }
}
