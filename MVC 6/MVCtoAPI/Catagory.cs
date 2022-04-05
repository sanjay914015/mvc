using System.ComponentModel.DataAnnotations;

namespace MVCtoAPI
{
    public class Catagory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public string description { get; set; }
    }
}
