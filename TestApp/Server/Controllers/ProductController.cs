using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApp.Domain.Dtos;
using TestApp.Domain.Global;
using TestApp.Domain.Interfaces.Services;
using TestApp.Infrastructure.Models;

namespace TestApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService; 
        private readonly IMapper _mapper;
        public ProductController(ILogger<ProductController> logger, IProductService productService, ICategoryService categoryService ,IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a new product
        /// <paramref name="productModel"/>
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<IActionResult> AddProduct(ProductModel productModel)
        {
            var _mappedroduct = _mapper.Map<Product>(productModel);
            await _productService.Add(_mappedroduct);


            return Ok();
        }

        /// <summary>
        /// Edits the specified product
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [Authorize(Constants.Roles.Admin)]
        public async Task<IActionResult> EditProduct(ProductModel productModel)
        {
            var _mappedroduct = _mapper.Map<Product>(productModel);
            await _productService.Update(_mappedroduct);

            return Ok();
        }

        /// <summary>
        /// Returns a list of all the products
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoryModel>> ListCategory()
        {
            var categories = await _categoryService.GetAll();

            var _mappedroducts = _mapper.Map<IEnumerable<CategoryModel>>(categories);
            return _mappedroducts;
        }


        /// <summary>
        /// Returns a list of all the products
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductModel>> ListProducts()
        {
            var products = await _productService.GetAll();

            var _mappedroducts = _mapper.Map<IEnumerable<ProductModel>>(products);
            return _mappedroducts;
        }

        /// <summary>
        /// Gets a product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ProductModel> GetProductById(Guid productId)
        {
            var product = await _productService.GetOne(productId);

            var _mappedroducts = _mapper.Map<ProductModel>(product);
            return _mappedroducts;
        }

        /// <summary>
        /// Deletes the product with the specified Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            await _productService.Delete(productId);

            return Ok();
        }

    }
}