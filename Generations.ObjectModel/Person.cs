namespace Generations.ObjectModel
{
    public class Person : BaseModel
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FormerName { get; set; } = string.Empty;

        public string MaidenName { get; set; } = string.Empty;

        public string NamePrefix { get; set; } = string.Empty;

        public string NameSuffix { get; set; } = string.Empty;

        public string NickName { get; set; } = string.Empty;

        public DateOnly? BirthDate { get; set; }

        public long? BirthPlaceId { get; set; }
        public Place? BirthPlace { get; set; } = null;

        public DateOnly? DeathDate { get; set; }

        public RelationshipTypes? Relationship { get; set; } = RelationshipTypes.Unknown;

        public Genders Gender { get; set; } = Genders.Unknown;
    }
}