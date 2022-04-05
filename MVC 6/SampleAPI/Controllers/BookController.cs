using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Data;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _db;
        public BookController(BookContext db)
        {
            _db = db;
        }

        //Get 
        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            return Ok(_db.BookList.ToList());
        }

        //Get Data by Id

        [HttpGet("{Id}")]

        public async Task<ActionResult<Book>> GetById(int Id)
        {
            var bookitem = _db.BookList.Find(Id);

            if(bookitem == null)
            {
                return BadRequest("Book Doesn't Exists");
            }
            return Ok(bookitem);
        }

        //Post Data
        [HttpPost]
        public async Task<ActionResult<List<Book>>> Post(Book item)
        {
            await _db.BookList.AddAsync(item);
            _db.SaveChanges();
            return Ok(_db.BookList.ToList());
        }

        //put request

        [HttpPut]
        public async Task<ActionResult<List<Book>>> Put(Book item)
        {
            var Bookitem = _db.BookList.Find(item.Id);

            if(Bookitem == null)
            {
                return BadRequest("Book Not Found");
            }
            Bookitem.Book_Name = item.Book_Name; 
            Bookitem.Author_Name = item.Author_Name;
            Bookitem.Price = item.Price;
            _db.SaveChanges();

            return Ok(item) ;
        }


        //Delete Data

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Book>>> DeleteById(int Id)
        {
            var Bookitem = _db.BookList.Find(Id);
            if(Bookitem == null)
            {
                return NotFound("Entered Book ID Doesn't Exist");
            }
            _db.BookList.Remove(Bookitem);
            _db.SaveChanges();
            return Ok(Bookitem);
        }

    }
}
