using Microsoft.EntityFrameworkCore;
using TestApp.Domain.Interfaces.Repositories;
using TestApp.Infrastructure.Models;

namespace TestApp.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            try
            {
                product.CreatedOn = DateTime.Now;
                product.ModifiedOn = DateTime.Now;
                product.CreatedBy = "Admin";
                product.ModifiedBy = "Admin";

                var newProduct = await _context.Products.AddAsync(product);

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
                var product = _context.Products.FirstOrDefault(x => x.Id == id);

                _context.Products.Remove(product);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            try
            {
                var product = await _context.Products
                  .Include(x => x.Category)
                  .Include(x => x.Inventory)
                  .AsNoTracking()
                  .ToListAsync();

                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Product> GetAsync(Guid id)
        {
            try
            {
                var product = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);

                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Product> GetByNameAsync(string productName)
        {
            try
            {
                return await _context.Products.FirstOrDefaultAsync(x => x.Name == productName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task UpdateAsync(Product product)
        {
            try
            {
                product.CreatedOn = DateTime.Now;
                product.ModifiedOn = DateTime.Now;
                product.CreatedBy = "Admin";
                product.ModifiedBy = "Admin";

                _context.Products.Update(product);
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
