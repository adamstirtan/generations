using System.ComponentModel.DataAnnotations;

namespace Generations.ObjectModel
{
    public class Place : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}