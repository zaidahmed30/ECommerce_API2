namespace ECommerce_API.DTOs.Product
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
