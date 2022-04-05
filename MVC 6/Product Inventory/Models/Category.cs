using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Inventory.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int price { get; set; }
        public string Beverages { get; set; }
        public string DailyConsume { get; set; }

        [ForeignKey(nameof(Products))]
        public int ProductId { get; set; }
    }
}
