using TestApp.BL.Requests;
using TestApp.Domain.Models;

namespace TestApp.BL.Services.Product
{
    public interface IProductService
    {
        Task<Product> GetProductAsync(string productId);
        Task<Product> UpdateProductAsync(string productId);
        Task<Product> CreateProductAsync(CreateProductRequest request);
        Task<Product> DeleteProductAsync(string productId);
    }
}
