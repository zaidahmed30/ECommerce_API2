using ECommerce_API.DTOs.Product;

namespace ECommerce_API.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllProducts();
        Task<ProductResponseDTO> GetProductById(int id);
        Task<int> CreateProduct(CreateProductDTO product);
        Task<bool> UpdateProduct(int id, UpdateProductDTO product);
        Task<bool> DeleteProduct(int id);
    }
}
