namespace Generations.API.Infrastructure
{
    public class PagedSet<T> where T : class
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public string NextUrl { get; set; } = string.Empty;

        public string PreviousUrl { get; set; } = string.Empty;

        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}