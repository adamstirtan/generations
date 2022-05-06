using System.ComponentModel.DataAnnotations;

namespace Generations.ObjectModel
{
    public class Tenant : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string FamilyName { get; set; } = string.Empty;
    }
}