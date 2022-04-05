using System.ComponentModel.DataAnnotations;

namespace authentication
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductType { get; set; }
    }
}
