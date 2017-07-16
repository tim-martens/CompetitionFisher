using CompetitionFisher.Data.Context.Configuration;
using CompetitionFisher.Data.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CompetitionFisher.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Table names match singular entity names by default (don't pluralize)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Globally disable the convention for cascading deletes
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Entity configurations
            modelBuilder.Configurations.Add(new ContestantConfiguration());
            modelBuilder.Configurations.Add(new ChampionshipConfiguration());
            modelBuilder.Configurations.Add(new CompetitionConfiguration());
            modelBuilder.Configurations.Add(new ResultConfiguration());
        }

    }
}
