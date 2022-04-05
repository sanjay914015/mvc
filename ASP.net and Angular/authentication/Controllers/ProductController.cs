using authentication.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _db;
        public ProductController(ProductContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(_db.ProductList.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> Post(Product item)
        {
            await _db.ProductList.AddAsync(item);
            _db.SaveChanges();
            return Ok(_db.ProductList.ToList());
        }
    }
}
