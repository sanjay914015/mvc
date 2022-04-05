using Microsoft.EntityFrameworkCore;
using Product_Inventory.Models;

namespace Product_Inventory.Data
{
    public class ProductsContext: DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }
        public DbSet<Products> ProductList { get; set; }
        public DbSet<Category> category  { get; set; }
        public DbSet<Distributor> distributor { get; set; }
        public DbSet<ManufacturerCompany> manufacturercompany { get; set; }
    }
}
