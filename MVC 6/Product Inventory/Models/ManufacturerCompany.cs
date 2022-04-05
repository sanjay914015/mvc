using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Inventory.Models
{
    public class ManufacturerCompany
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public long Contact { get; set; }
        [Required]
        public string WebSite { get; set; }

        [ForeignKey(nameof(Products))]
        public int ProductId { get; set; }

    }
}
