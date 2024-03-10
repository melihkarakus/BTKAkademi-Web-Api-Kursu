using BTKAkademiApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTKAkademiApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    ID = 1,
                    ProductName = "Book",
                },
                new Product()
                {
                    ID = 2,
                    ProductName = "Keybord",
                }
            };
            _logger.LogInformation("GetAllProducts action has been called.");
            return Ok(products); 
        }

        [HttpPost]
        public IActionResult GetAllProducts([FromBody]Product product)
        {
            _logger.LogWarning("Products Has Been Created");
            return StatusCode(201);
        }
    }
}
