using Microsoft.EntityFrameworkCore;

namespace Product_Invetory.Data
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> ProductList { get; set; }
    }
}
