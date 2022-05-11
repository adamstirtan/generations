using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Generations.ObjectModel;

namespace Generations.Data.EntityTypes
{
    internal class PlaceEntityTypeConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Latitude)
                .HasPrecision(3, 6);

            builder.Property(x => x.Latitude)
                .HasPrecision(3, 6);

            builder.Property(x => x.Created)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LastUpdated)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}