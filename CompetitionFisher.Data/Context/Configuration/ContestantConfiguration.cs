using CompetitionFisher.Data.Entities;
using CompetitionFisher.Data.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CompetitionFisher.Data.Context.Configuration
{
    public class ContestantConfiguration : EntityTypeConfiguration<Contestant>
    {
        public ContestantConfiguration()
        {
            //Id
            HasKey(el => el.Id);
            Property(el => el.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.

            //Auth0UserID
            Property(el => el.Auth0UserId)
                .HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM);

            //FirstName
            Property(el => el.FirstName)
                .IsRequired()
                .HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM)
                .HasIndexAnnotation("UX_FirstName_LastName", true, EntityConfigurationConstants.FIRST_INDEX_COLUMN);

            //LastName
            Property(el => el.LastName)
                .IsRequired()
                .HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM)
                .HasIndexAnnotation("UX_FirstName_LastName", true, EntityConfigurationConstants.SECOND_INDEX_COLUMN);

            //Email
            //Property(el => el.Email)
            //    .HasMaxLength(EntityConfigurationConstants.DEFAULT_SIZE_STRING_COLUMN_MEDIUM);


            //ApplicationUser
            //HasOptional(el => el.ApplicationUser) // mark ApplicationUser property optional for Competitor
            //    .WithRequired(el => el.User); // see https://www.codeproject.com/Articles/806344/One-to-zero-one-relation-in-entity-framework-code

            //Competitions
            //configured on other side of relation

            //Results
            HasMany(el => el.Results)
                .WithRequired(r => r.Contestant)
                .HasForeignKey(r => r.ContestantId);
        }
    }
}
