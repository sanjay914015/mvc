using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Product_Inventory.Data;
using Product_Inventory.Models;

namespace Product_Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _db;
        public ProductsController(ProductsContext db)
        {
            _db = db;
        }

        [HttpGet]

        public async Task<ActionResult<List<Products>>> Get()
        {
            string strjson = JsonSerializer.Create(_db.ProductListq);
            //return JsonConvert.SerializeObject(rootJSONObject);
            return Ok(strjson);
        }
    }
}
