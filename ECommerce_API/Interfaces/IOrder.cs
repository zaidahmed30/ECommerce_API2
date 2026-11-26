using ECommerce_API.DTOs.Order;

namespace ECommerce_API.Interfaces
{
    public interface IOrder
    {
        Task<IEnumerable<OrderResponseDTO>> GetAllOrders();
        Task<OrderResponseDTO> GetOrderById(long id);
        Task<long> CreateOrder(CreateOrderDTO order);
        Task<bool> UpdateOrder(long id, UpdateOrderDTO order);
        Task<bool> DeleteOrder(long id);
    }
}
