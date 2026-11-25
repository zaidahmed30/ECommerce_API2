using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        public bool IsActive { get; set; }
        public object Price { get; internal set; }
    }
}
