using CompetitionFisher.Data.Entities;
using CompetitionFisher.Data.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CompetitionFisher.Data.Context.Configuration
{
    public class CompetitionConfiguration : EntityTypeConfiguration<Competition>
    {
        public CompetitionConfiguration()
        {

            //Id
            HasKey(el => el.Id);
            Property(el => el.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.

            //Auth0UserID
            Property(el => el.Auth0UserId)
                .IsRequired()
                .HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM)
                .HasIndexAnnotation("IX_Auth0UserId", false);

            //Name
            Property(el => el.Name).IsRequired().HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM);

            //Date
            Property(el => el.Date)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasPrecision(0); ;

            //Contestants
            HasMany(c => c.Contestants)
                .WithMany(co => co.Competitions)
                .Map(cc =>
                {
                    cc.ToTable("Contestants_Competitions");
                    cc.MapRightKey("ContestantId");
                    cc.MapLeftKey("CompetitionId");
                });

            //Admins
            //HasMany(el => el.Admins)
            //    .WithMany(a => a.CompetitionsWhereAdmin)
            //    .Map(ac =>
            //    {
            //        ac.ToTable("CompetitionAdmin");
            //        ac.MapLeftKey("CompetitionId");
            //        ac.MapRightKey("UserId");

            //    });

            //Results
            HasMany(el => el.Results)
                .WithRequired(r => r.Competition)
                .HasForeignKey(r => r.CompetitionId);

        }
    }
}
