using System.ComponentModel.DataAnnotations;

namespace SampleAPI
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Book_Name { get; set; }

        [Required]

        public string Author_Name { get; set; }

        [Required]

        public int Price { get; set; }

    }
}
