using Microsoft.Extensions.Logging;
using TestApp.BL.Requests;
using TestApp.DAL.Repositories;
using TestApp.Domain.Models;

namespace TestApp.BL.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;
        public ProductService(ILogger<ProductService> logger, IProductRepository _productRepository)
        {
            _logger = logger;
            _productRepository = _productRepository;
        }

        public Task< > CreateProductAsync(CreateProductRequest request)
        {
            Product
 
        }

        public Task<ProductDto> DeleteProductAsync(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> UpdateProductAsync(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
