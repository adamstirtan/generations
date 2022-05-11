using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Generations.ObjectModel;
using Generations.Data.EntityTypes;

namespace Generations.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Person>? People { get; set; }

        public DbSet<Place>? Places { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new PlaceEntityTypeConfiguration().Configure(builder.Entity<Place>());
            new PersonEntityTypeConfiguration().Configure(builder.Entity<Person>());

            base.OnModelCreating(builder);
        }
    }
}