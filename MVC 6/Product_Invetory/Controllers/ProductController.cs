using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Invetory.Data;

namespace Product_Invetory.Controllers
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

        [HttpGet("{Id}")]

        public async Task<ActionResult<Product>> GetById(int Id)
        {
            var productitem = _db.ProductList.Find(Id);

            if (productitem == null)
            {
                return BadRequest("Product Doesn't Exists");
            }
            return Ok(productitem);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> Post(Product item)
        {
            await _db.ProductList.AddAsync(item);
            _db.SaveChanges();
            return Ok(_db.ProductList.ToList());
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Product>> Put(int Id)
        {
            return Ok(Put(Id));
        }


        [HttpPut]
        public async Task<ActionResult<List<Product>>> Put(int Id, Product item)
        {
            var Productitem = _db.ProductList.Find(item.Id);

            if (Productitem == null)
            {
                return BadRequest("Product Not Found");
            }
            Productitem.Id = item.Id;
            Productitem.ProductName = item.ProductName;
            Productitem.Quantity = item.Quantity;
            Productitem.price = item.price;
            Productitem.Beverages = item.Beverages;
            Productitem.DailyConsume = item.DailyConsume;
            Productitem.DistributorName = item.DistributorName;
            Productitem.Address_Street = item.Address_Street;
            Productitem.Address_City = item.Address_City;
            Productitem.Address_State = item.Address_State;
            Productitem.Distributor_Contact = item.Distributor_Contact;
            Productitem.Company_Name = item.Company_Name;
            Productitem.Company_Contact = item.Company_Contact;
            Productitem.AddModificationDate = item.AddModificationDate;
            Productitem.LastModificationDate = item.LastModificationDate;




            _db.SaveChanges();

            return Ok(item);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Product>>> DeleteById(int Id)
        {
            var productitem = _db.ProductList.Find(Id);
            if (productitem == null)
            {
                return NotFound("Entered Prooduct ID Doesn't Exist");
            }
            _db.ProductList.Remove(productitem);
            _db.SaveChanges();
            return Ok(productitem);
        }

    }
}
