using TestApp.Infrastructure.Models;

namespace TestApp.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(Guid id);
        Task<Category> GetByNameAsync(string categoryName);
        Task<IList<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task Delete(Guid id);
    }
}
