using System.ComponentModel.DataAnnotations;

namespace Generations.ObjectModel
{
    public class Person : BaseModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        public string FormerName { get; set; } = string.Empty;

        public string MaidenName { get; set; } = string.Empty;

        public string NamePrefix { get; set; } = string.Empty;

        public string NameSuffix { get; set; } = string.Empty;

        public string NickName { get; set; } = string.Empty;

        public DateOnly? BirthDate { get; set; }

        public Place? BirthPlace { get; set; } = null;

        public DateOnly? DeathDate { get; set; }

        public Relationship Relationship { get; set; } = new();

        public Genders Gender { get; set; } = Genders.Unknown;
    }
}