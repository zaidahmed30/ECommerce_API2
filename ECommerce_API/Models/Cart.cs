namespace ECommerce_API.Models
{
    public class Cart
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }
}
