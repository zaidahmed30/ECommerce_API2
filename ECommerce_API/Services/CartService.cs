using Dapper;
using ECommerce_API.Data;
using ECommerce_API.DTOs.Cart;
using ECommerce_API.Interfaces;

namespace ECommerce_API.Services
{
    public class CartService : ICart
    {
        private readonly DapperContext _context;
        public CartService(DapperContext context)
        {
            _context = context;
        }

        public async Task<long> CreateCart(CreateCartDTO cart)
        {
            using var connection = _context.CreateConnection();
            string query = @"
                INSERT INTO Carts
                (
                    UserId,
                    CreatedAtUtc,
                    UpdatedAtUtc
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @UserId,
                    @CreatedAtUtc,
                    @UpdatedAtUtc
                )";

            var parameters = new
            {
                cart.UserId,
                CreatedAtUtc = DateTime.UtcNow,
                UpdatedAtUtc = DateTime.UtcNow
            };

            return await connection.QuerySingleAsync<long>(query, parameters);
        }

        public async Task<bool> DeleteCart(long id)
        {
            using var connection = _context.CreateConnection();
            string query = @"
                DELETE FROM Carts
                WHERE Id = @Id";

            int rows = await connection.ExecuteAsync(query, new { Id = id });
            return rows > 0;
        }

        public async Task<IEnumerable<CartResponseDTO>> GetAllCarts()
        {
            using var connection = _context.CreateConnection();
            string query = @"
                SELECT
                    Id,
                    UserId,
                    CreatedAtUtc,
                    UpdatedAtUtc
                FROM Carts";
            return await connection.QueryAsync<CartResponseDTO>(query);
        }

        public async Task<CartResponseDTO> GetCartById(long id)
        {
            using var connection = _context.CreateConnection();
            string query = @"
                SELECT
                    Id,
                    UserId,
                    CreatedAtUtc,
                    UpdatedAtUtc
                FROM Carts
                WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<CartResponseDTO>(query, new { Id = id });
        }

        public async Task<bool> UpdateCart(long id)
        {
            using var connection = _context.CreateConnection();
            string query = @"
                UPDATE Carts
                SET UpdatedAtUtc = @UpdatedAtUtc
                WHERE Id = @Id";

            int rows = await connection.ExecuteAsync(
                query,
                new
                {
                    Id = id,
                    UpdatedAtUtc = DateTime.UtcNow
                }
            );
            return rows > 0;
        }
    }
}
