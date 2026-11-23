namespace ECommerce_API.DTOs.Category
{
    public class CategoryResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }
    }
}
