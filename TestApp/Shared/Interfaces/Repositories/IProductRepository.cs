using TestApp.Infrastructure.Models;

namespace TestApp.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(Guid id);
        Task<Product> GetByNameAsync(string productName);
        Task<IList<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task Delete(Guid id);
    }
}
