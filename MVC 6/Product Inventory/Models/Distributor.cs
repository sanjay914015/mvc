using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Inventory.Models
{
    public class Distributor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DistributorName { get; set; }

        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public long Contact { get; set; }
        [Required]
        public string Email { get; set; }

        [ForeignKey(nameof(Products))]
        public int ProductId { get; set; }

    }
}
