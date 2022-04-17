using TestApp.Domain.Interfaces.Repositories;
using TestApp.Domain.Interfaces.Services;
using TestApp.Infrastructure.Models;

namespace TestApp.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Add(Category category)
        {
            var productEntity = await _categoryRepository.GetByNameAsync(category.Name);

            if (productEntity != null)
                throw new Exception($"There is already a category named: {category.Name}");
            else
            {
                await _categoryRepository.AddAsync(category);
            }

        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Category>> GetAll()
        {
            var result = await _categoryRepository.GetAllAsync();
            if (result == null)
                throw new Exception($"There are no categories");

            return result;
        }

        public async Task<Category> GetOne(Guid id)
        {
            var result = await _categoryRepository.GetAsync(id);
            if (result == null)
                throw new Exception($"There is no category with Id: {id}");

            return result;
        }

        public async Task Update(Category category)
        {
            var result = await _categoryRepository.GetAsync(category.Id);
            if (result == null)
                throw new Exception($"There is no category with Id: {category.Id}");
            else
            {
                await _categoryRepository.UpdateAsync(category);
            }
        }
    }
}
