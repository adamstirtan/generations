namespace Generations.ObjectModel
{
    public abstract class BaseModel
    {
        public long? Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}