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

        public Task<bool> DeleteCart(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartResponseDTO>> GetAllCarts()
        {
            throw new NotImplementedException();
        }

        public Task<CartResponseDTO> GetCartById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCart(long id)
        {
            throw new NotImplementedException();
        }
    }
}
