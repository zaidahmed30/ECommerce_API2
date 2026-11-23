using Dapper;
using ECommerce_API.Data;
using ECommerce_API.DTOs.Category;
using ECommerce_API.Interfaces;

namespace ECommerce_API.Services
{
    public class CategoryService : ICategory
    {
        private readonly DapperContext _context;
        public CategoryService(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCategory(CreateCategoryDTO category)
        {
            using var connection = _context.CreateConnection();
            string query = @"INSERT INTO Categories (Name, Slug, IsActive) OUTPUT INSERTED.Id VALUES (@Name, @Slug, @IsActive)";
            return await connection.QuerySingleAsync<int>(
                query,
                category
            );
        }

        public async Task<IEnumerable<CategoryResponseDTO>> GetAllCategories()
        {
            using var connection = _context.CreateConnection();
            string query = @"SELECT Id, Name, Slug, IsActive FROM Categories";
            return await connection.QueryAsync<CategoryResponseDTO>(query);
        }

        public async Task<CategoryResponseDTO> GetCategoryById(int id)
        {
            using var connection = _context.CreateConnection();
            string query = @"SELECT Id, Name, Slug, IsActive FROM Categories WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync
                <CategoryResponseDTO>(query, new { Id = id });
        }

        public async Task<bool> UpdateCategory(int id, UpdateCategoryDTO category)
        {
            using var connection = _context.CreateConnection();
            string query = @"UPDATE Categories SET Name = @Name, Slug = @Slug, IsActive = @IsActive WHERE Id = @Id";
            int rows = await connection.ExecuteAsync(
                query,
                new
                {
                    Id = id,
                    category.Name,
                    category.Slug,
                    category.IsActive
                }
            );
            return rows > 0;
        }
    }
}
