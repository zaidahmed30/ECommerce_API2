using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.DTOs.Category
{
    public class CreateCategoryDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
