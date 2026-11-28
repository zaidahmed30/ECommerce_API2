using Dapper;
using ECommerce_API.Data;
using ECommerce_API.DTOs.CartItem;
using ECommerce_API.Interfaces;

namespace ECommerce_API.Services
{
    public class CartItemService : ICartItem
    {
        private readonly DapperContext _context;
        public CartItemService(DapperContext context)
        {
            _context = context;
        }
        public async Task<long> AddCartItem(AddCartItemDTO cartItem)
        {
            using var connection = _context.CreateConnection();

            string query = @"
                INSERT INTO CartItems
                (
                    CartId,
                    ProductId,
                    Quantity
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @CartId,
                    @ProductId,
                    @Quantity
                )";

            return await connection.QuerySingleAsync<long>(query, cartItem);
        }

        public async Task<bool> DeleteCartItem(long id)
        {
            using var connection = _context.CreateConnection();
            string query = @"
                DELETE FROM CartItems
                WHERE Id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }

        public async Task<IEnumerable<ResponseCartItemDTO>> GetAllCartItems()
        {
            using var connection = _context.CreateConnection();
            string query = @"
                SELECT Id, CartId, ProductId, Quantity
                FROM CartItems";
            return await connection.QueryAsync<ResponseCartItemDTO>(query);
        }

        public async Task<ResponseCartItemDTO> GetCartItemById(long id)
        {
            using var connection = _context.CreateConnection();
            string query = @"
                SELECT Id, CartId, ProductId, Quantity
                FROM CartItems
                WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<ResponseCartItemDTO>(query, new { Id = id });
        }

        public async Task<bool> UpdateCartItem(long id, UpdateCartItemDTO cartItem)
        {
            using var connection = _context.CreateConnection();
            string query = @"
                UPDATE CartItems
                SET Quantity = @Quantity
                WHERE Id = @Id";

            int rows = await connection.ExecuteAsync(
                query,
                new
                {
                    Id = id,
                    cartItem.Quantity
                }
            );
            return rows > 0;
        }
    }
}
