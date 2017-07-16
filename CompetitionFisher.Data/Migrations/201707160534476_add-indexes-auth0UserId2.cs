namespace CompetitionFisher.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addindexesauth0UserId2 : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "dbo.Championship", name: "IX_Championship_Auth0UserId", newName: "IX_Auth0UserId");
            RenameIndex(table: "dbo.Competition", name: "IX_Competition_Auth0UserId", newName: "IX_Auth0UserId");
        }

        public override void Down()
        {
            RenameIndex(table: "dbo.Competition", name: "IX_Auth0UserId", newName: "IX_Competition_Auth0UserId");
            RenameIndex(table: "dbo.Championship", name: "IX_Auth0UserId", newName: "IX_Championship_Auth0UserId");
        }
    }
}
