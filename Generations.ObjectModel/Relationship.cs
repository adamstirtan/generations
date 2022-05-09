using System.ComponentModel.DataAnnotations;

namespace Generations.ObjectModel
{
    public class Relationship : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // PersonId

        [Required]
        public RelationshipTypes Type { get; set; }
    }
}