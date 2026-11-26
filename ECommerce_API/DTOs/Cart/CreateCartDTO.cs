using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.DTOs.Cart
{
    public class CreateCartDTO
    {
        [Required]
        public long UserId { get; set; }
    }
}
