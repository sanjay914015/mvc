using System.ComponentModel.DataAnnotations;

namespace Product_Inventory.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        public ICollection<Category> category { get; set; }

        public ICollection<Distributor> distributor { get; set; }
        public ICollection<ManufacturerCompany> manufacturerCompany { get; set; }

        //public Category category { get; set; }
        //public ManufacturerCompany manufacturerCompany { get; set; }
        //public Distributor distributor { get; set; }

        public DateTime AddModificationDate { get; set; }

        [Required]
        public DateTime LastModificationDate { get; set; } = DateTime.Now;

    }
}
