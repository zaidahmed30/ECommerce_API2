namespace ECommerce_API.DTOs.CartItem
{
    public class ResponseCartItemDTO
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
