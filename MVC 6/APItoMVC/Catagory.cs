using System.ComponentModel.DataAnnotations;

namespace APItoMVC
{
    public class Catagory
    {
        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public string description { get; set; }
    }
}
