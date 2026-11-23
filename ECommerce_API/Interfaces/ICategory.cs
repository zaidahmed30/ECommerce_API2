using ECommerce_API.DTOs.Category;

namespace ECommerce_API.Interfaces
{
    public interface ICategory
    {
        Task<IEnumerable<CategoryResponseDTO>> GetAllCategories();
        Task<CategoryResponseDTO> GetCategoryById(int id);
        Task<int> CreateCategory(CreateCategoryDTO category);
        Task<bool> UpdateCategory(int id, UpdateCategoryDTO category);
    }
}
