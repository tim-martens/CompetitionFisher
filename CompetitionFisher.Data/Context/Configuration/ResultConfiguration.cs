using CompetitionFisher.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CompetitionFisher.Data.Context.Configuration
{
    public class ResultConfiguration : EntityTypeConfiguration<Result>
    {
        public ResultConfiguration()
        {
            //Id
            HasKey(el => el.Id);
            Property(el => el.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // Client must set the ID.

            //TotalNumber
            Property(el => el.TotalNumber)
                .IsRequired();

            //TotalWeight
            Property(el => el.TotalWeight)
                .IsRequired();

            //Competition 
            //configured on other side of relation

            //User
            //configured on other side of relation

        }
    }
}
