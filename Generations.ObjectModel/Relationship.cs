using System.ComponentModel.DataAnnotations;

namespace Generations.ObjectModel
{
    public class Relationship : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Person Person { get; set; } = new();

        [Required]
        public RelationshipTypes Type { get; set; }
    }
}