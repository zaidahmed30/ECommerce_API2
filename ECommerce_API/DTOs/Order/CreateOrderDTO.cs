using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.DTOs.Order
{
    public class CreateOrderDTO
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public long AddressId { get; set; }
        public decimal TotalAmount { get; set; }
        [Required]
        public string Status { get; set; } = "Pending";
    }
}
