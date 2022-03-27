namespace Generations.ObjectModel
{
    public abstract class BaseModel
    {
        public long Id { get; set; }

        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset Updated { get; set; } = DateTimeOffset.Now;
    }
}