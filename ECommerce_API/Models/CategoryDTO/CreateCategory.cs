namespace ECommerce_API.Models.CategoryDTO
{
    public class CreateCategory
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
