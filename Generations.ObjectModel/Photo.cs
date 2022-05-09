namespace Generations.ObjectModel
{
    public class Photo : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime DateTaken { get; set; }

        public Place PlaceTaken { get; set; } = new();

        public string Url { get; set; } = string.Empty;

        public string ThumbnailUrl { get; set; } = string.Empty;

        public int Width { get; set; }

        public int Height { get; set; }

        public FileTypes FileType { get; set; }
    }
}