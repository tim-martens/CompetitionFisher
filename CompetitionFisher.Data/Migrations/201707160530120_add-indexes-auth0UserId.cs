namespace CompetitionFisher.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addindexesauth0UserId : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Championship", "Auth0UserId", name: "IX_Championship_Auth0UserId");
            CreateIndex("dbo.Competition", "Auth0UserId", name: "IX_Competition_Auth0UserId");
        }

        public override void Down()
        {
            DropIndex("dbo.Competition", "IX_Competition_Auth0UserId");
            DropIndex("dbo.Championship", "IX_Championship_Auth0UserId");
        }
    }
}
