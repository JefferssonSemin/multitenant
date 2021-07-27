using System.Threading.Tasks;
using EFCore.HDelivery.Data.Repositories;
using EFCore.HDelivery.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EFCore.HDelivery.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var products = await _productRepository.GetByIdAsync(id);

            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productRepository.Add(product);
            var saved = _productRepository.Save();

            return Ok(product);
        }
    }
}