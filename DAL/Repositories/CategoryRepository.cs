using Microsoft.EntityFrameworkCore;
using TestApp.DAL;
using TestApp.Domain.Interfaces.Repositories;
using TestApp.Infrastructure.Models;

namespace TestApp.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            try
            {
                category.CreatedOn = DateTime.Now;
                category.ModifiedOn = DateTime.Now;
                category.CreatedBy = "Admin";
                category.ModifiedBy = "Admin";

                var newProduct = await _context.Categories.AddAsync(category);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(x => x.Id == id);

                _context.Categories.Remove(category);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            try
            {
                var categories = await _context.Categories 
                  .AsNoTracking()
                  .ToListAsync();

                return categories;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Category> GetAsync(Guid id)
        {
            try
            {
                var category = _context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == id);

                return category;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Category> GetByNameAsync(string categoryName)
        {
            try
            {
                return await _context.Categories.FirstOrDefaultAsync(x => x.Name == categoryName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task UpdateAsync(Category category)
        {
            try
            {
                category.CreatedOn = DateTime.Now;
                category.ModifiedOn = DateTime.Now;
                category.CreatedBy = "Admin";
                category.ModifiedBy = "Admin";

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
