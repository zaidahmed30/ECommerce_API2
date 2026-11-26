using ECommerce_API.DTOs.Cart;

namespace ECommerce_API.Interfaces
{
    public interface ICart
    {
        Task<IEnumerable<CartResponseDTO>> GetAllCarts();
        Task<CartResponseDTO> GetCartById(long id);
        Task<long> CreateCart(CreateCartDTO cart);
        Task<bool> UpdateCart(long id);
        Task<bool> DeleteCart(long id);
    }
}
