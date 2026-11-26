using ECommerce_API.Data;
using ECommerce_API.DTOs.Order;
using ECommerce_API.Interfaces;

namespace ECommerce_API.Services
{
    public class OrderService : IOrder
    {
        private readonly DapperContext _context;
        public OrderService(DapperContext context)
        {
            _context = context;
        }

        public Task<long> CreateOrder(CreateOrderDTO order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrder(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderResponseDTO>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponseDTO> GetOrderById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrder(long id, UpdateOrderDTO order)
        {
            throw new NotImplementedException();
        }
    }
}
