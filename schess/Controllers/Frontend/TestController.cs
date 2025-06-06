using Microsoft.AspNetCore.Mvc;

namespace SCHESS.Controllers.Frontend
{
    public class TestController : BaseFrontendController
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<string> { "Product A", "Product B" };
            return Ok(products);
        }
    }
}
