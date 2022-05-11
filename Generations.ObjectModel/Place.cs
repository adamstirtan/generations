namespace Generations.ObjectModel
{
    public class Place : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}