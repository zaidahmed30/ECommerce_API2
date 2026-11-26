namespace ECommerce_API.DTOs.Cart
{
    public class CartResponseDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }
}
