using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Generations.ObjectModel;

namespace Generations.Data.EntityTypes
{
    internal class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.FormerName)
                .HasMaxLength(300);

            builder.Property(x => x.MaidenName)
                .HasMaxLength(150);

            builder.Property(x => x.NamePrefix)
                .HasMaxLength(25);

            builder.Property(x => x.NamePrefix)
                .HasMaxLength(10);

            builder.Property(x => x.NameSuffix)
                .HasMaxLength(10);

            builder.Property(x => x.NickName)
                .HasMaxLength(150);

            builder.Property(x => x.BirthDate);

            builder
                .HasOne(x => x.BirthPlace)
                .WithOne()
                .HasForeignKey<Place>(b => b.Id);

            builder.Property(x => x.DeathDate);

            builder.Property(x => x.Relationship)
                .IsRequired();

            builder.Property(x => x.Gender)
                .IsRequired();

            builder.Property(x => x.Created)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LastUpdated)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}