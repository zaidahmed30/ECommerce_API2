using ECommerce_API.DTOs.CartItem;
using ECommerce_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItem _cartItem;

        public CartItemsController(ICartItem cartItem)
        {
            _cartItem = cartItem;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartItems()
        {
            var result = await _cartItem.GetAllCartItems();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItemById(long id)
        {
            var result = await _cartItem.GetCartItemById(id);
            if (result == null)
            {
                return NotFound("Cart item not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem(AddCartItemDTO cartItem)
        {
            long newId = await _cartItem.AddCartItem(cartItem);
            return Ok(new
            {
                Message = "Cart item added successfully",
                Id = newId
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(long id, UpdateCartItemDTO cartItem)
        {
            bool result = await _cartItem.UpdateCartItem(id, cartItem);
            if (!result)
            {
                return NotFound("Cart item not found");
            }                
            return Ok("Cart item updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(long id)
        {
            bool result = await _cartItem.DeleteCartItem(id);
            if (!result)
            {
                return NotFound("Cart item not found");
            }                
            return Ok("Cart item deleted successfully");
        }
    }
}
