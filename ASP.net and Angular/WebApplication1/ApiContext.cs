using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class ApiContext: DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }

    }
}
