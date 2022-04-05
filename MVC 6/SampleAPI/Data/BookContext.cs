using Microsoft.EntityFrameworkCore;

namespace SampleAPI.Data
{
    public class BookContext: DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
        public DbSet<Book> BookList { get; set; }
    }
}
