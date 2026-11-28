using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.DTOs.CartItem
{
    public class AddCartItemDTO
    {
        [Required]
        public long CartId { get; set; }
        [Required]
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
