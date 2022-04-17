using TestApp.Infrastructure.Models;

namespace TestApp.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<IList<Product>> GetAll();
        Task<Product> GetOne(Guid id);
        Task Update(Product product);
        Task Add(Product product);
        Task Delete(Guid id);
    }
}
