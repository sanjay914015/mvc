using Microsoft.EntityFrameworkCore;

namespace MinimalAPI
{
    public class ContainerContext: DbContext
    {

        public ContainerContext(DbContextOptions<ContainerContext> options) : base(options) { }

        public DbSet<container> Containers { get; set; }
    }
}
