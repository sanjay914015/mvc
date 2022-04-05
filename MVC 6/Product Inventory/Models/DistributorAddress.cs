using System.ComponentModel.DataAnnotations;


namespace Product_Inventory.Models
{
    public class DistributorAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int PinCode { get; set; }

    }
}
