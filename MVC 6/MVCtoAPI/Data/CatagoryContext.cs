using Microsoft.EntityFrameworkCore;

namespace MVCtoAPI.Data
{
    public class CatagoryContext: DbContext
    {
        public CatagoryContext(DbContextOptions<CatagoryContext> options) : base(options)
        {
        }
        public DbSet<Catagory> Catagories { get; set; }
    }
}
