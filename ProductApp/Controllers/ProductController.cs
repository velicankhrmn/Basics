using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
namespace ProductApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        /*
         * Aşağıda belirtilen ifade bir Depency Injection(DI) ifadesidir.
         * ILogger interface birden fazla class için implemente edilmiş olabilir.
         */

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        // HTTP get methodu ekleniyor.

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>();

            products.Add(new Product(){Id = 1, ProductName = "Computer"});
            products.Add(new Product(){Id = 2, ProductName = "Keyboard"});
            products.Add(new Product(){Id = 3, ProductName = "Mouse"});
            _logger.LogInformation("GetAllProduct method has been called.");
            return Ok(products);
        }
    }
}
