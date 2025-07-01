using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductListApp.Models;

namespace ProductListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>();

        [HttpGet("GetProductDetails")]
        public IActionResult GetProductDetails() => Ok(_products);

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return Ok(product);
        }
    }
}
