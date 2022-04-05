using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MinimalAPI
{
    [Index(nameof(ContainerID), IsUnique = true)]

    public class container
    {
        [Key]
        public int Id { get; set; }

        public string? ContainerID { get; set; }

        public string? ContainerType { get; set; }

    }
}
