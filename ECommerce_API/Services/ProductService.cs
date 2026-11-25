using Dapper;
using ECommerce_API.Data;
using ECommerce_API.DTOs.Product;
using ECommerce_API.Interfaces;

namespace ECommerce_API.Services
{
    public class ProductService : IProduct
    {
        private readonly DapperContext _context;
        public ProductService(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAllProducts()
        {
            using var connection = _context.CreateConnection();

            string query = @"
                SELECT
                    Id,
                    CategoryId,
                    Name,
                    Slug,
                    Price,
                    StockQuantity,
                    ImageUrl,
                    IsActive
                FROM Products";

            return await connection.QueryAsync<ProductResponseDTO>(query);
        }

        public async Task<ProductResponseDTO> GetProductById(int id)
        {
            using var connection = _context.CreateConnection();

            string query = @"
                SELECT
                    Id,
                    CategoryId,
                    Name,
                    Slug,
                    Price,
                    StockQuantity,
                    ImageUrl,
                    IsActive
                FROM Products
                WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<ProductResponseDTO>(query, new { Id = id });
        }

        public async Task<int> CreateProduct(CreateProductDTO product)
        {
            using var connection = _context.CreateConnection();

            string query = @"
                INSERT INTO Products
                (
                    CategoryId,
                    Name,
                    Slug,
                    Price,
                    StockQuantity,
                    ImageUrl,
                    IsActive
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @CategoryId,
                    @Name,
                    @Slug,
                    @Price,
                    @StockQuantity,
                    @ImageUrl,
                    @IsActive
                )";
            return await connection.QuerySingleAsync<int>(query, product);
        }

        public async Task<bool> UpdateProduct(int id, UpdateProductDTO product)
        {
            using var connection = _context.CreateConnection();
            string query = @"UPDATE Products SET
                    CategoryId = @CategoryId,
                    Name = @Name,
                    Slug = @Slug,
                    Price = @Price,
                    StockQuantity = @StockQuantity,
                    ImageUrl = @ImageUrl,
                    IsActive = @IsActive
                WHERE Id = @Id";

            int rows = await connection.ExecuteAsync(
                query,
                new
                {
                    Id = id,
                    product.CategoryId,
                    product.Name,
                    product.Slug,
                    product.Price,
                    product.StockQuantity,
                    product.ImageUrl,
                    product.IsActive
                }
            );
            return rows > 0;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            using var connection = _context.CreateConnection();
            string query = @"DELETE FROM Products WHERE Id = @Id";
            int rows = await connection.ExecuteAsync(
                query,
                new { Id = id }
            );
            return rows > 0;
        }
    }
}
