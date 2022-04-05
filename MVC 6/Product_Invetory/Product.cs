using System.ComponentModel.DataAnnotations;

namespace Product_Invetory
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int price { get; set; }
        public string Beverages { get; set; }
        public string DailyConsume { get; set; }
        [Required]
        public string DistributorName { get; set; }

        [Required]
        public string Address_Street { get; set; }
        [Required]
        public string Address_City { get; set; }
        [Required]
        public string Address_State { get; set; }
        [Required]
        public long Distributor_Contact { get; set; }
        [Required]
        public string Company_Name { get; set; }
        [Required]
        public long Company_Contact { get; set; }

        public DateTime AddModificationDate { get; set; }

        [Required]
        public DateTime LastModificationDate { get; set; } = DateTime.Now;
    }
}
