using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCtoAPI.Data;

namespace MVCtoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        private static List<Catagory> items = new List<Catagory>
            {
                new Catagory { Id=1, Name = "Banana", CreatedDate= DateTime.Now , description = "ruits" }
            };

        private readonly CatagoryContext _db;
        public CatagoryController(CatagoryContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Catagory>>> Get()
        {
            return Ok(_db.Catagories.ToList());
        }

 

        [HttpGet("{Id}")]
        public async Task<ActionResult<Catagory>> Get(int Id)
        {
            var item = _db.Catagories.Find(Id); 
            if(item == null)
            {
                return BadRequest("Item Not Found"); 
            }
            return Ok(item);
        }


        [HttpPost]
        public async Task<ActionResult<List<Catagory>>> Post(Catagory item)
        {
            await _db.Catagories.AddAsync(item);
            _db.SaveChanges();
            return Ok(_db.Catagories.ToList());
        }


        [HttpPut]
        public async Task<ActionResult<List<Catagory>>> Put(Catagory request)
        {
            var item = _db.Catagories.Find(request.Id);
            if (item == null)
            {
                return BadRequest("Item Not Found");
            }
            item.Id = request.Id;
            item.Name = request.Name;
            item.CreatedDate = request.CreatedDate;
            item.description = request.description;
            _db.SaveChanges();


            return Ok(_db.Catagories.ToList());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Catagory>> Delete(int Id)
        {
            var item = _db.Catagories.Find(Id);
            if (item == null)
            {
                return BadRequest("Item Not Found");
            }
            _db.Catagories.Remove(item);
            _db.SaveChanges();
            return Ok(item);
        }
    }
}
