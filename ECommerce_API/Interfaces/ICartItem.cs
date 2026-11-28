using ECommerce_API.DTOs.CartItem;

namespace ECommerce_API.Interfaces
{
    public interface ICartItem
    {
        Task<IEnumerable<ResponseCartItemDTO>> GetAllCartItems();
        Task<ResponseCartItemDTO> GetCartItemById(long id);
        Task<long> AddCartItem(AddCartItemDTO cartItem);
        Task<bool> UpdateCartItem(long id, UpdateCartItemDTO cartItem);
        Task<bool> DeleteCartItem(long id);
    }
}
