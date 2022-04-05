using Microsoft.EntityFrameworkCore;
using sample_application.Models;
namespace sample_application.Data
{
    public class CatagoryContext: DbContext
    {
        public CatagoryContext(DbContextOptions<CatagoryContext> options) : base(options)
        {

        }
        public DbSet<Catagory> Catagories { get; set; } 
    }
}
