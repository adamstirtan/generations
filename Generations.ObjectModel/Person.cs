using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generations.ObjectModel
{
    public class Person : BaseModel
    {
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; } = string.Empty;
    }
}