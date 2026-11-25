using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.DTOs.Product
{
    public class CreateProductDTO
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
