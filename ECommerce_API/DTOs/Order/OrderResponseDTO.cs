namespace ECommerce_API.DTOs.Order
{
    public class OrderResponseDTO
    {
        public long Id { get; set; }
        public string OrderNumber { get; set; }
        public long UserId { get; set; }
        public long AddressId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
