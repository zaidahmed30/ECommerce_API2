using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.DTOs.Order
{
    public class UpdateOrderDTO
    {
        [Required]
        public long AddressId { get; set; }
        public decimal TotalAmount { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
