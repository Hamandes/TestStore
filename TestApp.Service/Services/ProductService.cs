using TestApp.Domain.Interfaces.Repositories;
using TestApp.Domain.Interfaces.Services;
using TestApp.Infrastructure.Models;

namespace TestApp.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository; 
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            var productEntity = await _productRepository.GetByNameAsync(product.Name);

            if (productEntity != null)
                throw new Exception($"There is already a product named: {product.Name}");
            else
            {
                await _productRepository.AddAsync(product);
            }

        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetAll()
        {      
            var result = await _productRepository.GetAllAsync();
            if (result == null)
                throw new Exception($"There are no products");

            return result;
        }

        public async Task<Product> GetOne(Guid id)
        {
            var result = await _productRepository.GetAsync(id);
            if (result == null)
                throw new Exception($"There is no product with Id: {id}");

            return result;
        }

        public async Task Update(Product product)
        {
            var result = await _productRepository.GetAsync(product.Id);
            if (result == null)
                throw new Exception($"There is no product with Id: {product.Id}");
            else
            {
                await _productRepository.UpdateAsync(product);
            }
        }


        //var list = new List<Product>();
        //    for (int i = 0; i< 5; i++)
        //    {
        //        var category = new Category() { Name = "CategoryName" + i, Description = "CategoryDescription" + 1 };
        //category.CreatedOn = DateTime.Now;
        //        category.ModifiedOn = DateTime.Now;
        //        category.CreatedBy = "Admin";
        //        category.ModifiedBy = "Admin";

        //        var inventory = new Inventory() { Quantity = 1 };
        //inventory.CreatedOn = DateTime.Now;
        //        inventory.ModifiedOn = DateTime.Now;
        //        inventory.CreatedBy = "Admin";
        //        inventory.ModifiedBy = "Admin";

        //        var p = new Product()
        //        {
        //            Name = "NameProduct" + i,
        //            Price = 12,
        //            Rate = 3,
        //            Category = category,
        //            Inventory = inventory
        //        };

        //list.Add(p);
        //    }
        //    foreach (var item in list)
        //    {
        //        _productRepository.AddAsync(item);
        //    }
    }
}
