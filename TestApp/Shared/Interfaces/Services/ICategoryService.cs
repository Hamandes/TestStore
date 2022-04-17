using TestApp.Infrastructure.Models;

namespace TestApp.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAll();
        Task<Category> GetOne(Guid id);
        Task Update(Category product);
        Task Add(Category product);
        Task Delete(Guid id);
    }
}